﻿using Facebook;
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
        UserInformationWrapper user;
        readonly List<string> m_UserInformation;

        public HomeScreen(LoginResult i_LoginResult, User i_LoginUser, AppSettings i_AppSettings)
        {
            m_LoginResult = i_LoginResult;
            m_LoginUser = i_LoginUser;
            m_AppSettings = i_AppSettings;
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

        protected override void OnShown(EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Size = m_AppSettings.WindowSize;
            this.Location = m_AppSettings.WindowLocation;

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
            closeFormAndShowLogin();

        }

        private void tabControlHomeScreen_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                switch (tabControlHomeScreen.SelectedIndex)
                {
                    case 0:
                        fetchAbout();
                        break;
                    case 1:
                        fetchAlbums();
                        break;
                    case 2:
                        fetchPages();
                        break;
                    case 3:
                        fetchEvents();
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

            Label labelName = new Label();
            labelName.Text = "Name: " + user.m_FullName;
            labelName.Width += 100;
            selectedTab.Controls.Add(labelName);
            Label labelBirthday = new Label();
            labelBirthday.Text = "Birthday: " + user.m_Birthday;
            labelBirthday.Location = new Point(labelName.Location.X, labelName.Location.Y + 25);
            labelBirthday.Width += 100;
            selectedTab.Controls.Add(labelBirthday);
            Label labelGender = new Label();
            labelGender.Text = "Gender: " + user.m_Gender;
            labelGender.Location = new Point(labelBirthday.Location.X, labelBirthday.Location.Y + 25);
            labelGender.Width += 100;
            selectedTab.Controls.Add(labelGender);
            Label labelEmail = new Label();
            labelEmail.Text = "Email: " + user.m_Email;
            labelEmail.Width += 100;
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
    }
}
