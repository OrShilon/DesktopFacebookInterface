using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Facebook;
using FacebookWrapper;
using DesktopFacebookInterface.Logic;

namespace DesktopFacebookInterface.UI
{
    internal partial class FormLoginScreen : Form
    {
        private AppSettings m_AppSettings;
        private LoginResult m_LoginResult;
        protected const string k_AppId = "370214274434054";

        public FormLoginScreen()
        {
            m_AppSettings = AppSettings.LoadFile();
            InitializeComponent();
            this.BackColor = Color.FromArgb(60, 91, 154);
            ButtonLogin.ForeColor = Color.FromArgb(60, 91, 154);
            checkBoxRememberUser.ForeColor = Color.White;
            this.checkBoxRememberUser.Checked = m_AppSettings.m_RememberUser;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Thread t1 = new Thread(new ThreadStart(connectWithAccessToken));
            t1.Start();
            t1.Join();

            if (m_LoginResult != null)
            {
                closeFormAndShowHome();
            }
        }

        private void connectWithAccessToken()
        {
            if (m_AppSettings.m_RememberUser && !string.IsNullOrEmpty(m_AppSettings.m_UserAccessToken))
            {
                try
                {
                    m_LoginResult = FacebookService.Connect(m_AppSettings.m_UserAccessToken);
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
                    m_LoginResult = FacebookService.Login(
                        k_AppId,
                        "public_profile",
                        "email",
                        "user_birthday",
                        "user_age_range",
                        "user_gender",
                        "user_link",
                        "user_tagged_places",
                        "user_videos",
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
            SetUserInfoWrapper();
            SetAppSetingsParams();
            FormHomeScreen homeScreen = new FormHomeScreen();
            homeScreen.ShowDialog();
            this.Close();
        }

        private void SetUserInfoWrapper()
        {
            (FacebookUserFacade.GetFacebookUserInstance).SetUser(m_LoginResult.LoggedInUser);
        }

        private void SetAppSetingsParams() 
        {
            if (m_AppSettings.m_RememberUser)
            {
                m_AppSettings.m_UserAccessToken = m_LoginResult.AccessToken;
            }
            else
            {
                m_AppSettings.m_UserAccessToken = null;
            }
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
