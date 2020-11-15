namespace DesktopFacebookInterface
{
    partial class Form1
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
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.PictureBoxProfilePicture = new System.Windows.Forms.PictureBox();
            this.LabelAbout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.Location = new System.Drawing.Point(283, 298);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(212, 33);
            this.ButtonLogin.TabIndex = 0;
            this.ButtonLogin.Text = "Login";
            this.ButtonLogin.UseVisualStyleBackColor = true;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // PictureBoxProfilePicture
            // 
            this.PictureBoxProfilePicture.Location = new System.Drawing.Point(310, 100);
            this.PictureBoxProfilePicture.Name = "PictureBoxProfilePicture";
            this.PictureBoxProfilePicture.Size = new System.Drawing.Size(153, 106);
            this.PictureBoxProfilePicture.TabIndex = 1;
            this.PictureBoxProfilePicture.TabStop = false;
            this.PictureBoxProfilePicture.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // LabelAbout
            // 
            this.LabelAbout.AutoSize = true;
            this.LabelAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LabelAbout.Location = new System.Drawing.Point(46, 50);
            this.LabelAbout.Name = "LabelAbout";
            this.LabelAbout.Size = new System.Drawing.Size(81, 29);
            this.LabelAbout.TabIndex = 3;
            this.LabelAbout.Text = "About:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LabelAbout);
            this.Controls.Add(this.PictureBoxProfilePicture);
            this.Controls.Add(this.ButtonLogin);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.PictureBox PictureBoxProfilePicture;
        private System.Windows.Forms.Label LabelAbout;
    }
}

