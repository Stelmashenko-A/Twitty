using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TweetSharp;
using TwitterClient;

namespace TwitterControls
{
    public partial class TweetList : UserControl
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
        public void Add(TwitterStatus item)
        {
            var tweetControl = new TweetControl(item);
            BeginInvoke(new Action(()=>SetLocation(tweetControl.Height)));
            BeginInvoke(new Action(SetScrool));
            tweetControl.Location = new Point((Width-tweetControl.Width)/2, 0);
            _controls.AddFirst(tweetControl);
            BeginInvoke(new Action(
                () => Controls.Add(tweetControl)));
            

            BeginInvoke(new Action(
                Refresh));

        }

        public void AddRange(IEnumerable<TwitterStatus> items)
        {
            foreach (var variable in items)
            {
                Add(variable);
            }
        }

        public void InializeTweets(IEnumerable<TwitterStatus> items)
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
