using FacebookWrapper.ObjectModel;
using System.Collections.Generic;

namespace DesktopFacebookInterface
{
    class UserInformationWrapper
    {
        private User m_LoginUser;
        public string m_ProfileImage { get; set; }
        public string m_CoverImage { get; set; }
        public string m_FullName { get; set; }
        public string m_Email { get; set; }
        public string m_Gender { get; set; }
        public string m_Birthday { get; set; }
        public string m_City { get; set; }
        public string m_RelationshipStatus { get; set; }
        private readonly List<string> r_BasicInformation;

        public UserInformationWrapper(User i_LoginUser)
        {
            m_LoginUser = i_LoginUser;
            r_BasicInformation = new List<string>();
            updateInformation();
            m_ProfileImage = m_LoginUser.PictureNormalURL;
            addCoverPhoto();
        }

        private void updateInformation()
        {
            if (!string.IsNullOrEmpty(m_LoginUser.Name))
            {
                r_BasicInformation.Add(string.Format("Name: {0}", (m_FullName = m_LoginUser.Name)));
            }

            if (!string.IsNullOrEmpty(m_LoginUser.Gender.ToString()))
            {
                r_BasicInformation.Add(string.Format("Gender: {0}", (m_Gender = m_LoginUser.Gender.ToString())));
            }

            if (!string.IsNullOrEmpty(m_LoginUser.Birthday))
            {
                r_BasicInformation.Add(string.Format("Birthday: {0}", (m_Birthday = m_LoginUser.Birthday)));
            }

            if (!string.IsNullOrEmpty(m_LoginUser.Email))
            {
                r_BasicInformation.Add(string.Format("Email: {0}", (m_Email = m_LoginUser.Email)));
            }

            if (m_LoginUser.Hometown != null)
            {
                if (!string.IsNullOrEmpty(m_LoginUser.Hometown.Name))
                {
                    r_BasicInformation.Add(string.Format("City: {0}", (m_City = m_LoginUser.Hometown.Name)));
                }
            }

            if (!string.IsNullOrEmpty(m_LoginUser.RelationshipStatus.Value.ToString()))
            {
                r_BasicInformation.Add(string.Format("Relationship Status: {0}", (m_RelationshipStatus = m_LoginUser.RelationshipStatus.Value.ToString())));
            }
        }

        public List<string> BasicInfo
        {
            get
            {
                return r_BasicInformation;
            }
        }

        private void addCoverPhoto()
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
    }
}
