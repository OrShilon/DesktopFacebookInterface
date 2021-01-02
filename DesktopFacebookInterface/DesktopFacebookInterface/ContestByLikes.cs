using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    class ContestByLikes : Contest
    {
        public ContestByLikes(int i_ContestID, UserInformationWrapper i_UserInfo, string i_Status,
            string i_ImagePath, int i_NumberOfWinners) : base(i_ContestID, i_UserInfo, i_Status, i_ImagePath, i_NumberOfWinners)
        {

        }

        override
        public void UpdateParticipantsList()
        {
            if (m_ContestPost != null)
            {
                foreach (User currentUser in m_ContestPost.LikedBy)
                {
                    if (!r_ParticipantsList.Contains(currentUser))
                    {
                        r_ParticipantsList.Add(currentUser);
                        m_ParticipantsCount++;
                    }
                }
            }
        }
    }
}
