using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            tokens.ConsumerKey = "";
            tokens.ConsumerSecret = "";
            tokens.AccessToken = "";
            tokens.AccessTokenSecret = "";
            List<string> kw = new List<string>();
            kw.Add("Nepal");
           
            TwitterStream stream = new TwitterStream(new MessageProcessor(),tokens, "https://stream.twitter.com/1.1/statuses/filter.json", kw, new List<string>(), new List<string>());
            Sender<Tweet>.SenderEventHandler = GetData;
            Thread th = new Thread(stream.Start);
            th.Start();
            th.Join();



        }
        public static void GetData(Tweet tw)
        {
            try
            {
                if(tw.Coordinates!=null)
                Console.WriteLine(tw.Text);
                
            }
            catch (InvalidOperationException exception)
            {
            }
        }
    }
}
