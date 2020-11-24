using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    public class ContestLogic
    {
        public int m_ContestID { get; }
        public User m_ContestUser { get; set; }
        public int m_ParticipantsCount { get; set; }
        public bool m_ContestCondition { get; }
        public bool m_LikeCondition { get; }
        public bool m_CommentCondition { get; }
        public int m_NumberOfWinners { get; }
        public string m_Status { get; }
        public string m_ImagePath { get; }
        public GeoPostedItem m_ContestPost { get; set; }
        public readonly List<User> r_ContestWinners;
        public readonly List<User> r_ParticipantsList;

        public ContestLogic(int i_ContestID, User i_User, string i_Status, string i_ImagePath, bool i_LikeCondition, bool i_CommentCondition, int i_NumberOfWinners)
        {
            m_ContestID = i_ContestID;
            m_ContestUser = i_User;
            m_ParticipantsCount = 0;
            m_LikeCondition = i_LikeCondition;
            m_CommentCondition = i_CommentCondition;
            m_NumberOfWinners = i_NumberOfWinners;
            r_ParticipantsList = new List<User>();
            r_ContestWinners = new List<User>();
            m_ContestCondition = true;

            m_Status = i_Status; // We save this property because PostStatus doesnt work
            m_ImagePath = i_ImagePath; // We save this property because PostStatus doesnt work
        }

        public void PostContestStatus() 
        {
            m_ContestPost = UserPostStatusWrapper.PostStatus(m_ContestUser, m_ImagePath, m_Status);
        }

        public void UpdateParticipantsList()
        {
            if (m_CommentCondition && m_LikeCondition)
            {
                updateBeLikesAndComments();
            }
            else if (m_CommentCondition)
            {
                updateByComments();
            }
            else
            {
                UpdateByLikes();
            }
        }

        private void UpdateByLikes()
        {
            if (m_ContestPost != null)
            {
                foreach (User currentUser in m_ContestPost.LikedBy)
                {
                    r_ParticipantsList.Add(currentUser);
                }
            }
        }

        private void updateByComments()
        {
            if (m_ContestPost != null)
            {
                foreach (Comment postComment in m_ContestPost.Comments)
                {
                    User postCommentUser = postComment.From;
                    r_ParticipantsList.Add(postCommentUser);
                }
            }
        }

        private void updateBeLikesAndComments()
        {
            if (m_ContestPost != null)
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
        }

        public void ChooseWinners() 
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
    }
}
