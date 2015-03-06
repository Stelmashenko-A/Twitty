using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace Twitty.OAuth
{
    class WebRequestBuilder
    {
        public Uri RequestUri
        {
            get; set;
            
        }

        public Dictionary<string, object> Parameters
        {
            get; private set;           
        }

        public OAuthTokens Tokens
        {
            private get; set;        
        }

        private static readonly string[] OAuthParametersToIncludeInHeader = {
                                                              "oauth_version",
                                                              "oauth_nonce",
                                                              "oauth_timestamp",
                                                              "oauth_signature_method",
                                                              "oauth_consumer_key",
                                                              "oauth_token",
                                                              "oauth_verifier"
                                                          };

        private static readonly string[] SecretParameters = {
                                                                    "oauth_consumer_secret",
                                                                    "oauth_token_secret",
                                                                    "oauth_signature"
                                                                };

        public HTTPVerb Verb
        {
            get; set; 
        }

        private string _userAgent;

        private NetworkCredential _networkCredentials;

        public bool UseOAuth { get; private set; }

        public WebRequestBuilder(Uri requestUri, HTTPVerb verb, String userAgent, NetworkCredential networkCredentials)
        {
            if (requestUri == null)
            {
                throw new ArgumentNullException("requestUri");
            }
            RequestUri = requestUri;
            Verb = verb;
            _userAgent = userAgent;
            UseOAuth = false;
            if (networkCredentials != null)
            {
                _networkCredentials = networkCredentials;
            }
            Parameters = new Dictionary<string, object>();

            if (string.IsNullOrEmpty(RequestUri.Query))
            {
                return;
            }

            foreach (Match item in Regex.Matches(RequestUri.Query, @"(?<key>[^&?=]+)=(?<value>[^&?=]+)"))
            {
                Parameters.Add(item.Groups["key"].Value, item.Groups["value"].Value);
            }

            RequestUri = new Uri(RequestUri.AbsoluteUri.Replace(RequestUri.Query, ""));
        }
    }
}
