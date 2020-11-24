using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    public class ContestLogic
    {
        public int m_ContestID { get; }
        public int m_ParticipantsCount { get; set; }
        public bool m_ContestCondition { get; }
        public bool m_LikeCondition { get; }
        public bool m_CommentCondition { get; }
        public int m_NumberOfWinners { get; }
        public string m_Status { get; }
        public string m_ImagePath { get; }
        public GeoPostedItem m_ContestPost { get; }
        public readonly List<User> r_ContestWinners;
        public readonly List<User> r_ParticipantsList;

        public ContestLogic(int i_ContestID, User i_User, string i_Status, string i_ImagePath, bool i_LikeCondition, bool i_CommentCondition, int i_NumberOfWinners)
        {
            m_ContestID = i_ContestID;
            m_ParticipantsCount = 0;
            m_LikeCondition = i_LikeCondition;
            m_CommentCondition = i_CommentCondition;
            m_NumberOfWinners = i_NumberOfWinners;
            r_ParticipantsList = new List<User>();
            r_ContestWinners = new List<User>();
            m_ContestCondition = true;
            m_ContestPost = UserPostStatusWrapper.PostStatus(i_User, i_ImagePath, i_Status);
            m_Status = i_Status; // We save this property because PostStatus doesnt work
            m_ImagePath = i_ImagePath; // We save this property because PostStatus doesnt work
        }

        public void UpdateParticipantsList()
        {
            foreach (Comment postComment in m_ContestPost.Comments)
            {
                User postCommentUser = postComment.From;
                if (m_ContestPost.LikedBy.Contains(postCommentUser))
                {
                    r_ParticipantsList.Add(postCommentUser);
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
}
