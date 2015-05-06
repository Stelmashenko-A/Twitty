using System.Configuration;
using System.Windows.Forms;
using TweetSharp;
using TwitterClient;
using TwitterClient.Monitor;

namespace Gui
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            var service = new TwitterService(ConfigurationManager.AppSettings["consumer_key"], ConfigurationManager.AppSettings["consumer_secret"]);

            var access = new OAuthAccessToken
            {
                Token = ConfigurationManager.AppSettings["access_token"],
                TokenSecret = ConfigurationManager.AppSettings["access_token_secret"]
            }; 

            service.AuthenticateWith(access.Token, access.TokenSecret);

            var s = service.BeginListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions(){Count = 10});
            s.AsyncWaitHandle.WaitOne();
            var ss=new StreamSeparator();
            IMonitor<TwitterStatus> statusMonitor = new Monitor<TwitterStatus>(null,tweetList1);
            ss.Separate(service, statusMonitor);
        }
    }
}
