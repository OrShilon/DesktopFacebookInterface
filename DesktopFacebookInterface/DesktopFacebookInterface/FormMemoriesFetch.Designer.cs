
namespace DesktopFacebookInterface
{
    partial class FormMemoriesFetch
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBoxEverything = new System.Windows.Forms.CheckBox();
            this.checkBoxPosts = new System.Windows.Forms.CheckBox();
            this.checkBoxPhotos = new System.Windows.Forms.CheckBox();
            this.checkBoxFriends = new System.Windows.Forms.CheckBox();
            this.checkBoxEvents = new System.Windows.Forms.CheckBox();
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(452, 120);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(656, 706);
            this.textBox1.TabIndex = 10;
            // 
            // checkBoxEverything
            // 
            this.checkBoxEverything.AutoSize = true;
            this.checkBoxEverything.Location = new System.Drawing.Point(25, 54);
            this.checkBoxEverything.Name = "checkBoxEverything";
            this.checkBoxEverything.Size = new System.Drawing.Size(164, 36);
            this.checkBoxEverything.TabIndex = 11;
            this.checkBoxEverything.Text = "Everything";
            this.checkBoxEverything.UseVisualStyleBackColor = true;
            this.checkBoxEverything.CheckedChanged += new System.EventHandler(this.checkBoxEverything_CheckedChanged);
            // 
            // checkBoxPosts
            // 
            this.checkBoxPosts.AutoSize = true;
            this.checkBoxPosts.Location = new System.Drawing.Point(25, 81);
            this.checkBoxPosts.Name = "checkBoxPosts";
            this.checkBoxPosts.Size = new System.Drawing.Size(113, 36);
            this.checkBoxPosts.TabIndex = 12;
            this.checkBoxPosts.Text = "Posts";
            this.checkBoxPosts.UseVisualStyleBackColor = true;
            // 
            // checkBoxPhotos
            // 
            this.checkBoxPhotos.AutoSize = true;
            this.checkBoxPhotos.Location = new System.Drawing.Point(25, 111);
            this.checkBoxPhotos.Name = "checkBoxPhotos";
            this.checkBoxPhotos.Size = new System.Drawing.Size(128, 36);
            this.checkBoxPhotos.TabIndex = 13;
            this.checkBoxPhotos.Text = "Photos";
            this.checkBoxPhotos.UseVisualStyleBackColor = true;
            // 
            // checkBoxFriends
            // 
            this.checkBoxFriends.AutoSize = true;
            this.checkBoxFriends.Location = new System.Drawing.Point(25, 141);
            this.checkBoxFriends.Name = "checkBoxFriends";
            this.checkBoxFriends.Size = new System.Drawing.Size(132, 36);
            this.checkBoxFriends.TabIndex = 14;
            this.checkBoxFriends.Text = "Friends";
            this.checkBoxFriends.UseVisualStyleBackColor = true;
            // 
            // checkBoxEvents
            // 
            this.checkBoxEvents.AutoSize = true;
            this.checkBoxEvents.Location = new System.Drawing.Point(25, 172);
            this.checkBoxEvents.Name = "checkBoxEvents";
            this.checkBoxEvents.Size = new System.Drawing.Size(126, 36);
            this.checkBoxEvents.TabIndex = 15;
            this.checkBoxEvents.Text = "Events";
            this.checkBoxEvents.UseVisualStyleBackColor = true;
            // 
            // FormMemoriesFetch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 855);
            this.Controls.Add(this.checkBoxEvents);
            this.Controls.Add(this.checkBoxFriends);
            this.Controls.Add(this.checkBoxPhotos);
            this.Controls.Add(this.checkBoxPosts);
            this.Controls.Add(this.checkBoxEverything);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.monthCalendarEndDate);
            this.Controls.Add(this.monthCalendarStartDate);
            this.Controls.Add(this.buttonFetchData);
            this.Controls.Add(this.labelFilterContent);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMemoriesFetch";
            this.Text = "FormMemoriesFetch";
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBoxEverything;
        private System.Windows.Forms.CheckBox checkBoxPosts;
        private System.Windows.Forms.CheckBox checkBoxPhotos;
        private System.Windows.Forms.CheckBox checkBoxFriends;
        private System.Windows.Forms.CheckBox checkBoxEvents;
    }
}