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

        public HomeScreen(LoginResult i_LoginResult, User i_LoginUser)
        {
            m_LoginResult = i_LoginResult;
            m_LoginUser = i_LoginUser;
            user = new UserInformationWrapper(m_LoginUser);
            //Console.WriteLine(m_LoginUser.Name);
            InitializeComponent();
            PictureBoxProfile.LoadAsync(m_LoginUser.PictureNormalURL);
            PictureBoxCoverPhoto.LoadAsync(user.CoverImage);
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
    }
}
