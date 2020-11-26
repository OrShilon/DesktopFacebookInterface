using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    internal partial class FormHomeScreen : Form
    {
        private const string k_TextBoxPostStatusMsg = "Post something!";
        private const string k_AttachedFileTypeFilter = "Image Files *.BMP*;*.JPG*;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
        private LoginResult m_LoginResult;
        private AppSettings m_AppSettings;
        private UserInformationWrapper m_UserInfo;
        private FormContest m_FormContest;
        private string m_AttachedImagePath = null;
        private bool m_IsFirstContestClick = true;

        public FormHomeScreen(LoginResult i_LoginResult, AppSettings i_AppSettings)
        {
            m_LoginResult = i_LoginResult;
            m_AppSettings = i_AppSettings;
            m_UserInfo = new UserInformationWrapper(i_LoginResult.LoggedInUser);

            InitializeComponent();
            this.Text = string.Format("Facebook - {0}", m_UserInfo.User.Name);
            textBoxPostStatus.Text = k_TextBoxPostStatusMsg;
            PictureBoxProfile.LoadAsync(m_UserInfo.User.PictureNormalURL);
            PictureBoxCoverPhoto.LoadAsync(m_UserInfo.fetchCoverPhotoURL());
            displayAbout();
            displayTimeline();
        }

        protected override void OnShown(EventArgs e)
        {
            if (!m_AppSettings.m_WindowSize.IsEmpty)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Size = m_AppSettings.m_WindowSize;
                this.Location = m_AppSettings.m_WindowLocation;
            }

            base.OnShown(e);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.Logout(new Action(loggedOutFinished));
        }

        private void loggedOutFinished()
        {
            m_AppSettings.m_UserAccessToken = null;
            m_AppSettings.m_RememberUser = false;
            m_AppSettings.SaveFile();
            MessageBox.Show("You are now logged out!");
            this.Hide();
            this.Close();
        }

        private void displayTimeline()
        {
            List<string> listTimeLine = m_UserInfo.fetchTimeline();

            listBoxTimeline.Items.Clear();
            listBoxTimeline.DisplayMember = "Name";

            foreach (string post in listTimeLine)
            {
                listBoxTimeline.Items.Add(post);
            }
        }

        private void tabControlHomeScreen_Selected(object sender, TabControlEventArgs e)
        {
            eTabOptions tabClicked = (eTabOptions)tabControlHomeScreen.SelectedIndex;

            try
            {
                switch (tabClicked)
                {
                    case eTabOptions.About:
                        displayAbout();
                        break;
                    case eTabOptions.Albums:
                        displayAlbums();
                        break;
                    case eTabOptions.Pages:
                        displayPages();
                        break;
                    case eTabOptions.Events:
                        displayEvents();
                        break;
                    case eTabOptions.Friends:
                        displayFriends();
                        break;
                    default:
                        break;
                }
            }
            catch (FacebookOAuthException)
            {
                MessageBox.Show(string.Format("Unable to load: No Permissions to view {0}.", tabClicked));
            }
        }

        private void displayAbout()
        {
            List<string> listAbout = m_UserInfo.fetchAbout();

            TabPage selectedTab = tabControlHomeScreen.SelectedTab;
            Label prevLabel = new Label();

            foreach (string info in listAbout)
            {
                Label labelInfo = new Label();

                if (listAbout[0].Equals(info))
                {
                    labelInfo.Text = info;
                    labelInfo.Width += 100;
                    selectedTab.Controls.Add(labelInfo);
                }
                else
                {
                    labelInfo.Text = info;
                    labelInfo.Width += 100;
                    labelInfo.Location = new Point(prevLabel.Location.X, prevLabel.Location.Y + 25);
                    selectedTab.Controls.Add(labelInfo);
                }

                prevLabel = labelInfo;
            }
        }

        private void displayAlbums()
        {
            listBoxAlbums.Items.Clear();
            listBoxAlbums.Size = tabControlHomeScreen.SelectedTab.Size;
            listBoxAlbums.DisplayMember = "Name";

            foreach (Album album in m_UserInfo.User.Albums)
            {
                listBoxAlbums.Items.Add(album);
            }

            if (m_UserInfo.User.Albums.Count == 0)
            {
                MessageBox.Show("No Albums found");
            }
        }

        private void listBoxAlbums_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            displaySelectedAlbum();
        }

        private void displaySelectedAlbum()
        {
            if (listBoxAlbums.SelectedItems.Count == 1)
            {
                Album selectedAlbum = listBoxAlbums.SelectedItem as Album;

                if (selectedAlbum.Photos.Count < 1)
                {
                    MessageBox.Show("This album is empty");
                }
                else
                {
                    FormShowAlbum album = new FormShowAlbum(selectedAlbum);
                    album.ShowDialog();
                }
            }
        }

        private void displayPages()
        {
            listBoxPages.Items.Clear();
            listBoxPages.Size = tabControlHomeScreen.SelectedTab.Size;
            listBoxPages.DisplayMember = "Name";

            foreach (Page page in m_UserInfo.User.LikedPages)
            {
                listBoxPages.Items.Add(page);
            }

            if (m_UserInfo.User.LikedPages.Count == 0)
            {
                MessageBox.Show("No pages found");
            }
        }

        private void displayEvents()
        {
            listBoxEvents.Items.Clear();
            listBoxEvents.Size = tabControlHomeScreen.SelectedTab.Size;
            listBoxEvents.DisplayMember = "Name";

            foreach (Event userEvent in m_UserInfo.User.Events)
            {
                listBoxEvents.Items.Add(userEvent);
            }

            if (m_UserInfo.User.Events.Count == 0)
            {
                MessageBox.Show("No events found");
            }
        }

        private void displayFriends()
        {
            listBoxFriends.Items.Clear();
            listBoxFriends.Size = tabControlHomeScreen.SelectedTab.Size;
            listBoxFriends.DisplayMember = "Name";

            foreach (User friend in m_UserInfo.User.Friends)
            {
                listBoxFriends.Items.Add(friend.Name);
            }

            if (m_UserInfo.User.Friends.Count == 0)
            {
                MessageBox.Show("No friends found");
            }
        }

        private void SaveAppSettings()
        {
            m_AppSettings.m_WindowLocation = this.Location;
            m_AppSettings.m_WindowSize = this.Size;

            if (m_AppSettings.m_RememberUser)
            {
                m_AppSettings.m_UserAccessToken = m_LoginResult.AccessToken;
            }
            else
            {
                m_AppSettings.m_UserAccessToken = null;
            }

            m_AppSettings.SaveFile();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            SaveAppSettings();
            base.OnFormClosed(e);
        }

        private void buttonPostStatus_Click(object sender, EventArgs e)
        {
            try
            {
                GeoPostedItem postedItem = m_UserInfo.PostStatus(m_AttachedImagePath, textBoxPostStatus.Text);
                MessageBox.Show(string.Format("Post published successfully!{1} Post ID: {0}", postedItem.Id, Environment.NewLine));
            }
            catch (FacebookOAuthException)
            {
                MessageBox.Show("Status post failed: No permissions.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAttachImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = k_AttachedFileTypeFilter;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                m_AttachedImagePath = ofd.FileName;
                buttonCancelAttachment.Visible = true;
            }
        }

        private void buttonCancelAttachment_Click(object sender, EventArgs e)
        {
            m_AttachedImagePath = null;
            buttonCancelAttachment.Visible = false;
        }

        private void buttonContestMenu_Click(object sender, EventArgs e)
        {
            if (m_IsFirstContestClick)
            {
                m_FormContest = new FormContest(m_UserInfo);
                m_FormContest.ShowDialog();
                m_IsFirstContestClick = false;
            }
            else
            {
                m_FormContest.ShowDialog();
            }
        }

        private void textBoxPostStatus_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBoxPostStatus.Text == k_TextBoxPostStatusMsg)
            {
                textBoxPostStatus.Text = string.Empty;
            }
        }

        private void textBoxPostStatus_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPostStatus.Text))
            {
                textBoxPostStatus.Text = k_TextBoxPostStatusMsg;
            }
        }

        private void buttonMemories_Click(object sender, EventArgs e)
        {
            FormMemoriesFetch newForm = new FormMemoriesFetch(m_UserInfo);
            newForm.ShowDialog();
        }
    }
}
