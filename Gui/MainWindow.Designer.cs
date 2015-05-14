namespace Gui
{
    sealed partial class MainWindow
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tweetViewer1 = new TwitterControls.TweetViewer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonSendTweet = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // tweetViewer1
            // 
            this.tweetViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tweetViewer1.BackColor = System.Drawing.SystemColors.Control;
            this.tweetViewer1.Location = new System.Drawing.Point(12, 197);
            this.tweetViewer1.MaximumSize = new System.Drawing.Size(440, 500);
            this.tweetViewer1.MinimumSize = new System.Drawing.Size(440, 500);
            this.tweetViewer1.Name = "tweetViewer1";
            this.tweetViewer1.Size = new System.Drawing.Size(440, 500);
            this.tweetViewer1.TabIndex = 0;
            this.tweetViewer1.UseSelectable = true;
            this.tweetViewer1.Load += new System.EventHandler(this.tweetViewer1_Load_1);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBox1.Location = new System.Drawing.Point(12, 79);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(440, 64);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "123456789012345678901234567890123456789012345678901234567890123456789012345678901" +
    "23456789012345678901234567890123456789012345678901234567890";
            // 
            // buttonSendTweet
            // 
            this.buttonSendTweet.AutoSize = true;
            this.buttonSendTweet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSendTweet.Depth = 0;
            this.buttonSendTweet.Location = new System.Drawing.Point(12, 152);
            this.buttonSendTweet.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSendTweet.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSendTweet.Name = "buttonSendTweet";
            this.buttonSendTweet.Primary = false;
            this.buttonSendTweet.Size = new System.Drawing.Size(94, 36);
            this.buttonSendTweet.TabIndex = 2;
            this.buttonSendTweet.Text = "Send tweet";
            this.buttonSendTweet.UseVisualStyleBackColor = true;
            this.buttonSendTweet.Click += new System.EventHandler(this.buttonSendTweet_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(468, 710);
            this.Controls.Add(this.buttonSendTweet);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tweetViewer1);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private TwitterControls.TweetViewer tweetViewer1;
        private System.Windows.Forms.TextBox textBox1;
        private MaterialSkin.Controls.MaterialFlatButton buttonSendTweet;
    }
}

