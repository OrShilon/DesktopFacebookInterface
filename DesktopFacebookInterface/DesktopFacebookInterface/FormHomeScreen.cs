using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
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
        private Size tabPageSize;

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
            tabPageSize = tabControlHomeScreen.TabPages[0].Size;
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
            fetchUserInfo();

        }

        private void fetchUserInfo()
        {
            new Thread(displayAbout).Start();
            new Thread(displayAlbums).Start();
            new Thread(displayFriends).Start();
            new Thread(displayPages).Start();
            new Thread(displayEvents).Start();
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

        private void displayAbout()
        {
            List<string> listAbout = m_UserInfo.fetchAbout();
            StringBuilder generateAbout = new StringBuilder();

            foreach (string info in listAbout)
            {
                if(info.Equals(listAbout[listAbout.Count - 1]))
                {
                    generateAbout.Append(string.Format("{0}", info));
                }
                else
                {
                    generateAbout.Append(string.Format("{0}{1}{1}", info, Environment.NewLine));
                }
            }

            labelAbout.Invoke(new Action(() => labelAbout.Text = generateAbout.ToString()));
            labelAbout.Invoke(new Action(() =>
            { 
                if(labelAbout.Height > tabControlHomeScreen.TabPages[0].Height)
                {
                    tabControlHomeScreen.TabPages[0].AutoScroll = true;
                }
            }));
        }

        private void displayAlbums()
        {
            listBoxAlbums.Items.Clear();
            listBoxAlbums.Size = tabPageSize;
            listBoxAlbums.DisplayMember = "Name";

            try
            {
                foreach (Album album in m_UserInfo.User.Albums)
                {
                    listBoxAlbums.Invoke(new Action(() => listBoxAlbums.Items.Add(album)));
                }

                if (m_UserInfo.User.Albums.Count == 0)
                {
                    listBoxAlbums.Invoke(new Action(() => listBoxAlbums.Items.Add("No Albums found")));
                    listBoxAlbums.MouseDoubleClick -= new MouseEventHandler(listBoxAlbums_MouseDoubleClick);

                }
            }
            catch (FacebookOAuthException)
            {
                listBoxAlbums.Invoke(new Action(() => listBoxAlbums.Items.Add("Unable to load: No Permissions to view Albums.")));
                //MessageBox.Show(string.Format("Unable to load: No Permissions to view {0}."));
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
                    FormDisplayPhotos albumPhotos = new FormDisplayPhotos(selectedAlbum);
                    albumPhotos.ShowDialog();
                }
            }
        }

        private void displayPages()
        {
            listBoxPages.Items.Clear();
            listBoxPages.Size = tabPageSize;
            listBoxPages.DisplayMember = "Name";

            try
            {
                foreach (Page page in m_UserInfo.User.LikedPages)
                {
                    listBoxPages.Invoke(new Action(() => listBoxPages.Items.Add(page)));
                }

                if (m_UserInfo.User.LikedPages.Count == 0)
                {
                    listBoxPages.Invoke(new Action(() => listBoxPages.Items.Add("No pages found")));
                    //MessageBox.Show("No pages found");
                }
            }
            catch (FacebookOAuthException)
            {
                listBoxPages.Invoke(new Action(() => listBoxPages.Items.Add("Unable to load: No Permissions to view Pages.")));
                //MessageBox.Show(string.Format("Unable to load: No Permissions to view {0}."));
            }
        }

        private void displayEvents()
        {
            listBoxEvents.Items.Clear();
            listBoxEvents.Size = tabPageSize;
            listBoxEvents.DisplayMember = "Name";

            try
            {
                foreach (Event userEvent in m_UserInfo.User.Events)
                {
                    listBoxEvents.Invoke(new Action(() => listBoxEvents.Items.Add(userEvent)));
                }

                if (m_UserInfo.User.Events.Count == 0)
                {
                    listBoxEvents.Invoke(new Action(() => listBoxEvents.Items.Add("No events found")));
                    //MessageBox.Show("No events found");
                }
            }
            catch (FacebookOAuthException)
            {
                listBoxEvents.Invoke(new Action(() => listBoxEvents.Items.Add("Unable to load: No Permissions to view Events.")));
                //MessageBox.Show(string.Format("Unable to load: No Permissions to view {0}."));
            }
        }

        private void displayFriends()
        {
            listBoxFriends.Items.Clear();
            listBoxFriends.Size = tabPageSize;
            listBoxFriends.DisplayMember = "Name";


            try
            {
                foreach (User friend in m_UserInfo.User.Friends)
                {
                    listBoxFriends.Invoke(new Action(() => listBoxFriends.Items.Add(friend.Name)));
                }

                if (m_UserInfo.User.Friends.Count == 0)
                {
                    listBoxFriends.Invoke(new Action(() => listBoxFriends.Items.Add("No friends found")));
                    //MessageBox.Show("No friends found");
                }
            }
            catch (FacebookOAuthException)
            {
                listBoxFriends.Invoke(new Action(() => listBoxFriends.Items.Add("Unable to load: No Permissions to view Friends.")));
                //MessageBox.Show(string.Format("Unable to load: No Permissions to view {0}."));
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
