using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Facebook;
using DesktopFacebookInterface.Logic;
using DesktopFacebookInterface.ContestFactoryMethod;

namespace DesktopFacebookInterface.UI
{
    internal partial class FormContest : Form
    {
        private const int k_MaxNumberOfContests = 15;
        private readonly List<IContest> m_ListOfContests;
        private int m_TabIndex = 0;
        private ReportDeletedContestDelegate m_ReportDeletedContestDelegate;


        public FormContest()
        {
            m_ListOfContests = new List<IContest>();

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
            if(m_TabIndex < k_MaxNumberOfContests)
            {
                TabPageObserver tabPageContest = new TabPageObserver();

                if (m_TabIndex == 0)
                {
                    tabPageContest.Padding = new Padding(3);
                }

                FormAddContest newFormContest = new FormAddContest();
                newFormContest.ShowDialog();

                if (newFormContest.DialogResult == DialogResult.OK)
                {
                    IContest newContest = ContestFactory.CreateContest(
                        m_TabIndex + 1,
                        newFormContest.Status,
                        newFormContest.ImagePath,
                        newFormContest.NumberOfWinners,
                        newFormContest.LikeRequired,
                        newFormContest.CommentRequired);
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

                    m_ReportDeletedContestDelegate += tabPageContest.m_ReportDeletedContestObserver;
                }
            }
            else
            {
                MessageBox.Show("You have reached the maximum number of contests.");
            }
        }

        private void buildContest(TabPageObserver i_CurrentTabPage)
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
                i_CurrentTabPage.Controls.Add(labelPicture);
                i_CurrentTabPage.Controls.Add(pictureBoxAttachedImage);
            }

            buildParticipantsControls(labelParticipants, textBoxDescription, listBoxParticipants, labelContestrequirements, checkBoxCommentCondition);
            buildRequirementsControls(labelParticipants, labelContestrequirements, checkBoxCommentCondition, checkBoxLikeCondition, textBoxDescription, listBoxParticipants);
            updateRequirementsCheckBoxes(m_ListOfContests[m_ListOfContests.Count - 1], checkBoxCommentCondition, checkBoxLikeCondition);
            buildButtonsControls(listBoxParticipants, buttonUpdateParticipants, buttonChooseWinner, buttonDeleteConstest, labelParticipants);

            i_CurrentTabPage.Controls.Add(labelPost);
            i_CurrentTabPage.Controls.Add(textBoxDescription);
            i_CurrentTabPage.Controls.Add(labelParticipants);
            i_CurrentTabPage.Controls.Add(listBoxParticipants);
            i_CurrentTabPage.Controls.Add(labelContestrequirements);
            i_CurrentTabPage.Controls.Add(checkBoxLikeCondition);
            i_CurrentTabPage.Controls.Add(checkBoxCommentCondition);
            i_CurrentTabPage.Controls.Add(buttonUpdateParticipants);
            i_CurrentTabPage.Controls.Add(buttonChooseWinner);
            i_CurrentTabPage.Controls.Add(buttonDeleteConstest);

