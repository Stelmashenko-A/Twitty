namespace TwitterControls
{
    partial class TweetList
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.materialFlatButtonNewTweets = new MaterialSkin.Controls.MaterialFlatButton();
            this.button1 = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // materialFlatButtonNewTweets
            // 
            this.materialFlatButtonNewTweets.AutoSize = true;
            this.materialFlatButtonNewTweets.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButtonNewTweets.Depth = 0;
            this.materialFlatButtonNewTweets.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialFlatButtonNewTweets.Location = new System.Drawing.Point(0, 0);
            this.materialFlatButtonNewTweets.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButtonNewTweets.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButtonNewTweets.Name = "materialFlatButtonNewTweets";
            this.materialFlatButtonNewTweets.Primary = false;
            this.materialFlatButtonNewTweets.Size = new System.Drawing.Size(440, 36);
            this.materialFlatButtonNewTweets.TabIndex = 3;
            this.materialFlatButtonNewTweets.Text = "materialFlatButton1";
            this.materialFlatButtonNewTweets.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Interval = 101;
            // 
            // TweetList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(2, 2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.materialFlatButtonNewTweets);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(440, 365);
            this.Name = "TweetList";
            this.Size = new System.Drawing.Size(440, 365);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton materialFlatButtonNewTweets;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer;
    }
}
