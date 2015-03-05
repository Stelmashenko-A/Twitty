using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twitty.Kernel;

namespace Twitty
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            var account = new Account();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
