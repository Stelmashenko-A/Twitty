using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace TwitterControls
{
    partial class TweetControl
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
            this.FavouriteCheckBox = new MaterialCheckBox();
            this.RetweetCheckBox = new MaterialCheckBox();
            this.label1 = new Label();
            this.SuspendLayout();
            // 
            // FavouriteCheckBox
            // 
            this.FavouriteCheckBox.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.FavouriteCheckBox.Appearance = Appearance.Button;
            this.FavouriteCheckBox.Depth = 0;
            this.FavouriteCheckBox.Font = new Font("Roboto", 10F);
            this.FavouriteCheckBox.Location = new Point(80, 41);
            this.FavouriteCheckBox.Margin = new Padding(0);
            this.FavouriteCheckBox.MouseLocation = new Point(-1, -1);
            this.FavouriteCheckBox.MouseState = MouseState.HOVER;
            this.FavouriteCheckBox.Name = "FavouriteCheckBox";
            this.FavouriteCheckBox.Ripple = true;
            this.FavouriteCheckBox.Size = new Size(86, 19);
            this.FavouriteCheckBox.TabIndex = 0;
            this.FavouriteCheckBox.Text = "Favoutite";
            this.FavouriteCheckBox.UseVisualStyleBackColor = true;
            this.FavouriteCheckBox.CheckedChanged += new EventHandler(this.FavouriteCheckBox_CheckedChanged);
            // 
            // RetweetCheckBox
            // 
            this.RetweetCheckBox.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.RetweetCheckBox.Depth = 0;
            this.RetweetCheckBox.Font = new Font("Roboto", 10F);
            this.RetweetCheckBox.Location = new Point(0, 41);
            this.RetweetCheckBox.Margin = new Padding(0);
            this.RetweetCheckBox.MouseLocation = new Point(-1, -1);
            this.RetweetCheckBox.MouseState = MouseState.HOVER;
            this.RetweetCheckBox.Name = "RetweetCheckBox";
            this.RetweetCheckBox.Ripple = true;
            this.RetweetCheckBox.Size = new Size(80, 19);
            this.RetweetCheckBox.TabIndex = 1;
            this.RetweetCheckBox.Text = "Retweet";
            this.RetweetCheckBox.UseVisualStyleBackColor = true;
            this.RetweetCheckBox.CheckedChanged += new EventHandler(this.RetweetCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left)));
            this.label1.Location = new Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(438, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "123456789012345678901234567890123456789012345678901234567890123456789012345678901" +
    "23456789012345678901234567890123456789012345678901234567890";
            // 
            // TweetControl
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            //this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RetweetCheckBox);
            this.Controls.Add(this.FavouriteCheckBox);
            this.MaximumSize = new Size(435, 60);
            this.MinimumSize = new Size(400, 60);
            this.Name = "TweetControl";
            this.Size = new Size(435, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialCheckBox FavouriteCheckBox;
        private MaterialCheckBox RetweetCheckBox;
        private Label label1;
    }
}