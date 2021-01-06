namespace DesktopFacebookInterface.ContestFactoryMethod
{
    public static class ContestFactory
    {
        public static IContest CreateContest(int i_ContestID, string i_Status, string i_ImagePath, int i_NumberOfWinners, bool i_LikeRequired, bool i_CommentRequired)
        {
            IContest newContest;

            if(i_LikeRequired && i_CommentRequired)
            {
                newContest = new ContestByLikesAndComments(i_ContestID, i_Status, i_ImagePath, i_NumberOfWinners);
            }
            else if(i_LikeRequired)
            {
                newContest = new ContestByLikes(i_ContestID, i_Status, i_ImagePath, i_NumberOfWinners);
            }
            else
            {
                newContest = new ContestByComments(i_ContestID, i_Status, i_ImagePath, i_NumberOfWinners);
            }

            return newContest;
        }
    }
}
