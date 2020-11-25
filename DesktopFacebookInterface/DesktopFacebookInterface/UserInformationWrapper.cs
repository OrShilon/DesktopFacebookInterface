using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    internal class UserInformationWrapper : User
    {
        public UserInformationWrapper() : base()
        {
        }

        public List<string> GetListInformation()
        {
            List<string> userInfo = new List<string>();

            if (!string.IsNullOrEmpty(base.Name))
            {
                userInfo.Add(string.Format("Name: {0}", base.Name));
            }

            if (!string.IsNullOrEmpty(base.Gender.ToString()))
            {
                userInfo.Add(string.Format("Gender: {0}", base.Gender.ToString()));
            }

            if (!string.IsNullOrEmpty(base.Birthday))
            {
                userInfo.Add(string.Format("Birthday: {0}", base.Birthday));
            }

            if (!string.IsNullOrEmpty(base.Email))
            {
                userInfo.Add(string.Format("Email: {0}", base.Email));
            }

            if (base.Hometown != null)
            {
                if (!string.IsNullOrEmpty(base.Hometown.Name))
                {
                    userInfo.Add(string.Format("City: {0}", base.Hometown.Name));
                }
            }

            if (!string.IsNullOrEmpty(base.RelationshipStatus.Value.ToString()))
            {
                userInfo.Add(string.Format("Relationship Status: {0}", base.RelationshipStatus.Value.ToString()));
            }

            return userInfo;
        }

        public string fetchCoverPhotoURL()
        {
            string coverPhotoURL = "";

            foreach (Album album in base.Albums)
            {
                string albumName = album.Name.ToLower();

                if (albumName.Equals("cover photos"))
                {
                    coverPhotoURL = album.Photos[0].PictureNormalURL;
                }
            }

            return coverPhotoURL;
        }        
    }
}
