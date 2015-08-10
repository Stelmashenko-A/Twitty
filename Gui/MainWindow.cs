using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using MaterialSkin.Controls;
using TweetSharp;
using TwitterClient;
using TwitterClient.Decorator;
using TwitterClient.Filter;
using TwitterClient.Monitor;
using TwitterControls;

namespace Gui
{
    public sealed partial class MainWindow : MaterialForm
    {
        private readonly TwitterClient.TwitterClient _service =
            new TwitterClient.TwitterClient(ConfigurationManager.AppSettings["consumer_key"],
                ConfigurationManager.AppSettings["consumer_secret"]);

        private UserProfile _userProfile;

        private readonly OAuthAccessToken _access = new OAuthAccessToken
        {
            Token = ConfigurationManager.AppSettings["access_token"],
            TokenSecret = ConfigurationManager.AppSettings["access_token_secret"]
        };

        public MainWindow()
        {
            InitializeComponent();
            Refresh();
            TweetControl.FavoriteTweetEventHandlerEvent += SetFavorite;
            TweetControl.RetweetEventHandlerEvent += SetRetweted;
            TweetControl.UndoFavoriteTweetEventHandlerEvent += SetUndoFavorite;
            TweetControl.UndoRetweetEventHandlerEvent += SetUndoRetweted;

        }

        private void SetFavorite(object sender, TwitterStatusEventArgs e)
        {
            _service.FavoriteTweet(new FavoriteTweetOptions()
            {
                Id = e.Id
            });
        }

        private void SetUndoFavorite(object sender, TwitterStatusEventArgs e)
        {

            _service.UndoFavourite(new FavoriteTweetOptions()
            {
                Id = e.Id
            });
        }

        private void SetRetweted(object sender, TwitterStatusEventArgs e)
        {
            _service.Retweet(new RetweetOptions()
            {
                Id = e.Id
            });
        }

        private void SetUndoRetweted(object sender, TwitterStatusEventArgs e)
        {
            var myRtw = _userProfile.AuthenticatedUserRetweets[e.Id];
            _service.DeleteTweet(new DeleteTweetOptions() {Id = myRtw});
        }

        private void tweetViewer1_Load_1(object sender, EventArgs e)
        {
            List<IFilter<DecoratedTwitterStatus>> filters = new List<IFilter<DecoratedTwitterStatus>>
            {
                new TextSpamFilter(),
                new UserRetweetFilter(),
                new RewteetFilter()
            };

            _service.AuthenticateWith(_access.Token, _access.TokenSecret);

            IMonitor<DecoratedTwitterStatus> statusMonitor = new Monitor<DecoratedTwitterStatus>(tweetViewer1);
            _userProfile = new UserProfile(_service);
            Decorator<TwitterStatus, DecoratedTwitterStatus> tweetDecorator = new TwitterStatusDecorator(statusMonitor,
                _userProfile);

            var result = _service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions {Count = 100},
                (tweets, response) =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        tweetViewer1.SetDataFromRestApi(tweetDecorator.Decorate(tweets));
                    }
                });

            result.AsyncWaitHandle.WaitOne();
            var streamSeparator = new StreamSeparator();
            streamSeparator.Separate(_service, tweetDecorator);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void buttonSendTweet_Click(object sender, EventArgs e)
        {
            _service.SendTweet(new SendTweetOptions() {Status = textBox1.Text});
        }
    }
}
