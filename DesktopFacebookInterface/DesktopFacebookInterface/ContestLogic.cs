using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    public class ContestLogic
    {
        public int m_ParticipantsCount { get; internal set; }
        public bool m_ContestCondition { get; internal set; }
        public bool m_LikeCondition { get; internal set; }
        public bool m_CommentCondition { get; internal set; }
        public int m_NumberOfWinners { get; internal set; }
        public GeoPostedItem m_ContestPost { get; internal set; }
        public readonly List<User> m_ContestWinners;
        public readonly List<User> m_ParticipantsList;

        public ContestLogic(User i_User, string i_Status, string i_ImagePath, bool i_LikeCondition, bool i_CommentCondition, int i_NumberOfWinners)
        {
            m_LikeCondition = i_LikeCondition;
            m_CommentCondition = i_CommentCondition;
            m_NumberOfWinners = i_NumberOfWinners;
            m_ParticipantsList = new List<User>();
            m_ContestWinners = new List<User>();
            // code to post status and put in m_ContestStatus
            m_ContestCondition = true;
            m_ContestPost = UserPostStatusWrapper.PostStatus(i_User, i_ImagePath, i_Status);
        }

        public void UpdateParticipantsList()
        {
            foreach (Comment postComment in m_ContestPost.Comments)
            {
                User postCommentUser = postComment.From;
                if (m_ContestPost.LikedBy.Contains(postCommentUser))
                {
                    m_ParticipantsList.Add(postCommentUser);
                    m_ParticipantsCount++;
                }
            }
        }

        public void ChooseWinners() 
        {
            bool[] winnersIndex = new bool[m_NumberOfWinners];
            int countWinners = 0;
            Random rnd = new Random();

            while (countWinners < m_NumberOfWinners)
            {
                int winningIndex = rnd.Next(0, m_ParticipantsList.Count - 1);
                if (!winnersIndex[winningIndex])
                {
                    m_ContestWinners.Add(m_ParticipantsList[winningIndex]);
                    winnersIndex[winningIndex] = true;
                    countWinners++;
                }
            }
        }

        //public int Count
        //{
        //    get
        //    {
        //        return m_ParticipantsCount;
        //    }
        //}

        //public int NumberOfWinners
        //{
        //    get
        //    {
        //        return m_NumberOfWinners;
        //    }
        //}

        //public bool IsContestRunning()
        //{
        //    return m_ContestCondition;
        //}

        //public List<User> ContestWinners
        //{
        //    get
        //    {
        //        return m_ContestWinners;
        //    }
        //}

        //public Status Status
        //{
        //    get
        //    {
        //        return m_ContestStatus;
        //    }
        //}

        //public List<User> ParticipantsList
        //{
        //    get
        //    {
        //        return m_ParticipantsList;
        //    }
        //}
    }
}
