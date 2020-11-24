namespace DesktopFacebookInterface
{
    internal partial class FormShowAlbum
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonPrevious = new System.Windows.Forms.Button();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonNext
            // 
            this.ButtonNext.Location = new System.Drawing.Point(270, 287);
            this.ButtonNext.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(82, 22);
            this.ButtonNext.TabIndex = 1;
            this.ButtonNext.Text = "Next";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // ButtonPrevious
            // 
            this.ButtonPrevious.Location = new System.Drawing.Point(161, 287);
            this.ButtonPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonPrevious.Name = "ButtonPrevious";
            this.ButtonPrevious.Size = new System.Drawing.Size(80, 22);
            this.ButtonPrevious.TabIndex = 2;
            this.ButtonPrevious.Text = "Previous";
            this.ButtonPrevious.UseVisualStyleBackColor = true;
            this.ButtonPrevious.Click += new System.EventHandler(this.ButtonPrevious_Click);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(23, 11);
            this.pictureBoxImage.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(487, 250);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 3;
            this.pictureBoxImage.TabStop = false;
            // 
            // ShowAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 320);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.ButtonPrevious);
            this.Controls.Add(this.ButtonNext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowAlbum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShowAlbum";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonPrevious;
        private System.Windows.Forms.PictureBox pictureBoxImage;
    }
}