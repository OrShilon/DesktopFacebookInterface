using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface.UI
{
    internal partial class FormDiplayWinners : Form
    {
        private readonly List<User> r_ContestWinners;
        private int m_IndexInWinnerList = 0;

        public FormDiplayWinners(List<User> i_ContestWinners)
        {
            r_ContestWinners = i_ContestWinners;
            InitializeComponent();
            initWinners();
        }

        private void initWinners()
        {
            labelNumOfWinner.Text = string.Format("Winner number: {0}", m_IndexInWinnerList + 1);
            labelvWinnerName.Text = string.Format("Full name: {0}", r_ContestWinners[m_IndexInWinnerList].Name);
            pictureBoxWinnerPicture.LoadAsync(r_ContestWinners[m_IndexInWinnerList].PictureNormalURL);
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (m_IndexInWinnerList == 0)
            {
                m_IndexInWinnerList = r_ContestWinners.Count - 1;
            }
            else
            {
                m_IndexInWinnerList--;
            }

            displayImage();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (m_IndexInWinnerList == r_ContestWinners.Count - 1)
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
            pictureBoxWinnerPicture.LoadAsync(r_ContestWinners[m_IndexInWinnerList].PictureNormalURL);
            updateButtonPrevious();
            updateButtonNext();
        }

        private void updateButtonPrevious()
        {
            buttonPrevious.Enabled = (m_IndexInWinnerList == 0) ? false : true;
        }

        private void updateButtonNext()
        {
            buttonNext.Enabled = (m_IndexInWinnerList == r_ContestWinners.Count - 1) ? false : true;
        }
    }
}
