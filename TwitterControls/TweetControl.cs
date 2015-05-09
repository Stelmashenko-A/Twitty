using System;
using MetroFramework.Controls;
using TweetSharp;

namespace TwitterControls
{
    
    public sealed partial class TweetControl: MetroUserControl
    {
        private readonly TwitterStatus _status;

        public TweetControl()
        {
            InitializeComponent();
        }
        public TweetControl(TwitterStatus status)
        {
            
            InitializeComponent();
            _status = status;
            
            label1.Text = status.Text;
            if (status.IsFavorited)
            {
                FavouriteCheckBox.Checked = true;
            }
            if (status.RetweetedStatus != null)
            {
                RetweetCheckBox.Checked = true;
            }
        }

        public delegate void FavoriteTweetEventHandler(object sender, TwitterStatusEventArgs e);

        public delegate void RetweetEventHandler(object sender, TwitterStatusEventArgs e);

        public static event FavoriteTweetEventHandler FavoriteTweetEventHandlerEvent;
        public static event RetweetEventHandler RetweetEventHandlerEvent;

        private void OnFavoriteTweetEventHandlerEvent(TwitterStatusEventArgs e)
        {
            var handler = FavoriteTweetEventHandlerEvent;
            if (handler != null) handler(this, e);
        }

        private void OnRetweetEventHandlerEvent(TwitterStatusEventArgs e)
        {
            var handler = RetweetEventHandlerEvent;
            if (handler != null) handler(this, e);
        }

        private void TweetControl_Load(object sender, EventArgs e)
        {
            
        }

        private void RetweetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RetweetCheckBox.Checked)
            {
                OnRetweetEventHandlerEvent(new TwitterStatusEventArgs(_status.Id));
            }
        }

        private void FavouriteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FavouriteCheckBox.Checked)
            {
                OnFavoriteTweetEventHandlerEvent(new TwitterStatusEventArgs(_status.Id));
            }
        }


    }
}
