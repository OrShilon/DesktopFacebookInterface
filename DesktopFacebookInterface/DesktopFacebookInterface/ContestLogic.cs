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
        public int m_ParticipantsCount;
        public bool m_ContestCondition;
        public bool m_LikeCondition;
        public bool m_CommentCondition;
        public int m_NumberOfWinners;
        public Status m_ContestStatus;
        public readonly List<User> m_ContestWinners;
        public readonly List<User> m_ParticipantsList;

        public ContestLogic(User i_User, string i_Status, string i_ImagePath, bool i_LikeCondition, bool i_CommentCondition, int i_NumberOfWinners)
        {
            m_LikeCondition = i_LikeCondition;
            m_CommentCondition = i_CommentCondition;
            m_NumberOfWinners = i_NumberOfWinners;
            m_ParticipantsList = new List<User>();
            // code to post status and put in m_ContestStatus
            m_ContestCondition = true;
            UserPostStatusWrapper.PostStatus(i_User, i_ImagePath, i_Status);
        }

        public void UpdateParticipantsList()
        {
            foreach (User user in m_ContestStatus.LikedBy)
            {
                if (!m_ParticipantsList.Contains(user))
                {
                    m_ParticipantsList.Add(user);
                    m_ParticipantsCount++;
                }
            }
        }

        public void ChooseWinners() 
        {
            bool[] winnersIndex = new bool[m_NumberOfWinners];
            int numWins = 0;
            Random rnd = new Random();

            while (numWins < m_NumberOfWinners)
            {
                int winningIndex = rnd.Next(0, m_ParticipantsList.Count - 1);
                if (!winnersIndex[winningIndex])
                {
                    m_ContestWinners.Add(m_ParticipantsList[winningIndex]);
                    winnersIndex[winningIndex] = true;
                    numWins++;
                }
            }
        }

        public int Count
        {
            get
            {
                return m_ParticipantsCount;
            }
        }

        public int NumberOfWinners
        {
            get
            {
                return m_NumberOfWinners;
            }
        }

        public bool IsContestRunning()
        {
            return m_ContestCondition;
        }

        public List<User> ContestWinners
        {
            get
            {
                return m_ContestWinners;
            }
        }

        public Status Status
        {
            get
            {
                return m_ContestStatus;
            }
        }

        public List<User> ParticipantsList
        {
            get
            {
                return m_ParticipantsList;
            }
        }
    }
}
