using System;
using MetroFramework.Controls;
using TweetSharp;

namespace TwitterControls
{
    
    public partial class TweetControl: MetroUserControl
    {
        private readonly TwitterStatus _status;

        public TweetControl(TwitterStatus status)
        {
            _status = status;
            InitializeComponent();
            label1.Text = status.Text;
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

        public delegate void FavoriteTweetEventHandler(object sender, TwitterStatusEventArgs e);

        public delegate void RetweetEventHandler(object sender, TwitterStatusEventArgs e);

        public static event FavoriteTweetEventHandler FavoriteTweetEventHandlerEvent;
        public static event RetweetEventHandler RetweetEventHandlerEvent;

        protected virtual void OnFavoriteTweetEventHandlerEvent(TwitterStatusEventArgs e)
        {
            var handler = FavoriteTweetEventHandlerEvent;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnRetweetEventHandlerEvent(TwitterStatusEventArgs e)
        {
            var handler = RetweetEventHandlerEvent;
            if (handler != null) handler(this, e);
        }
    }
}
