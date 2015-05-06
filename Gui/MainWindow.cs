using System.Windows.Forms;
using TweetSharp;
using TwitterClient;

namespace Gui
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            var service = new TwitterService("", "");

            var access = new OAuthAccessToken
            {
                Token = "",
                TokenSecret = ""
            }; 

            service.AuthenticateWith(access.Token, access.TokenSecret);

            var s = service.BeginListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions(){Count = 10});
            s.AsyncWaitHandle.WaitOne();
            var ss=new StreamSeparator();
            ss.Separate(service, tweetList1);
        }
    }
}
