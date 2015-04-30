using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitterAnalyzer;
using Twitty.OAuth;
using Twitty.Streaming;
using Twitty.Tweets;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = new OAuthTokens();
            tokens.ConsumerKey = "ENJEA6bYkNsPgoPaFf2Zk2Hvl";
            tokens.ConsumerSecret = "m4GajYEqj8v6YvplTPwvbZZQKOWOTWPPwKcluGtrKlavhpSHNU";
            tokens.AccessToken = "2765688547-vun5RgYHxZ28ru7MShpaDtMedZQX2DopGesRYEb";
            tokens.AccessTokenSecret = "hov1Q58KnL5g7ztMEd0KaY3R75Y8LrQBiIYdZPvw7pbCd";
            List<string> kw = new List<string>();
            //kw.Add("Nepal");
            List<string> koordList = new List<string>();
            koordList.Add("-180.0");
            koordList.Add("-90.0");
            koordList.Add("0.0");
            koordList.Add("90.0");
            koordList.Add("0.0");
            koordList.Add("-90.0");
            koordList.Add("180.0");
            koordList.Add("90.0");
            ISender<Tweet> sender = new MessageSender(@".\private$\Twitter");
            MessageProcessor message = new MessageProcessor(sender);
            TwitterStream stream = new TwitterStream(message, tokens, "https://stream.twitter.com/1.1/statuses/filter.json", kw, new List<string>(), koordList);
            //Sender<Tweet>.SenderEventHandler = GetData;
            IGetter<Tweet> getter = new Getter(@".\private$\Twitter");
            
            //Visualizer<Tweet> visualizer = new Visualizer<Tweet>(getter,th);
            Thread th = new Thread(stream.Start);
            //Thread th2 = new Thread(visualizer.Start);
            th.Start();
            
            //th2.Start();
            



        }

        
        public static void GetData(Tweet tw)
        {
            try
            {            
                //Console.WriteLine(tw.Text);
                
            }
            catch (InvalidOperationException exception)
            {
            }
        }
    }
}
