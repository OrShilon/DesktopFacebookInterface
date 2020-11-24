﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            InitializeComponent();
            m_ListOfContests = new List<ContestLogic>();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControlContest.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControlContest.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                //g.FillRectangle(Brushes.White, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", 10.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void buttonAddContest_Click(object sender, EventArgs e)
        {
            TabPage tabPageContest = new TabPage();

            if (m_TabIndex == 0)
            {
                tabPageContest.Padding = new Padding(3);
            }

            FormAddContest newFormContest = new FormAddContest();
            newFormContest.ShowDialog();

            if(newFormContest.DialogResult == DialogResult.OK)
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
            else if(newFormContest.DialogResult == DialogResult.Cancel)
            {
                // missing code
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

            labelPost.AutoSize = true;
            labelPost.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPost.Location = new Point(10, 10);
            labelPost.Name = "labelPost";
            labelPost.Size = new Size(195, 25);
            labelPost.Text = "Contest description:";
            labelPost.TabIndex = 0;
            labelPost.TabStop = false;

            textBoxDescription.Location = new Point(labelPost.Location.X, labelPost.Bottom + 10);
            textBoxDescription.Margin = new Padding(2, 2, 2, 2);
            textBoxDescription.Name = "textBoxContestDescription";
            textBoxDescription.Text = m_ListOfContests[m_ListOfContests.Count - 1].m_Status;
            textBoxDescription.Size = new Size(350, 160);
            textBoxDescription.ScrollBars = ScrollBars.Vertical;
            textBoxDescription.Multiline = true;
            textBoxDescription.WordWrap = true;
            textBoxDescription.ReadOnly = true;
            textBoxDescription.TabIndex = 1;

            if(m_ListOfContests[m_ListOfContests.Count - 1].m_ImagePath != null)
            {
                pictureBoxAttachedImage.Location = new Point(textBoxDescription.Right + 15, textBoxDescription.Location.Y);
                pictureBoxAttachedImage.Margin = new Padding(5, 6, 5, 6);
                pictureBoxAttachedImage.Name = "pictureBoxAttachedImage";
                pictureBoxAttachedImage.Size = new Size(200, textBoxDescription.Height);
                pictureBoxAttachedImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxAttachedImage.BorderStyle = BorderStyle.FixedSingle;
                pictureBoxAttachedImage.Image = Image.FromFile(m_ListOfContests[m_ListOfContests.Count - 1].m_ImagePath);
                pictureBoxAttachedImage.TabIndex = 2;
                pictureBoxAttachedImage.TabStop = false;

                labelPicture.Location = new Point(pictureBoxAttachedImage.Location.X, labelPost.Location.Y);
                labelPicture.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
                labelPicture.Margin = new Padding(2, 2, 2, 2);
                labelPicture.Name = "textBoxContestDescription";
                labelPicture.Text = "Image attached to the post:";
                labelPicture.Size = new Size(195, 25);

                currentTabPage.Controls.Add(labelPicture);
                currentTabPage.Controls.Add(pictureBoxAttachedImage);
            }

            labelParticipants.AutoSize = true;
            labelParticipants.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelParticipants.Location = new Point(textBoxDescription.Location.X, textBoxDescription.Bottom + 15);
            labelParticipants.Name = "labelParticipants";
            labelParticipants.Size = new Size(100, 25);
            labelParticipants.Text = "List of participants:";
            labelParticipants.TabIndex = 3;
            labelParticipants.TabStop = false;

            listBoxParticipants.FormattingEnabled = true;
            listBoxParticipants.ItemHeight = 20;
            listBoxParticipants.Location = new Point(textBoxDescription.Location.X, labelParticipants.Bottom + 10);
            listBoxParticipants.Margin = new Padding(3, 2, 3, 2);
            listBoxParticipants.Name = "listBoxParticipants";
            listBoxParticipants.Size = new Size(220, 100);
            listBoxParticipants.TabIndex = 4;

            labelContestrequirements.AutoSize = true;
            labelContestrequirements.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelContestrequirements.Location = new Point(textBoxDescription.Right - labelContestrequirements.Width, labelParticipants.Location.Y);
            labelContestrequirements.Name = "labelContestrequirements";
            labelContestrequirements.Size = new Size(100, 25);
            labelContestrequirements.Text = "List of requirements:";
            labelContestrequirements.TabIndex = 5;
            labelContestrequirements.TabStop = false;

            checkBoxLikeCondition.AutoSize = true;
            checkBoxLikeCondition.Location = new Point(labelContestrequirements.Location.X, listBoxParticipants.Bottom - (int)(listBoxParticipants.Height / 1.5));
            checkBoxLikeCondition.Name = "checkBoxLikeCondition";
            checkBoxLikeCondition.Size = new Size(123, 24);
            checkBoxLikeCondition.TabIndex = 6;
            checkBoxLikeCondition.Text = "Like my post";
            checkBoxLikeCondition.UseVisualStyleBackColor = true;
            checkBoxLikeCondition.Checked = m_ListOfContests[m_TabIndex].m_LikeRequired;
            checkBoxLikeCondition.Enabled = false;

            checkBoxCommentCondition.AutoSize = true;
            checkBoxCommentCondition.Location = new Point(checkBoxLikeCondition.Right + 15, checkBoxLikeCondition.Location.Y);
            checkBoxCommentCondition.Name = "checkBoxCommentCondition";
            checkBoxCommentCondition.Size = new Size(163, 24);
            checkBoxCommentCondition.TabIndex = 7;
            checkBoxCommentCondition.Text = "Comment my post";
            checkBoxCommentCondition.UseVisualStyleBackColor = true;
            checkBoxCommentCondition.Checked = m_ListOfContests[m_TabIndex].m_CommentRequired;
            checkBoxCommentCondition.Enabled = false;

            buttonUpdateParticipants.Location = new Point(listBoxParticipants.Left + (listBoxParticipants.Width / 4), listBoxParticipants.Bottom + 10);
            buttonUpdateParticipants.Margin = new Padding(5, 6, 5, 6);
            buttonUpdateParticipants.Name = string.Format("buttonUpdateParticipants{0}", m_ListOfContests.Count);
            buttonUpdateParticipants.Size = new Size(120, 35);
            buttonUpdateParticipants.TabIndex = 8;
            buttonUpdateParticipants.Text = "Update participants";
            buttonUpdateParticipants.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            //buttonUpdateParticipants.UseVisualStyleBackColor = true;
            buttonUpdateParticipants.Click += new EventHandler(this.buttonUpdateParticipants_Click);

            buttonChooseWinner.Location = new Point(buttonUpdateParticipants.Right + (buttonUpdateParticipants.Width / 4), buttonUpdateParticipants.Location.Y);
            buttonChooseWinner.Margin = new Padding(5, 6, 5, 6);
            buttonChooseWinner.Name = string.Format("buttonChooseWinner{0}", m_ListOfContests.Count);
            buttonChooseWinner.Size = new Size(120, 35);
            buttonChooseWinner.TabIndex = 9;
            buttonChooseWinner.BackColor = Color.Green;
            buttonChooseWinner.Text = m_ListOfContests[m_ListOfContests.Count - 1].m_NumberOfWinners < 2 ? "Choose winner" : "Choose winners";
            buttonChooseWinner.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            //buttonChooseWinner.UseVisualStyleBackColor = true;
            buttonChooseWinner.Click += new EventHandler(this.buttonChooseWinner_Click);

            buttonDeleteConstest.Location = new Point(buttonChooseWinner.Right + (buttonChooseWinner.Width / 4), buttonChooseWinner.Location.Y);
            buttonDeleteConstest.Margin = new Padding(5, 6, 5, 6);
            buttonDeleteConstest.Name = string.Format("buttonDeleteConstest{0}", m_ListOfContests.Count);
            buttonDeleteConstest.Size = new Size(120, 35);
            buttonDeleteConstest.TabIndex = 10;
            buttonDeleteConstest.BackColor = Color.Red;
            buttonDeleteConstest.Text = "Delete contest";
            buttonDeleteConstest.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            //buttonDeleteConstest.UseVisualStyleBackColor = true;
            buttonDeleteConstest.Click += new EventHandler(this.buttonDeleteConstest_Click);

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

        private void buttonUpdateParticipants_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int index = (button.Name[button.Name.Length - 1] - '0') - 1;

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
            Button button = (Button)sender;
            int index = (button.Name[button.Name.Length - 1] - '0') - 1;
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
            Button button = (Button)sender;
            TabPage tabPageToDelete = button.Parent as TabPage;
            tabControlContest.TabPages.Remove(tabPageToDelete);

            if (m_TabIndex == 1)
            {
                m_TabIndex--;
            }
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
