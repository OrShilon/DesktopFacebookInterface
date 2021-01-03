using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    public abstract class Contest
    {
        public readonly List<User> r_ContestWinners;
        public readonly List<User> r_ParticipantsList;
        public FacebookUserFacade m_UserInfo;
        public int m_ContestID;
        public int m_ParticipantsCount;
        public int m_NumberOfWinners;
        public string m_Status;
        public string m_ImagePath;
        public GeoPostedItem m_ContestPost;

        public Contest(int i_ContestID, string i_Status, string i_ImagePath, int i_NumberOfWinners)
        {
            m_ContestID = i_ContestID;
            m_UserInfo = FacebookUserFacade.GetFacebookUserInstance;
            m_ParticipantsCount = 0;
            m_NumberOfWinners = i_NumberOfWinners;
            r_ParticipantsList = new List<User>();
            r_ContestWinners = new List<User>();
            m_Status = i_Status; // We save this property because PostStatus doesnt work
            m_ImagePath = i_ImagePath; // We save this property because PostStatus doesnt work
        }

        public void PostContestStatus() 
        {
            m_ContestPost = m_UserInfo.PostStatus(m_ImagePath, m_Status);
        }

        public void GenerateWinners()
        {
            bool[] winnersIndex = new bool[m_NumberOfWinners];
            int countWinners = 0;
            Random rnd = new Random();
            if (r_ParticipantsList.Count >= m_NumberOfWinners)
            {
                while (countWinners < m_NumberOfWinners)
                {
                    int winningIndex = rnd.Next(0, r_ParticipantsList.Count - 1);
                    if (!winnersIndex[winningIndex])
                    {
                        r_ContestWinners.Add(r_ParticipantsList[winningIndex]);
                        winnersIndex[winningIndex] = true;
                        countWinners++;
                    }
                }
            }
        }

        public abstract void UpdateParticipantsList();
    }
}
