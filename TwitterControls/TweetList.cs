using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TweetSharp;

namespace TwitterControls
{
    public partial class TweetList : UserControl
    {
        public TweetList()
        {
            InitializeComponent();
            MouseWheel += mouseWheel_eventHendler;
        }

        public void Initialize(List<TwitterStatus> statuses)
        {
            _statuses = new LinkedList<TwitterStatus>(statuses);
        }
        private LinkedList<TwitterStatus> _statuses;
        private readonly LinkedList<TweetControl> _controls=new LinkedList<TweetControl>(); 

        public void Add()
        {
            var tweetControl = new TweetControl(_statuses.Last.Value);
            _statuses.RemoveLast();
            tweetControl.Location = new Point(0, -tweetControl.Height - 5 + materialFlatButtonNewTweets.Height);
            _controls.AddFirst(tweetControl);
            Controls.Add(tweetControl);
            var delta = tweetControl.Height + 5;
            InitializeTranform(500, delta);
            Refresh();
        }

        public void mouseWheel_eventHendler(object sender, MouseEventArgs e)
        {
            InitializeTranform(20,e.Delta);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add();
            materialFlatButtonNewTweets.BringToFront();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            InitializeTranform(500,Height);
        }

        private int _steps;
        private int _timeCounter;
        private int _delta;
        private void timer_Tick(object sender, EventArgs e)
        {
            _timeCounter++;
            
            if (_timeCounter > _steps)
            {
                timer.Stop();
                return;
            }
            Relocate(_delta);
        }

        private void InitializeTranform(int mileseconds, int delta)
        {
            if (delta > 0)
            {
                if (_controls.First.Value.Location.Y - materialFlatButtonNewTweets.Height + delta > 0)
                {
                    delta = -_controls.First.Value.Location.Y + materialFlatButtonNewTweets.Height;
                }

            }
            if (delta < 0)
            {
                if (_controls.Last.Value.Location.Y + _controls.Last.Value.Height + delta < Height)
                {
                    delta = -(_controls.Last.Value.Location.Y + _controls.Last.Value.Height - Height);
                }
                if (_controls.Last.Value.Location.Y + _controls.Last.Value.Height < Height)
                    delta = 0;
            }
            _timeCounter = 0;
            _steps = mileseconds/timer.Interval;
            if (_steps == 0) _steps = 1;
            _delta = delta/_steps;
            timer.Start();
        }

        private void Relocate(int delta)
        {
            
            if (delta < 0)
            {
                
            }
            //delta = Math.Min(delta, -_controls.First.Value.Location.Y);
            //delta = Math.Max(delta, this.Height - _controls.Last.Value.Location.Y);
            foreach (var variable in _controls)
            {
                Point p = new Point(variable.Location.X, variable.Location.Y + delta);
                variable.Location = p;
            }
            Refresh();
        }
    }
}
