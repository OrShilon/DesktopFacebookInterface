using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    public class ContestLogic
    {
        public readonly List<User> r_ContestWinners;
        public readonly List<User> r_ParticipantsList;
        public int m_ContestID;
        public User m_ContestUser;
        public int m_ParticipantsCount;
        public bool m_LikeRequired;
        public bool m_CommentRequired;
        public int m_NumberOfWinners;
        public string m_Status;
        public string m_ImagePath;
        public GeoPostedItem m_ContestPost;

        public ContestLogic(int i_ContestID, User i_User, string i_Status, string i_ImagePath, bool i_LikeRequired, bool i_CommentRequired, int i_NumberOfWinners)
        {
            m_ContestID = i_ContestID;
            m_ContestUser = i_User;
            m_ParticipantsCount = 0;
            m_LikeRequired = i_LikeRequired;
            m_CommentRequired = i_CommentRequired;
            m_NumberOfWinners = i_NumberOfWinners;
            r_ParticipantsList = new List<User>();
            r_ContestWinners = new List<User>();
            m_Status = i_Status; // We save this property because PostStatus doesnt work
            m_ImagePath = i_ImagePath; // We save this property because PostStatus doesnt work
        }

        public void PostContestStatus() 
        {
            m_ContestPost = UserPostStatusWrapper.PostStatus(m_ContestUser, m_ImagePath, m_Status);
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

        public void UpdateParticipantsList()
        {
            if (m_CommentRequired && m_LikeRequired)
            {
                likeAndCommentRequired();
            }
            else if (m_CommentRequired)
            {
                commentRequired();
            }
            else
            {
                likeRequired();
            }
        }

        private void likeRequired()
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

        private void commentRequired()
        {
            if (m_ContestPost != null)
            {
                foreach (Comment postComment in m_ContestPost.Comments)
                {
                    User postCommentUser = postComment.From;

                    if (!r_ParticipantsList.Contains(postCommentUser))
                    {
                        r_ParticipantsList.Add(postCommentUser);
                        m_ParticipantsCount++;
                    }
                }
            }
        }

        private void likeAndCommentRequired()
        {
            if (m_ContestPost != null)
            {
                foreach (Comment postComment in m_ContestPost.Comments)
                {
                    User postCommentUser = postComment.From;
                    if (m_ContestPost.LikedBy.Contains(postCommentUser))
                    {
                        if (!r_ParticipantsList.Contains(postCommentUser))
                        {
                            r_ParticipantsList.Add(postCommentUser);
                            m_ParticipantsCount++;
                        }
                    }
                }
            }
        }
    }
}
