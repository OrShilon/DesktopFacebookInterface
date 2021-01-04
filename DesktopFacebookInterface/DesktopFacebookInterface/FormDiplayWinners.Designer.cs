namespace DesktopFacebookInterface.UI
{
    internal partial class FormDiplayWinners
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
            this.labelvWinnerName = new System.Windows.Forms.Label();
            this.labelNumOfWinner = new System.Windows.Forms.Label();
            this.pictureBoxWinnerPicture = new System.Windows.Forms.PictureBox();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWinnerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // labelvWinnerName
            // 
            this.labelvWinnerName.AutoSize = true;
            this.labelvWinnerName.Location = new System.Drawing.Point(53, 112);
            this.labelvWinnerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelvWinnerName.Name = "labelvWinnerName";
            this.labelvWinnerName.Size = new System.Drawing.Size(35, 13);
            this.labelvWinnerName.TabIndex = 0;
            this.labelvWinnerName.Text = "Name";
            // 
            // labelNumOfWinner
            // 
            this.labelNumOfWinner.AutoSize = true;
            this.labelNumOfWinner.Location = new System.Drawing.Point(53, 70);
            this.labelNumOfWinner.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumOfWinner.Name = "labelNumOfWinner";
            this.labelNumOfWinner.Size = new System.Drawing.Size(79, 13);
            this.labelNumOfWinner.TabIndex = 1;
            this.labelNumOfWinner.Text = "Winner number";
            // 
            // pictureBoxWinnerPicture
            // 
            this.pictureBoxWinnerPicture.Location = new System.Drawing.Point(222, 8);
            this.pictureBoxWinnerPicture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxWinnerPicture.Name = "pictureBoxWinnerPicture";
            this.pictureBoxWinnerPicture.Size = new System.Drawing.Size(255, 179);
            this.pictureBoxWinnerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxWinnerPicture.TabIndex = 2;
            this.pictureBoxWinnerPicture.TabStop = false;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(148, 202);
            this.buttonPrevious.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(87, 23);
            this.buttonPrevious.TabIndex = 3;
            this.buttonPrevious.Text = "Previous";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(265, 202);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(87, 23);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // FormDiplayWinners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 258);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.pictureBoxWinnerPicture);
            this.Controls.Add(this.labelNumOfWinner);
            this.Controls.Add(this.labelvWinnerName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDiplayWinners";
            this.Text = "Contest Winners";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWinnerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelvWinnerName;
        private System.Windows.Forms.Label labelNumOfWinner;
        private System.Windows.Forms.PictureBox pictureBoxWinnerPicture;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
    }
}