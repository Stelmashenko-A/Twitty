using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using Hammock.Web;
using TweetSharp;

namespace test3
{
    class Program
    {
        static void Main(string[] args)
        {
            TwitterService service = new TwitterService(ConfigurationManager.AppSettings["consumerKey"], ConfigurationManager.AppSettings["consumerSecret"]);

           // OAuthRequestToken requestToken = service.GetRequestToken();

           // Uri uri = service.GetAuthorizationUri(requestToken);
            //Process.Start(uri.ToString());

            // Step 3 - Exchange the Request Token for an Access Token
            //var verifier = Console.ReadLine(); // <-- This is input into your application by your user
            OAuthAccessToken access = new OAuthAccessToken
            {
                ScreenName = "_BuS_TeR_",
                Token = "",
                TokenSecret = "",
                UserId = 2765688547
            }; // = service.GetAccessToken(requestToken, verifier);
            // Step 4 - User authenticates using the Access Token
            //service.StreamFilter()
            service.AuthenticateWith(access.Token, access.TokenSecret);
            var t = service.BeginGetFriendshipInfo(new GetFriendshipInfoOptions());
            var s = service.BeginListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions());
            var g = service.EndListTweetsOnHomeTimeline(s);
            

            IEnumerable<TwitterStatus> mentions = service.ListTweetsMentioningMe(new ListTweetsMentioningMeOptions());
        }
    }
}
