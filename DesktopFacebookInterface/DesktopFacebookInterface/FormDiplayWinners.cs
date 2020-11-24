using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopFacebookInterface
{
    public partial class FormDiplayWinners : Form
    {
        readonly List<User> m_ContestWinners;
        int m_IndexInWinnerList = 0;
        public FormDiplayWinners(List<User> i_ContestWinners)
        {
            m_ContestWinners = i_ContestWinners;
            InitializeComponent();
        }

        private void initWinners()
        {
            labelNumOfWinner.Text = string.Format("Winner number: {0}", m_IndexInWinnerList + 1);
            labelvWinnerName.Text = string.Format("Full name: {0}", m_ContestWinners[m_IndexInWinnerList].Name);
            pictureBoxWinnerPicture.LoadAsync(m_ContestWinners[m_IndexInWinnerList].PictureNormalURL);
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (m_IndexInWinnerList == 0)
            {
                m_IndexInWinnerList = m_ContestWinners.Count - 1;
            }
            else
            {
                m_IndexInWinnerList--;
            }

            displayImage();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (m_IndexInWinnerList == m_ContestWinners.Count - 1)
            {
                m_IndexInWinnerList = 0;
            }
            else
            {
                m_IndexInWinnerList++;
            }

            displayImage();
        }

        private void displayImage()
        {
            pictureBoxWinnerPicture.LoadAsync(m_ContestWinners[m_IndexInWinnerList].PictureNormalURL);
            UpdateButtonPrevious();
            UpdateButtonNext();
        }

        private void UpdateButtonPrevious()
        {
            buttonPrevious.Enabled = (m_IndexInWinnerList == 0) ? false : true;
        }

        private void UpdateButtonNext()
        {
            buttonNext.Enabled = (m_IndexInWinnerList == m_ContestWinners.Count - 1) ? false : true;
        }
    }
}
