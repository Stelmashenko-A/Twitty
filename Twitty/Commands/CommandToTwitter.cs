using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Twitty.Account;
using Twitty.Kernel;
using Twitty.OAuth;

namespace Twitty.Commands
{
    internal abstract class CommandToTwitter<T> : ICommand<T> where T : ITwitterObject
    {
        public Dictionary<string, object> Parameters { get; set; }

        byte[] responseData;

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public TwitterResponse<T> ExecuteCommand()
        {
            var twitterResponse = new TwitterResponse<T>();
            var parameters = Parameters.ToDictionary(value => value.Key, value => value.Value);
            twitterResponse.ResponseObject = default(T);
            twitterResponse.RequestUrl = _uri.AbsoluteUri;
            try
            {
                var requestBuilder = new WebRequestBuilder(_uri, _verb, Tokens);
                foreach (var value in parameters)
                {
                    requestBuilder.Parameters.Add(value.Key, value.Value);
                }
                var response = requestBuilder.ExecutedRequest;


            }
            catch (Exception)
            {
                
                throw;
            }
            return twitterResponse;
        }

        public OAuthTokens Tokens { get; private set; }

        private HTTPVerb _verb { get; set; }

        private Uri _uri { get; set; }

        protected CommandToTwitter(HTTPVerb method, string endPoint, OAuthTokens tokens)
        {
            Parameters = new Dictionary<string, object>();
            _verb = method;
            Tokens = tokens;
            _uri = new Uri(endPoint);
        }
    }
}
