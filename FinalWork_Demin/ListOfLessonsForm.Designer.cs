
namespace FinalWork_Demin
{
    partial class ListOfLessonsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListOfLessonsForm));
            this.LoginAndPasswordPanel = new System.Windows.Forms.Panel();
            this.ListOfLessonsdataGridView = new System.Windows.Forms.DataGridView();
            this.SemestrComboBox = new System.Windows.Forms.ComboBox();
            this.Semestrlabel = new System.Windows.Forms.Label();
            this.GroupcomboBox = new System.Windows.Forms.ComboBox();
            this.Grouplabel = new System.Windows.Forms.Label();
            this.authorizationPanel = new System.Windows.Forms.Panel();
            this.NavigationLabel = new System.Windows.Forms.Label();
            this.SetUpLabel = new System.Windows.Forms.Label();
            this.LoginAndPasswordPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListOfLessonsdataGridView)).BeginInit();
            this.authorizationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginAndPasswordPanel
            // 
            this.LoginAndPasswordPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.LoginAndPasswordPanel.Controls.Add(this.ListOfLessonsdataGridView);
            this.LoginAndPasswordPanel.Controls.Add(this.SemestrComboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.Semestrlabel);
            this.LoginAndPasswordPanel.Controls.Add(this.GroupcomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.Grouplabel);
            this.LoginAndPasswordPanel.Controls.Add(this.authorizationPanel);
            this.LoginAndPasswordPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginAndPasswordPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginAndPasswordPanel.Name = "LoginAndPasswordPanel";
            this.LoginAndPasswordPanel.Size = new System.Drawing.Size(1160, 563);
            this.LoginAndPasswordPanel.TabIndex = 3;
            // 
            // ListOfLessonsdataGridView
            // 
            this.ListOfLessonsdataGridView.AllowUserToAddRows = false;
            this.ListOfLessonsdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListOfLessonsdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ListOfLessonsdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListOfLessonsdataGridView.Location = new System.Drawing.Point(10, 115);
            this.ListOfLessonsdataGridView.Name = "ListOfLessonsdataGridView";
            this.ListOfLessonsdataGridView.ReadOnly = true;
            this.ListOfLessonsdataGridView.Size = new System.Drawing.Size(1147, 436);
            this.ListOfLessonsdataGridView.TabIndex = 34;
            // 
            // SemestrComboBox
            // 
            this.SemestrComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SemestrComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.SemestrComboBox.Location = new System.Drawing.Point(463, 67);
            this.SemestrComboBox.Name = "SemestrComboBox";
            this.SemestrComboBox.Size = new System.Drawing.Size(75, 39);
            this.SemestrComboBox.TabIndex = 33;
            this.SemestrComboBox.SelectedIndexChanged += new System.EventHandler(this.SemestrComboBox_SelectedIndexChanged);
            // 
            // Semestrlabel
            // 
            this.Semestrlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.Semestrlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.Semestrlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Semestrlabel.Location = new System.Drawing.Point(332, 67);
            this.Semestrlabel.Name = "Semestrlabel";
            this.Semestrlabel.Size = new System.Drawing.Size(125, 39);
            this.Semestrlabel.TabIndex = 32;
            this.Semestrlabel.Text = "Семестр";
            this.Semestrlabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GroupcomboBox
            // 
            this.GroupcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.GroupcomboBox.Location = new System.Drawing.Point(122, 67);
            this.GroupcomboBox.Name = "GroupcomboBox";
            this.GroupcomboBox.Size = new System.Drawing.Size(204, 39);
            this.GroupcomboBox.TabIndex = 21;
            this.GroupcomboBox.SelectedIndexChanged += new System.EventHandler(this.GroupcomboBox_SelectedIndexChanged);
            // 
            // Grouplabel
            // 
            this.Grouplabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.Grouplabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.Grouplabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Grouplabel.Location = new System.Drawing.Point(12, 67);
            this.Grouplabel.Name = "Grouplabel";
            this.Grouplabel.Size = new System.Drawing.Size(104, 39);
            this.Grouplabel.TabIndex = 20;
            this.Grouplabel.Text = "Группа";
            this.Grouplabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // authorizationPanel
            // 
            this.authorizationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(1)))), ((int)(((byte)(15)))));
            this.authorizationPanel.Controls.Add(this.NavigationLabel);
            this.authorizationPanel.Controls.Add(this.SetUpLabel);
            this.authorizationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.authorizationPanel.Location = new System.Drawing.Point(0, 0);
            this.authorizationPanel.Name = "authorizationPanel";
            this.authorizationPanel.Size = new System.Drawing.Size(1160, 64);
            this.authorizationPanel.TabIndex = 0;
            // 
            // NavigationLabel
            // 
            this.NavigationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NavigationLabel.AutoSize = true;
            this.NavigationLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(98)))), ((int)(((byte)(159)))));
            this.NavigationLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NavigationLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NavigationLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NavigationLabel.Location = new System.Drawing.Point(934, 42);
            this.NavigationLabel.Name = "NavigationLabel";
            this.NavigationLabel.Size = new System.Drawing.Size(223, 22);
            this.NavigationLabel.TabIndex = 8;
            this.NavigationLabel.Text = "Назад в главное меню";
            this.NavigationLabel.Click += new System.EventHandler(this.NavigationLabel_Click);
            // 
            // SetUpLabel
            // 
            this.SetUpLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(98)))), ((int)(((byte)(159)))));
            this.SetUpLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SetUpLabel.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SetUpLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.SetUpLabel.Location = new System.Drawing.Point(0, 0);
            this.SetUpLabel.Name = "SetUpLabel";
            this.SetUpLabel.Size = new System.Drawing.Size(1160, 64);
            this.SetUpLabel.TabIndex = 0;
            this.SetUpLabel.Text = "Список занятий";
            this.SetUpLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ListOfLessonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 563);
            this.Controls.Add(this.LoginAndPasswordPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListOfLessonsForm";
            this.Text = "  Список занятий";
            this.LoginAndPasswordPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListOfLessonsdataGridView)).EndInit();
            this.authorizationPanel.ResumeLayout(false);
            this.authorizationPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LoginAndPasswordPanel;
        private System.Windows.Forms.ComboBox SemestrComboBox;
        private System.Windows.Forms.Label Semestrlabel;
        private System.Windows.Forms.ComboBox GroupcomboBox;
        private System.Windows.Forms.Label Grouplabel;
        private System.Windows.Forms.Panel authorizationPanel;
        private System.Windows.Forms.Label NavigationLabel;
        private System.Windows.Forms.Label SetUpLabel;
        private System.Windows.Forms.DataGridView ListOfLessonsdataGridView;
    }
}