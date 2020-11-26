namespace DesktopFacebookInterface
{
    public partial class FormMemoriesFetch
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
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelFilterContent = new System.Windows.Forms.Label();
            this.buttonFetchData = new System.Windows.Forms.Button();
            this.monthCalendarStartDate = new System.Windows.Forms.MonthCalendar();
            this.monthCalendarEndDate = new System.Windows.Forms.MonthCalendar();
            this.textBoxFetchResault = new System.Windows.Forms.TextBox();
            this.checkBoxCheckAll = new System.Windows.Forms.CheckBox();
            this.checkBoxPosts = new System.Windows.Forms.CheckBox();
            this.checkBoxCheckIn = new System.Windows.Forms.CheckBox();
            this.checkBoxEvents = new System.Windows.Forms.CheckBox();
            this.checkBoxSingleDay = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(21, 229);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(87, 20);
            this.labelStartDate.TabIndex = 1;
            this.labelStartDate.Text = "Start Date:";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(21, 545);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(81, 20);
            this.labelEndDate.TabIndex = 2;
            this.labelEndDate.Text = "End Date:";
            // 
            // labelFilterContent
            // 
            this.labelFilterContent.AutoSize = true;
            this.labelFilterContent.Location = new System.Drawing.Point(21, 14);
            this.labelFilterContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFilterContent.Name = "labelFilterContent";
            this.labelFilterContent.Size = new System.Drawing.Size(171, 20);
            this.labelFilterContent.TabIndex = 5;
            this.labelFilterContent.Text = "Show me the following:";
            // 
            // buttonFetchData
            // 
            this.buttonFetchData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFetchData.Location = new System.Drawing.Point(452, 14);
            this.buttonFetchData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonFetchData.Name = "buttonFetchData";
            this.buttonFetchData.Size = new System.Drawing.Size(340, 97);
            this.buttonFetchData.TabIndex = 7;
            this.buttonFetchData.Text = "Fetch";
            this.buttonFetchData.UseVisualStyleBackColor = true;
            this.buttonFetchData.Click += new System.EventHandler(this.buttonFetchData_Click);
            // 
            // monthCalendarStartDate
            // 
            this.monthCalendarStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendarStartDate.Location = new System.Drawing.Point(26, 263);
            this.monthCalendarStartDate.Margin = new System.Windows.Forms.Padding(14);
            this.monthCalendarStartDate.MaxSelectionCount = 1;
            this.monthCalendarStartDate.Name = "monthCalendarStartDate";
            this.monthCalendarStartDate.ScrollChange = 1;
            this.monthCalendarStartDate.ShowToday = false;
            this.monthCalendarStartDate.TabIndex = 8;
            this.monthCalendarStartDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarStartDate_DateSelected);
            // 
            // monthCalendarEndDate
            // 
            this.monthCalendarEndDate.Location = new System.Drawing.Point(26, 578);
            this.monthCalendarEndDate.Margin = new System.Windows.Forms.Padding(14);
            this.monthCalendarEndDate.MaxSelectionCount = 1;
            this.monthCalendarEndDate.Name = "monthCalendarEndDate";
            this.monthCalendarEndDate.ShowToday = false;
            this.monthCalendarEndDate.TabIndex = 9;
            this.monthCalendarEndDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarEndDate_DateSelected);
            // 
            // textBoxFetchResault
            // 
            this.textBoxFetchResault.Location = new System.Drawing.Point(452, 120);
            this.textBoxFetchResault.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxFetchResault.Multiline = true;
            this.textBoxFetchResault.Name = "textBoxFetchResault";
            this.textBoxFetchResault.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFetchResault.Size = new System.Drawing.Size(656, 706);
            this.textBoxFetchResault.TabIndex = 10;
            // 
            // checkBoxCheckAll
            // 
            this.checkBoxCheckAll.AutoSize = true;
            this.checkBoxCheckAll.Location = new System.Drawing.Point(26, 54);
            this.checkBoxCheckAll.Name = "checkBoxCheckAll";
            this.checkBoxCheckAll.Size = new System.Drawing.Size(99, 24);
            this.checkBoxCheckAll.TabIndex = 11;
            this.checkBoxCheckAll.Text = "Check all";
            this.checkBoxCheckAll.UseVisualStyleBackColor = true;
            this.checkBoxCheckAll.CheckedChanged += new System.EventHandler(this.checkBoxCheckAll_CheckedChanged);
            // 
            // checkBoxPosts
            // 
            this.checkBoxPosts.AutoSize = true;
            this.checkBoxPosts.Location = new System.Drawing.Point(26, 82);
            this.checkBoxPosts.Name = "checkBoxPosts";
            this.checkBoxPosts.Size = new System.Drawing.Size(75, 24);
            this.checkBoxPosts.TabIndex = 12;
            this.checkBoxPosts.Text = "Posts";
            this.checkBoxPosts.UseVisualStyleBackColor = true;
            this.checkBoxPosts.CheckedChanged += new System.EventHandler(this.checkBoxPosts_CheckedChanged);
            // 
            // checkBoxCheckIn
            // 
            this.checkBoxCheckIn.AutoSize = true;
            this.checkBoxCheckIn.Location = new System.Drawing.Point(26, 110);
            this.checkBoxCheckIn.Name = "checkBoxCheckIn";
            this.checkBoxCheckIn.Size = new System.Drawing.Size(96, 24);
            this.checkBoxCheckIn.TabIndex = 14;
            this.checkBoxCheckIn.Text = "Check in";
            this.checkBoxCheckIn.UseVisualStyleBackColor = true;
            this.checkBoxCheckIn.CheckedChanged += new System.EventHandler(this.checkBoxCheckIn_CheckedChanged);
            // 
            // checkBoxEvents
            // 
            this.checkBoxEvents.AutoSize = true;
            this.checkBoxEvents.Location = new System.Drawing.Point(26, 141);
            this.checkBoxEvents.Name = "checkBoxEvents";
            this.checkBoxEvents.Size = new System.Drawing.Size(84, 24);
            this.checkBoxEvents.TabIndex = 15;
            this.checkBoxEvents.Text = "Events";
            this.checkBoxEvents.UseVisualStyleBackColor = true;
            this.checkBoxEvents.CheckedChanged += new System.EventHandler(this.checkBoxEvents_CheckedChanged);
            // 
            // checkBoxSingleDay
            // 
            this.checkBoxSingleDay.AutoSize = true;
            this.checkBoxSingleDay.Enabled = false;
            this.checkBoxSingleDay.Location = new System.Drawing.Point(122, 515);
            this.checkBoxSingleDay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxSingleDay.Name = "checkBoxSingleDay";
            this.checkBoxSingleDay.Size = new System.Drawing.Size(108, 24);
            this.checkBoxSingleDay.TabIndex = 16;
            this.checkBoxSingleDay.Text = "Single day";
            this.checkBoxSingleDay.UseVisualStyleBackColor = true;
            this.checkBoxSingleDay.CheckedChanged += new System.EventHandler(this.checkBoxSingleDay_CheckedChanged);
            // 
            // FormMemoriesFetch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 855);
            this.Controls.Add(this.checkBoxSingleDay);
            this.Controls.Add(this.checkBoxEvents);
            this.Controls.Add(this.checkBoxCheckIn);
            this.Controls.Add(this.checkBoxPosts);
            this.Controls.Add(this.checkBoxCheckAll);
            this.Controls.Add(this.textBoxFetchResault);
            this.Controls.Add(this.monthCalendarEndDate);
            this.Controls.Add(this.monthCalendarStartDate);
            this.Controls.Add(this.buttonFetchData);
            this.Controls.Add(this.labelFilterContent);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormMemoriesFetch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Memories";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelFilterContent;
        private System.Windows.Forms.Button buttonFetchData;
        private System.Windows.Forms.MonthCalendar monthCalendarStartDate;
        private System.Windows.Forms.MonthCalendar monthCalendarEndDate;
        private System.Windows.Forms.TextBox textBoxFetchResault;
        private System.Windows.Forms.CheckBox checkBoxCheckAll;
        private System.Windows.Forms.CheckBox checkBoxPosts;
        private System.Windows.Forms.CheckBox checkBoxCheckIn;
        private System.Windows.Forms.CheckBox checkBoxEvents;
        private System.Windows.Forms.CheckBox checkBoxSingleDay;
    }
}