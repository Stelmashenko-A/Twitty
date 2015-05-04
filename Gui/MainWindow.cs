using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Gui
{
    public partial class MainWindow : Form
    {
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox;
        public MainWindow()
        {
            InitializeComponent();
            this.materialCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialCheckBox.AutoSize = true;
            this.materialCheckBox.Text = "materialCheckBoxasdf";
            this.Controls.Add(materialCheckBox);
            

        }
    }
}
