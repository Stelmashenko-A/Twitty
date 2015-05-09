using System;
using System.ComponentModel;
using System.Drawing;
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
            this.RetweetCheckBox = new System.Windows.Forms.CheckBox();
            this.FavouriteCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "123456789012345678901234567890123456789012345678901234567890123456789012345678901" +
    "23456789012345678901234567890123456789012345678901234567890";
            // 
            // RetweetCheckBox
            // 
            this.RetweetCheckBox.AutoSize = true;
            this.RetweetCheckBox.Location = new System.Drawing.Point(3, 43);
            this.RetweetCheckBox.Name = "RetweetCheckBox";
            this.RetweetCheckBox.Size = new System.Drawing.Size(66, 17);
            this.RetweetCheckBox.TabIndex = 6;
            this.RetweetCheckBox.Text = "Retweet";
            this.RetweetCheckBox.UseVisualStyleBackColor = true;
            this.RetweetCheckBox.CheckedChanged += new System.EventHandler(this.RetweetCheckBox_CheckedChanged);
            // 
            // FavouriteCheckBox
            // 
            this.FavouriteCheckBox.AutoSize = true;
            this.FavouriteCheckBox.Location = new System.Drawing.Point(75, 43);
            this.FavouriteCheckBox.Name = "FavouriteCheckBox";
            this.FavouriteCheckBox.Size = new System.Drawing.Size(70, 17);
            this.FavouriteCheckBox.TabIndex = 7;
            this.FavouriteCheckBox.Text = "Favourite";
            this.FavouriteCheckBox.UseVisualStyleBackColor = true;
            this.FavouriteCheckBox.CheckedChanged += new System.EventHandler(this.FavouriteCheckBox_CheckedChanged);
            // 
            // TweetControl
            // 
            this.AutoSize = true;
            this.Controls.Add(this.FavouriteCheckBox);
            this.Controls.Add(this.RetweetCheckBox);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(435, 60);
            this.MinimumSize = new System.Drawing.Size(400, 60);
            this.Name = "TweetControl";
            this.Size = new System.Drawing.Size(435, 60);
            this.Load += new System.EventHandler(this.TweetControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private CheckBox RetweetCheckBox;
        private CheckBox FavouriteCheckBox;
    }
}