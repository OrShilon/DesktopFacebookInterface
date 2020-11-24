using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
        public string m_Status { get; internal set; }
        public string m_ImagePath { get; internal set; }
        public GeoPostedItem m_ContestPost { get; internal set; }
        public readonly List<User> r_ContestWinners;
        public readonly List<User> r_ParticipantsList;

        public ContestLogic(User i_User, string i_Status, string i_ImagePath, bool i_LikeCondition, bool i_CommentCondition, int i_NumberOfWinners)
        {
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
                if(m_CommentCondition && m_LikeCondition)
                {
                    updateBeLikesAndComments();
                }
                else if(m_CommentCondition)
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
            try
            {
                if (m_ContestPost != null)
                {
                    foreach (User currentUser in m_ContestPost.LikedBy)
                    {
                        r_ParticipantsList.Add(currentUser);
                    }
                }
                else
                {
                    MessageBox.Show("No user meets the requirements of your contest.");
                }
            }
            catch(Facebook.FacebookOAuthException)
            {
                MessageBox.Show("Unable to load. No permission.");
            }
            catch (Exception)
            {
                MessageBox.Show("No user meets the requirements of your contest.");
            }
        }

        private void updateByComments()
        {
            try
            {
                if(m_ContestPost != null)
                {
                    foreach (Comment postComment in m_ContestPost.Comments)
                    {
                        User postCommentUser = postComment.From;
                        r_ParticipantsList.Add(postCommentUser);
                    }
                }
                else
                {
                    MessageBox.Show("No user meets the requirements of your contest.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No user meets the requirements of your contest.");
            }
        }

        private void updateBeLikesAndComments()
        {
            try
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
                else
                {
                    MessageBox.Show("No user meets the requirements of your contest.");
                }
            }
            catch (Facebook.FacebookOAuthException)
            {
                MessageBox.Show("Unable to load. No permission.");
            }
            catch (Exception)
            {
                MessageBox.Show("No user meets the requirements of your contest.");
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
