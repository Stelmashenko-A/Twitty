using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace TwitterControls
{
    sealed partial class TweetControl
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "123456789012345678901234567890123456789012345678901234567890123456789012345678901" +
    "23456789012345678901234567890123456789012345678901234567890";
            // 
            // TweetControl
            // 
            this.AutoSize = true;
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(435, 80);
            this.MinimumSize = new System.Drawing.Size(400, 60);
            this.Name = "TweetControl";
            this.Size = new System.Drawing.Size(435, 80);
            this.Load += new System.EventHandler(this.TweetControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private CheckBox FavouriteCheckBox;
    }
}