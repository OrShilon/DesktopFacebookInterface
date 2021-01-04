using FacebookWrapper.ObjectModel;
using DesktopFacebookInterface.Logic;

namespace DesktopFacebookInterface.ContestFactoryMethod
{
    class ContestByLikes : IContest
    {
        internal ContestByLikes(int i_ContestID, string i_Status,
            string i_ImagePath, int i_NumberOfWinners) : base(i_ContestID, i_Status, i_ImagePath, i_NumberOfWinners)
        {

        }

        override
        public void UpdateParticipantsList()
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
    }
}
