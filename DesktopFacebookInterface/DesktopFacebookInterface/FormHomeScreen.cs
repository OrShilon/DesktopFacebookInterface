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
        private AppSettings m_AppSettings;
        private FacebookUserFacade m_UserInfo;
        private FormContest m_FormContest;
        private string m_AttachedImagePath = null;
        private bool m_IsFirstContestClick = true;
        private Size tabPageSize;

        public FormHomeScreen()
        {
            m_AppSettings = AppSettings.LoadFile();
            m_UserInfo = FacebookUserFacade.GetFacebookUserInstance;

            InitializeComponent();
            this.Text = string.Format("Facebook - {0}", m_UserInfo.Name);
            textBoxPostStatus.Text = k_TextBoxPostStatusMsg;
            PictureBoxProfile.LoadAsync(m_UserInfo.PictureNormalURL);
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
            displayUserInfo();

        }

        private void displayUserInfo()
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
            AppSettings.SaveFile();
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
            FacebookObjectCollection<Album> albumList = null;

            try
            {
                albumList = m_UserInfo.FetchAlbums();
                foreach (Album album in albumList)
                {
                    listBoxAlbums.Invoke(new Action(() => listBoxAlbums.Items.Add(album)));
                }

                if (albumList.Count == 0)
                {
                    listBoxAlbums.Invoke(new Action(() => listBoxAlbums.Items.Add("No Albums found")));
                    listBoxAlbums.MouseDoubleClick -= new MouseEventHandler(listBoxAlbums_MouseDoubleClick);

                }
            }
            catch (FacebookOAuthException)
            {
                listBoxAlbums.Invoke(new Action(() => listBoxAlbums.Items.Add("Unable to load: No Permissions to view Albums.")));
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
            FacebookObjectCollection<Page> likedPages = null;

            try
            {
                likedPages = m_UserInfo.FetchLikedPages();
                foreach (Page page in likedPages)
                {
                    listBoxPages.Invoke(new Action(() => listBoxPages.Items.Add(page)));
                }

                if (likedPages.Count == 0)
                {
                    listBoxPages.Invoke(new Action(() => listBoxPages.Items.Add("No pages found")));
                }
            }
            catch (FacebookOAuthException)
            {
                listBoxPages.Invoke(new Action(() => listBoxPages.Items.Add("Unable to load: No Permissions to view Pages.")));
            }
        }

        private void displayEvents()
        {
            listBoxEvents.Items.Clear();
            listBoxEvents.Size = tabPageSize;
            listBoxEvents.DisplayMember = "Name";
            FacebookObjectCollection<Event> events = null;

            try
            {
                events = m_UserInfo.FetchEvents();
                foreach (Event userEvent in events)
                {
                    listBoxEvents.Invoke(new Action(() => listBoxEvents.Items.Add(userEvent)));
                }

                if (events.Count == 0)
                {
                    listBoxEvents.Invoke(new Action(() => listBoxEvents.Items.Add("No events found")));
                }
            }
            catch (FacebookOAuthException)
            {
                listBoxEvents.Invoke(new Action(() => listBoxEvents.Items.Add("Unable to load: No Permissions to view Events.")));
            }
        }

        private void displayFriends()
        {
            listBoxFriends.Items.Clear();
            listBoxFriends.Size = tabPageSize;
            listBoxFriends.DisplayMember = "Name";
            FacebookObjectCollection<User> friends = null;


            try
            {
                friends = m_UserInfo.FetchFriends();
                foreach (User friend in friends)
                {
                    listBoxFriends.Invoke(new Action(() => listBoxFriends.Items.Add(friend.Name)));
                }

                if (friends.Count == 0)
                {
                    listBoxFriends.Invoke(new Action(() => listBoxFriends.Items.Add("No friends found")));
                }
            }
            catch (FacebookOAuthException)
            {
                listBoxFriends.Invoke(new Action(() => listBoxFriends.Items.Add("Unable to load: No Permissions to view Friends.")));
            }
        }

        private void SaveAppSettings()
        {
            m_AppSettings.m_WindowLocation = this.Location;
            m_AppSettings.m_WindowSize = this.Size;

            AppSettings.SaveFile();
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
                m_FormContest = new FormContest();
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
            FormMemoriesFetch newForm = new FormMemoriesFetch();
            newForm.ShowDialog();
        }
    }
}
