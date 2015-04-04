using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Twitty.Account;
using Twitty.Kernel;
using Twitty.OAuth;
using Twitty.Utility;

namespace Twitty.Commands
{
    internal abstract class CommandToTwitter<T> : ICommand<T> where T : ITwitterObject
    {
        public Dictionary<string, object> Parameters { get; set; }
        protected Options.TwitterOptions Options { get; set; }

        byte[] _responseData;

        public abstract void Initialize();

        public Response<T> ExecuteCommand()
        {
            var twitterResponse = new Response<T>();
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
                //Never delete next string: "HttpWebResponse resp = requestBuilder.ExecutedRequest;"
                //ignor ReSharper here
                var resp = requestBuilder.ExecutedRequest;
                _responseData = ConversionUtility.ReadStream(resp.GetResponseStream());
                twitterResponse.Content = Encoding.UTF8.GetString(_responseData, 0, _responseData.Length);
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
        protected CommandToTwitter(HTTPVerb method, string endPoint, OAuthTokens tokens, Options.TwitterOptions options)
        {
            Parameters = new Dictionary<string, object>();
            Verb = method;
            Tokens = tokens;
            Options = options ?? new Options.TwitterOptions();
            SetCommandUri(endPoint);
        }
        protected void SetCommandUri(string endPoint)
        {
            if (endPoint.StartsWith("/"))
                throw new ArgumentException("The API endpoint cannot begin with a forward slash. This will result in 404 errors and headaches.", "endPoint");

            Uri = new Uri(endPoint);
        }
    }
}
