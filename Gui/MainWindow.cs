using System;
using System.Configuration;
using System.Net;
using System.Windows.Forms;
using TweetSharp;
using TwitterClient;
using TwitterClient.Monitor;
using TwitterControls;

namespace Gui
{
    public partial class MainWindow : Form
    {
        readonly TwitterService _service = new TwitterService(ConfigurationManager.AppSettings["consumer_key"], ConfigurationManager.AppSettings["consumer_secret"]);

        readonly OAuthAccessToken _access = new OAuthAccessToken
        {
            Token = ConfigurationManager.AppSettings["access_token"],
            TokenSecret = ConfigurationManager.AppSettings["access_token_secret"]
        };
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MainWindow_Load(object sender, System.EventArgs e)
        {
            
        }

        private void tweetList1_Load(object sender, EventArgs e)
        {
            
        }

        private void tweetViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void tweetViewer1_Load_1(object sender, EventArgs e)
        {
            _service.AuthenticateWith(_access.Token, _access.TokenSecret);

            // var asyncResult = _service.BeginListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions() { Count = 10 });
            // asyncResult.AsyncWaitHandle.WaitOne();
            IAsyncResult result = _service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions() { Count = 100 },
                (tweets, response) =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        tweetViewer1.SetDataFromRestApi(tweets);
                    }
                });
            result.AsyncWaitHandle.WaitOne();
            var streamSeparator = new StreamSeparator();
            IMonitor<TwitterStatus> statusMonitor = new Monitor<TwitterStatus>(null, tweetViewer1);
            streamSeparator.Separate(_service, statusMonitor);
        }


    }
}
