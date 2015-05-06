using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TweetSharp;

namespace ConsoleApplication1
{
    class Program
    {

        const string _consumerKey = "ENJEA6bYkNsPgoPaFf2Zk2Hvl";
        const string _consumerSecret = "m4GajYEqj8v6YvplTPwvbZZQKOWOTWPPwKcluGtrKlavhpSHNU";
        const string _accessToken = "2765688547-vun5RgYHxZ28ru7MShpaDtMedZQX2DopGesRYEb";
        const string _accessTokenSecret = "hov1Q58KnL5g7ztMEd0KaY3R75Y8LrQBiIYdZPvw7pbCd";

        static void Main(string[] args)
        {
            const int maxStreamEvents = 5;

            var block = new AutoResetEvent(false);
            var count = 0;

            var service = GetAuthenticatedService();
            
            service.StreamUser((streamEvent, response) =>
            {
                if (streamEvent is TwitterUserStreamEnd)
                {
                    block.Set();
                }

                if (response.StatusCode == 0)
                {
                    if (streamEvent is TwitterUserStreamFriends)
                    {
                        var friends = (TwitterUserStreamFriends)streamEvent;
                        Console.WriteLine(streamEvent.RawSource);
                    }

                    if (streamEvent is TwitterUserStreamEvent)
                    {
                        var @event = (TwitterUserStreamEvent)streamEvent;
                        Console.WriteLine(streamEvent.RawSource);
                    }

                    if (streamEvent is TwitterUserStreamStatus)
                    {
                        var tweet = ((TwitterUserStreamStatus)streamEvent).Status;
                        Console.WriteLine(streamEvent.RawSource);
                    }

                    if (streamEvent is TwitterUserStreamDirectMessage)
                    {
                        var dm = ((TwitterUserStreamDirectMessage)streamEvent).DirectMessage;
                        Console.WriteLine(streamEvent.RawSource);
                    }

                    if (streamEvent is TwitterUserStreamDeleteStatus)
                    {
                        var deleted = (TwitterUserStreamDeleteStatus)streamEvent;
                        Console.WriteLine(streamEvent.RawSource);
                    }

                    if (streamEvent is TwitterUserStreamDeleteDirectMessage)
                    {
                        var deleted = (TwitterUserStreamDeleteDirectMessage)streamEvent;
                        Console.WriteLine(streamEvent.RawSource);
                    }
                    count++;
                    if (count == maxStreamEvents)
                    {
                        block.Set();
                    }
                }
                else
                {
                    Console.Error.WriteLine("Unable to start stream");
                }
            });

            block.WaitOne();
            service.CancelStreaming();
        }

        private static TwitterService GetAuthenticatedService()
        {
            var service = new TwitterService(_consumerKey, _consumerSecret);
            service.TraceEnabled = true;
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
            return service;
        }
    }
}
