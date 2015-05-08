namespace Gui
{
    partial class MainWindow
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
            this.SuspendLayout();
            // 
            // tweetViewer1
            // 
            this.tweetViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tweetViewer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tweetViewer1.Location = new System.Drawing.Point(138, 12);
            this.tweetViewer1.Name = "tweetViewer1";
            this.tweetViewer1.Size = new System.Drawing.Size(435, 380);
            this.tweetViewer1.TabIndex = 0;
            this.tweetViewer1.Load += new System.EventHandler(this.tweetViewer1_Load_1);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 380);
            this.Controls.Add(this.tweetViewer1);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TwitterControls.TweetViewer tweetViewer1;







    }
}

