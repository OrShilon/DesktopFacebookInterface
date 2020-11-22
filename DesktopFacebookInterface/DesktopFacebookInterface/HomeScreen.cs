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
            MessageBox.Show("You are now logged out!!");
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
