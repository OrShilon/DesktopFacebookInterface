using System.Windows.Forms;
using Facebook;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    internal static class UserPostStatusWrapper
    {
        public static GeoPostedItem PostStatus(User i_User, string i_ImagePath, string i_Status)
        {
            GeoPostedItem newPostedItem = null;

            if (i_ImagePath == null)
            {
                newPostedItem = i_User.PostStatus(i_Status);
            }
            else
            {
                newPostedItem = i_User.PostPhoto(i_ImagePath, i_Status);
            }

            return newPostedItem;
        }
    }
}
