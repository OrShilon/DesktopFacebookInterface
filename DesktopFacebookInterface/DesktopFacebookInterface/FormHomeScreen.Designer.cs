namespace DesktopFacebookInterface
{
    internal partial class FormHomeScreen
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
            this.tabPageFriends = new System.Windows.Forms.TabPage();
            this.listBoxFriends = new System.Windows.Forms.ListBox();
            this.tabPagePages = new System.Windows.Forms.TabPage();
            this.listBoxPages = new System.Windows.Forms.ListBox();
            this.tabPageEvents = new System.Windows.Forms.TabPage();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.listBoxTimeline = new System.Windows.Forms.ListBox();
            this.textBoxPostStatus = new System.Windows.Forms.TextBox();
            this.labelPostStatus = new System.Windows.Forms.Label();
            this.buttonPostStatus = new System.Windows.Forms.Button();
            this.labelTimeline = new System.Windows.Forms.Label();
            this.buttonAttachImage = new System.Windows.Forms.Button();
            this.buttonCancelAttachment = new System.Windows.Forms.Button();
            this.buttonContestMenu = new System.Windows.Forms.Button();
            this.buttonMemories = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCoverPhoto)).BeginInit();
            this.tabControlHomeScreen.SuspendLayout();
            this.tabPageAlbums.SuspendLayout();
            this.tabPageFriends.SuspendLayout();
            this.tabPagePages.SuspendLayout();
            this.tabPageEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLogout.Location = new System.Drawing.Point(1037, 279);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(160, 94);
            this.buttonLogout.TabIndex = 6;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // PictureBoxProfile
            // 
            this.PictureBoxProfile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PictureBoxProfile.Location = new System.Drawing.Point(528, 89);
            this.PictureBoxProfile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.PictureBoxProfile.Name = "PictureBoxProfile";
            this.PictureBoxProfile.Size = new System.Drawing.Size(160, 154);
            this.PictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxProfile.TabIndex = 1;
            this.PictureBoxProfile.TabStop = false;
            // 
            // PictureBoxCoverPhoto
            // 
            this.PictureBoxCoverPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PictureBoxCoverPhoto.Location = new System.Drawing.Point(20, 10);
            this.PictureBoxCoverPhoto.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.PictureBoxCoverPhoto.Name = "PictureBoxCoverPhoto";
            this.PictureBoxCoverPhoto.Size = new System.Drawing.Size(1176, 235);
            this.PictureBoxCoverPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxCoverPhoto.TabIndex = 0;
            this.PictureBoxCoverPhoto.TabStop = false;
            // 
            // tabControlHomeScreen
            // 
            this.tabControlHomeScreen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControlHomeScreen.Controls.Add(this.tabPageAbout);
            this.tabControlHomeScreen.Controls.Add(this.tabPageAlbums);
            this.tabControlHomeScreen.Controls.Add(this.tabPageFriends);
            this.tabControlHomeScreen.Controls.Add(this.tabPagePages);
            this.tabControlHomeScreen.Controls.Add(this.tabPageEvents);
            this.tabControlHomeScreen.Location = new System.Drawing.Point(611, 418);
            this.tabControlHomeScreen.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlHomeScreen.Name = "tabControlHomeScreen";
            this.tabControlHomeScreen.SelectedIndex = 0;
            this.tabControlHomeScreen.Size = new System.Drawing.Size(588, 289);
            this.tabControlHomeScreen.TabIndex = 5;
            this.tabControlHomeScreen.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlHomeScreen_Selected);
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Location = new System.Drawing.Point(8, 39);
            this.tabPageAbout.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageAbout.Size = new System.Drawing.Size(572, 242);
            this.tabPageAbout.TabIndex = 0;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // tabPageAlbums
            // 
            this.tabPageAlbums.Controls.Add(this.listBoxAlbums);
            this.tabPageAlbums.Location = new System.Drawing.Point(8, 39);
            this.tabPageAlbums.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageAlbums.Name = "tabPageAlbums";
            this.tabPageAlbums.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabPageAlbums.Size = new System.Drawing.Size(572, 242);
            this.tabPageAlbums.TabIndex = 1;
            this.tabPageAlbums.Text = "Albums";
            this.tabPageAlbums.UseVisualStyleBackColor = true;
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 25;
            this.listBoxAlbums.Location = new System.Drawing.Point(-5, 0);
            this.listBoxAlbums.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(401, 104);
            this.listBoxAlbums.TabIndex = 0;
            this.listBoxAlbums.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxAlbums_MouseDoubleClick);
            // 
            // tabPageFriends
            // 
            this.tabPageFriends.Controls.Add(this.listBoxFriends);
            this.tabPageFriends.Location = new System.Drawing.Point(8, 39);
            this.tabPageFriends.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabPageFriends.Name = "tabPageFriends";
            this.tabPageFriends.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabPageFriends.Size = new System.Drawing.Size(572, 242);
            this.tabPageFriends.TabIndex = 4;
            this.tabPageFriends.Text = "Friends";
            this.tabPageFriends.UseVisualStyleBackColor = true;
            // 
            // listBoxFriends
            // 
            this.listBoxFriends.FormattingEnabled = true;
            this.listBoxFriends.ItemHeight = 25;
            this.listBoxFriends.Location = new System.Drawing.Point(0, 0);
            this.listBoxFriends.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.listBoxFriends.Name = "listBoxFriends";
            this.listBoxFriends.Size = new System.Drawing.Size(260, 204);
            this.listBoxFriends.TabIndex = 0;
            // 
            // tabPagePages
            // 
            this.tabPagePages.Controls.Add(this.listBoxPages);
            this.tabPagePages.Location = new System.Drawing.Point(8, 39);
            this.tabPagePages.Margin = new System.Windows.Forms.Padding(4);
            this.tabPagePages.Name = "tabPagePages";
            this.tabPagePages.Size = new System.Drawing.Size(572, 242);
            this.tabPagePages.TabIndex = 2;
            this.tabPagePages.Text = "Pages";
            this.tabPagePages.UseVisualStyleBackColor = true;
            // 
            // listBoxPages
            // 
            this.listBoxPages.FormattingEnabled = true;
            this.listBoxPages.ItemHeight = 25;
            this.listBoxPages.Location = new System.Drawing.Point(0, 0);
            this.listBoxPages.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.listBoxPages.Name = "listBoxPages";
            this.listBoxPages.Size = new System.Drawing.Size(260, 204);
            this.listBoxPages.TabIndex = 0;
            // 
            // tabPageEvents
            // 
            this.tabPageEvents.Controls.Add(this.listBoxEvents);
            this.tabPageEvents.Location = new System.Drawing.Point(8, 39);
            this.tabPageEvents.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageEvents.Name = "tabPageEvents";
            this.tabPageEvents.Size = new System.Drawing.Size(572, 242);
            this.tabPageEvents.TabIndex = 3;
            this.tabPageEvents.Text = "Events";
            this.tabPageEvents.UseVisualStyleBackColor = true;
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 25;
            this.listBoxEvents.Location = new System.Drawing.Point(0, 0);
            this.listBoxEvents.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(260, 204);
            this.listBoxEvents.TabIndex = 0;
            // 
            // listBoxTimeline
            // 
            this.listBoxTimeline.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxTimeline.FormattingEnabled = true;
            this.listBoxTimeline.ItemHeight = 25;
            this.listBoxTimeline.Location = new System.Drawing.Point(20, 453);
            this.listBoxTimeline.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxTimeline.Name = "listBoxTimeline";
            this.listBoxTimeline.Size = new System.Drawing.Size(508, 254);
            this.listBoxTimeline.TabIndex = 4;
            // 
            // textBoxPostStatus
            // 
            this.textBoxPostStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPostStatus.Location = new System.Drawing.Point(20, 286);
            this.textBoxPostStatus.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPostStatus.Name = "textBoxPostStatus";
            this.textBoxPostStatus.Size = new System.Drawing.Size(384, 31);
            this.textBoxPostStatus.TabIndex = 2;
            this.textBoxPostStatus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxPostStatus_MouseClick);
            this.textBoxPostStatus.Leave += new System.EventHandler(this.textBoxPostStatus_Leave);
            // 
            // labelPostStatus
            // 
            this.labelPostStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPostStatus.AutoSize = true;
            this.labelPostStatus.Location = new System.Drawing.Point(20, 253);
            this.labelPostStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPostStatus.Name = "labelPostStatus";
            this.labelPostStatus.Size = new System.Drawing.Size(125, 25);
            this.labelPostStatus.TabIndex = 0;
            this.labelPostStatus.Text = "Post status:";
            // 
            // buttonPostStatus
            // 
            this.buttonPostStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPostStatus.Location = new System.Drawing.Point(419, 279);
            this.buttonPostStatus.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPostStatus.Name = "buttonPostStatus";
            this.buttonPostStatus.Size = new System.Drawing.Size(116, 44);
            this.buttonPostStatus.TabIndex = 3;
            this.buttonPostStatus.Text = "Post";
            this.buttonPostStatus.UseVisualStyleBackColor = true;
            this.buttonPostStatus.Click += new System.EventHandler(this.buttonPostStatus_Click);
            // 
            // labelTimeline
            // 
            this.labelTimeline.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTimeline.AutoSize = true;
            this.labelTimeline.Location = new System.Drawing.Point(20, 419);
            this.labelTimeline.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimeline.Name = "labelTimeline";
            this.labelTimeline.Size = new System.Drawing.Size(99, 25);
            this.labelTimeline.TabIndex = 8;
            this.labelTimeline.Text = "Timeline:";
            // 
            // buttonAttachImage
            // 
            this.buttonAttachImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAttachImage.Location = new System.Drawing.Point(20, 331);
            this.buttonAttachImage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAttachImage.Name = "buttonAttachImage";
            this.buttonAttachImage.Size = new System.Drawing.Size(184, 50);
            this.buttonAttachImage.TabIndex = 1;
            this.buttonAttachImage.Text = "Attach Image";
            this.buttonAttachImage.UseVisualStyleBackColor = true;
            this.buttonAttachImage.Click += new System.EventHandler(this.buttonAttachImage_Click);
            // 
            // buttonCancelAttachment
            // 
            this.buttonCancelAttachment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCancelAttachment.Location = new System.Drawing.Point(213, 331);
            this.buttonCancelAttachment.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancelAttachment.Name = "buttonCancelAttachment";
            this.buttonCancelAttachment.Size = new System.Drawing.Size(40, 50);
            this.buttonCancelAttachment.TabIndex = 10;
            this.buttonCancelAttachment.Text = "X";
            this.buttonCancelAttachment.UseVisualStyleBackColor = true;
            this.buttonCancelAttachment.Visible = false;
            this.buttonCancelAttachment.Click += new System.EventHandler(this.buttonCancelAttachment_Click);
            // 
            // buttonContestMenu
            // 
            this.buttonContestMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonContestMenu.Location = new System.Drawing.Point(611, 279);
            this.buttonContestMenu.Margin = new System.Windows.Forms.Padding(4);
            this.buttonContestMenu.Name = "buttonContestMenu";
            this.buttonContestMenu.Size = new System.Drawing.Size(160, 94);
            this.buttonContestMenu.TabIndex = 4;
            this.buttonContestMenu.Text = "Contest Menu";
            this.buttonContestMenu.UseVisualStyleBackColor = true;
            this.buttonContestMenu.Click += new System.EventHandler(this.buttonContestMenu_Click);
            // 
            // buttonMemories
            // 
            this.buttonMemories.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonMemories.Location = new System.Drawing.Point(824, 279);
            this.buttonMemories.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMemories.Name = "buttonMemories";
            this.buttonMemories.Size = new System.Drawing.Size(160, 94);
            this.buttonMemories.TabIndex = 11;
            this.buttonMemories.Text = "Memories";
            this.buttonMemories.UseVisualStyleBackColor = true;
            this.buttonMemories.Click += new System.EventHandler(this.buttonMemories_Click);
            // 
            // FormHomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 748);
            this.Controls.Add(this.buttonMemories);
            this.Controls.Add(this.buttonContestMenu);
            this.Controls.Add(this.buttonCancelAttachment);
            this.Controls.Add(this.buttonAttachImage);
            this.Controls.Add(this.labelTimeline);
            this.Controls.Add(this.buttonPostStatus);
            this.Controls.Add(this.labelPostStatus);
            this.Controls.Add(this.textBoxPostStatus);
            this.Controls.Add(this.listBoxTimeline);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.PictureBoxProfile);
            this.Controls.Add(this.PictureBoxCoverPhoto);
            this.Controls.Add(this.tabControlHomeScreen);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MinimumSize = new System.Drawing.Size(1202, 683);
            this.Name = "FormHomeScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeScreen";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCoverPhoto)).EndInit();
            this.tabControlHomeScreen.ResumeLayout(false);
            this.tabPageAlbums.ResumeLayout(false);
            this.tabPageFriends.ResumeLayout(false);
            this.tabPagePages.ResumeLayout(false);
            this.tabPageEvents.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonAttachImage;
        private System.Windows.Forms.Button buttonCancelAttachment;
        private System.Windows.Forms.Button buttonContestMenu;
        private System.Windows.Forms.Button buttonMemories;
    }
}