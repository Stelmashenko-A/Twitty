using System;
using System.Windows.Forms;

namespace Twitty.Utility
{
    public partial class InputBox : Form, Kernel.IDataReader
    {
        private static InputBox _newInputBox;
        private static string _returnString;

        public InputBox()
        {
            InitializeComponent();
        }

        public static string Show(string inputBoxText)
        {
            _newInputBox = new InputBox {label = {Text = inputBoxText}};
            _newInputBox.ShowDialog();
            return _returnString;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _returnString = textBox.Text;
            _newInputBox.Dispose();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _returnString = string.Empty;
            _newInputBox.Dispose();
        }

        public string Data
        {
            get { return _returnString; }
            set { throw new NotImplementedException(); }
        }
    }
}
