using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Twitty.OAuth
{
    public class WebRequestBuilder
    {
        public const string Api = "Twitter API";
        public bool AddRealm = true;
        public bool AddUserAgent = true;
        
        
        private static readonly string[] PublicParameters = {
            "oauth_consumer_secret",
            "oauth_signature",
            "oauth_token_secret"
           
        };

        private static readonly string[] ParametersInHeader = {
            "oauth_consumer_key",
            "oauth_nonce",
            "oauth_signature_method",
            "oauth_timestamp",
            "oauth_token",
            "oauth_verifier",
            "oauth_version"
        };

        public string AuthorizationHeader { get; set; }
        public Uri RequestUri { get; set; }

        public Dictionary<string, object> Parameters { get; private set; }

        public OAuthTokens Tokens { private get; set; }

        public HTTPVerb Verb { get; set; }

        private GettingOAuthTokens GettingOAuthTokens
        {
            get; set;
        }

        public bool UseOAuth { get; private set; }

        public HttpWebResponse ExecutedRequest
        {
            get
            {
                var request = PreparedRequest;
                return (HttpWebResponse) request.GetResponse();
            }
        }

        public HttpWebRequest PreparedRequest
        {
            get
            {   //Parameters initialization (tokens, signature and etc.)
                SetupParametrs();
                //Adding parametres to Uri from dictionary "Parameters"
                AddParametersToUri();

                //Reqest creating and initialization
                var request = (HttpWebRequest)WebRequest.Create(RequestUri);
                request.AutomaticDecompression = DecompressionMethods.None;
                request.UseDefaultCredentials = true;
                request.Method = Verb.ToString();
                request.ContentLength = 0;
                if (AddUserAgent)
                {
                    request.UserAgent = string.Format(CultureInfo.InvariantCulture, "Twitty/{0}",
                        System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
                }
                request.ServicePoint.Expect100Continue = false;
                request.Headers.Add("Authorization", GenerateAuthorizationHeader());

                return request;
            }
        }

        public string GenerateAuthorizationHeader()
        {
           
            var authHeaderBuilder = new StringBuilder();
            if (AddRealm)
            {
                authHeaderBuilder.AppendFormat("OAuth realm=\"{0}\"", Api);
            }
            //By OAuth protocol parameters must be sorted in lexicographic order
            var sortedParameters = from p in Parameters
                                   where ParametersInHeader.Contains(p.Key)
                                   orderby p.Key, UrlEncode( (p.Value is string) ? (string)p.Value : string.Empty)
                                   select p;

            foreach (var value in sortedParameters)
            {
                authHeaderBuilder.AppendFormat(
                    ",{0}=\"{1}\"",
                    UrlEncode(value.Key),
                    UrlEncode((string)value.Value ));
            }
            //By OAuth protocol there is signature after parametres

                authHeaderBuilder.AppendFormat(",oauth_signature=\"{0}\"",
                    UrlEncode((string) Parameters["oauth_signature"]));

                AuthorizationHeader = authHeaderBuilder.ToString();
            return AuthorizationHeader;
        }
        
        public WebRequestBuilder(Uri requestUri, HTTPVerb verb)
        {
            if (requestUri == null)
            {
                throw new ArgumentNullException("requestUri");
            }
            RequestUri = requestUri;
            Verb = verb;
            UseOAuth = false;
            Parameters = new Dictionary<string, object>();

            if (string.IsNullOrEmpty(RequestUri.Query))
            {
                return;
            }

            foreach (Match value in Regex.Matches(RequestUri.Query, @"(?<key>[^&?=]+)=(?<value>[^&?=]+)"))
            {
                Parameters.Add(value.Groups["key"].Value, value.Groups["value"].Value);
            }

            RequestUri = new Uri(RequestUri.AbsoluteUri.Replace(RequestUri.Query, ""));
        }

        public WebRequestBuilder(Uri requestUri, HTTPVerb verb, OAuthTokens tokens)
            : this(requestUri, verb)
        {
            UseOAuth = true;
            Tokens = tokens;
        }

        public WebRequestBuilder(Uri requestUri, HTTPVerb verb, OAuthTokens oAuthTokensokens, GettingOAuthTokens gettingOAuthTokens)
            : this(requestUri, verb, oAuthTokensokens)
        {
            GettingOAuthTokens = gettingOAuthTokens;
        }
        private void SetupParametrs()
        {
            try
            {
                //Initialize parametres of request
                Parameters.Add("oauth_consumer_key", Tokens.ConsumerKey);
                Parameters.Add("oauth_consumer_secret", Tokens.ConsumerSecret);
                Parameters.Add("oauth_nonce", GenerateNonce());
                Parameters.Add("oauth_signature_method", "HMAC-SHA1");
                Parameters.Add("oauth_timestamp", GenerateTimeStamp());
                Parameters.Add("oauth_version", "1.0");
                if (!string.IsNullOrEmpty(Tokens.AccessToken))
                {
                    Parameters.Add("oauth_token", Tokens.AccessToken);
                }

                if (!string.IsNullOrEmpty(Tokens.AccessTokenSecret))
                {
                    Parameters.Add("oauth_token_secret", Tokens.AccessTokenSecret);
                }
                //Signature generation with using parametres
                var signature = GenerateSignature();
                Parameters.Add("oauth_signature", signature);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        /*The oauth_nonce parameter is a unique token your application
        * should generate for each unique request. 
        * Twitter will use this value to determine whether a request
        * has been submitted multiple times. 
        * The value for this request was generated by base64 
        * encoding 32 bytes of random data, and stripping out all non-word characters,
        * but any approach which produces a relatively random alphanumeric string should be OK here.*/
        public static string GenerateNonce()
        {
            return new Random()
                .Next(123400, int.MaxValue)
                .ToString("X", CultureInfo.InvariantCulture);
        }

        /*The oauth_timestamp parameter indicates when the request was created.
         * This value should be the number of seconds since the Unix epoch at the point the request is generated,
         * and should be easily generated in most programming languages. 
         * Twitter will reject requests which were created too far in the past, 
         * so it is important to keep the clock of the computer generating requests in sync with NTP.*/
        public static string GenerateTimeStamp()
        {
            var timeStamp = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(timeStamp.TotalSeconds, CultureInfo.CurrentCulture).ToString(CultureInfo.CurrentCulture);
        }

        /*The oauth_signature parameter contains a value which is generated by running
         * all of the other request parameters and two secret values through a signing algorithm.
         * The purpose of the signature is so that Twitter can verify
         * that the request has not been modified in transit, verify the application sending the request,
         * and verify that the application has authorization to interact with the user’s account.*/
        public string GenerateSignature()
        {
            //Selection of public parametres
            var publicParameters = (from p in Parameters
                where (!PublicParameters.Contains(p.Key))
                select p);

            var urlForCoding = RequestUri;

            //Creatin non coded signature
            var signature = string.Format(
                CultureInfo.InvariantCulture,
                "{0}&{1}&{2}",
                Verb.ToString().ToUpper(CultureInfo.InvariantCulture),
                UrlEncode(NormalizeUrl(urlForCoding)),
                UrlEncode(publicParameters));

            //Key generaion with using consumer_secret and access_token_secret
            var key = string.Format(
                CultureInfo.InvariantCulture,
                "{0}&{1}",
                UrlEncode(Tokens.ConsumerSecret),
                UrlEncode(Tokens.AccessTokenSecret));
            //signature is calculated by passing the signature base
            //string and signing key to the HMAC-SHA1 hashing algorithm.
            var code = new HMACSHA1(Encoding.UTF8.GetBytes(key));
            var signatureBytes = code.ComputeHash(Encoding.UTF8.GetBytes(signature));
            return Convert.ToBase64String(signatureBytes);
        }

        //Url modification by OAuth protocol
        public static string UrlEncode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            str = Uri.EscapeDataString(str);
            str = Regex.Replace(str, "(%[0-9a-f][0-9a-f])", ch => ch.Value.ToUpper());
            str = str
                .Replace("!", "%21")
                .Replace("$", "%24")
                .Replace("(", "%28")
                .Replace(")", "%29")
                .Replace("'", "%27")
                .Replace("*", "%2A");
                
            str = str.Replace("%7E", "~");

            return str;
        }

        //Normalizin url by OAuth protocol
        public static string NormalizeUrl(Uri url)
        {
            var newUrl = string.Format(CultureInfo.InvariantCulture, "{0}://{1}", url.Scheme, url.Host);
            if (!((url.Scheme == "http" && url.Port == 80) || (url.Scheme == "https" && url.Port == 443)))
            {
                newUrl += ":" + url.Port;
            }

            newUrl += url.AbsolutePath;
            return newUrl;
        }
        //Url encode for object of interface IEnumerable
        private static string UrlEncode(IEnumerable<KeyValuePair<string, object>> parameters)
        {
            var parameterString = new StringBuilder();

            var sortedParametrs = from param in parameters
                orderby param.Key, param.Value
                select param;

            foreach (var value in sortedParametrs.Where(value => value.Value is string))
            {
                if (parameterString.Length > 0)
                {
                    parameterString.Append("&");
                }

                parameterString.Append(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "{0}={1}",
                        UrlEncode(value.Key),
                        UrlEncode((string) value.Value)));
            }

            return UrlEncode(parameterString.ToString());
        }

        //Creating Uri with parameters for authorization
        private void AddParametersToUri()
        {
            var parametersBuilder = new StringBuilder(RequestUri.AbsoluteUri);
            parametersBuilder.Append(RequestUri.Query.Length == 0 ? "?" : "&");

            var fields = new Dictionary<string, object>(Parameters.Where(param => !ParametersInHeader.Contains(param.Key) &&
                                         !PublicParameters.Contains(param.Key)).ToDictionary(param => param.Key, param => param.Value));

            foreach (var variable in fields.Where(value => value.Value is string))
            {
                parametersBuilder.AppendFormat("{0}={1}&", variable.Key, UrlEncode((string)variable.Value));
            }

            if (parametersBuilder.Length == 0)
            {
                return;
            }
            parametersBuilder.Remove(parametersBuilder.Length - 1, 1);

            RequestUri = new Uri(parametersBuilder.ToString());
        }
    }
}