            tabControlContest.SelectedTab = i_CurrentTabPage;
        }

        private void buildPostControls(Label i_LabelPost, TextBox i_TextBoxDescription)
        {
            i_LabelPost.AutoSize = true;
            i_LabelPost.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            i_LabelPost.Location = new Point(10, 10);
            i_LabelPost.Name = string.Format("labelPost{0}", m_ListOfContests.Count);
            i_LabelPost.Size = new Size(195, 25);
            i_LabelPost.Text = "Contest description:";
            i_LabelPost.TabIndex = 0;
            i_LabelPost.TabStop = false;

            i_TextBoxDescription.Location = new Point(i_LabelPost.Location.X, i_LabelPost.Bottom + 10);
            i_TextBoxDescription.Margin = new Padding(2, 2, 2, 2);
            i_TextBoxDescription.Name = string.Format("textBoxContestDescription{0}", m_ListOfContests.Count);
            i_TextBoxDescription.Text = m_ListOfContests[m_ListOfContests.Count - 1].m_Status;
            i_TextBoxDescription.Size = new Size(350, 160);
            i_TextBoxDescription.ScrollBars = ScrollBars.Vertical;
            i_TextBoxDescription.Multiline = true;
            i_TextBoxDescription.WordWrap = true;
            i_TextBoxDescription.ReadOnly = true;
            i_TextBoxDescription.TabIndex = 1;
        }

        private void buildPictureControls(Label i_LabelPost, Label i_LabelPicture, TextBox i_TextBoxDescription, PictureBox i_PictureBoxAttachedImage)
        {
            i_PictureBoxAttachedImage.Location = new Point(i_TextBoxDescription.Right + 15, i_TextBoxDescription.Location.Y);
            i_PictureBoxAttachedImage.Margin = new Padding(5, 6, 5, 6);
            i_PictureBoxAttachedImage.Name = string.Format("pictureBoxAttachedImage{0}", m_ListOfContests.Count);
            i_PictureBoxAttachedImage.Size = new Size(200, i_TextBoxDescription.Height);
            i_PictureBoxAttachedImage.SizeMode = PictureBoxSizeMode.StretchImage;
            i_PictureBoxAttachedImage.BorderStyle = BorderStyle.FixedSingle;
            i_PictureBoxAttachedImage.Image = Image.FromFile(m_ListOfContests[m_ListOfContests.Count - 1].m_ImagePath);
            i_PictureBoxAttachedImage.TabIndex = 2;
            i_PictureBoxAttachedImage.TabStop = false;

            i_LabelPicture.Location = new Point(i_PictureBoxAttachedImage.Location.X, i_LabelPost.Location.Y);
            i_LabelPicture.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            i_LabelPicture.Margin = new Padding(2, 2, 2, 2);
            i_LabelPicture.Name = string.Format("textBoxContestDescription{0}", m_ListOfContests.Count);
            i_LabelPicture.Text = "Image attached to the post:";
            i_LabelPicture.Size = new Size(195, 25);
        }

        private void buildRequirementsControls(Label i_LabelParticipants, Label i_LabelContestRequirements, CheckBox i_CheckBoxCommentCondition, CheckBox i_CheckBoxLikeCondition, TextBox i_TextBoxDescription, ListBox i_ListBoxParticipants)
        {
            i_LabelContestRequirements.AutoSize = true;
            i_LabelContestRequirements.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            i_LabelContestRequirements.Location = new Point(i_TextBoxDescription.Location.X, i_TextBoxDescription.Bottom + 15);
            i_LabelContestRequirements.Name = string.Format("labelContestrequirements{0}", m_ListOfContests.Count);
            i_LabelContestRequirements.Size = new Size(100, 25);
            i_LabelContestRequirements.Text = "List of requirements:";
            i_LabelContestRequirements.TabIndex = 5;
            i_LabelContestRequirements.TabStop = false;

            i_CheckBoxLikeCondition.AutoSize = true;
            i_CheckBoxLikeCondition.Location = new Point(i_LabelContestRequirements.Location.X, i_LabelContestRequirements.Bottom + 15);
            i_CheckBoxLikeCondition.Name = string.Format("checkBoxLikeCondition{0}", m_ListOfContests.Count);
            i_CheckBoxLikeCondition.Size = new Size(123, 24);
            i_CheckBoxLikeCondition.TabIndex = 6;
            i_CheckBoxLikeCondition.Text = "Require to like my post";
            i_CheckBoxLikeCondition.UseVisualStyleBackColor = true;
            i_CheckBoxLikeCondition.Enabled = false;

            i_CheckBoxCommentCondition.AutoSize = true;
            i_CheckBoxCommentCondition.Location = new Point(i_LabelContestRequirements.Location.X, i_CheckBoxLikeCondition.Location.Y + (i_ListBoxParticipants.Height / 2));
            i_CheckBoxCommentCondition.Name = string.Format("checkBoxCommentCondition{0}", m_ListOfContests.Count);
            i_CheckBoxCommentCondition.Size = new Size(163, 24);
            i_CheckBoxCommentCondition.TabIndex = 7;
            i_CheckBoxCommentCondition.Text = "Require to comment my post";
            i_CheckBoxCommentCondition.UseVisualStyleBackColor = true;
            i_CheckBoxCommentCondition.Enabled = false;
        }

        private void buildParticipantsControls(Label i_LabelParticipants, TextBox i_TextBoxDescription, ListBox i_ListBoxParticipants, Label i_LabelContestRequirements, CheckBox i_CheckBoxCommentCondition)
        {
            i_LabelParticipants.AutoSize = true;
            i_LabelParticipants.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            i_LabelParticipants.Location = new Point(i_CheckBoxCommentCondition.Right + i_LabelParticipants.Width - 10, i_TextBoxDescription.Bottom + 15);
            i_LabelParticipants.Name = string.Format("labelParticipants{0}", m_ListOfContests.Count);
            i_LabelParticipants.Size = new Size(100, 25);
            i_LabelParticipants.Text = "List of participants:";
            i_LabelParticipants.TabIndex = 3;
            i_LabelParticipants.TabStop = false;

            i_ListBoxParticipants.FormattingEnabled = true;
            i_ListBoxParticipants.ItemHeight = 20;
            i_ListBoxParticipants.Location = new Point(i_LabelParticipants.Location.X, i_LabelParticipants.Bottom + 10);
            i_ListBoxParticipants.Margin = new Padding(3, 2, 3, 2);
            i_ListBoxParticipants.Name = string.Format("listBoxParticipants{0}", m_ListOfContests.Count);
            i_ListBoxParticipants.Size = new Size(170, 70);
            i_ListBoxParticipants.TabIndex = 4;
        }

        private void buildButtonsControls(ListBox i_ListBoxParticipants, Button i_ButtonUpdateParticipants, Button i_ButtonChooseWinner, Button i_ButtonDeleteContest, Label i_LabelParticipants)
        {
            i_ButtonUpdateParticipants.Location = new Point(i_ListBoxParticipants.Location.X + (i_ListBoxParticipants.Width / 7) + 3, i_ListBoxParticipants.Bottom + 10);
            i_ButtonUpdateParticipants.Margin = new Padding(5, 6, 5, 6);
            i_ButtonUpdateParticipants.Name = string.Format("buttonUpdateParticipants{0}", m_ListOfContests.Count);
            i_ButtonUpdateParticipants.Size = new Size(120, 35);
            i_ButtonUpdateParticipants.TabIndex = 8;
            i_ButtonUpdateParticipants.Text = "Update participants";
            i_ButtonUpdateParticipants.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            i_ButtonUpdateParticipants.Click += new EventHandler(this.buttonUpdateParticipants_Click);

            i_ButtonChooseWinner.Location = new Point(i_ListBoxParticipants.Right + (i_ButtonChooseWinner.Width / 2), i_LabelParticipants.Bottom);
            i_ButtonChooseWinner.Margin = new Padding(5, 6, 5, 6);
            i_ButtonChooseWinner.Name = string.Format("buttonChooseWinner{0}", m_ListOfContests.Count);
            i_ButtonChooseWinner.Size = new Size(120, 35);
            i_ButtonChooseWinner.TabIndex = 9;
            i_ButtonChooseWinner.BackColor = Color.Green;
            i_ButtonChooseWinner.Text = m_ListOfContests[m_ListOfContests.Count - 1].m_NumberOfWinners < 2 ? "Choose winner" : "Choose winners";
            i_ButtonChooseWinner.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            i_ButtonChooseWinner.Click += new EventHandler(this.buttonChooseWinner_Click);

            i_ButtonDeleteContest.Location = new Point(i_ButtonChooseWinner.Location.X, i_ButtonUpdateParticipants.Location.Y);
            i_ButtonDeleteContest.Margin = new Padding(5, 6, 5, 6);
            i_ButtonDeleteContest.Name = string.Format("buttonDeleteConstest{0}", m_ListOfContests.Count);
            i_ButtonDeleteContest.Size = new Size(120, 35);
            i_ButtonDeleteContest.TabIndex = 10;
            i_ButtonDeleteContest.BackColor = Color.Red;
            i_ButtonDeleteContest.Text = "Delete contest";
            i_ButtonDeleteContest.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            i_ButtonDeleteContest.Click += new EventHandler(this.buttonDeleteConstest_Click);
        }

        private void updateRequirementsCheckBoxes(IContest i_Contest, CheckBox i_CheckBoxCommentCondition, CheckBox i_CheckBoxLikeCondition)
        {
            if(i_Contest is ContestByLikes)
            {
                i_CheckBoxLikeCondition.Checked = true;
                i_CheckBoxCommentCondition.Checked = false;
            }

            if(i_Contest is ContestByComments)
            {
                i_CheckBoxLikeCondition.Checked = false;
                i_CheckBoxCommentCondition.Checked = true;
            }

            if(i_Contest is ContestByLikesAndComments)
            {
                i_CheckBoxLikeCondition.Checked = true;
                i_CheckBoxCommentCondition.Checked = true;
            }
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
            TabPageObserver tabPageToDelete = buttonDelete.Parent as TabPageObserver;

            m_ReportDeletedContestDelegate -= tabPageToDelete.m_ReportDeletedContestObserver;
            m_TabIndex--;
            tabControlContest.TabPages.Remove(tabPageToDelete);
            m_ListOfContests.RemoveAt((buttonDelete.Name[buttonDelete.Name.Length - 1] - '0') - 1);

            m_ReportDeletedContestDelegate.Invoke(int.Parse(tabPageToDelete.Text.Split(' ')[1]));
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
