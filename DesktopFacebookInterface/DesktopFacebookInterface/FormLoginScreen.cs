using System;
using System.Drawing;
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

        protected const string k_AppId = "370214274434054";

        public FormLoginScreen()
        {
            m_AppSettings = AppSettings.LoadFile();
            InitializeComponent();
            this.BackColor = Color.FromArgb(66, 103, 178);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = m_AppSettings.m_WindowLocation;
            this.checkBoxRememberUser.Checked = m_AppSettings.m_RememberUser;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Thread t1 = new Thread(new ThreadStart(connectByUserAccessToken));
            t1.Start();
            t1.Join();

            if (m_LoginResult != null)
            {
                closeFormAndShowHome();
            }
        }

        private void connectByUserAccessToken()
        {
            if (m_AppSettings.m_RememberUser && !string.IsNullOrEmpty(m_AppSettings.m_UserAccessToken))
            {
                try
                {
                    m_LoginResult = FacebookService.Connect(m_AppSettings.m_UserAccessToken);
                    m_LoginUser = m_LoginResult.LoggedInUser;
                }

                catch (FacebookOAuthException e)
                {
                    m_LoginResult = null;
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void loginAndInit()
        {
            if (m_LoginResult == null)
            {
                try
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
                catch (FacebookOAuthException foae)
                {
                    MessageBox.Show(foae.Message);
                }
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
            loginAndInit();
        }

        private void checkBoxRememberUser_CheckedChanged(object sender, EventArgs e)
        {
            m_AppSettings.m_RememberUser = checkBoxRememberUser.Checked;
        }
    }
}
