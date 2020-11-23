using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopFacebookInterface
{
    public partial class HomeScreen : Form
    {
        LoginResult m_LoginResult;
        AppSettings m_AppSettings;
        User m_LoginUser;
        UserInformationWrapper m_UserInfo;
        string m_PostAttachedFilePath = null;

        public HomeScreen(LoginResult i_LoginResult, User i_LoginUser, AppSettings i_AppSettings)
        {
            m_LoginResult = i_LoginResult;
            m_LoginUser = i_LoginUser;
            m_AppSettings = i_AppSettings;
            m_UserInfo = new UserInformationWrapper(m_LoginUser);
            InitializeComponent();
            this.Text = string.Format("Facebook - {0}", m_UserInfo.m_FullName);
            PictureBoxProfile.LoadAsync(m_UserInfo.m_ProfileImage);
            PictureBoxCoverPhoto.LoadAsync(m_UserInfo.m_CoverImage);
            fetchAbout();
            fetchTimeline();
            this.ShowDialog();
        }

        protected override void OnShown(EventArgs e)
        {
            if (!m_AppSettings.WindowSize.IsEmpty)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Size = m_AppSettings.WindowSize;
                this.Location = m_AppSettings.WindowLocation;
            }
            base.OnShown(e);
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.Logout(new Action(loggedOutFinished));
        }

        private void loggedOutFinished()
        {
            m_LoginUser = null;
            m_AppSettings.UserAccessToken = null;
            m_AppSettings.RememberUser = false;
            m_AppSettings.SaveFile();
            MessageBox.Show("You are now logged out!");
            this.Hide();
            this.Close();
        }

        private void fetchTimeline()
        {
            listBoxTimeline.Items.Clear();
            listBoxTimeline.DisplayMember = "Name";

            foreach (Post post in m_LoginUser.Posts)
            {
                if (post.Message != null)
                {
                    listBoxTimeline.Items.Add(post.Message);
                }
                else if (post.Caption != null)
                {
                    listBoxTimeline.Items.Add(post.Caption);
                }
                else
                {
                    listBoxTimeline.Items.Add(string.Format("[{0}]", post.Type));
                }
            }

            if (m_LoginUser.Posts.Count == 0)
            {
                listBoxTimeline.Items.Add("Your timeline has 0 posts!");
            }
        }

        private void tabControlHomeScreen_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                switch ((eTabOptions)tabControlHomeScreen.SelectedIndex)
                {
                    case eTabOptions.About:
                        fetchAbout();
                        break;
                    case eTabOptions.Albums:
                        fetchAlbums();
                        break;
                    case eTabOptions.Pages:
                        fetchPages();
                        break;
                    case eTabOptions.Events:
                        fetchEvents();
                        break;
                    case eTabOptions.Friends:
                        fetchFriends();
                        break;
                    default:
                        break;
                }
            }
            catch(FacebookOAuthException fe)
            {
                MessageBox.Show("No Permissions!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unknown Error.");
            }
        }

        private void fetchAbout()
        {
            TabPage selectedTab = tabControlHomeScreen.SelectedTab;
            Label prevLabel = new Label();

            foreach(string info in m_UserInfo.BasicInfo)
            {
                Label labelInfo = new Label();

                if(m_UserInfo.BasicInfo[0].Equals(info))
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






            //Label labelName = new Label();
            //labelName.Text = "Name: " + m_UserInfo.m_FullName;
            //labelName.Width += 100;
            //selectedTab.Controls.Add(labelName);
            //Label labelBirthday = new Label();
            //labelBirthday.Text = "Birthday: " + m_UserInfo.m_Birthday;
            //labelBirthday.Location = new Point(labelName.Location.X, labelName.Location.Y + 25);
            //labelBirthday.Width += 100;
            //selectedTab.Controls.Add(labelBirthday);
            //Label labelGender = new Label();
            //labelGender.Text = "Gender: " + m_UserInfo.m_Gender;
            //labelGender.Location = new Point(labelBirthday.Location.X, labelBirthday.Location.Y + 25);
            //labelGender.Width += 100;
            //selectedTab.Controls.Add(labelGender);
            //Label labelEmail = new Label();
            //labelEmail.Text = "Email: " + m_UserInfo.m_Email;
            //labelEmail.Width += 100;
            //labelEmail.Location = new Point(labelGender.Location.X, labelGender.Location.Y + 25);
            //selectedTab.Controls.Add(labelEmail);
            //Label labelCity = new Label();
            //labelCity.Text = "City: " + m_UserInfo.m_City;
            //labelCity.Location = new Point(labelEmail.Location.X, labelEmail.Location.Y + 25);

        }

        private void fetchAlbums()
        {
            listBoxAlbums.Items.Clear();
            listBoxAlbums.DisplayMember = "Name";

            foreach(Album album in m_LoginUser.Albums)
            {
                listBoxAlbums.Items.Add(album);
            }

            if(m_LoginUser.Albums.Count == 0)
            {
                MessageBox.Show("No Albums to retrieve :(");
            }
        }

        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedAlbum();
        }

        private void displaySelectedAlbum()
        {
            if (listBoxAlbums.SelectedItems.Count == 1)
            {
                Album selectedAlbum = listBoxAlbums.SelectedItem as Album;
                if(selectedAlbum.Photos.Count < 1)
                {
                    MessageBox.Show("This album is empty");
                }
                else
                {
                    ShowAlbum album = new ShowAlbum(selectedAlbum);
                    album.ShowDialog();
                }
                /*if (selectedAlbum.PictureAlbumURL != null)
                {
                    pictureBoxAlbum.LoadAsync(selectedAlbum.PictureAlbumURL);
                }
                else
                {
                    pictureBoxProfile.Image = pictureBoxProfile.ErrorImage;
                }*/
            }
        }

        private void fetchPages()
        {
            listBoxPages.Items.Clear();
            listBoxPages.DisplayMember = "Name";

            foreach (Page page in m_LoginUser.LikedPages)
            {
                listBoxPages.Items.Add(page);
            }

            if (m_LoginUser.LikedPages.Count == 0)
            {
                MessageBox.Show("No pages to retrieve :(");
            }
        }
        private void fetchEvents()
        {
            listBoxEvents.Items.Clear();
            listBoxEvents.DisplayMember = "Name";

            foreach (Event userEvent in m_LoginUser.Events)
            {
                listBoxEvents.Items.Add(userEvent);
            }

            if (m_LoginUser.Events.Count == 0)
            {
                MessageBox.Show("No events to retrieve :(");
            }
        }

        private void fetchFriends()
        {
            listBoxFriends.Items.Clear();
            listBoxFriends.DisplayMember = "Name";

            

            foreach (User friend in m_LoginUser.Friends)
            {
                listBoxFriends.Items.Add(friend.Name);
            }

            if (m_LoginUser.Friends.Count == 0)
            {
                MessageBox.Show("No friends to retrieve :(");
            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            m_AppSettings.WindowLocation = this.Location;
            m_AppSettings.WindowSize = this.Size;

            if (m_AppSettings.RememberUser)
            {
                m_AppSettings.UserAccessToken = m_LoginResult.AccessToken;
            }
            else
            {
                m_AppSettings.UserAccessToken = null;
            }

            m_AppSettings.SaveFile();

            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }

        private void HomeScreen_Resize(object sender, EventArgs e)
        {
            buttonLogout.Location = new Point(this.Width - 110, buttonLogout.Location.Y);
            //tabControlHomeScreen.Width = this.Width - 100;
            tabControlHomeScreen.Width = this.Width - buttonPostStatus.Right - 20;
            tabControlHomeScreen.Height = this.Height - PictureBoxCoverPhoto.Bottom - 45;
            //tabControlHomeScreen.Height = this.Height - PictureBoxCoverPhoto.Height;
            //listBoxTimeline.Height = this.Height - labelTimeline.Location.Y;
        }

        private void buttonPostStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_PostAttachedFilePath == null)
                {
                    m_LoginUser.PostStatus(textBoxPostStatus.Text);

                }
                else
                {
                    m_LoginUser.PostPhoto(m_PostAttachedFilePath, textBoxPostStatus.Text);
                }
                MessageBox.Show("Status posted successfully!");
            }
            catch(FacebookOAuthException foae)
            {
                MessageBox.Show(foae.Message);
            }
        }

        private void buttonAttachImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ("Image Files *.BMP*;*.JPG*;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG");
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                m_PostAttachedFilePath  = ofd.FileName;
            }
        }
    }
}
