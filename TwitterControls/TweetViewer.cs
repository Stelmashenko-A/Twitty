using System;
using System.Collections.Generic;
using MetroFramework.Controls;
using TwitterClient;
using TwitterClient.Decorator;

namespace TwitterControls
{
    public partial class TweetViewer : MetroUserControl, IAddable<DecoratedTwitterStatus>
    {
        private int _count;

        private readonly List<DecoratedTwitterStatus> _buffer = new List<DecoratedTwitterStatus>();

        public TweetViewer()
        {
            InitializeComponent();
        }

        public void Add(DecoratedTwitterStatus item)
        {
            if (_count == 0)
            {
                BeginInvoke(new Action(() => materialFlatButton1.Visible = true));
            }
            _count++;
            BeginInvoke(new Action(() => materialFlatButton1.Text = _count.ToString()));
            _buffer.Add(item);
            BeginInvoke(new Action(Refresh));
        }

        public void AddRange(IEnumerable<DecoratedTwitterStatus> item)
        {
            foreach (var variable in item)
            {
                Add(variable);
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            tweetList1.AddRange(_buffer);
            materialFlatButton1.Hide();
            _count = 0;
            Refresh();
        }

        public void SetDataFromRestApi(IEnumerable<DecoratedTwitterStatus> items)
        {
            BeginInvoke(new Action(() => tweetList1.InializeTweets(items)));
        }
    }
}
