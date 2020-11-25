using System;
using System.Text;
using System.Windows.Forms;

namespace DesktopFacebookInterface
{
    internal partial class FormAddContest : Form
    {
        private string m_contestDescription = string.Empty;
        private string m_attachedImagePath = null;
        private bool m_likeRequired = false;
        private bool m_commentRequired = false;
        private int m_numberOfWinnersCondition = -1;
        private string m_missingDetails = string.Empty;
        private const int k_maxNumberOfWinnersAllowed = 10;
        private const string k_attachedFileTypeFilter = "Image Files *.BMP*;*.JPG*;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";

        public FormAddContest()
        {
            InitializeComponent();
            textBoxContestDetails.Text = string.Empty;

            for(int i = 1; i < k_maxNumberOfWinnersAllowed + 1; i++) // +1 because i starts at 1
            {
                comboBoxNumOfWinners.Items.Add(i);
            }
        }

        private void linkLabelAttachImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = k_attachedFileTypeFilter;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                m_attachedImagePath = ofd.FileName;
            }
        }

        private void buttonStartContest_Click(object sender, EventArgs e)
        {
            StringBuilder missingDetails = new StringBuilder();

            if ((m_contestDescription = textBoxContestDetails.Text).Equals(string.Empty))
            {
                missingDetails.Append(string.Format("Missing constest description.{0}", Environment.NewLine));
            }

            if ((m_likeRequired = checkBoxLikes.Checked) == false && (m_commentRequired = checkBoxComments.Checked) == false)
            {
                missingDetails.Append(string.Format("You need to choose at least on option of the requirements.{0}", Environment.NewLine));
            }
            else
            {
                m_commentRequired = checkBoxComments.Checked;
            }

            if ((m_numberOfWinnersCondition = comboBoxNumOfWinners.SelectedIndex) == -1)
            {
                missingDetails.Append(string.Format("You need to choose the number of winners."));
            }

            m_missingDetails = missingDetails.ToString();

            if (string.IsNullOrEmpty(m_missingDetails))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(m_missingDetails);
                m_missingDetails = string.Empty;
            }
        }

        public string Status
        {
            get
            {
                return m_contestDescription;
            }
        }

        public string ImagePath
        {
            get
            {
                return m_attachedImagePath;
            }
        }

        public bool LikeRequired
        {
            get
            {
                return m_likeRequired;
            }
        }

        public bool CommentRequired
        {
            get
            {
                return m_commentRequired;
            }
        }

        public int NumberOfWinners
        {
            get
            {
                return m_numberOfWinnersCondition + 1; // index 0 --> 1 winner, index 1 --> 2 winners.........
            }
        }
    }
}
