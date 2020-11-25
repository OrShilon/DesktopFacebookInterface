using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Facebook;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    internal partial class FormContest : Form
    {
        private readonly List<ContestLogic> m_ListOfContests;
        private int m_TabIndex = 0;
        private User m_LoginUser;

        public FormContest(User i_LoginUser)
        {
            m_LoginUser = i_LoginUser;
            m_ListOfContests = new List<ContestLogic>();

            InitializeComponent();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush textBrush;
            TabPage tabPage = tabControlContest.TabPages[e.Index];
            Font tabFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StringFormat stringFlags = new StringFormat();
            stringFlags.Alignment = StringAlignment.Center;
            stringFlags.LineAlignment = StringAlignment.Center;

            if (e.State == DrawItemState.Selected)
            {
                textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                textBrush = new SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            g.DrawString(tabPage.Text, tabFont, textBrush, tabControlContest.GetTabRect(e.Index), new StringFormat(stringFlags));
        }

        private void buttonAddContest_Click(object sender, EventArgs e)
        {
            if(m_TabIndex < 15)
            {
                TabPage tabPageContest = new TabPage();

                if (m_TabIndex == 0)
                {
                    tabPageContest.Padding = new Padding(3);
                }

                FormAddContest newFormContest = new FormAddContest();
                newFormContest.ShowDialog();

                if (newFormContest.DialogResult == DialogResult.OK)
                {
                    ContestLogic newContest = new ContestLogic(
                        m_TabIndex + 1,
                        m_LoginUser,
                        newFormContest.Status,
                        newFormContest.ImagePath,
                        newFormContest.LikeRequired,
                        newFormContest.CommentRequired,
                        newFormContest.NumberOfWinners);
                    m_ListOfContests.Add(newContest);

                    try
                    {
                        newContest.PostContestStatus();
                    }
                    catch (FacebookOAuthException)
                    {
                        MessageBox.Show("Failed to post status: No permissions.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    tabPageContest.Location = new Point(104, 4);
                    tabPageContest.Name = string.Format("tabPageContest{0}", m_TabIndex + 1);
                    tabPageContest.Size = new Size(867, 616);
                    tabPageContest.TabIndex = m_TabIndex;
                    tabPageContest.Text = string.Format("Contest {0}", m_TabIndex + 1);
                    tabPageContest.UseVisualStyleBackColor = true;
                    tabControlContest.Controls.Add(tabPageContest);
                    buildContest(tabPageContest);
                    m_TabIndex++;
                }
            }
            else
            {
                MessageBox.Show("You have reached the maximum number of contests.");
            }
        }

        private void buildContest(TabPage currentTabPage)
        {
            Label labelPost = new Label();
            Label labelParticipants = new Label();
            Label labelPicture = new Label();
            Label labelContestrequirements = new Label();
            CheckBox checkBoxCommentCondition = new CheckBox();
            CheckBox checkBoxLikeCondition = new CheckBox();
            TextBox textBoxDescription = new TextBox();
            PictureBox pictureBoxAttachedImage = new PictureBox();
            ListBox listBoxParticipants = new ListBox();
            Button buttonUpdateParticipants = new Button();
            Button buttonChooseWinner = new Button();
            Button buttonDeleteConstest = new Button();

            buildPostControls(labelPost, textBoxDescription);
            if (m_ListOfContests[m_ListOfContests.Count - 1].m_ImagePath != null)
            {
                buildPictureControls(labelPost, labelPicture, textBoxDescription, pictureBoxAttachedImage);
                currentTabPage.Controls.Add(labelPicture);
                currentTabPage.Controls.Add(pictureBoxAttachedImage);
            }

            buildParticipantsControls(labelParticipants, textBoxDescription, listBoxParticipants, labelContestrequirements, checkBoxCommentCondition);
            buildRequirementsControls(labelParticipants, labelContestrequirements, checkBoxCommentCondition, checkBoxLikeCondition, textBoxDescription, listBoxParticipants);
            buildButtonsControls(listBoxParticipants, buttonUpdateParticipants, buttonChooseWinner, buttonDeleteConstest, labelParticipants);

            currentTabPage.Controls.Add(labelPost);
            currentTabPage.Controls.Add(textBoxDescription);
            currentTabPage.Controls.Add(labelParticipants);
            currentTabPage.Controls.Add(listBoxParticipants);
            currentTabPage.Controls.Add(labelContestrequirements);
            currentTabPage.Controls.Add(checkBoxLikeCondition);
            currentTabPage.Controls.Add(checkBoxCommentCondition);
            currentTabPage.Controls.Add(buttonUpdateParticipants);
            currentTabPage.Controls.Add(buttonChooseWinner);
            currentTabPage.Controls.Add(buttonDeleteConstest);

            tabControlContest.SelectedTab = currentTabPage;
        }

        private void buildPostControls(Label labelPost, TextBox textBoxDescription)
        {
            labelPost.AutoSize = true;
            labelPost.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPost.Location = new Point(10, 10);
            labelPost.Name = string.Format("labelPost{0}", m_ListOfContests.Count);
            labelPost.Size = new Size(195, 25);
            labelPost.Text = "Contest description:";
            labelPost.TabIndex = 0;
            labelPost.TabStop = false;

            textBoxDescription.Location = new Point(labelPost.Location.X, labelPost.Bottom + 10);
            textBoxDescription.Margin = new Padding(2, 2, 2, 2);
            textBoxDescription.Name = string.Format("textBoxContestDescription{0}", m_ListOfContests.Count);
            textBoxDescription.Text = m_ListOfContests[m_ListOfContests.Count - 1].m_Status;
            textBoxDescription.Size = new Size(350, 160);
            textBoxDescription.ScrollBars = ScrollBars.Vertical;
            textBoxDescription.Multiline = true;
            textBoxDescription.WordWrap = true;
            textBoxDescription.ReadOnly = true;
            textBoxDescription.TabIndex = 1;
        }

        private void buildPictureControls(Label labelPost, Label labelPicture, TextBox textBoxDescription, PictureBox pictureBoxAttachedImage)
        {
            pictureBoxAttachedImage.Location = new Point(textBoxDescription.Right + 15, textBoxDescription.Location.Y);
            pictureBoxAttachedImage.Margin = new Padding(5, 6, 5, 6);
            pictureBoxAttachedImage.Name = string.Format("pictureBoxAttachedImage{0}", m_ListOfContests.Count);
            pictureBoxAttachedImage.Size = new Size(200, textBoxDescription.Height);
            pictureBoxAttachedImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxAttachedImage.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxAttachedImage.Image = Image.FromFile(m_ListOfContests[m_ListOfContests.Count - 1].m_ImagePath);
            pictureBoxAttachedImage.TabIndex = 2;
            pictureBoxAttachedImage.TabStop = false;

            labelPicture.Location = new Point(pictureBoxAttachedImage.Location.X, labelPost.Location.Y);
            labelPicture.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPicture.Margin = new Padding(2, 2, 2, 2);
            labelPicture.Name = string.Format("textBoxContestDescription{0}", m_ListOfContests.Count);
            labelPicture.Text = "Image attached to the post:";
            labelPicture.Size = new Size(195, 25);
        }

        private void buildRequirementsControls(Label labelParticipants, Label labelContestrequirements, CheckBox checkBoxCommentCondition, CheckBox checkBoxLikeCondition, TextBox textBoxDescription, ListBox listBoxParticipants)
        {
            labelContestrequirements.AutoSize = true;
            labelContestrequirements.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelContestrequirements.Location = new Point(textBoxDescription.Location.X, textBoxDescription.Bottom + 15);
            labelContestrequirements.Name = string.Format("labelContestrequirements{0}", m_ListOfContests.Count);
            labelContestrequirements.Size = new Size(100, 25);
            labelContestrequirements.Text = "List of requirements:";
            labelContestrequirements.TabIndex = 5;
            labelContestrequirements.TabStop = false;

            checkBoxLikeCondition.AutoSize = true;
            checkBoxLikeCondition.Location = new Point(labelContestrequirements.Location.X, labelContestrequirements.Bottom + 15);
            checkBoxLikeCondition.Name = string.Format("checkBoxLikeCondition{0}", m_ListOfContests.Count);
            checkBoxLikeCondition.Size = new Size(123, 24);
            checkBoxLikeCondition.TabIndex = 6;
            checkBoxLikeCondition.Text = "Require to like my post";
            checkBoxLikeCondition.UseVisualStyleBackColor = true;
            checkBoxLikeCondition.Checked = m_ListOfContests[m_TabIndex].m_LikeRequired;
            checkBoxLikeCondition.Enabled = false;

            checkBoxCommentCondition.AutoSize = true;
            checkBoxCommentCondition.Location = new Point(labelContestrequirements.Location.X, checkBoxLikeCondition.Location.Y +(listBoxParticipants.Height / 2));
            checkBoxCommentCondition.Name = string.Format("checkBoxCommentCondition{0}", m_ListOfContests.Count);
            checkBoxCommentCondition.Size = new Size(163, 24);
            checkBoxCommentCondition.TabIndex = 7;
            checkBoxCommentCondition.Text = "Require to comment my post";
            checkBoxCommentCondition.UseVisualStyleBackColor = true;
            checkBoxCommentCondition.Checked = m_ListOfContests[m_TabIndex].m_CommentRequired;
            checkBoxCommentCondition.Enabled = false;
        }

        private void buildParticipantsControls(Label labelParticipants, TextBox textBoxDescription, ListBox listBoxParticipants, Label labelContestrequirements, CheckBox checkBoxCommentCondition)
        {
            labelParticipants.AutoSize = true;
            labelParticipants.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelParticipants.Location = new Point(checkBoxCommentCondition.Right + labelParticipants.Width - 10, textBoxDescription.Bottom + 15);
            labelParticipants.Name = string.Format("labelParticipants{0}", m_ListOfContests.Count);
            labelParticipants.Size = new Size(100, 25);
            labelParticipants.Text = "List of participants:";
            labelParticipants.TabIndex = 3;
            labelParticipants.TabStop = false;

            listBoxParticipants.FormattingEnabled = true;
            listBoxParticipants.ItemHeight = 20;
            listBoxParticipants.Location = new Point(labelParticipants.Location.X, labelParticipants.Bottom + 10);
            listBoxParticipants.Margin = new Padding(3, 2, 3, 2);
            listBoxParticipants.Name = string.Format("listBoxParticipants{0}", m_ListOfContests.Count);
            listBoxParticipants.Size = new Size(170, 70);
            listBoxParticipants.TabIndex = 4;
        }

        private void buildButtonsControls(ListBox listBoxParticipants, Button buttonUpdateParticipants, Button buttonChooseWinner, Button buttonDeleteConstest, Label labelParticipants)
        {
            buttonUpdateParticipants.Location = new Point(listBoxParticipants.Location.X + (listBoxParticipants.Width / 7) + 3, listBoxParticipants.Bottom + 10);
            buttonUpdateParticipants.Margin = new Padding(5, 6, 5, 6);
            buttonUpdateParticipants.Name = string.Format("buttonUpdateParticipants{0}", m_ListOfContests.Count);
            buttonUpdateParticipants.Size = new Size(120, 35);
            buttonUpdateParticipants.TabIndex = 8;
            buttonUpdateParticipants.Text = "Update participants";
            buttonUpdateParticipants.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonUpdateParticipants.Click += new EventHandler(this.buttonUpdateParticipants_Click);

            buttonChooseWinner.Location = new Point(listBoxParticipants.Right + (buttonChooseWinner.Width / 2), labelParticipants.Bottom);
            buttonChooseWinner.Margin = new Padding(5, 6, 5, 6);
            buttonChooseWinner.Name = string.Format("buttonChooseWinner{0}", m_ListOfContests.Count);
            buttonChooseWinner.Size = new Size(120, 35);
            buttonChooseWinner.TabIndex = 9;
            buttonChooseWinner.BackColor = Color.Green;
            buttonChooseWinner.Text = m_ListOfContests[m_ListOfContests.Count - 1].m_NumberOfWinners < 2 ? "Choose winner" : "Choose winners";
            buttonChooseWinner.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonChooseWinner.Click += new EventHandler(this.buttonChooseWinner_Click);

            buttonDeleteConstest.Location = new Point(buttonChooseWinner.Location.X, buttonUpdateParticipants.Location.Y);
            buttonDeleteConstest.Margin = new Padding(5, 6, 5, 6);
            buttonDeleteConstest.Name = string.Format("buttonDeleteConstest{0}", m_ListOfContests.Count);
            buttonDeleteConstest.Size = new Size(120, 35);
            buttonDeleteConstest.TabIndex = 10;
            buttonDeleteConstest.BackColor = Color.Red;
            buttonDeleteConstest.Text = "Delete contest";
            buttonDeleteConstest.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonDeleteConstest.Click += new EventHandler(this.buttonDeleteConstest_Click);
        }

        private void buttonUpdateParticipants_Click(object sender, EventArgs e)
        {
            Button buttonUpdateParticipants = (Button)sender;
            int index = (buttonUpdateParticipants.Name[buttonUpdateParticipants.Name.Length - 1] - '0') - 1;

            try
            {
                m_ListOfContests[index].UpdateParticipantsList();

                if (m_ListOfContests[index].r_ParticipantsList.Count == 0)
                {
                    MessageBox.Show("No user meets the requirements of your contest.");
                }
            }
            catch (FacebookOAuthException)
            {
                MessageBox.Show("Unable to load. No permission.");
            }
            catch (Exception)
            {
                MessageBox.Show("No user meets the requirements of your contest.");
            }
        }

        private void buttonChooseWinner_Click(object sender, EventArgs e)
        {
            Button buttonWinner = (Button)sender;
            int index = (buttonWinner.Name[buttonWinner.Name.Length - 1] - '0') - 1;
            m_ListOfContests[index].GenerateWinners();

            if(m_ListOfContests[index].r_ContestWinners.Count > 0)
            {
                FormDiplayWinners displayWinners = new FormDiplayWinners(m_ListOfContests[index].r_ContestWinners);
                displayWinners.ShowDialog();
            }
            else
            {
                MessageBox.Show(string.Format("Not enough participants to choose {0}.", m_ListOfContests[index].m_NumberOfWinners > 1 ? "winners" : "winner"));
            }
        }

        private void buttonDeleteConstest_Click(object sender, EventArgs e)
        {
            Button buttonDelete = (Button)sender;
            TabPage tabPageToDelete = buttonDelete.Parent as TabPage;

            tabControlContest.TabPages.Remove(tabPageToDelete);
            m_ListOfContests.RemoveAt((buttonDelete.Name[buttonDelete.Name.Length - 1] - '0') - 1);

            handleIndexesAfterDelete();
        }

        private void handleIndexesAfterDelete()
        {
            int index = 1;

            foreach(TabPage tabPage in tabControlContest.TabPages)
            {
                if(tabPage.Name.Length > this.tabControlContest.TabPages[0].Name.Length) 
                {
                    tabPage.Name = tabPage.Name.Substring(0, tabPage.Name.Length - 2) + index;
                    tabPage.Text = tabPage.Text.Substring(0, tabPage.Text.Length - 2) + index;
                }
                else
                {
                    tabPage.Name = tabPage.Name.Substring(0, tabPage.Name.Length - 1) + index;
                    tabPage.Text = tabPage.Text.Substring(0, tabPage.Text.Length - 1) + index;
                }

                int controlIterator = 0;

                foreach (Control control in tabPage.Controls)
                {
                    
                    if (control.Name.Length > this.tabControlContest.TabPages[0].Controls[controlIterator].Name.Length)
                    {
                        control.Name = control.Name.Substring(0, control.Name.Length - 2) + index;
                    }
                    else
                    {
                        control.Name = control.Name.Substring(0, control.Name.Length - 1) + index;
                    }

                    controlIterator++;

                }

                index++;
            }

                m_TabIndex--;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}
