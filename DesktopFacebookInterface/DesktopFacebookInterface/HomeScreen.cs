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
        User m_LoginUser;
        UserInformationWrapper user;
        readonly List<string> m_UserInformation;

        public HomeScreen(LoginResult i_LoginResult, User i_LoginUser)
        {
            m_LoginResult = i_LoginResult;
            m_LoginUser = i_LoginUser;
            user = new UserInformationWrapper(m_LoginUser);
            //Console.WriteLine(m_LoginUser.Name);
            InitializeComponent();
            PictureBoxProfile.LoadAsync(m_LoginUser.PictureNormalURL);
            PictureBoxCoverPhoto.LoadAsync(user.CoverImage);
            m_UserInformation = new List<string>();
            fetchAbout();
            this.ShowDialog();
            //PictureBoxCoverPhoto.Load(m_LoginUser.Cover.SourceURL);
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
            MessageBox.Show("You are now logged out!!");
        }

        private void tabControlHomeScreen_Selected(object sender, TabControlEventArgs e)
        {
            switch(tabControlHomeScreen.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    fetchAlbums();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }

        private void fetchAbout()
        {
            TabPage selectedTab = tabControlHomeScreen.SelectedTab;

            Label labelName = new Label();
            labelName.Text = user.m_FullName;
            selectedTab.Controls.Add(labelName);
            Label labelBirthday = new Label();
            labelBirthday.Text = user.m_Birthday;
            labelBirthday.Location = new Point(labelName.Location.X, labelName.Location.Y + 25);
            selectedTab.Controls.Add(labelBirthday);
            Label labelGender = new Label();
            labelGender.Text = user.m_Gender;
            labelGender.Location = new Point(labelBirthday.Location.X, labelBirthday.Location.Y + 25);
            selectedTab.Controls.Add(labelGender);
            Label labelEmail = new Label();
            labelEmail.Text = user.m_Email;
            labelEmail.Width += 10;
            labelEmail.Location = new Point(labelGender.Location.X, labelGender.Location.Y + 25);
            selectedTab.Controls.Add(labelEmail);

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
                ShowAlbum album = new ShowAlbum(selectedAlbum);
                album.ShowDialog();
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
    }
}
