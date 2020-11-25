using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using static System.Windows.Forms.CheckedListBox;

namespace DesktopFacebookInterface
{
    public partial class FormMemoriesFetch : Form
    {
        UserInformationWrapper m_User;
        private DateTime m_StartDate;
        private DateTime m_EndDate;
        private readonly List<CheckBox> r_MemoriesOptions;
        private readonly List<string> r_Memories;

        public FormMemoriesFetch(UserInformationWrapper i_User)
        {
            m_User = i_User;
            InitializeComponent();
            r_MemoriesOptions = new List<CheckBox>();
            r_Memories = new List<string>();
            initMemoryOptionsList();
            monthCalendarStartDate.MinDate = new DateTime(2005, 1, 1);
            monthCalendarStartDate.MaxDate = DateTime.Today;
            monthCalendarEndDate.MinDate = new DateTime(2005, 1, 1);
            monthCalendarEndDate.MaxDate = DateTime.Today;
        }

        private void initMemoryOptionsList()
        {

            r_MemoriesOptions.Add(checkBoxCheckAll);
            r_MemoriesOptions.Add(checkBoxPosts);
            r_MemoriesOptions.Add(checkBoxPhotos);
            r_MemoriesOptions.Add(checkBoxCheckIn);
            r_MemoriesOptions.Add(checkBoxEvents);

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

        private void buttonFetchData_Click(object sender, EventArgs e)
        {
            textBoxFetchResault.Text = string.Empty;
            r_Memories.Clear();

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
                textBoxFetchResault.Text += option + Environment.NewLine;
            }
        }

        private void displayPosts()
        {
            string title = string.Format("{0}Posts:{0}", Environment.NewLine);
            List<string> posts = m_User.fetchPostsByDate(m_StartDate, m_EndDate);

            r_Memories.Add(title);

            foreach(string post in posts)
            {
                r_Memories.Add(post);
            }
        }

        //private void displayPhotos()
        //{

        //}

        private void displayCheckIn()
        {
            string title = string.Format("{0}Check in:{0}", Environment.NewLine);
            List<string> checkIn = m_User.fetchCheckInsByDate(m_StartDate, m_EndDate);

            r_Memories.Add(title);

            foreach (string post in checkIn)
            {
                r_Memories.Add(post);
            }
        }

        private void displayEvents()
        {
            string title = string.Format("{0}Events:{0}", Environment.NewLine);
            List<string> events = m_User.fetchEventsByDate(m_StartDate, m_EndDate);

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

        private void checkBoxPhotos_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxPhotos.Checked)
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
            checkBoxCheckAll.CheckedChanged -= new EventHandler(this.checkBoxCheckAll_CheckedChanged);
            checkBoxCheckAll.Checked = false;
            checkBoxCheckAll.CheckedChanged += new EventHandler(this.checkBoxCheckAll_CheckedChanged);
        }

        private void checkBoxSingleDay_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxSingleDay.Checked)
            {
                monthCalendarEndDate.Enabled = false;
            }
            else
            {
                monthCalendarEndDate.Enabled = true;
            }
        }
    }
}
