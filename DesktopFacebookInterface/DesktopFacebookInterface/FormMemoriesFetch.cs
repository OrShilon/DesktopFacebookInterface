using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DesktopFacebookInterface.Logic;

namespace DesktopFacebookInterface.UI
{
    public partial class FormMemoriesFetch : Form
    {
        private readonly List<CheckBox> r_MemoriesTypes;
        private readonly List<string> r_FetchedMemories;
        private FacebookUserFacade m_UserInfo;
        private DateTime m_StartDate;
        private DateTime m_EndDate;
        private StringBuilder m_MissingDetails;

        public FormMemoriesFetch()
        {
            m_UserInfo = FacebookUserFacade.GetFacebookUserInstance;
            InitializeComponent();
            r_MemoriesTypes = new List<CheckBox>();
            r_FetchedMemories = new List<string>();
            m_MissingDetails = new StringBuilder();
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
            r_MemoriesTypes.Add(checkBoxCheckAll);
            r_MemoriesTypes.Add(checkBoxPosts);
            r_MemoriesTypes.Add(checkBoxCheckIn);
            r_MemoriesTypes.Add(checkBoxEvents);
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
            m_MissingDetails.Clear();
            r_FetchedMemories.Clear();
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

            foreach (string option in r_FetchedMemories)
            {
                fetchResults.Append(option + Environment.NewLine);
            }

            if(isValidForm(fetchResults))
            {
                textBoxFetchResault.Text = fetchResults.ToString();
            }
            else
            {
                MessageBox.Show(m_MissingDetails.ToString());
            }
        }

        private bool isValidForm(StringBuilder i_fetchResult)
        {
            if (i_fetchResult.Length == 0)
            {
                m_MissingDetails.Append(string.Format("At least 1 checkbox of options should be checked.{0}", Environment.NewLine));
            }

            if (m_StartDate < monthCalendarStartDate.MinDate)
            {
                m_MissingDetails.Append(string.Format("Need to select start day.{0}", Environment.NewLine));
            }

            if (m_EndDate < monthCalendarEndDate.MinDate)
            {
                m_MissingDetails.Append(string.Format("Need to select end day.{0}", Environment.NewLine));
            }

            return string.IsNullOrEmpty(m_MissingDetails.ToString());
        }

        private void displayPosts()
        {
            string title = string.Format("{0}Posts:{0}", Environment.NewLine);
            List<string> posts = m_UserInfo.FetchPostsByDate(m_StartDate, m_EndDate);

            r_FetchedMemories.Add(title);

            foreach(string post in posts)
            {
                r_FetchedMemories.Add(post);
            }
        }

        private void displayCheckIn()
        {
            string title = string.Format("{0}Check in:{0}", Environment.NewLine);
            List<string> checkIn = m_UserInfo.fetchCheckInsByDate(m_StartDate, m_EndDate);

            r_FetchedMemories.Add(title);

            foreach (string post in checkIn)
            {
                r_FetchedMemories.Add(post);
            }
        }

        private void displayEvents()
        {
            string title = string.Format("{0}Events:{0}", Environment.NewLine);
            List<string> events = m_UserInfo.fetchEventsByDate(m_StartDate, m_EndDate);

            r_FetchedMemories.Add(title);

            foreach (string post in events)
            {
                r_FetchedMemories.Add(post);
            }
        }

        private void checkBoxCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkAll = (CheckBox)sender;

            if(checkAll.Checked)
            {
                foreach(CheckBox currentOption in r_MemoriesTypes)
                {
                    currentOption.Checked = true;
                }
            }
            else
            {
                foreach (CheckBox currentOption in r_MemoriesTypes)
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
