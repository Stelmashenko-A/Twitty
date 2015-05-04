namespace TwitterControls
{
    partial class UserControl1
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // FavouriteCheckBox
            // 
            this.FavouriteCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FavouriteCheckBox.AutoSize = true;
            this.FavouriteCheckBox.Depth = 0;
            this.FavouriteCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.FavouriteCheckBox.Location = new System.Drawing.Point(80, 57);
            this.FavouriteCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.FavouriteCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.FavouriteCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.FavouriteCheckBox.Name = "FavouriteCheckBox";
            this.FavouriteCheckBox.Ripple = true;
            this.FavouriteCheckBox.Size = new System.Drawing.Size(87, 30);
            this.FavouriteCheckBox.TabIndex = 0;
            this.FavouriteCheckBox.Text = "Favoutite";
            this.FavouriteCheckBox.UseVisualStyleBackColor = true;
            this.FavouriteCheckBox.CheckedChanged += new System.EventHandler(this.materialCheckBox1_CheckedChanged);
            // 
            // RetweetCheckBox
            // 
            this.RetweetCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RetweetCheckBox.AutoSize = true;
            this.RetweetCheckBox.Depth = 0;
            this.RetweetCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.RetweetCheckBox.Location = new System.Drawing.Point(0, 57);
            this.RetweetCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.RetweetCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.RetweetCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.RetweetCheckBox.Name = "RetweetCheckBox";
            this.RetweetCheckBox.Ripple = true;
            this.RetweetCheckBox.Size = new System.Drawing.Size(80, 30);
            this.RetweetCheckBox.TabIndex = 1;
            this.RetweetCheckBox.Text = "Retweet";
            this.RetweetCheckBox.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(4, 4);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(575, 53);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "123456789012345678901234567890123456789012345678901234567890123456789012345678901" +
    "23456789012345678901234567890123456789012345678901234567890";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.RetweetCheckBox);
            this.Controls.Add(this.FavouriteCheckBox);
            this.MinimumSize = new System.Drawing.Size(585, 85);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(585, 87);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialCheckBox FavouriteCheckBox;
        private MaterialSkin.Controls.MaterialCheckBox RetweetCheckBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;



    }
}
