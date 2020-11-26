using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using static System.Windows.Forms.CheckedListBox;

namespace DesktopFacebookInterface
{
    public partial class FormMemoriesFetch : Form
    {
        UserInformationWrapper m_UserInfo;
        private DateTime m_StartDate;
        private DateTime m_EndDate;
        private readonly List<CheckBox> r_MemoriesOptions;
        private readonly List<string> r_Memories;
        private string m_MissingDetails = string.Empty;

        public FormMemoriesFetch(UserInformationWrapper i_UserInfo)
        {
            m_UserInfo = i_UserInfo;
            InitializeComponent();
            r_MemoriesOptions = new List<CheckBox>();
            r_Memories = new List<string>();
            initMemoryOptionsList();
            monthCalendarStartDate.MinDate = new DateTime(2005, 1, 1);
            monthCalendarStartDate.MaxDate = DateTime.Today;
            monthCalendarEndDate.MinDate = new DateTime(2005, 1, 1);
            monthCalendarEndDate.MaxDate = DateTime.Today;
            m_StartDate = new DateTime(1999, 1, 1);
            m_EndDate = new DateTime(1999, 1, 1);
        }

        private void initMemoryOptionsList()
        {

            r_MemoriesOptions.Add(checkBoxCheckAll);
            r_MemoriesOptions.Add(checkBoxPosts);
            r_MemoriesOptions.Add(checkBoxCheckIn);
            r_MemoriesOptions.Add(checkBoxEvents);

        }

        private void monthCalendarStartDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            m_StartDate = monthCalendarStartDate.SelectionStart;
            labelStartDate.Text = string.Format("Start Date: {0}/{1}/{2}", m_StartDate.Day, m_StartDate.Month, m_StartDate.Year);
            checkBoxSingleDay.Enabled = true;
        }

        private void monthCalendarEndDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            m_EndDate = monthCalendarEndDate.SelectionStart;
            labelEndDate.Text = string.Format("End Date: {0}/{1}/{2}", m_EndDate.Day, m_EndDate.Month, m_EndDate.Year);
        }

        private void buttonFetchData_Click(object sender, EventArgs e)
        {
            textBoxFetchResault.Text = string.Empty;
            m_MissingDetails = string.Empty;
            r_Memories.Clear();
            StringBuilder fetchResults = new StringBuilder();

            if (checkBoxPosts.Checked)
            {
                displayPosts();
            }

            if (checkBoxCheckIn.Checked)
            {
                displayCheckIn();
            }

            if (checkBoxEvents.Checked)
            {
                displayEvents();
            }

            foreach (string option in r_Memories)
            {
                fetchResults.Append(option + Environment.NewLine);
            }

            if(isValidForm(fetchResults))
            {
                textBoxFetchResault.Text = fetchResults.ToString();
            }
            else
            {
                MessageBox.Show(m_MissingDetails);
            }
        }

        private bool isValidForm(StringBuilder i_fetchResult)
        {
            if (i_fetchResult.Length == 0)
            {
                m_MissingDetails += string.Format("At least 1 checkbox of options should be checked.{0}", Environment.NewLine);

            }

            if (m_StartDate < monthCalendarStartDate.MinDate)
            {
                m_MissingDetails += string.Format("Need to select start day.{0}", Environment.NewLine);
            }

            if (m_EndDate < monthCalendarEndDate.MinDate)
            {
                m_MissingDetails += string.Format("Need to select end day.{0}", Environment.NewLine);
            }

            return string.IsNullOrEmpty(m_MissingDetails);
        }
        private void displayPosts()
        {
            string title = string.Format("{0}Posts:{0}", Environment.NewLine);
            List<string> posts = m_UserInfo.fetchPostsByDate(m_StartDate, m_EndDate);

            r_Memories.Add(title);

            foreach(string post in posts)
            {
                r_Memories.Add(post);
            }
        }

        private void displayCheckIn()
        {
            string title = string.Format("{0}Check in:{0}", Environment.NewLine);
            List<string> checkIn = m_UserInfo.fetchCheckInsByDate(m_StartDate, m_EndDate);

            r_Memories.Add(title);

            foreach (string post in checkIn)
            {
                r_Memories.Add(post);
            }
        }

        private void displayEvents()
        {
            string title = string.Format("{0}Events:{0}", Environment.NewLine);
            List<string> events = m_UserInfo.fetchEventsByDate(m_StartDate, m_EndDate);

            r_Memories.Add(title);

            foreach (string post in events)
            {
                r_Memories.Add(post);
            }
        }

        private void checkBoxCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkAll = (CheckBox)sender;

            if(checkAll.Checked)
            {
                foreach(CheckBox currentOption in r_MemoriesOptions)
                {
                    currentOption.Checked = true;
                }
            }
            else
            {
                foreach (CheckBox currentOption in r_MemoriesOptions)
                {
                    currentOption.Checked = false;
                }
            }
        }

        private void checkBoxPosts_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxPosts.Checked)
            {
                uncheckTheCheckAllButton();
            }
        }

        private void checkBoxCheckIn_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxCheckIn.Checked)
            {
                uncheckTheCheckAllButton();
            }
        }

        private void checkBoxEvents_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxEvents.Checked)
            {
                uncheckTheCheckAllButton();
            }
        }

        private void uncheckTheCheckAllButton()
        {
            checkBoxCheckAll.CheckedChanged -= new EventHandler(checkBoxCheckAll_CheckedChanged);
            checkBoxCheckAll.Checked = false;
            checkBoxCheckAll.CheckedChanged += new EventHandler(checkBoxCheckAll_CheckedChanged);
        }

        private void checkBoxSingleDay_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxSingleDay.Checked)
            {
                monthCalendarEndDate.Enabled = false;
                m_EndDate = monthCalendarStartDate.SelectionStart;
                labelEndDate.Text = string.Format("End Date: {0}/{1}/{2}", m_StartDate.Day, m_StartDate.Month, m_StartDate.Year);
            }
            else
            {
                monthCalendarEndDate.Enabled = true;
                m_EndDate = monthCalendarEndDate.SelectionStart;
                labelEndDate.Text = string.Format("End Date: {0}/{1}/{2}", m_EndDate.Day, m_EndDate.Month, m_EndDate.Year);
            }
        }
    }
}
