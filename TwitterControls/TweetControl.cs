using System;
using MetroFramework.Controls;
using TwitterClient.Decorator;

namespace TwitterControls
{
    
    public sealed partial class TweetControl: MetroUserControl
    {
        private readonly DecoratedTwitterStatus _status;

        public delegate void FavoriteTweetEventHandler(object sender, TwitterStatusEventArgs e);
        public delegate void RetweetEventHandler(object sender, TwitterStatusEventArgs e);

        public delegate void UndoFavoriteTweetEventHandler(object sender, TwitterStatusEventArgs e);
        public delegate void UndoRetweetEventHandler(object sender, TwitterStatusEventArgs e);

        public static event FavoriteTweetEventHandler FavoriteTweetEventHandlerEvent;
        public static event RetweetEventHandler RetweetEventHandlerEvent;

        public static event UndoFavoriteTweetEventHandler UndoFavoriteTweetEventHandlerEvent;
        public static event UndoRetweetEventHandler UndoRetweetEventHandlerEvent;
        public TweetControl()
        {
            InitializeComponent();
        }
        public TweetControl(DecoratedTwitterStatus status)
        {
            InitializeComponent();
            _status = status;
            
            label1.Text = status.Base.Text;
            if (status.Base.IsFavorited)
            {
                FavouriteCheckBox.Checked = true;
            }
            if (status.IsRetweted)
            {
                RetweetCheckBox.Checked = true;
            }
        }



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

        private static void OnUndoFavoriteTweetEventHandlerEvent(TwitterStatusEventArgs e)
        {
            var handler = UndoFavoriteTweetEventHandlerEvent;
            if (handler != null) handler(null, e);
        }

        private static void OnUndoRetweetEventHandlerEvent(TwitterStatusEventArgs e)
        {
            var handler = UndoRetweetEventHandlerEvent;
            if (handler != null) handler(null, e);
        }

        private void FavouriteCheckBox_Click(object sender, EventArgs e)
        {
           /* if (FavouriteCheckBox.Checked)
            {
                OnFavoriteTweetEventHandlerEvent(new TwitterStatusEventArgs(_status.Base.Id));
                return;
            }
            OnUndoFavoriteTweetEventHandlerEvent(new TwitterStatusEventArgs(_status.RetweetedStatus.Id));*/
        }

        private void RetweetCheckBox_Click(object sender, EventArgs e)
        {
            var eventArgs = new TwitterStatusEventArgs(_status.Base.Id);
            if (RetweetCheckBox.Checked)
            {
                OnRetweetEventHandlerEvent(eventArgs);
                return;
            }
            OnUndoRetweetEventHandlerEvent(new TwitterStatusEventArgs(_status.Base.Id));
        }

        private void TweetControl_Load(object sender, EventArgs e)
        {

        }

        private void RetweetCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
