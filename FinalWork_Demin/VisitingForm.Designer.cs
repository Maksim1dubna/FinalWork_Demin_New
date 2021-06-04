
namespace FinalWork_Demin
{
    partial class VisitingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisitingForm));
            this.GroupComboBox = new System.Windows.Forms.ComboBox();
            this.VisitsAndProgressDataGridView = new System.Windows.Forms.DataGridView();
            this.DisciplinecomboBox = new System.Windows.Forms.ComboBox();
            this.Grouplabel = new System.Windows.Forms.Label();
            this.Disciplinelabel = new System.Windows.Forms.Label();
            this.SemestrcomboBox = new System.Windows.Forms.ComboBox();
            this.Semestrlabel = new System.Windows.Forms.Label();
            this.MissesofGroupSignlabel = new System.Windows.Forms.Label();
            this.LoginAndPasswordPanel = new System.Windows.Forms.Panel();
            this.NumoflessoncomboBox = new System.Windows.Forms.ComboBox();
            this.Numoflessonlabel = new System.Windows.Forms.Label();
            this.DisciplineidcomboBox = new System.Windows.Forms.ComboBox();
            this.GroupidcomboBox = new System.Windows.Forms.ComboBox();
            this.AllLessonsofGrouptextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MissesofGrouptextBox = new System.Windows.Forms.TextBox();
            this.authorizationPanel = new System.Windows.Forms.Panel();
            this.NavigationLabel = new System.Windows.Forms.Label();
            this.SetUpLabel = new System.Windows.Forms.Label();
            this.DateComboBox = new System.Windows.Forms.ComboBox();
            this.Datelabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VisitsAndProgressDataGridView)).BeginInit();
            this.LoginAndPasswordPanel.SuspendLayout();
            this.authorizationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupComboBox
            // 
            this.GroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupComboBox.Location = new System.Drawing.Point(106, 70);
            this.GroupComboBox.Name = "GroupComboBox";
            this.GroupComboBox.Size = new System.Drawing.Size(344, 26);
            this.GroupComboBox.TabIndex = 12;
            this.GroupComboBox.SelectedIndexChanged += new System.EventHandler(this.GroupComboBox_SelectedIndexChanged);
            // 
            // VisitsAndProgressDataGridView
            // 
            this.VisitsAndProgressDataGridView.AllowUserToAddRows = false;
            this.VisitsAndProgressDataGridView.AllowUserToOrderColumns = true;
            this.VisitsAndProgressDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VisitsAndProgressDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.VisitsAndProgressDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VisitsAndProgressDataGridView.Location = new System.Drawing.Point(12, 198);
            this.VisitsAndProgressDataGridView.Name = "VisitsAndProgressDataGridView";
            this.VisitsAndProgressDataGridView.Size = new System.Drawing.Size(897, 249);
            this.VisitsAndProgressDataGridView.TabIndex = 13;
            this.VisitsAndProgressDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.VisitsAndProgressDataGridView_CellValueChanged);
            // 
            // DisciplinecomboBox
            // 
            this.DisciplinecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DisciplinecomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.DisciplinecomboBox.Location = new System.Drawing.Point(147, 134);
            this.DisciplinecomboBox.Name = "DisciplinecomboBox";
            this.DisciplinecomboBox.Size = new System.Drawing.Size(303, 26);
            this.DisciplinecomboBox.TabIndex = 14;
            this.DisciplinecomboBox.SelectedIndexChanged += new System.EventHandler(this.DisciplinecomboBox_SelectedIndexChanged);
            // 
            // Grouplabel
            // 
            this.Grouplabel.AutoSize = true;
            this.Grouplabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.Grouplabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Grouplabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Grouplabel.Location = new System.Drawing.Point(6, 70);
            this.Grouplabel.Name = "Grouplabel";
            this.Grouplabel.Size = new System.Drawing.Size(83, 25);
            this.Grouplabel.TabIndex = 22;
            this.Grouplabel.Text = "Группа";
            // 
            // Disciplinelabel
            // 
            this.Disciplinelabel.AutoSize = true;
            this.Disciplinelabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.Disciplinelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Disciplinelabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Disciplinelabel.Location = new System.Drawing.Point(6, 134);
            this.Disciplinelabel.Name = "Disciplinelabel";
            this.Disciplinelabel.Size = new System.Drawing.Size(135, 25);
            this.Disciplinelabel.TabIndex = 24;
            this.Disciplinelabel.Text = "Дисциплина";
            // 
            // SemestrcomboBox
            // 
            this.SemestrcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SemestrcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SemestrcomboBox.Location = new System.Drawing.Point(106, 102);
            this.SemestrcomboBox.Name = "SemestrcomboBox";
            this.SemestrcomboBox.Size = new System.Drawing.Size(73, 26);
            this.SemestrcomboBox.TabIndex = 34;
            this.SemestrcomboBox.SelectedIndexChanged += new System.EventHandler(this.SemestrcomboBox_SelectedIndexChanged);
            // 
            // Semestrlabel
            // 
            this.Semestrlabel.AutoSize = true;
            this.Semestrlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.Semestrlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Semestrlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Semestrlabel.Location = new System.Drawing.Point(3, 102);
            this.Semestrlabel.Name = "Semestrlabel";
            this.Semestrlabel.Size = new System.Drawing.Size(99, 25);
            this.Semestrlabel.TabIndex = 35;
            this.Semestrlabel.Text = "Семестр";
            // 
            // MissesofGroupSignlabel
            // 
            this.MissesofGroupSignlabel.AutoSize = true;
            this.MissesofGroupSignlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.MissesofGroupSignlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.MissesofGroupSignlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MissesofGroupSignlabel.Location = new System.Drawing.Point(567, 164);
            this.MissesofGroupSignlabel.Name = "MissesofGroupSignlabel";
            this.MissesofGroupSignlabel.Size = new System.Drawing.Size(184, 25);
            this.MissesofGroupSignlabel.TabIndex = 37;
            this.MissesofGroupSignlabel.Text = "Пропуски группы";
            // 
            // LoginAndPasswordPanel
            // 
            this.LoginAndPasswordPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.LoginAndPasswordPanel.Controls.Add(this.NumoflessoncomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.Numoflessonlabel);
            this.LoginAndPasswordPanel.Controls.Add(this.DisciplineidcomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.GroupidcomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.AllLessonsofGrouptextBox);
            this.LoginAndPasswordPanel.Controls.Add(this.label1);
            this.LoginAndPasswordPanel.Controls.Add(this.MissesofGrouptextBox);
            this.LoginAndPasswordPanel.Controls.Add(this.VisitsAndProgressDataGridView);
            this.LoginAndPasswordPanel.Controls.Add(this.MissesofGroupSignlabel);
            this.LoginAndPasswordPanel.Controls.Add(this.authorizationPanel);
            this.LoginAndPasswordPanel.Controls.Add(this.GroupComboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.Semestrlabel);
            this.LoginAndPasswordPanel.Controls.Add(this.DisciplinecomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.SemestrcomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.DateComboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.Disciplinelabel);
            this.LoginAndPasswordPanel.Controls.Add(this.Grouplabel);
            this.LoginAndPasswordPanel.Controls.Add(this.Datelabel);
            this.LoginAndPasswordPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginAndPasswordPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginAndPasswordPanel.Name = "LoginAndPasswordPanel";
            this.LoginAndPasswordPanel.Size = new System.Drawing.Size(921, 459);
            this.LoginAndPasswordPanel.TabIndex = 38;
            // 
            // NumoflessoncomboBox
            // 
            this.NumoflessoncomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NumoflessoncomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.NumoflessoncomboBox.Location = new System.Drawing.Point(456, 165);
            this.NumoflessoncomboBox.Name = "NumoflessoncomboBox";
            this.NumoflessoncomboBox.Size = new System.Drawing.Size(67, 26);
            this.NumoflessoncomboBox.TabIndex = 100;
            this.NumoflessoncomboBox.SelectedIndexChanged += new System.EventHandler(this.NumoflessoncomboBox_SelectedIndexChanged);
            // 
            // Numoflessonlabel
            // 
            this.Numoflessonlabel.AutoSize = true;
            this.Numoflessonlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.Numoflessonlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Numoflessonlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Numoflessonlabel.Location = new System.Drawing.Point(315, 166);
            this.Numoflessonlabel.Name = "Numoflessonlabel";
            this.Numoflessonlabel.Size = new System.Drawing.Size(135, 25);
            this.Numoflessonlabel.TabIndex = 98;
            this.Numoflessonlabel.Text = "Номер пары";
            // 
            // DisciplineidcomboBox
            // 
            this.DisciplineidcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DisciplineidcomboBox.Enabled = false;
            this.DisciplineidcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.DisciplineidcomboBox.Location = new System.Drawing.Point(456, 134);
            this.DisciplineidcomboBox.Name = "DisciplineidcomboBox";
            this.DisciplineidcomboBox.Size = new System.Drawing.Size(67, 26);
            this.DisciplineidcomboBox.TabIndex = 97;
            // 
            // GroupidcomboBox
            // 
            this.GroupidcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupidcomboBox.Enabled = false;
            this.GroupidcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.GroupidcomboBox.Location = new System.Drawing.Point(456, 70);
            this.GroupidcomboBox.Name = "GroupidcomboBox";
            this.GroupidcomboBox.Size = new System.Drawing.Size(67, 26);
            this.GroupidcomboBox.TabIndex = 96;
            // 
            // AllLessonsofGrouptextBox
            // 
            this.AllLessonsofGrouptextBox.Enabled = false;
            this.AllLessonsofGrouptextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.AllLessonsofGrouptextBox.Location = new System.Drawing.Point(840, 165);
            this.AllLessonsofGrouptextBox.Name = "AllLessonsofGrouptextBox";
            this.AllLessonsofGrouptextBox.Size = new System.Drawing.Size(57, 24);
            this.AllLessonsofGrouptextBox.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(808, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 25);
            this.label1.TabIndex = 42;
            this.label1.Text = "из";
            // 
            // MissesofGrouptextBox
            // 
            this.MissesofGrouptextBox.Enabled = false;
            this.MissesofGrouptextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.MissesofGrouptextBox.Location = new System.Drawing.Point(757, 165);
            this.MissesofGrouptextBox.Name = "MissesofGrouptextBox";
            this.MissesofGrouptextBox.Size = new System.Drawing.Size(57, 24);
            this.MissesofGrouptextBox.TabIndex = 40;
            // 
            // authorizationPanel
            // 
            this.authorizationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(1)))), ((int)(((byte)(15)))));
            this.authorizationPanel.Controls.Add(this.NavigationLabel);
            this.authorizationPanel.Controls.Add(this.SetUpLabel);
            this.authorizationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.authorizationPanel.Location = new System.Drawing.Point(0, 0);
            this.authorizationPanel.Name = "authorizationPanel";
            this.authorizationPanel.Size = new System.Drawing.Size(921, 64);
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
            this.NavigationLabel.Location = new System.Drawing.Point(695, 42);
            this.NavigationLabel.Name = "NavigationLabel";
            this.NavigationLabel.Size = new System.Drawing.Size(223, 22);
            this.NavigationLabel.TabIndex = 26;
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
            this.SetUpLabel.Size = new System.Drawing.Size(921, 64);
            this.SetUpLabel.TabIndex = 0;
            this.SetUpLabel.Text = "Посещаемость";
            this.SetUpLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DateComboBox
            // 
            this.DateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DateComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.DateComboBox.Location = new System.Drawing.Point(74, 166);
            this.DateComboBox.Name = "DateComboBox";
            this.DateComboBox.Size = new System.Drawing.Size(235, 26);
            this.DateComboBox.TabIndex = 16;
            this.DateComboBox.SelectedIndexChanged += new System.EventHandler(this.DateComboBox_SelectedIndexChanged);
            // 
            // Datelabel
            // 
            this.Datelabel.AutoSize = true;
            this.Datelabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.Datelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Datelabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Datelabel.Location = new System.Drawing.Point(6, 166);
            this.Datelabel.Name = "Datelabel";
            this.Datelabel.Size = new System.Drawing.Size(62, 25);
            this.Datelabel.TabIndex = 23;
            this.Datelabel.Text = "Дата";
            // 
            // VisitingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 459);
            this.Controls.Add(this.LoginAndPasswordPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(934, 489);
            this.Name = "VisitingForm";
            this.Text = "Посещаемость";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.VisitsAndProgressDataGridView)).EndInit();
            this.LoginAndPasswordPanel.ResumeLayout(false);
            this.LoginAndPasswordPanel.PerformLayout();
            this.authorizationPanel.ResumeLayout(false);
            this.authorizationPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox GroupComboBox;
        private System.Windows.Forms.DataGridView VisitsAndProgressDataGridView;
        private System.Windows.Forms.ComboBox DisciplinecomboBox;
        private System.Windows.Forms.Label Grouplabel;
        private System.Windows.Forms.Label Disciplinelabel;
        private System.Windows.Forms.ComboBox SemestrcomboBox;
        private System.Windows.Forms.Label Semestrlabel;
        private System.Windows.Forms.Label MissesofGroupSignlabel;
        private System.Windows.Forms.Panel LoginAndPasswordPanel;
        private System.Windows.Forms.Panel authorizationPanel;
        private System.Windows.Forms.Label SetUpLabel;
        private System.Windows.Forms.TextBox MissesofGrouptextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AllLessonsofGrouptextBox;
        private System.Windows.Forms.Label NavigationLabel;
        private System.Windows.Forms.ComboBox DateComboBox;
        private System.Windows.Forms.Label Datelabel;
        private System.Windows.Forms.ComboBox GroupidcomboBox;
        private System.Windows.Forms.ComboBox DisciplineidcomboBox;
        private System.Windows.Forms.Label Numoflessonlabel;
        private System.Windows.Forms.ComboBox NumoflessoncomboBox;
    }
}