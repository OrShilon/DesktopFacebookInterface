namespace DesktopFacebookInterface
{
    partial class FormLoginScreen
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
            this.checkBoxRememberUser = new System.Windows.Forms.CheckBox();
            this.PictureBoxProfilePicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLogin.Location = new System.Drawing.Point(276, 315);
            this.ButtonLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(294, 62);
            this.ButtonLogin.TabIndex = 0;
            this.ButtonLogin.Text = "Login To Facebook";
            this.ButtonLogin.UseVisualStyleBackColor = true;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // checkBoxRememberUser
            // 
            this.checkBoxRememberUser.AutoSize = true;
            this.checkBoxRememberUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRememberUser.ForeColor = System.Drawing.Color.White;
            this.checkBoxRememberUser.Location = new System.Drawing.Point(306, 415);
            this.checkBoxRememberUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxRememberUser.Name = "checkBoxRememberUser";
            this.checkBoxRememberUser.Size = new System.Drawing.Size(223, 35);
            this.checkBoxRememberUser.TabIndex = 2;
            this.checkBoxRememberUser.Text = "Remember Me";
            this.checkBoxRememberUser.UseVisualStyleBackColor = true;
            this.checkBoxRememberUser.CheckedChanged += new System.EventHandler(this.checkBoxRememberUser_CheckedChanged);
            // 
            // PictureBoxProfilePicture
            // 
            this.PictureBoxProfilePicture.Image = global::DesktopFacebookInterface.Properties.Resources.FacebookLogo;
            this.PictureBoxProfilePicture.Location = new System.Drawing.Point(0, 35);
            this.PictureBoxProfilePicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PictureBoxProfilePicture.Name = "PictureBoxProfilePicture";
            this.PictureBoxProfilePicture.Size = new System.Drawing.Size(858, 237);
            this.PictureBoxProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBoxProfilePicture.TabIndex = 1;
            this.PictureBoxProfilePicture.TabStop = false;
            // 
            // FormLoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 565);
            this.Controls.Add(this.checkBoxRememberUser);
            this.Controls.Add(this.PictureBoxProfilePicture);
            this.Controls.Add(this.ButtonLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormLoginScreen";
            this.Text = "FormLoginScreen";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.PictureBox PictureBoxProfilePicture;
        private System.Windows.Forms.CheckBox checkBoxRememberUser;
    }
}