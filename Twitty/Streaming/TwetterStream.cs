using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using Twitty.OAuth;
using Twitty.Utility;

namespace Twitty.Streaming
{
    public class TwitterStream
    {
        private readonly IMessageProcessor _messageProcessor;
        private readonly OAuthTokens _tokens;
        private readonly string _streamUrl;
        private readonly List<string> _trackKeywords;
        private readonly List<string> _followUserId;
        private readonly List<string> _locationCoord;

        public TwitterStream(IMessageProcessor messageProcessor, OAuthTokens tokens, string streamUrl, List<string> trackKeywords, List<string> followUserId, List<string> locationCoord)
        {
            _messageProcessor = messageProcessor;
            _tokens = tokens;
            _streamUrl = streamUrl;
            _trackKeywords = trackKeywords;
            _followUserId = followUserId;
            _locationCoord = locationCoord;
        }

        public int Counter
        {
            get { return _counter; }
            set { _counter = value; }
        }

        public void Start()
        {
            if (!_tokens.IsIdentified())
            {
                throw new ArgumentNullException(_tokens.ToString());
            }
            //Twitter Streaming API
            HttpWebRequest webRequest = null;
            HttpWebResponse webResponse = null;
            StreamReader responseStream = null;

            StringBuilder post = new StringBuilder("");
            if (_trackKeywords.Count != 0)
            {
                post.Append("&track=");
                post.Append(Joiner.Join(_trackKeywords, ","));
            }
            if (_followUserId.Count != 0)
            {
                post.Append("&follow=");
                post.Append(Joiner.Join(_followUserId, ","));
            }
            if (_locationCoord.Count != 0)
            {
                post.Append("&locations=");
                post.Append(Joiner.Join(_locationCoord, ","));
            }
            string postparameters = post.ToString();


            if (!string.IsNullOrEmpty(postparameters))
            {
                if (postparameters.IndexOf('&') == 0)
                    postparameters = postparameters.Remove(0, 1).Replace("#", "%23");
            }

            var pause = 0;

            Console.Beep();
            try
            {
                while (true)
                {
                    try
                    {
                        //Connect

                        webRequest = (HttpWebRequest) WebRequest.Create(_streamUrl);
                        webRequest.Timeout = 100000;
                        webRequest.Headers.Add("Authorization", GetAuthHeader(_tokens, _streamUrl + "?" + postparameters));

                        var encode = Encoding.GetEncoding("utf-8");
                        if (postparameters.Length > 0)
                        {
                            webRequest.Method = "POST";
                            webRequest.ContentType = "application/x-www-form-urlencoded";

                            var twitterTrack = encode.GetBytes(postparameters);

                            webRequest.ContentLength = twitterTrack.Length;
                            var twitterPost = webRequest.GetRequestStream();
                            twitterPost.Write(twitterTrack, 0, twitterTrack.Length);
                            twitterPost.Close();
                        }

                        using (webResponse = (HttpWebResponse) webRequest.GetResponse())
                        {

                            // ReSharper disable once AssignNullToNotNullAttribute
                            responseStream = new StreamReader(webResponse.GetResponseStream(), encode);
                            while (true)
                            {
                                _counter++;

                                var jsonText = responseStream.ReadLine();
                                _messageProcessor.Proccess(jsonText);
                            }
                        }
                    }
                    catch (WebException ex)
                    {
                        Console.WriteLine(@"norm");
                        Console.WriteLine(ex.Message);
                        if (ex.Status == WebExceptionStatus.ProtocolError)
                        {
                            //Twitter Docs
                            //When a HTTP error (> 200) is returned, back off exponentially. 
                            //Perhaps start with a 10 second wait, double on each subsequent failure, 
                            //and finally cap the wait at 240 seconds. 
                            //Exponential Backoff
                            if (pause < 10000)
                                pause = 10000;
                            else
                            {
                                if (pause < 240000)
                                    pause = pause*2;
                            }
                        }
                        else
                        {
                            //Twitter Docs
                            //When a network error (TCP/IP level) is encountered, back off linearly. 
                            //Perhaps start at 250 milliseconds and cap at 16 seconds.
                            //Linear Backoff
                            if (pause < 16000)
                                pause += 250;
                        }
                    }
                    catch (Exception ex)
                    {
                        
                        Console.Beep();

                        if (webResponse != null)
                        {
                            webResponse.Dispose();
                            if (responseStream != null)
                            {
                                responseStream.Dispose();
                                GC.Collect();
                                GC.Collect(GC.GetGeneration(responseStream),GCCollectionMode.Forced,true);
                            }
                            GC.Collect(GC.GetGeneration(webResponse), GCCollectionMode.Forced, true);
                        }
                        pause = 1000;
                        Thread.Sleep(pause);
                        Console.WriteLine(ex.Message);

                    }
                    finally
                    {
                        if (webRequest != null)
                        {
                            webRequest.Abort();
                            webRequest = null;
                        }
                        if (responseStream != null)
                        {
                            responseStream.Close();
                            responseStream = null;
                        }

                        if (webResponse != null)
                        {
                            webResponse.Close();
                            webResponse = null;
                        }
                        Console.WriteLine(@"Waiting: " + pause);
                        Thread.Sleep(pause);
                        
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(@"norm2");
                Console.Beep();
                //Console.WriteLine(ex.Message);
                //Console.WriteLine("Waiting: " + pause);
                Thread.Sleep(pause);
            }
        }



        private int _counter;

        public void MessageProcess(object objMessage)
        {
            //TODO:  Add messageProcessor
        }

        private string GetAuthHeader(OAuthTokens tokens, string url)
        {

            var wb = new WebRequestBuilder(new Uri(url), HttpVerb.Post, tokens);
            // ReSharper disable once UnusedVariable
            var resp = wb.ExecutedRequest;

            return wb.AuthorizationHeader;
        }
    }
}
