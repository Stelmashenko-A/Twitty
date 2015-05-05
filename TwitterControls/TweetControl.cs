using System;
using System.Drawing;
using MaterialSkin.Controls;
using MetroFramework.Controls;

namespace TwitterControls
{
    
    public partial class TweetControl: MetroUserControl
    {
        public event MyEventHandler MyEvent;
        public TweetControl()
        {
            InitializeComponent();
        }
        
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (MyEvent != null) MyEvent(this,e);
        }

        public delegate void MyEventHandler(object sender, EventArgs e);
        public class MyEventArgs : EventArgs
        {

        }
    }
}
