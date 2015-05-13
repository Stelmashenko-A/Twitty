using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Controls;
using TwitterClient.Decorator;

namespace TwitterControls
{
    public partial class TweetList : MetroUserControl
    {
        public TweetList()
        {
            InitializeComponent();
        }

        private readonly LinkedList<TweetControl> _controls = new LinkedList<TweetControl>();
        
        void SetLocation(int i)
        {
            foreach (var variable in _controls)
            {
                variable.Location = new Point(variable.Location.X, variable.Location.Y + i + 5);
            }
        }

        void SetScrool()
        {
            if (_controls.Last.Value.Location.Y + _controls.Last.Value.Height > Height)
            {
                AutoScrollMinSize = new Size(0, _controls.Last.Value.Location.Y + _controls.Last.Value.Height - Height);
            }
        }

        private void PushItem(TweetControl tweetControl)
        {
            SetLocation(tweetControl.Height);
            SetScrool();

            tweetControl.Location = new Point((Width - tweetControl.Width) / 2, 0);

            _controls.AddFirst(tweetControl);
            Controls.Add(tweetControl);

            Refresh();
        }
        public void Add(DecoratedTwitterStatus item)
        {
            var tweetControl = new TweetControl(item);
            BeginInvoke(new Action(() => PushItem(tweetControl)));
        }

        public void AddRange(IEnumerable<DecoratedTwitterStatus> items)
        {
            foreach (var variable in items)
            {
                Add(variable);
            }
        }

        public void InializeTweets(IEnumerable<DecoratedTwitterStatus> items)
        {
            var twitterStatuses = items.ToArray();
            var tweetControl = new TweetControl(twitterStatuses[0]) {Location = new Point(0, 0)};
            _controls.AddFirst(tweetControl);
            var location = tweetControl.Height + 5;
            var control = tweetControl;

            BeginInvoke(new Action(
                    () => Controls.Add(control)));

            
            for (var i = 1; i < twitterStatuses.Count(); i++)
            {
                tweetControl = new TweetControl(twitterStatuses[i]) { Location = new Point(0, location) };
                _controls.AddFirst(tweetControl);
                var control1 = tweetControl;
                BeginInvoke(new Action(
                () => Controls.Add(control1)));
                location += (tweetControl.Height + 5);
            }

            BeginInvoke(new Action(
                Refresh));
        }
    }
}
