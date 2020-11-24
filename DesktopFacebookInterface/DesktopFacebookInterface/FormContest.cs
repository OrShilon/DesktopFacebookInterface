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
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
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
            TextBox textBoxDescription = new TextBox();
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

            textBoxDescription.Location = new Point(labelPost.Location.X, labelPost.Location.Y + 20);
            textBoxDescription.Margin = new Padding(2, 2, 2, 2);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxContestDescription";
            //textBoxDescription.Text = m_ListOfContests[m_ListOfContests.Count - 1]
            textBoxDescription.Size = new Size(420, 120);
            textBoxDescription.TabIndex = 1;

            pictureBoxAttachedImage.Location = new Point(textBoxDescription.Right + 15, textBoxDescription.Location.Y);
            pictureBoxAttachedImage.Margin = new Padding(5, 6, 5, 6);
            pictureBoxAttachedImage.Name = "pictureBoxAttachedImage";
            pictureBoxAttachedImage.Size = new Size(200, 145);
            pictureBoxAttachedImage.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBoxAttachedImage.LoadAsync(m_ListOfContests[m_ListOfContests.Count - 1])
            pictureBoxAttachedImage.TabIndex = 2;
            pictureBoxAttachedImage.TabStop = false;

            listBoxParticipants.AutoSize = true;
            listBoxParticipants.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            listBoxParticipants.Location = new Point(textBoxDescription.Location.X, textBoxDescription.Location.Y + 30);
            listBoxParticipants.Name = "listBoxParticipants";
            listBoxParticipants.Size = new Size(195, 25);
            listBoxParticipants.Text = "List of participants:";
            listBoxParticipants.TabIndex = 3;
            listBoxParticipants.TabStop = false;



            currentTabPage.Controls.Add(labelPost);
            currentTabPage.Controls.Add(textBoxDescription);
            currentTabPage.Controls.Add(pictureBoxAttachedImage);
            currentTabPage.Controls.Add(listBoxParticipants);

        }
    }
}
