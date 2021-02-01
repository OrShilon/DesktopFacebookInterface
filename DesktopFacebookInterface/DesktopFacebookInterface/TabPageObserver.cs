using System.Windows.Forms;

namespace DesktopFacebookInterface
{
    public delegate void ReportDeletedContestDelegate(int i_DeletedIndex);

    class TabPageObserver : TabPage
    {
        public ReportDeletedContestDelegate m_ReportDeletedContestObserver { get; }

        public TabPageObserver() : base()
        {
            m_ReportDeletedContestObserver = new ReportDeletedContestDelegate(this.UpdateIndexNumber);
        }

        public void UpdateIndexNumber(int i_DeletedIndex)
        {
            int myIndex = int.Parse(this.Text.Split(' ')[1]);
            int newIndex = myIndex - 1;

            if (myIndex > i_DeletedIndex)
            {
                this.Text = "Contest " + newIndex;
                this.Name = "tabPageContest" + newIndex;

                foreach (Control control in this.Controls)
                {
                    if (myIndex > 9)
                    {
                        control.Name = control.Name.Substring(0, control.Name.Length - 2) + newIndex;
                    }
                    else
                    {
                        control.Name = control.Name.Substring(0, control.Name.Length - 1) + newIndex;
                    }
                }
            }
        }
    }
}
