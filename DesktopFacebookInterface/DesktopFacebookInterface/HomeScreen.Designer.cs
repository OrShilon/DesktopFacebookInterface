namespace DesktopFacebookInterface
{
    partial class HomeScreen
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
            this.buttonLogout = new System.Windows.Forms.Button();
            this.PictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.PictureBoxCoverPhoto = new System.Windows.Forms.PictureBox();
            this.tabControlHomeScreen = new System.Windows.Forms.TabControl();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.tabPageAlbums = new System.Windows.Forms.TabPage();
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.tabPagePages = new System.Windows.Forms.TabPage();
            this.tabPageEvents = new System.Windows.Forms.TabPage();
            this.listBoxPages = new System.Windows.Forms.ListBox();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCoverPhoto)).BeginInit();
            this.tabControlHomeScreen.SuspendLayout();
            this.tabPageAlbums.SuspendLayout();
            this.tabPagePages.SuspendLayout();
            this.tabPageEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(669, 44);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(112, 35);
            this.buttonLogout.TabIndex = 2;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // PictureBoxProfile
            // 
            this.PictureBoxProfile.Location = new System.Drawing.Point(221, 72);
            this.PictureBoxProfile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PictureBoxProfile.Name = "PictureBoxProfile";
            this.PictureBoxProfile.Size = new System.Drawing.Size(150, 114);
            this.PictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxProfile.TabIndex = 1;
            this.PictureBoxProfile.TabStop = false;
            // 
            // PictureBoxCoverPhoto
            // 
            this.PictureBoxCoverPhoto.Location = new System.Drawing.Point(-1, -2);
            this.PictureBoxCoverPhoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PictureBoxCoverPhoto.Name = "PictureBoxCoverPhoto";
            this.PictureBoxCoverPhoto.Size = new System.Drawing.Size(628, 188);
            this.PictureBoxCoverPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxCoverPhoto.TabIndex = 0;
            this.PictureBoxCoverPhoto.TabStop = false;
            // 
            // tabControlHomeScreen
            // 
            this.tabControlHomeScreen.Controls.Add(this.tabPageAbout);
            this.tabControlHomeScreen.Controls.Add(this.tabPageAlbums);
            this.tabControlHomeScreen.Controls.Add(this.tabPagePages);
            this.tabControlHomeScreen.Controls.Add(this.tabPageEvents);
            this.tabControlHomeScreen.Location = new System.Drawing.Point(-1, 186);
            this.tabControlHomeScreen.Name = "tabControlHomeScreen";
            this.tabControlHomeScreen.SelectedIndex = 0;
            this.tabControlHomeScreen.Size = new System.Drawing.Size(822, 273);
            this.tabControlHomeScreen.TabIndex = 3;
            this.tabControlHomeScreen.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlHomeScreen_Selected);
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Location = new System.Drawing.Point(4, 29);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAbout.Size = new System.Drawing.Size(814, 240);
            this.tabPageAbout.TabIndex = 0;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // tabPageAlbums
            // 
            this.tabPageAlbums.Controls.Add(this.listBoxAlbums);
            this.tabPageAlbums.Location = new System.Drawing.Point(4, 29);
            this.tabPageAlbums.Name = "tabPageAlbums";
            this.tabPageAlbums.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlbums.Size = new System.Drawing.Size(814, 240);
            this.tabPageAlbums.TabIndex = 1;
            this.tabPageAlbums.Text = "Albums";
            this.tabPageAlbums.UseVisualStyleBackColor = true;
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 20;
            this.listBoxAlbums.Location = new System.Drawing.Point(3, 3);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(261, 204);
            this.listBoxAlbums.TabIndex = 0;
            this.listBoxAlbums.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbums_SelectedIndexChanged);
            // 
            // tabPagePages
            // 
            this.tabPagePages.Controls.Add(this.listBoxPages);
            this.tabPagePages.Location = new System.Drawing.Point(4, 29);
            this.tabPagePages.Name = "tabPagePages";
            this.tabPagePages.Size = new System.Drawing.Size(814, 240);
            this.tabPagePages.TabIndex = 2;
            this.tabPagePages.Text = "Pages";
            this.tabPagePages.UseVisualStyleBackColor = true;
            // 
            // tabPageEvents
            // 
            this.tabPageEvents.Controls.Add(this.listBoxEvents);
            this.tabPageEvents.Location = new System.Drawing.Point(4, 29);
            this.tabPageEvents.Name = "tabPageEvents";
            this.tabPageEvents.Size = new System.Drawing.Size(814, 240);
            this.tabPageEvents.TabIndex = 3;
            this.tabPageEvents.Text = "Events";
            this.tabPageEvents.UseVisualStyleBackColor = true;
            // 
            // listBoxPages
            // 
            this.listBoxPages.FormattingEnabled = true;
            this.listBoxPages.ItemHeight = 20;
            this.listBoxPages.Location = new System.Drawing.Point(3, 3);
            this.listBoxPages.Name = "listBoxPages";
            this.listBoxPages.Size = new System.Drawing.Size(205, 204);
            this.listBoxPages.TabIndex = 0;
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 20;
            this.listBoxEvents.Location = new System.Drawing.Point(0, 4);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(235, 204);
            this.listBoxEvents.TabIndex = 0;
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 456);
            this.Controls.Add(this.tabControlHomeScreen);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.PictureBoxProfile);
            this.Controls.Add(this.PictureBoxCoverPhoto);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HomeScreen";
            this.Text = "HomeScreen";
            this.Load += new System.EventHandler(this.HomeScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCoverPhoto)).EndInit();
            this.tabControlHomeScreen.ResumeLayout(false);
            this.tabPageAlbums.ResumeLayout(false);
            this.tabPagePages.ResumeLayout(false);
            this.tabPageEvents.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxCoverPhoto;
        private System.Windows.Forms.PictureBox PictureBoxProfile;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.TabControl tabControlHomeScreen;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.TabPage tabPageAlbums;
        private System.Windows.Forms.TabPage tabPagePages;
        private System.Windows.Forms.TabPage tabPageEvents;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.ListBox listBoxPages;
        private System.Windows.Forms.ListBox listBoxEvents;
    }
}