namespace TwitterControls
{
    partial class TweetViewer
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
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.tweetList1 = new TwitterControls.TweetList();
            this.SuspendLayout();
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.BackColor = System.Drawing.SystemColors.Control;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialFlatButton1.Location = new System.Drawing.Point(0, 0);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(440, 36);
            this.materialFlatButton1.TabIndex = 0;
            this.materialFlatButton1.Text = "materialFlatButton1";
            this.materialFlatButton1.UseVisualStyleBackColor = false;
            this.materialFlatButton1.Visible = false;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // tweetList1
            // 
            this.tweetList1.AutoScroll = true;
            this.tweetList1.AutoScrollMargin = new System.Drawing.Size(2, 2);
            this.tweetList1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tweetList1.BackColor = System.Drawing.SystemColors.Control;
            this.tweetList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tweetList1.Location = new System.Drawing.Point(0, 36);
            this.tweetList1.MinimumSize = new System.Drawing.Size(440, 365);
            this.tweetList1.Name = "tweetList1";
            this.tweetList1.Size = new System.Drawing.Size(440, 464);
            this.tweetList1.TabIndex = 1;
            // 
            // TweetViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tweetList1);
            this.Controls.Add(this.materialFlatButton1);
            this.MaximumSize = new System.Drawing.Size(440, 500);
            this.MinimumSize = new System.Drawing.Size(440, 500);
            this.Name = "TweetViewer";
            this.Size = new System.Drawing.Size(440, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private TweetList tweetList1;
    }
}
