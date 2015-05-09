using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TweetSharp;
using TwitterClient;

namespace TwitterControls
{
    public partial class TweetViewer : UserControl, IAddable<TwitterStatus>
    {
        public TweetViewer()
        {
            InitializeComponent();
        }

        private int _count;
        readonly List<TwitterStatus> _buffer = new List<TwitterStatus>();
        public void Add(TwitterStatus item)
        {
            if (_count == 0)
            {
                BeginInvoke(new Action(()=>materialFlatButton1.Visible = true));
            }
            _count++;
            BeginInvoke(new Action(()=>materialFlatButton1.Text = _count.ToString()));
            _buffer.Add(item);
            BeginInvoke(new Action(Refresh));
        }

        public void AddRange(IEnumerable<TwitterStatus> item)
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

        public void SetDataFromRestApi(IEnumerable<TwitterStatus> items)
        {
            tweetList1.InializeTweets(items);
        }
    }
}
