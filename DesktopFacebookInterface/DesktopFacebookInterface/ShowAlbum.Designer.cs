namespace DesktopFacebookInterface
{
    partial class ShowAlbum
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
            this.labelAlbumName = new System.Windows.Forms.Label();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonPrevious = new System.Windows.Forms.Button();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAlbumName
            // 
            this.labelAlbumName.AutoSize = true;
            this.labelAlbumName.Location = new System.Drawing.Point(41, 16);
            this.labelAlbumName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAlbumName.Name = "labelAlbumName";
            this.labelAlbumName.Size = new System.Drawing.Size(134, 25);
            this.labelAlbumName.TabIndex = 0;
            this.labelAlbumName.Text = "Album Name";
            // 
            // ButtonNext
            // 
            this.ButtonNext.Location = new System.Drawing.Point(532, 509);
            this.ButtonNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(164, 42);
            this.ButtonNext.TabIndex = 1;
            this.ButtonNext.Text = "Next";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // ButtonPrevious
            // 
            this.ButtonPrevious.Location = new System.Drawing.Point(364, 509);
            this.ButtonPrevious.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonPrevious.Name = "ButtonPrevious";
            this.ButtonPrevious.Size = new System.Drawing.Size(160, 42);
            this.ButtonPrevious.TabIndex = 2;
            this.ButtonPrevious.Text = "Previous";
            this.ButtonPrevious.UseVisualStyleBackColor = true;
            this.ButtonPrevious.Click += new System.EventHandler(this.ButtonPrevious_Click);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(153, 64);
            this.pictureBoxImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(707, 410);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 3;
            this.pictureBoxImage.TabStop = false;
            // 
            // ShowAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 632);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.ButtonPrevious);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.labelAlbumName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ShowAlbum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowAlbum";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAlbumName;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonPrevious;
        private System.Windows.Forms.PictureBox pictureBoxImage;
    }
}