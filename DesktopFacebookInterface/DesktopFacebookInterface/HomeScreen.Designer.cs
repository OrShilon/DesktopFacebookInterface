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
            this.listBoxPages = new System.Windows.Forms.ListBox();
            this.tabPageEvents = new System.Windows.Forms.TabPage();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.tabPageFriends = new System.Windows.Forms.TabPage();
            this.listBoxTimeline = new System.Windows.Forms.ListBox();
            this.textBoxPostStatus = new System.Windows.Forms.TextBox();
            this.labelPostStatus = new System.Windows.Forms.Label();
            this.buttonPostStatus = new System.Windows.Forms.Button();
            this.labelTimeline = new System.Windows.Forms.Label();
            this.listBoxFriends = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCoverPhoto)).BeginInit();
            this.tabControlHomeScreen.SuspendLayout();
            this.tabPageAlbums.SuspendLayout();
            this.tabPagePages.SuspendLayout();
            this.tabPageEvents.SuspendLayout();
            this.tabPageFriends.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(1195, 44);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(160, 44);
            this.buttonLogout.TabIndex = 2;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // PictureBoxProfile
            // 
            this.PictureBoxProfile.Location = new System.Drawing.Point(295, 90);
            this.PictureBoxProfile.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.PictureBoxProfile.Name = "PictureBoxProfile";
            this.PictureBoxProfile.Size = new System.Drawing.Size(200, 142);
            this.PictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxProfile.TabIndex = 1;
            this.PictureBoxProfile.TabStop = false;
            // 
            // PictureBoxCoverPhoto
            // 
            this.PictureBoxCoverPhoto.Location = new System.Drawing.Point(-1, -2);
            this.PictureBoxCoverPhoto.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.PictureBoxCoverPhoto.Name = "PictureBoxCoverPhoto";
            this.PictureBoxCoverPhoto.Size = new System.Drawing.Size(837, 235);
            this.PictureBoxCoverPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxCoverPhoto.TabIndex = 0;
            this.PictureBoxCoverPhoto.TabStop = false;
            // 
            // tabControlHomeScreen
            // 
            this.tabControlHomeScreen.Controls.Add(this.tabPageAbout);
            this.tabControlHomeScreen.Controls.Add(this.tabPageAlbums);
            this.tabControlHomeScreen.Controls.Add(this.tabPageFriends);
            this.tabControlHomeScreen.Controls.Add(this.tabPagePages);
            this.tabControlHomeScreen.Controls.Add(this.tabPageEvents);
            this.tabControlHomeScreen.Location = new System.Drawing.Point(543, 242);
            this.tabControlHomeScreen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControlHomeScreen.Name = "tabControlHomeScreen";
            this.tabControlHomeScreen.SelectedIndex = 0;
            this.tabControlHomeScreen.Size = new System.Drawing.Size(608, 452);
            this.tabControlHomeScreen.TabIndex = 3;
            this.tabControlHomeScreen.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlHomeScreen_Selected);
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Location = new System.Drawing.Point(8, 39);
            this.tabPageAbout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageAbout.Size = new System.Drawing.Size(592, 405);
            this.tabPageAbout.TabIndex = 0;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // tabPageAlbums
            // 
            this.tabPageAlbums.Controls.Add(this.listBoxAlbums);
            this.tabPageAlbums.Location = new System.Drawing.Point(8, 39);
            this.tabPageAlbums.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageAlbums.Name = "tabPageAlbums";
            this.tabPageAlbums.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlbums.Size = new System.Drawing.Size(448, 329);
            this.tabPageAlbums.TabIndex = 1;
            this.tabPageAlbums.Text = "Albums";
            this.tabPageAlbums.UseVisualStyleBackColor = true;
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 20;
            this.listBoxAlbums.Location = new System.Drawing.Point(0, 0);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(260, 224);
            this.listBoxAlbums.TabIndex = 0;
            this.listBoxAlbums.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbums_SelectedIndexChanged);
            // 
            // tabPagePages
            // 
            this.tabPagePages.Controls.Add(this.listBoxPages);
            this.tabPagePages.Location = new System.Drawing.Point(8, 39);
            this.tabPagePages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPagePages.Name = "tabPagePages";
            this.tabPagePages.Size = new System.Drawing.Size(448, 329);
            this.tabPagePages.TabIndex = 2;
            this.tabPagePages.Text = "Pages";
            this.tabPagePages.UseVisualStyleBackColor = true;
            // 
            // listBoxPages
            // 
            this.listBoxPages.FormattingEnabled = true;
            this.listBoxPages.ItemHeight = 20;
            this.listBoxPages.Location = new System.Drawing.Point(0, 0);
            this.listBoxPages.Name = "listBoxPages";
            this.listBoxPages.Size = new System.Drawing.Size(260, 224);
            this.listBoxPages.TabIndex = 0;
            // 
            // tabPageEvents
            // 
            this.tabPageEvents.Controls.Add(this.listBoxEvents);
            this.tabPageEvents.Location = new System.Drawing.Point(8, 39);
            this.tabPageEvents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageEvents.Name = "tabPageEvents";
            this.tabPageEvents.Size = new System.Drawing.Size(448, 329);
            this.tabPageEvents.TabIndex = 3;
            this.tabPageEvents.Text = "Events";
            this.tabPageEvents.UseVisualStyleBackColor = true;
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 20;
            this.listBoxEvents.Location = new System.Drawing.Point(0, 0);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(260, 224);
            this.listBoxEvents.TabIndex = 0;
            // 
            // tabPageFriends
            // 
            this.tabPageFriends.Controls.Add(this.listBoxFriends);
            this.tabPageFriends.Location = new System.Drawing.Point(4, 29);
            this.tabPageFriends.Name = "tabPageFriends";
            this.tabPageFriends.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFriends.Size = new System.Drawing.Size(448, 329);
            this.tabPageFriends.TabIndex = 4;
            this.tabPageFriends.Text = "Friends";
            this.tabPageFriends.UseVisualStyleBackColor = true;
            // 
            // listBoxTimeline
            // 
            this.listBoxTimeline.FormattingEnabled = true;
            this.listBoxTimeline.ItemHeight = 25;
            this.listBoxTimeline.Location = new System.Drawing.Point(16, 440);
            this.listBoxTimeline.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxTimeline.Name = "listBoxTimeline";
            this.listBoxTimeline.Size = new System.Drawing.Size(405, 254);
            this.listBoxTimeline.TabIndex = 4;
            // 
            // textBoxPostStatus
            // 
            this.textBoxPostStatus.Location = new System.Drawing.Point(16, 299);
            this.textBoxPostStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPostStatus.Name = "textBoxPostStatus";
            this.textBoxPostStatus.Size = new System.Drawing.Size(383, 31);
            this.textBoxPostStatus.TabIndex = 5;
            this.textBoxPostStatus.Text = "Post something!";
            // 
            // labelPostStatus
            // 
            this.labelPostStatus.AutoSize = true;
            this.labelPostStatus.Location = new System.Drawing.Point(16, 252);
            this.labelPostStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPostStatus.Name = "labelPostStatus";
            this.labelPostStatus.Size = new System.Drawing.Size(125, 25);
            this.labelPostStatus.TabIndex = 6;
            this.labelPostStatus.Text = "Post status:";
            // 
            // buttonPostStatus
            // 
            this.buttonPostStatus.Location = new System.Drawing.Point(420, 299);
            this.buttonPostStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPostStatus.Name = "buttonPostStatus";
            this.buttonPostStatus.Size = new System.Drawing.Size(115, 32);
            this.buttonPostStatus.TabIndex = 7;
            this.buttonPostStatus.Text = "Post";
            this.buttonPostStatus.UseVisualStyleBackColor = true;
            // 
            // labelTimeline
            // 
            this.labelTimeline.AutoSize = true;
            this.labelTimeline.Location = new System.Drawing.Point(21, 386);
            this.labelTimeline.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimeline.Name = "labelTimeline";
            this.labelTimeline.Size = new System.Drawing.Size(99, 25);
            this.labelTimeline.TabIndex = 8;
            this.labelTimeline.Text = "Timeline:";
            // 
            // listBoxFriends
            // 
            this.listBoxFriends.FormattingEnabled = true;
            this.listBoxFriends.ItemHeight = 20;
            this.listBoxFriends.Location = new System.Drawing.Point(0, 0);
            this.listBoxFriends.Name = "listBoxFriends";
            this.listBoxFriends.Size = new System.Drawing.Size(260, 224);
            this.listBoxFriends.TabIndex = 0;
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 698);
            this.Controls.Add(this.labelTimeline);
            this.Controls.Add(this.buttonPostStatus);
            this.Controls.Add(this.labelPostStatus);
            this.Controls.Add(this.textBoxPostStatus);
            this.Controls.Add(this.listBoxTimeline);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.PictureBoxProfile);
            this.Controls.Add(this.PictureBoxCoverPhoto);
            this.Controls.Add(this.tabControlHomeScreen);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(545, 330);
            this.Name = "HomeScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeScreen";
            this.Load += new System.EventHandler(this.HomeScreen_Load);
            this.Resize += new System.EventHandler(this.HomeScreen_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCoverPhoto)).EndInit();
            this.tabControlHomeScreen.ResumeLayout(false);
            this.tabPageAlbums.ResumeLayout(false);
            this.tabPagePages.ResumeLayout(false);
            this.tabPageEvents.ResumeLayout(false);
            this.tabPageFriends.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ListBox listBoxTimeline;
        private System.Windows.Forms.TextBox textBoxPostStatus;
        private System.Windows.Forms.Label labelPostStatus;
        private System.Windows.Forms.Button buttonPostStatus;
        private System.Windows.Forms.Label labelTimeline;
        private System.Windows.Forms.TabPage tabPageFriends;
        private System.Windows.Forms.ListBox listBoxFriends;
    }
}