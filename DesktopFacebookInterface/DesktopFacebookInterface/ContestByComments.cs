using FacebookWrapper.ObjectModel;
using DesktopFacebookInterface.Logic;

namespace DesktopFacebookInterface.ContestFactoryMethod
{
    public class ContestByComments : IContest
    {
        internal ContestByComments(int i_ContestID, string i_Status, string i_ImagePath, int i_NumberOfWinners) : base(i_ContestID, i_Status, i_ImagePath, i_NumberOfWinners)
        {
        }

        public override void UpdateParticipantsList()
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
