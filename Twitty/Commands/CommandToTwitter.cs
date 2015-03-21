using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Twitty.Account;
using Twitty.Kernel;
using Twitty.OAuth;

namespace Twitty.Commands
{
    internal abstract class CommandToTwitter<T> : ICommand<T> where T : ITwitterObject
    {
        public Dictionary<string, object> Parameters { get; set; }

        byte[] _responseData;

        public abstract void Initialize();

        public TwitterResponse<T> ExecuteCommand()
        {
            var twitterResponse = new TwitterResponse<T>();
            Uri = new Uri(Uri.AbsoluteUri.Replace("http://", "https://"));

            var parameters = Parameters.ToDictionary(value => value.Key, value => value.Value);
            twitterResponse.ResponseObject = default(T);
            twitterResponse.RequestUrl = Uri.AbsoluteUri;
            try
            {
                var requestBuilder = new WebRequestBuilder(Uri, Verb, Tokens);
                requestBuilder.Parameters.Clear();
                foreach (var value in parameters)
                {
                    requestBuilder.Parameters.Add(value.Key, value.Value);

                }
                HttpWebResponse resp = requestBuilder.ExecutedRequest;
            }
            catch (Exception e)
            {
                
                throw;
            }
            
            return twitterResponse;
        }

        public OAuthTokens Tokens { get; private set; }

        private HTTPVerb Verb { get; set; }

        private Uri Uri { get; set; }

        protected CommandToTwitter(HTTPVerb method, string endPoint, OAuthTokens tokens, byte[] responseData)
        {
            Parameters = new Dictionary<string, object>();
            Verb = method;
            Tokens = tokens;
            _responseData = responseData;
            Uri = new Uri(endPoint);
        }
    }
}
