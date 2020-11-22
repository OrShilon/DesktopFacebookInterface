using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopFacebookInterface
{
    class UserInformationWrapper
    {

        User m_LoginUser;
        string m_CoverImage;
        public string m_FullName { get; set; }
        public string m_Email { get; set; }
        public string m_Gender { get; set; }
        public string m_Birthday { get; set; }
        

        public UserInformationWrapper(User i_LoginUser)
        {
            m_LoginUser = i_LoginUser;
            m_FullName = m_LoginUser.Name;
            m_Email = m_LoginUser.Email;
            m_Gender = m_LoginUser.Gender.ToString();
            m_Birthday = m_LoginUser.Birthday;

            addCoverPhoto();
        }

        private void addCoverPhoto()
        {
            try
            {
                foreach (Album album in m_LoginUser.Albums)
                {
                    string albumName = album.Name.ToLower();
                    if (albumName.Equals("cover photos"))
                    {
                        m_CoverImage = album.Photos[0].PictureNormalURL;
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("got here");
            }
        }

        public string CoverImage
        {
            get
            {
                return m_CoverImage;
            }
        }

        
    }
}
