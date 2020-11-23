using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;
using Facebook;
using System.Drawing;

namespace DesktopFacebookInterface
{
    class ContestLogic
    {
        int m_ParticipantsCount;
        bool m_ActiveContest;
        DateTime m_ExpiryDate;
        List<User> m_ParticipantsList;
        User m_ContestWinner;
        Post m_ContestPost;

        public ContestLogic(string i_MessageToPost, Image i_ImageToPost)
        {

        }

        public void UpdateParticipants()
        {
            foreach (User user in m_ContestPost.LikedBy)
            {
                if (!m_ParticipantsList.Contains(user))
                {
                    m_ParticipantsList.Add(user);
                }
            }
        }

        public void ChooseWinner()
        {
            Random rnd = new Random();
            int winnerIndex = rnd.Next(0, m_ParticipantsList.Count - 1);

            m_ContestWinner = m_ParticipantsList[winnerIndex];
        }

        public void AnnounceWinner()
        {
            //
        }
    }
}
