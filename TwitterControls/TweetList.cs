using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TweetSharp;
using TwitterClient;

namespace TwitterControls
{
    public partial class TweetList : UserControl,IAddable<TwitterStatus>
    {
        public TweetList()
        {
            InitializeComponent();
        }
        
        private readonly LinkedList<TweetControl> _controls=new LinkedList<TweetControl>(); 
        
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
            Invoke(new Action(()=>SetLocation(tweetControl.Height)));
            tweetControl.Location = new Point(0, materialFlatButtonNewTweets.Height);
            _controls.AddFirst(tweetControl);
            Invoke(new Action(
                () => Controls.Add(tweetControl)));
            Console.Beep();
            Invoke(new Action(
               () => Controls.Add(tweetControl)));
            Invoke(new Action(SetScrool));
            
            Invoke(new Action(
                Refresh));

        }
    }
}
