using System;
using System.Configuration;
using System.Net;
using System.Windows.Forms;
using TweetSharp;
using TwitterClient;
using TwitterClient.Decorator;
using TwitterClient.Monitor;
using TwitterControls;

namespace Gui
{
    public partial class MainWindow : Form
    {
        readonly TwitterClient.TwitterClient _service = new TwitterClient.TwitterClient(ConfigurationManager.AppSettings["consumer_key"], ConfigurationManager.AppSettings["consumer_secret"]);
        private UserProfile _userProfile;

        readonly OAuthAccessToken _access = new OAuthAccessToken
        {
            Token = ConfigurationManager.AppSettings["access_token"],
            TokenSecret = ConfigurationManager.AppSettings["access_token_secret"]
        };
        public MainWindow()
        {
            InitializeComponent();
            TweetControl.FavoriteTweetEventHandlerEvent += SetFavorite;
            TweetControl.RetweetEventHandlerEvent += SetRetweted;
            TweetControl.UndoFavoriteTweetEventHandlerEvent += SetUndoFavorite;
            TweetControl.UndoRetweetEventHandlerEvent += SetUndoRetweted;

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
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
            _service.DeleteTweet(new DeleteTweetOptions() { Id = 597782746379976704 });
        }

        private void tweetViewer1_Load_1(object sender, EventArgs e)
        {
            
            _service.AuthenticateWith(_access.Token, _access.TokenSecret);
            IMonitor<DecoratedTwitterStatus> statusMonitor = new Monitor<DecoratedTwitterStatus>(null, tweetViewer1);
            _userProfile = new UserProfile(_service);
            Decorator<TwitterStatus, DecoratedTwitterStatus> tweetDecorator = new TwitterStatusDecorator(statusMonitor, _userProfile);
            IAsyncResult result = _service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions() { Count = 100 },
                (tweets, response) =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        tweetViewer1.SetDataFromRestApi(tweetDecorator.Decorate(tweets));
                    }
                });
            result.AsyncWaitHandle.WaitOne();
            var streamSeparator = new StreamSeparator();



            streamSeparator.Separate(_service,tweetDecorator);
            
        }


    }
}
