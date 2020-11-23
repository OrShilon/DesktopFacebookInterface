namespace DesktopFacebookInterface
{
    partial class FormContest
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
            this.tabControlContest = new System.Windows.Forms.TabControl();
            this.buttonAddContest = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlContest.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlContest
            // 
            this.tabControlContest.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlContest.Controls.Add(this.tabPage1);
            this.tabControlContest.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlContest.ItemSize = new System.Drawing.Size(25, 100);
            this.tabControlContest.Location = new System.Drawing.Point(12, 12);
            this.tabControlContest.Multiline = true;
            this.tabControlContest.Name = "tabControlContest";
            this.tabControlContest.SelectedIndex = 0;
            this.tabControlContest.Size = new System.Drawing.Size(975, 624);
            this.tabControlContest.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlContest.TabIndex = 0;
            this.tabControlContest.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // buttonAddContest
            // 
            this.buttonAddContest.Location = new System.Drawing.Point(12, 642);
            this.buttonAddContest.Name = "buttonAddContest";
            this.buttonAddContest.Size = new System.Drawing.Size(93, 54);
            this.buttonAddContest.TabIndex = 1;
            this.buttonAddContest.Text = "Add new contest";
            this.buttonAddContest.UseVisualStyleBackColor = true;
            this.buttonAddContest.Click += new System.EventHandler(this.buttonAddContest_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(104, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(867, 616);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // FormContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 710);
            this.Controls.Add(this.buttonAddContest);
            this.Controls.Add(this.tabControlContest);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormContest";
            this.Text = "FormContest";
            this.tabControlContest.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlContest;
        private System.Windows.Forms.Button buttonAddContest;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
    }
}