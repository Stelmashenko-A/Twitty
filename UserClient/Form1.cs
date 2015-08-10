using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Twitty.OAuth;
using Twitty.Streaming;
using Twitty.Tweets;

namespace UserClient
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
           
        }

        private static string _address =
            "http://api.twitter.com/1/statuses/user_timeline.json?include_entities=true&include_rts=true&screen_name=scottgu&count=5";

        private void Form1_Load(object sender, EventArgs e)
        {
            var tokens = new OAuthTokens();
            tokens.ConsumerKey = ConfigurationManager.AppSettings["consumer_key"];
            tokens.ConsumerSecret = ConfigurationManager.AppSettings["consumer_secret"];
            tokens.AccessToken = ConfigurationManager.AppSettings["access_token"];
            tokens.AccessTokenSecret = ConfigurationManager.AppSettings["access_token_secret"];
            /*var tokens = new OAuthTokens();
            tokens.ConsumerKey = "";
            tokens.ConsumerSecret = "";
            tokens.AccessToken = "";
            tokens.AccessTokenSecret = "";*/
           List<string> kw = new List<string>();
           List<string> koordList = new List<string>();
            koordList.Add("-180.0");
            koordList.Add("-90.0");
            koordList.Add("0.0");
            koordList.Add("90.0");
            koordList.Add("0.0");
            koordList.Add("-90.0");
            koordList.Add("180.0");
            koordList.Add("90.0");
            ConcurrentQueue<string> textQueue = new ConcurrentQueue<string>();
            ISender<string> stringSender = new MessageSender<string>(textQueue);
            var stream = new TwitterStream(stringSender, tokens, "https://stream.twitter.com/1.1/statuses/filter.json",
                kw, new List<string>(), koordList);
            var streamThread = new Thread(stream.Start) {Priority = ThreadPriority.Highest};

            IGetter<string> stringGetter = new Getter<string>(textQueue);
            ConcurrentQueue<Tweet>  tweetsQueue= new ConcurrentQueue<Tweet>();
            ISender<Tweet> tweetSender = new MessageSender<Tweet>(tweetsQueue);
            var parser = new StreamSerializer<Tweet, IGetter<string>>(stringGetter, tweetSender);
            var parserThread = new Thread(parser.Start);

            IGetter<Tweet> tweetGetter = new Getter<Tweet>(tweetsQueue);
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = bitmap;
            var visualizer = new Visualizer<Tweet>(bitmap, tweetGetter);
            visualizer.OnCount += Rewrite;
            var visualizerThread = new Thread(visualizer.Start);
            parserThread.Start();
            visualizerThread.Start();
                try
                {

                
                streamThread.Start();
                }
                catch (Exception)
                {

                    
                }
        }

        private void Rewrite(Bitmap bitmap)
        {
            Invoke(new Action(() => pictureBox1.Image = bitmap));
            Invoke(new Action(Refresh));
            
        }
    }
}
