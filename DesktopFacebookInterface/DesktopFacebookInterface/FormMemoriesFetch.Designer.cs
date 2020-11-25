
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.buttonFetchData = new System.Windows.Forms.Button();
            this.monthCalendarStartDate = new System.Windows.Forms.MonthCalendar();
            this.monthCalendarEndDate = new System.Windows.Forms.MonthCalendar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(14, 149);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(58, 13);
            this.labelStartDate.TabIndex = 1;
            this.labelStartDate.Text = "Start Date:";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(14, 354);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(55, 13);
            this.labelEndDate.TabIndex = 2;
            this.labelEndDate.Text = "End Date:";
            // 
            // labelFilterContent
            // 
            this.labelFilterContent.AutoSize = true;
            this.labelFilterContent.Location = new System.Drawing.Point(14, 9);
            this.labelFilterContent.Name = "labelFilterContent";
            this.labelFilterContent.Size = new System.Drawing.Size(116, 13);
            this.labelFilterContent.TabIndex = 5;
            this.labelFilterContent.Text = "Show me the following:";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Everything",
            "Posts",
            "Photos",
            "Friends",
            "Events"});
            this.checkedListBox1.Location = new System.Drawing.Point(17, 37);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(161, 95);
            this.checkedListBox1.TabIndex = 6;
            // 
            // buttonFetchData
            // 
            this.buttonFetchData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFetchData.Location = new System.Drawing.Point(301, 9);
            this.buttonFetchData.Name = "buttonFetchData";
            this.buttonFetchData.Size = new System.Drawing.Size(227, 63);
            this.buttonFetchData.TabIndex = 7;
            this.buttonFetchData.Text = "Fetch";
            this.buttonFetchData.UseVisualStyleBackColor = true;
            // 
            // monthCalendarStartDate
            // 
            this.monthCalendarStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendarStartDate.Location = new System.Drawing.Point(17, 171);
            this.monthCalendarStartDate.MaxSelectionCount = 1;
            this.monthCalendarStartDate.Name = "monthCalendarStartDate";
            this.monthCalendarStartDate.ScrollChange = 1;
            this.monthCalendarStartDate.ShowToday = false;
            this.monthCalendarStartDate.TabIndex = 8;
            this.monthCalendarStartDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarStartDate_DateSelected);
            // 
            // monthCalendarEndDate
            // 
            this.monthCalendarEndDate.Location = new System.Drawing.Point(17, 376);
            this.monthCalendarEndDate.MaxSelectionCount = 1;
            this.monthCalendarEndDate.Name = "monthCalendarEndDate";
            this.monthCalendarEndDate.ShowToday = false;
            this.monthCalendarEndDate.TabIndex = 9;
            this.monthCalendarEndDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarEndDate_DateSelected);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(301, 78);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(439, 460);
            this.textBox1.TabIndex = 10;
            // 
            // FormMemoriesFetch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 556);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.monthCalendarEndDate);
            this.Controls.Add(this.monthCalendarStartDate);
            this.Controls.Add(this.buttonFetchData);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.labelFilterContent);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Name = "FormMemoriesFetch";
            this.Text = "FormMemoriesFetch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelFilterContent;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button buttonFetchData;
        private System.Windows.Forms.MonthCalendar monthCalendarStartDate;
        private System.Windows.Forms.MonthCalendar monthCalendarEndDate;
        private System.Windows.Forms.TextBox textBox1;
    }
}