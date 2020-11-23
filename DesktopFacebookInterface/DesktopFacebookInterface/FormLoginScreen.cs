using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    public partial class FormLoginScreen : Form
    {
        AppSettings m_AppSettings;
        LoginResult m_LoginResult;
        User m_LoginUser;

        const string k_AppId = "370214274434054";

        public FormLoginScreen()
        {
            m_AppSettings = AppSettings.LoadFile();
            InitializeComponent();
            this.BackColor = Color.FromArgb(66, 103, 178);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = m_AppSettings.WindowLocation;
            this.checkBoxRememberUser.Checked = m_AppSettings.RememberUser;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Thread t1 = new Thread(new ThreadStart(ConnectByUserAccessToken));
            t1.Start();
            t1.Join();
            if(m_LoginResult != null)
            {
                closeFormAndShowHome();
            }
        }

        private void ConnectByUserAccessToken()
        {
            if (m_AppSettings.RememberUser && !string.IsNullOrEmpty(m_AppSettings.UserAccessToken))
            {
                try
                {
                    m_LoginResult = FacebookService.Connect(m_AppSettings.UserAccessToken);
                    m_LoginUser = m_LoginResult.LoggedInUser;
                }

                catch (FacebookOAuthException e)
                {
                    m_LoginResult = null;
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void LoginAndInit()
        {
            if (m_LoginResult == null)
            {
                m_LoginResult = FacebookService.Login(k_AppId,
                    "public_profile",
                    "email",
                    "publish_to_groups",
                    "user_birthday",
                    "user_age_range",
                    "user_gender",
                    "user_link",
                    "user_tagged_places",
                    "user_videos",
                    "publish_to_groups",
                    "groups_access_member_info",
                    "user_friends",
                    "user_events",
                    "user_likes",
                    "user_location",
                    "user_photos",
                    "user_posts",
                    "user_hometown");
            }
            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                m_LoginUser = m_LoginResult.LoggedInUser;
                PictureBoxProfilePicture.Image = m_LoginUser.ImageNormal;
                closeFormAndShowHome();
            }
            else
            {
                MessageBox.Show(m_LoginResult.ErrorMessage);
            }
        }

        private void closeFormAndShowHome()
        {
            this.Hide();
            HomeScreen homeScreen = new HomeScreen(m_LoginResult, m_LoginUser, m_AppSettings);
            this.Close();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            LoginAndInit();
        }

        private void checkBoxRememberUser_CheckedChanged(object sender, EventArgs e)
        {
            m_AppSettings.RememberUser = checkBoxRememberUser.Checked;
        }
    }
}
