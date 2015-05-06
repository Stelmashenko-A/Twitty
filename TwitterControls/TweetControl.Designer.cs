namespace TwitterControls
{
    partial class TweetControl
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
            this.FavouriteCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.RetweetCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FavouriteCheckBox
            // 
            this.FavouriteCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FavouriteCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.FavouriteCheckBox.Depth = 0;
            this.FavouriteCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.FavouriteCheckBox.Location = new System.Drawing.Point(80, 41);
            this.FavouriteCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.FavouriteCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.FavouriteCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.FavouriteCheckBox.Name = "FavouriteCheckBox";
            this.FavouriteCheckBox.Ripple = true;
            this.FavouriteCheckBox.Size = new System.Drawing.Size(86, 19);
            this.FavouriteCheckBox.TabIndex = 0;
            this.FavouriteCheckBox.Text = "Favoutite";
            this.FavouriteCheckBox.UseVisualStyleBackColor = true;
            // 
            // RetweetCheckBox
            // 
            this.RetweetCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RetweetCheckBox.Depth = 0;
            this.RetweetCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.RetweetCheckBox.Location = new System.Drawing.Point(0, 41);
            this.RetweetCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.RetweetCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.RetweetCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.RetweetCheckBox.Name = "RetweetCheckBox";
            this.RetweetCheckBox.Ripple = true;
            this.RetweetCheckBox.Size = new System.Drawing.Size(80, 19);
            this.RetweetCheckBox.TabIndex = 1;
            this.RetweetCheckBox.Text = "Retweet";
            this.RetweetCheckBox.UseVisualStyleBackColor = true;
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
            // TweetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RetweetCheckBox);
            this.Controls.Add(this.FavouriteCheckBox);
            this.MaximumSize = new System.Drawing.Size(435, 60);
            this.MinimumSize = new System.Drawing.Size(400, 60);
            this.Name = "TweetControl";
            this.Size = new System.Drawing.Size(435, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCheckBox FavouriteCheckBox;
        private MaterialSkin.Controls.MaterialCheckBox RetweetCheckBox;
        private System.Windows.Forms.Label label1;



    }
}
