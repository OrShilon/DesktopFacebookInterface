using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    internal partial class FormDiplayWinners : Form
    {
        private readonly List<User> m_contestWinners;
        private int m_indexInWinnerList = 0;

        public FormDiplayWinners(List<User> i_ContestWinners)
        {
            m_contestWinners = i_ContestWinners;
            InitializeComponent();
            initWinners();
        }

        private void initWinners()
        {
            labelNumOfWinner.Text = string.Format("Winner number: {0}", m_indexInWinnerList + 1);
            labelvWinnerName.Text = string.Format("Full name: {0}", m_contestWinners[m_indexInWinnerList].Name);
            pictureBoxWinnerPicture.LoadAsync(m_contestWinners[m_indexInWinnerList].PictureNormalURL);
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (m_indexInWinnerList == 0)
            {
                m_indexInWinnerList = m_contestWinners.Count - 1;
            }
            else
            {
                m_indexInWinnerList--;
            }

            displayImage();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (m_indexInWinnerList == m_contestWinners.Count - 1)
            {
                m_indexInWinnerList = 0;
            }
            else
            {
                m_indexInWinnerList++;
            }

            displayImage();
        }

        private void displayImage()
        {
            pictureBoxWinnerPicture.LoadAsync(m_contestWinners[m_indexInWinnerList].PictureNormalURL);
            updateButtonPrevious();
            updateButtonNext();
        }

        private void updateButtonPrevious()
        {
            buttonPrevious.Enabled = (m_indexInWinnerList == 0) ? false : true;
        }

        private void updateButtonNext()
        {
            buttonNext.Enabled = (m_indexInWinnerList == m_contestWinners.Count - 1) ? false : true;
        }
    }
}
