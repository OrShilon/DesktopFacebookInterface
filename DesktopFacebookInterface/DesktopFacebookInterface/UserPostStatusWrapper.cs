using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facebook;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    static class UserPostStatusWrapper
    {
        public static void PostStatus(User i_User, string i_ImagePath, string i_Status)
        {
            try
            {
                if (i_ImagePath == null)
                {
                    i_User.PostStatus(i_Status);

                }
                else
                {
                    i_User.PostPhoto(i_ImagePath, i_Status);
                }
                MessageBox.Show("Status posted successfully!");
            }
            catch (FacebookOAuthException foae)
            {
                MessageBox.Show(foae.Message);
            }
        }
    }
}
