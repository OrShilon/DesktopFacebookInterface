using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using static System.Windows.Forms.CheckedListBox;

namespace DesktopFacebookInterface
{
    public partial class FormMemoriesFetch : Form
    {
        private DateTime m_StartDate;
        private DateTime m_EndDate;
        private readonly List<CheckBox> m_MemoriesOptions;

        public FormMemoriesFetch()
        {
            InitializeComponent();
            m_MemoriesOptions = new List<CheckBox>();
            initMemoryOptionsList();
            monthCalendarStartDate.MinDate = new DateTime(2005, 1, 1);
            monthCalendarStartDate.MaxDate = DateTime.Today;
            monthCalendarEndDate.MinDate = new DateTime(2005, 1, 1);
            monthCalendarEndDate.MaxDate = DateTime.Today;
        }

        private void initMemoryOptionsList()
        {

            m_MemoriesOptions.Add(checkBoxCheckAll);
            m_MemoriesOptions.Add(checkBoxPosts);
            m_MemoriesOptions.Add(checkBoxPhotos);
            m_MemoriesOptions.Add(checkBoxCheckIn);
            m_MemoriesOptions.Add(checkBoxEvents);

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
            
        }

        private void checkBoxCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkAll = (CheckBox)sender;

            if(checkAll.Checked)
            {
                foreach(CheckBox currentOption in m_MemoriesOptions)
                {
                    currentOption.Checked = true;
                }
            }
            else
            {
                foreach (CheckBox currentOption in m_MemoriesOptions)
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
