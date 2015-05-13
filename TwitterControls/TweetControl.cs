using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MetroFramework.Controls;
using TwitterClient.Decorator;

namespace TwitterControls
{

    public sealed partial class TweetControl : MetroUserControl
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

        public CheckBox RetweetCheckBox;

        public TweetControl(DecoratedTwitterStatus status)
        {
            _status = status;
            InitializeComponent();
            InitilizeCheckboxes();

            Refresh();

            label1.Text = _status.Base.Text;
            if (_status.Base.IsFavorited)
            {
                FavouriteCheckBox.Checked = true;
            }
            if (_status.IsRetweted)
            {
                RetweetCheckBox.Checked = true;
            }
        }

        private void InitilizeCheckboxes()
        {
            FavouriteCheckBox = new MaterialCheckBox
            {
                Text = "Favourite",
                Depth = 0,
                Ripple = true,
                Location = new Point(150, 60),
                Name = "FavouriteCheckBox",
                Size = new Size(150, 17),
                TabIndex = 7,
                UseVisualStyleBackColor = true
            };
            FavouriteCheckBox.Click += FavouriteCheckBox_Click;
            Controls.Add(FavouriteCheckBox);

            RetweetCheckBox = new MaterialCheckBox
            {
                Text = "Retweet  ",
                Location = new Point(0, 60),
                Name = "RetweetCheckBox",
                Size = new Size(150, 17),
                TabIndex = 7,
                UseVisualStyleBackColor = true
            };
            RetweetCheckBox.Click += RetweetCheckBox_Click;
            Controls.Add(RetweetCheckBox);
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
            if (FavouriteCheckBox.Checked)
            {
                OnFavoriteTweetEventHandlerEvent(new TwitterStatusEventArgs(_status.Base.Id));
                return;
            }
            OnUndoFavoriteTweetEventHandlerEvent(new TwitterStatusEventArgs(_status.Base.Id));
        }

        private void RetweetCheckBox_Click(object sender, EventArgs e)
        {
            var eventArgs = new TwitterStatusEventArgs(_status.Base.Id);
            if (RetweetCheckBox.Checked)
            {
                OnRetweetEventHandlerEvent(eventArgs);
                return;
            }
            var id = _status.Base.Id;
            if (_status.Base.RetweetedStatus != null)
                id = _status.Base.RetweetedStatus.Id;
            OnUndoRetweetEventHandlerEvent(new TwitterStatusEventArgs(id));
        }
    }
}