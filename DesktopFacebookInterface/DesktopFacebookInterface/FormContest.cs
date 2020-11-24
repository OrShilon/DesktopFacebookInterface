using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    public partial class FormContest : Form
    {
        private int m_TabIndex = 0;
        User m_LoginUser;
        private readonly List<ContestLogic> m_ListOfContests;
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

            FormAddContest newFormConstest = new FormAddContest();
            newFormConstest.ShowDialog();
            if(newFormConstest.DialogResult == DialogResult.OK)
            {
                ContestLogic newContest = new ContestLogic(m_LoginUser, newFormConstest.Status, newFormConstest.ImagePath,
                    newFormConstest.LikeCondition, newFormConstest.CommentCondition, newFormConstest.NumberOfWinners);
                m_ListOfContests.Add(newContest);
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
            else if(newFormConstest.DialogResult == DialogResult.Cancel)
            {

            }
        }

        private void buildContest(TabPage currentTabPage)
        {
            Label labelPost = new Label();
            Label labelParticipants = new Label();
            Label labelDescription = new Label();
            Label labelPicture = new Label();
            PictureBox pictureBoxAttachedImage = new PictureBox();
            ListBox listBoxParticipants = new ListBox();
            Button buttonUpdateParticipants = new Button();
            Button buttonChooseWinner = new Button();

            labelPost.AutoSize = true;
            labelPost.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPost.Location = new Point(10, 10);
            labelPost.Name = "labelPost";
            labelPost.Size = new Size(195, 25);
            labelPost.Text = "Contest description:";
            labelPost.TabIndex = 0;
            labelPost.TabStop = false;

            labelDescription.Location = new Point(labelPost.Location.X, labelPost.Bottom + 20);
            labelDescription.Margin = new Padding(2, 2, 2, 2);
            labelDescription.Name = "textBoxContestDescription";
            labelDescription.Text = m_ListOfContests[m_ListOfContests.Count - 1].m_Status;
            labelDescription.Size = new Size(350, 160);
            labelDescription.BorderStyle = BorderStyle.FixedSingle;
            labelDescription.TabIndex = 1;

            if(m_ListOfContests[m_ListOfContests.Count - 1].m_ImagePath != null)
            {
                pictureBoxAttachedImage.Location = new Point(labelDescription.Right + 15, labelDescription.Location.Y);
                pictureBoxAttachedImage.Margin = new Padding(5, 6, 5, 6);
                pictureBoxAttachedImage.Name = "pictureBoxAttachedImage";
                pictureBoxAttachedImage.Size = new Size(200, labelDescription.Height);
                pictureBoxAttachedImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxAttachedImage.Image = Image.FromFile(m_ListOfContests[m_ListOfContests.Count - 1].m_ImagePath);
                pictureBoxAttachedImage.TabIndex = 2;
                pictureBoxAttachedImage.TabStop = false;

                labelPicture.Location = new Point(pictureBoxAttachedImage.Location.X ,labelPost.Location.Y);
                labelPicture.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelPicture.Margin = new Padding(2, 2, 2, 2);
                labelPicture.Name = "textBoxContestDescription";
                labelPicture.Text = "Image attached to the post:";
                labelPicture.Size = new Size(195, 25);

                currentTabPage.Controls.Add(labelPicture);
                currentTabPage.Controls.Add(pictureBoxAttachedImage);
            }

            labelParticipants.AutoSize = true;
            labelParticipants.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelParticipants.Location = new Point(labelDescription.Location.X, labelDescription.Bottom + 15);
            labelParticipants.Name = "labelParticipants";
            labelParticipants.Size = new Size(100, 25);
            labelParticipants.Text = "List of participants:";
            labelParticipants.TabIndex = 3;
            labelParticipants.TabStop = false;

            listBoxParticipants.FormattingEnabled = true;
            listBoxParticipants.ItemHeight = 20;
            listBoxParticipants.Location = new Point(labelDescription.Location.X, labelParticipants.Bottom + 20);
            listBoxParticipants.Margin = new Padding(3, 2, 3, 2);
            listBoxParticipants.Name = "listBoxParticipants";
            listBoxParticipants.Size = new Size(220, 100);
            listBoxParticipants.TabIndex = 4;

            buttonUpdateParticipants.Location = new Point(listBoxParticipants.Right + 40, (listBoxParticipants.Bottom - listBoxParticipants.Height / 2) - buttonUpdateParticipants.Height / 2);
            buttonUpdateParticipants.Margin = new Padding(5, 6, 5, 6);
            buttonUpdateParticipants.Name = string.Format("buttonUpdateParticipants{0}", m_ListOfContests.Count);
            buttonUpdateParticipants.Size = new Size(120, 35);
            buttonUpdateParticipants.TabIndex = 5;
            buttonUpdateParticipants.Text = "Update participants";
            buttonUpdateParticipants.Font = new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonUpdateParticipants.UseVisualStyleBackColor = true;
            buttonUpdateParticipants.Click += new EventHandler(this.buttonUpdateParticipants_Click);

            buttonChooseWinner.Location = new Point(buttonUpdateParticipants.Right + 25, buttonUpdateParticipants.Location.Y);
            buttonChooseWinner.Margin = new Padding(5, 6, 5, 6);
            buttonChooseWinner.Name = "buttonChooseWinner";
            buttonChooseWinner.Size = new Size(120, 35);
            buttonChooseWinner.TabIndex = 6;
            buttonChooseWinner.Text = m_ListOfContests[m_ListOfContests.Count - 1].m_NumberOfWinners < 2 ? "Choose winner" : "Choose winners";
            buttonChooseWinner.Font = new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonChooseWinner.UseVisualStyleBackColor = true;
            //buttonUpdateParticipants.Click += new System.EventHandler(this.buttonLogout_Click);



            currentTabPage.Controls.Add(labelPost);
            currentTabPage.Controls.Add(labelDescription);
            currentTabPage.Controls.Add(labelParticipants);
            currentTabPage.Controls.Add(listBoxParticipants);
            currentTabPage.Controls.Add(buttonUpdateParticipants);
            currentTabPage.Controls.Add(buttonChooseWinner);
        }

        private void buttonUpdateParticipants_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            char character = button.Name[button.Name.Length - 1];
            int temp = (character - '0') - 1;
            m_ListOfContests[temp].UpdateParticipantsList();
        }
    }
}
