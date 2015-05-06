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
    }
}
