﻿namespace DesktopFacebookInterface
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
            this.SuspendLayout();
            // 
            // tabControlContest
            // 
            this.tabControlContest.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlContest.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlContest.ItemSize = new System.Drawing.Size(25, 100);
            this.tabControlContest.Location = new System.Drawing.Point(0, 62);
            this.tabControlContest.Multiline = true;
            this.tabControlContest.Name = "tabControlContest";
            this.tabControlContest.SelectedIndex = 0;
            this.tabControlContest.Size = new System.Drawing.Size(1053, 598);
            this.tabControlContest.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlContest.TabIndex = 0;
            this.tabControlContest.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // buttonAddContest
            // 
            this.buttonAddContest.Location = new System.Drawing.Point(4, 5);
            this.buttonAddContest.Name = "buttonAddContest";
            this.buttonAddContest.Size = new System.Drawing.Size(93, 54);
            this.buttonAddContest.TabIndex = 1;
            this.buttonAddContest.Text = "Add new contest";
            this.buttonAddContest.UseVisualStyleBackColor = true;
            this.buttonAddContest.Click += new System.EventHandler(this.buttonAddContest_Click);
            // 
            // FormContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 659);
            this.Controls.Add(this.buttonAddContest);
            this.Controls.Add(this.tabControlContest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormContest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormContest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlContest;
        private System.Windows.Forms.Button buttonAddContest;
    }
}