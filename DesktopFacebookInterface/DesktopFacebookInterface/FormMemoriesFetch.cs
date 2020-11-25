using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    public partial class FormMemoriesFetch : Form
    {
        private DateTime m_StartDate;
        private DateTime m_EndDate;

        public FormMemoriesFetch()
        {
            InitializeComponent();
            monthCalendarStartDate.MinDate = new DateTime(2005, 1, 1);
            monthCalendarStartDate.MaxDate = DateTime.Today;
            monthCalendarEndDate.MinDate = new DateTime(2005, 1, 1);
            monthCalendarEndDate.MaxDate = DateTime.Today;
        }

        private void monthCalendarStartDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            m_StartDate = monthCalendarStartDate.SelectionStart;
            labelStartDate.Text = string.Format("Start Date: {0}/{1}/{2}", m_StartDate.Day, m_StartDate.Month, m_StartDate.Year);
        }

        private void monthCalendarEndDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            m_EndDate = monthCalendarEndDate.SelectionStart;
            labelEndDate.Text = string.Format("End Date: {0}/{1}/{2}", m_EndDate.Day, m_EndDate.Month, m_EndDate.Year);
        }
    }
}
