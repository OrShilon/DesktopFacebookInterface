namespace DesktopFacebookInterface
{
    internal partial class FormAddContest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labeltatus = new System.Windows.Forms.Label();
            this.textBoxContestDetails = new System.Windows.Forms.TextBox();
            this.linkLabelAttachImage = new System.Windows.Forms.LinkLabel();
            this.checkBoxLikes = new System.Windows.Forms.CheckBox();
            this.checkBoxComments = new System.Windows.Forms.CheckBox();
            this.labelLikeOrComment = new System.Windows.Forms.Label();
            this.buttonStartContest = new System.Windows.Forms.Button();
            this.buttonCancelContest = new System.Windows.Forms.Button();
            this.comboBoxNumOfWinners = new System.Windows.Forms.ComboBox();
            this.labelNumOfWinners = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labeltatus
            // 
            this.labeltatus.AutoSize = true;
            this.labeltatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltatus.Location = new System.Drawing.Point(14, 12);
            this.labeltatus.Name = "labeltatus";
            this.labeltatus.Size = new System.Drawing.Size(193, 25);
            this.labeltatus.TabIndex = 0;
            this.labeltatus.Text = "Enter contest details:";
            // 
            // textBoxContestDetails
            // 
            this.textBoxContestDetails.Location = new System.Drawing.Point(18, 52);
            this.textBoxContestDetails.Multiline = true;
            this.textBoxContestDetails.Name = "textBoxContestDetails";
            this.textBoxContestDetails.Size = new System.Drawing.Size(746, 133);
            this.textBoxContestDetails.TabIndex = 1;
            // 
            // linkLabelAttachImage
            // 
            this.linkLabelAttachImage.AutoSize = true;
            this.linkLabelAttachImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelAttachImage.Location = new System.Drawing.Point(14, 212);
            this.linkLabelAttachImage.Name = "linkLabelAttachImage";
            this.linkLabelAttachImage.Size = new System.Drawing.Size(127, 25);
            this.linkLabelAttachImage.TabIndex = 2;
            this.linkLabelAttachImage.TabStop = true;
            this.linkLabelAttachImage.Text = "Attach Image";
            this.linkLabelAttachImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAttachImage_LinkClicked);
            // 
            // checkBoxLikes
            // 
            this.checkBoxLikes.AutoSize = true;
            this.checkBoxLikes.Location = new System.Drawing.Point(330, 265);
            this.checkBoxLikes.Name = "checkBoxLikes";
            this.checkBoxLikes.Size = new System.Drawing.Size(123, 24);
            this.checkBoxLikes.TabIndex = 3;
            this.checkBoxLikes.Text = "Like my post";
            this.checkBoxLikes.UseVisualStyleBackColor = true;
            // 
            // checkBoxComments
            // 
            this.checkBoxComments.AutoSize = true;
            this.checkBoxComments.Location = new System.Drawing.Point(484, 265);
            this.checkBoxComments.Name = "checkBoxComments";
            this.checkBoxComments.Size = new System.Drawing.Size(163, 24);
            this.checkBoxComments.TabIndex = 4;
            this.checkBoxComments.Text = "Comment my post";
            this.checkBoxComments.UseVisualStyleBackColor = true;
            // 
            // labelLikeOrComment
            // 
            this.labelLikeOrComment.AutoSize = true;
            this.labelLikeOrComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLikeOrComment.Location = new System.Drawing.Point(14, 262);
            this.labelLikeOrComment.Name = "labelLikeOrComment";
            this.labelLikeOrComment.Size = new System.Drawing.Size(276, 25);
            this.labelLikeOrComment.TabIndex = 5;
            this.labelLikeOrComment.Text = "Requirements for your contest:";
            // 
            // buttonStartContest
            // 
            this.buttonStartContest.Location = new System.Drawing.Point(422, 385);
            this.buttonStartContest.Name = "buttonStartContest";
            this.buttonStartContest.Size = new System.Drawing.Size(160, 37);
            this.buttonStartContest.TabIndex = 6;
            this.buttonStartContest.Text = "Start contest!";
            this.buttonStartContest.UseVisualStyleBackColor = true;
            this.buttonStartContest.Click += new System.EventHandler(this.buttonStartContest_Click);
            // 
            // buttonCancelContest
            // 
            this.buttonCancelContest.Location = new System.Drawing.Point(604, 385);
            this.buttonCancelContest.Name = "buttonCancelContest";
            this.buttonCancelContest.Size = new System.Drawing.Size(160, 37);
            this.buttonCancelContest.TabIndex = 7;
            this.buttonCancelContest.Text = "Cancel";
            this.buttonCancelContest.UseVisualStyleBackColor = true;
            // 
            // comboBoxNumOfWinners
            // 
            this.comboBoxNumOfWinners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumOfWinners.FormattingEnabled = true;
            this.comboBoxNumOfWinners.Location = new System.Drawing.Point(330, 311);
            this.comboBoxNumOfWinners.Name = "comboBoxNumOfWinners";
            this.comboBoxNumOfWinners.Size = new System.Drawing.Size(67, 28);
            this.comboBoxNumOfWinners.TabIndex = 8;
            // 
            // labelNumOfWinners
            // 
            this.labelNumOfWinners.AutoSize = true;
            this.labelNumOfWinners.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumOfWinners.Location = new System.Drawing.Point(14, 311);
            this.labelNumOfWinners.Name = "labelNumOfWinners";
            this.labelNumOfWinners.Size = new System.Drawing.Size(180, 25);
            this.labelNumOfWinners.TabIndex = 9;
            this.labelNumOfWinners.Text = "Number of winners:";
            // 
            // FormAddContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.labelNumOfWinners);
            this.Controls.Add(this.comboBoxNumOfWinners);
            this.Controls.Add(this.buttonCancelContest);
            this.Controls.Add(this.buttonStartContest);
            this.Controls.Add(this.labelLikeOrComment);
            this.Controls.Add(this.checkBoxComments);
            this.Controls.Add(this.checkBoxLikes);
            this.Controls.Add(this.linkLabelAttachImage);
            this.Controls.Add(this.textBoxContestDetails);
            this.Controls.Add(this.labeltatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddContest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create new contest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labeltatus;
        private System.Windows.Forms.TextBox textBoxContestDetails;
        private System.Windows.Forms.LinkLabel linkLabelAttachImage;
        private System.Windows.Forms.CheckBox checkBoxLikes;
        private System.Windows.Forms.CheckBox checkBoxComments;
        private System.Windows.Forms.Label labelLikeOrComment;
        private System.Windows.Forms.Button buttonStartContest;
        private System.Windows.Forms.Button buttonCancelContest;
        private System.Windows.Forms.ComboBox comboBoxNumOfWinners;
        private System.Windows.Forms.Label labelNumOfWinners;
    }
}