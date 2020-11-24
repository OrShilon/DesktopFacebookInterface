﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopFacebookInterface
{
    internal partial class FormAddContest : Form
    {
        private string m_ContestDescription = string.Empty;
        private string m_AttachedImagePath = null;
        private bool m_LikeRequired = false;
        private bool m_CommentRequired = false;
        private int m_NumberOfWinnersCondition = -1;
        private string m_MissingDetails = string.Empty;

        public FormAddContest()
        {
            InitializeComponent();
            textBoxContestDetails.Text = string.Empty;
            for(int i = 1; i < 11; i++)
            {
                comboBoxNumOfWinners.Items.Add(i);
            }
        }

        private void linkLabelAttachImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files *.BMP*;*.JPG*;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                m_AttachedImagePath = ofd.FileName;
            }
        }

        private void buttonStartContest_Click(object sender, EventArgs e)
        {
            if ((m_ContestDescription = textBoxContestDetails.Text).Equals(string.Empty))
            {
                m_MissingDetails = string.Format("Missing constest description.{0}", Environment.NewLine);
            }

            if ((m_LikeRequired = checkBoxLikes.Checked) == false && (m_CommentRequired = checkBoxComments.Checked) == false)
            {
                m_MissingDetails += string.Format("You need to choose at least on option of the requirements.{0}", Environment.NewLine);
            }
            else
            {
                m_CommentRequired = checkBoxComments.Checked;
            }

            if ((m_NumberOfWinnersCondition = comboBoxNumOfWinners.SelectedIndex) == -1)
            {
                m_MissingDetails += string.Format("You need to choose the number of winners.");
            }

            if (string.IsNullOrEmpty(m_MissingDetails))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(m_MissingDetails);
                m_MissingDetails = string.Empty;
            }
        }

        public string Status
        {
            get
            {
                return m_ContestDescription;
            }
        }

        public string ImagePath
        {
            get
            {
                return m_AttachedImagePath;
            }
        }

        public bool LikeRequired
        {
            get
            {
                return m_LikeRequired;
            }
        }

        public bool CommentRequired
        {
            get
            {
                return m_CommentRequired;
            }
        }

        public int NumberOfWinners
        {
            get
            {
                return m_NumberOfWinnersCondition + 1; // index 0 --> 1 winner, index 1 --> 2 winners.........
            }
        }
    }
}
