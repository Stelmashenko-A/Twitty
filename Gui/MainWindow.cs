using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using TweetSharp;
using TwitterControls;

namespace Gui
{
    public partial class MainWindow : Form
    {
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox;
        public MainWindow()
        {
            InitializeComponent();
            TwitterService service = new TwitterService("ENJEA6bYkNsPgoPaFf2Zk2Hvl", "m4GajYEqj8v6YvplTPwvbZZQKOWOTWPPwKcluGtrKlavhpSHNU");

            // Step 1 - Retrieve an OAuth Request Token
            //OAuthRequestToken requestToken = service.GetRequestToken();

            // Step 2 - Redirect to the OAuth Authorization URL
            //Uri uri = service.GetAuthorizationUri(requestToken);
            //Process.Start(uri.ToString());

            // Step 3 - Exchange the Request Token for an Access Token
            //string verifier = "123456"; // <-- This is input into your application by your user
            OAuthAccessToken access = new OAuthAccessToken();// = service.GetAccessToken(requestToken, verifier);
            access.Token = "2765688547-vun5RgYHxZ28ru7MShpaDtMedZQX2DopGesRYEb";
            access.TokenSecret = "hov1Q58KnL5g7ztMEd0KaY3R75Y8LrQBiIYdZPvw7pbCd";
            // Step 4 - User authenticates using the Access Token
            service.AuthenticateWith(access.Token, access.TokenSecret);
            IEnumerable<TwitterStatus> mentions = service.ListTweetsMentioningMe(new ListTweetsMentioningMeOptions());
            //service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions() {Count = 500});
            var s = service.BeginListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions(){Count = 1000});


            s.AsyncWaitHandle.WaitOne();
             //Hammock
            tweetList1.Initialize(service.EndListTweetsOnHomeTimeline(s).ToList());
            this.materialCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialCheckBox.AutoSize = true;
            this.materialCheckBox.Text = "materialCheckBoxasdf";
            this.Controls.Add(materialCheckBox);
            

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load_1(object sender, EventArgs e)
        {

        }
    }
}
