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

        public UserInformationWrapper(User i_LoginUser)
        {
            m_LoginUser = i_LoginUser;
            addCoverPhoto();
        }

        private void addCoverPhoto()
        {
            try
            {
                foreach (Album album in m_LoginUser.Albums)
                {
                    string albumName = album.Name.ToLower();
                    if (album.Name.Equals("cover photos"))
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
