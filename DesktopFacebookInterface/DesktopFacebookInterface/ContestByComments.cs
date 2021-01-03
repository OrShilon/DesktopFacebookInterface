using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    class ContestByComments : Contest
    {
        public ContestByComments(int i_ContestID, string i_Status,
            string i_ImagePath, int i_NumberOfWinners) : base(i_ContestID, i_Status, i_ImagePath, i_NumberOfWinners)
        {

        }

        override
        public void UpdateParticipantsList()
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
    }
}
