using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    public partial class Form1 : Form
    {
        LoginResult m_LoginResult;
        User m_LoginUser;
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            LoginAndInit();
        }

        private void LoginAndInit()
        {
            if(m_LoginResult == null)
            {
                m_LoginResult = FacebookService.Login("370214274434054", 
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

            }
            else
            {
                MessageBox.Show(m_LoginResult.ErrorMessage);
            }
        }

        private void FetchUserInfo()
        {
            //after getting the token, take the necessary info from user facebook profile
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
