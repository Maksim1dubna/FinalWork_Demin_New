
namespace FinalWork_Demin
{
    partial class CourseWorksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseWorksForm));
            this.LoginAndPasswordPanel = new System.Windows.Forms.Panel();
            this.DisciplinePrintidcomboBox = new System.Windows.Forms.ComboBox();
            this.DisciplineprintcomboBox = new System.Windows.Forms.ComboBox();
            this.Disciplinelabel = new System.Windows.Forms.Label();
            this.DisciplineidcomboBox = new System.Windows.Forms.ComboBox();
            this.StudentidcomboBox = new System.Windows.Forms.ComboBox();
            this.GroupidcomboBox = new System.Windows.Forms.ComboBox();
            this.DisciplinecomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Printbutton = new System.Windows.Forms.Button();
            this.Themelabel = new System.Windows.Forms.Label();
            this.ThemetextBox = new System.Windows.Forms.TextBox();
            this.MarkcomboBox = new System.Windows.Forms.ComboBox();
            this.Marklabel = new System.Windows.Forms.Label();
            this.SemestrComboBox = new System.Windows.Forms.ComboBox();
            this.Semestrlabel2 = new System.Windows.Forms.Label();
            this.InsertMarksButton = new System.Windows.Forms.Button();
            this.GroupcomboBox = new System.Windows.Forms.ComboBox();
            this.Grouplabel2 = new System.Windows.Forms.Label();
            this.StudentcomboBox = new System.Windows.Forms.ComboBox();
            this.Studentlabel = new System.Windows.Forms.Label();
            this.authorizationPanel = new System.Windows.Forms.Panel();
            this.NavigationLabel = new System.Windows.Forms.Label();
            this.SetUpLabel = new System.Windows.Forms.Label();
            this.LoginAndPasswordPanel.SuspendLayout();
            this.authorizationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginAndPasswordPanel
            // 
            this.LoginAndPasswordPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.LoginAndPasswordPanel.Controls.Add(this.DisciplinePrintidcomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.DisciplineprintcomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.Disciplinelabel);
            this.LoginAndPasswordPanel.Controls.Add(this.DisciplineidcomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.StudentidcomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.GroupidcomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.DisciplinecomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.label1);
            this.LoginAndPasswordPanel.Controls.Add(this.Printbutton);
            this.LoginAndPasswordPanel.Controls.Add(this.Themelabel);
            this.LoginAndPasswordPanel.Controls.Add(this.ThemetextBox);
            this.LoginAndPasswordPanel.Controls.Add(this.MarkcomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.Marklabel);
            this.LoginAndPasswordPanel.Controls.Add(this.SemestrComboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.Semestrlabel2);
            this.LoginAndPasswordPanel.Controls.Add(this.InsertMarksButton);
            this.LoginAndPasswordPanel.Controls.Add(this.GroupcomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.Grouplabel2);
            this.LoginAndPasswordPanel.Controls.Add(this.StudentcomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.Studentlabel);
            this.LoginAndPasswordPanel.Controls.Add(this.authorizationPanel);
            this.LoginAndPasswordPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginAndPasswordPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginAndPasswordPanel.Name = "LoginAndPasswordPanel";
            this.LoginAndPasswordPanel.Size = new System.Drawing.Size(1006, 585);
            this.LoginAndPasswordPanel.TabIndex = 3;
            // 
            // DisciplinePrintidcomboBox
            // 
            this.DisciplinePrintidcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DisciplinePrintidcomboBox.Enabled = false;
            this.DisciplinePrintidcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.DisciplinePrintidcomboBox.Location = new System.Drawing.Point(702, 483);
            this.DisciplinePrintidcomboBox.Name = "DisciplinePrintidcomboBox";
            this.DisciplinePrintidcomboBox.Size = new System.Drawing.Size(143, 39);
            this.DisciplinePrintidcomboBox.TabIndex = 92;
            // 
            // DisciplineprintcomboBox
            // 
            this.DisciplineprintcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DisciplineprintcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.DisciplineprintcomboBox.Location = new System.Drawing.Point(195, 483);
            this.DisciplineprintcomboBox.Name = "DisciplineprintcomboBox";
            this.DisciplineprintcomboBox.Size = new System.Drawing.Size(501, 39);
            this.DisciplineprintcomboBox.TabIndex = 91;
            this.DisciplineprintcomboBox.SelectedIndexChanged += new System.EventHandler(this.DisciplineprintcomboBox_SelectedIndexChanged);
            // 
            // Disciplinelabel
            // 
            this.Disciplinelabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.Disciplinelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.Disciplinelabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Disciplinelabel.Location = new System.Drawing.Point(12, 483);
            this.Disciplinelabel.Name = "Disciplinelabel";
            this.Disciplinelabel.Size = new System.Drawing.Size(177, 39);
            this.Disciplinelabel.TabIndex = 90;
            this.Disciplinelabel.Text = "Дисциплина";
            this.Disciplinelabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DisciplineidcomboBox
            // 
            this.DisciplineidcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DisciplineidcomboBox.Enabled = false;
            this.DisciplineidcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.DisciplineidcomboBox.Location = new System.Drawing.Point(702, 161);
            this.DisciplineidcomboBox.Name = "DisciplineidcomboBox";
            this.DisciplineidcomboBox.Size = new System.Drawing.Size(143, 39);
            this.DisciplineidcomboBox.TabIndex = 89;
            // 
            // StudentidcomboBox
            // 
            this.StudentidcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StudentidcomboBox.Enabled = false;
            this.StudentidcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.StudentidcomboBox.Location = new System.Drawing.Point(851, 116);
            this.StudentidcomboBox.Name = "StudentidcomboBox";
            this.StudentidcomboBox.Size = new System.Drawing.Size(143, 39);
            this.StudentidcomboBox.TabIndex = 88;
            // 
            // GroupidcomboBox
            // 
            this.GroupidcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupidcomboBox.Enabled = false;
            this.GroupidcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.GroupidcomboBox.Location = new System.Drawing.Point(332, 71);
            this.GroupidcomboBox.Name = "GroupidcomboBox";
            this.GroupidcomboBox.Size = new System.Drawing.Size(67, 39);
            this.GroupidcomboBox.TabIndex = 87;
            // 
            // DisciplinecomboBox
            // 
            this.DisciplinecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DisciplinecomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.DisciplinecomboBox.Location = new System.Drawing.Point(195, 161);
            this.DisciplinecomboBox.Name = "DisciplinecomboBox";
            this.DisciplinecomboBox.Size = new System.Drawing.Size(501, 39);
            this.DisciplinecomboBox.TabIndex = 48;
            this.DisciplinecomboBox.SelectedIndexChanged += new System.EventHandler(this.DisciplinecomboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 39);
            this.label1.TabIndex = 47;
            this.label1.Text = "Дисциплина";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Printbutton
            // 
            this.Printbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.Printbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Printbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Printbutton.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Printbutton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Printbutton.Location = new System.Drawing.Point(10, 528);
            this.Printbutton.Name = "Printbutton";
            this.Printbutton.Size = new System.Drawing.Size(431, 45);
            this.Printbutton.TabIndex = 45;
            this.Printbutton.Text = "Сформировать ведомость";
            this.Printbutton.UseVisualStyleBackColor = false;
            this.Printbutton.Click += new System.EventHandler(this.Printbutton_Click);
            // 
            // Themelabel
            // 
            this.Themelabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.Themelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.Themelabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Themelabel.Location = new System.Drawing.Point(12, 251);
            this.Themelabel.Name = "Themelabel";
            this.Themelabel.Size = new System.Drawing.Size(177, 38);
            this.Themelabel.TabIndex = 44;
            this.Themelabel.Text = "Тема работы";
            this.Themelabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ThemetextBox
            // 
            this.ThemetextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.ThemetextBox.Location = new System.Drawing.Point(195, 251);
            this.ThemetextBox.Name = "ThemetextBox";
            this.ThemetextBox.Size = new System.Drawing.Size(650, 38);
            this.ThemetextBox.TabIndex = 43;
            // 
            // MarkcomboBox
            // 
            this.MarkcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MarkcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.MarkcomboBox.Items.AddRange(new object[] {
            "Отлично",
            "Хорошо",
            "Удовлетворительно",
            "Неудовлетворительно",
            "н/я",
            "-"});
            this.MarkcomboBox.Location = new System.Drawing.Point(195, 206);
            this.MarkcomboBox.Name = "MarkcomboBox";
            this.MarkcomboBox.Size = new System.Drawing.Size(204, 39);
            this.MarkcomboBox.TabIndex = 42;
            // 
            // Marklabel
            // 
            this.Marklabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.Marklabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.Marklabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Marklabel.Location = new System.Drawing.Point(12, 206);
            this.Marklabel.Name = "Marklabel";
            this.Marklabel.Size = new System.Drawing.Size(177, 39);
            this.Marklabel.TabIndex = 41;
            this.Marklabel.Text = "Оценка";
            this.Marklabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SemestrComboBox
            // 
            this.SemestrComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SemestrComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.SemestrComboBox.Location = new System.Drawing.Point(536, 71);
            this.SemestrComboBox.Name = "SemestrComboBox";
            this.SemestrComboBox.Size = new System.Drawing.Size(63, 39);
            this.SemestrComboBox.TabIndex = 40;
            this.SemestrComboBox.SelectedIndexChanged += new System.EventHandler(this.SemestrComboBox2_SelectedIndexChanged);
            // 
            // Semestrlabel2
            // 
            this.Semestrlabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.Semestrlabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.Semestrlabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Semestrlabel2.Location = new System.Drawing.Point(405, 71);
            this.Semestrlabel2.Name = "Semestrlabel2";
            this.Semestrlabel2.Size = new System.Drawing.Size(125, 39);
            this.Semestrlabel2.TabIndex = 39;
            this.Semestrlabel2.Text = "Семестр";
            this.Semestrlabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // InsertMarksButton
            // 
            this.InsertMarksButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.InsertMarksButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InsertMarksButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InsertMarksButton.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InsertMarksButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.InsertMarksButton.Location = new System.Drawing.Point(10, 295);
            this.InsertMarksButton.Name = "InsertMarksButton";
            this.InsertMarksButton.Size = new System.Drawing.Size(179, 45);
            this.InsertMarksButton.TabIndex = 38;
            this.InsertMarksButton.Text = "Записать";
            this.InsertMarksButton.UseVisualStyleBackColor = false;
            this.InsertMarksButton.Click += new System.EventHandler(this.InsertMarksButton_Click);
            // 
            // GroupcomboBox
            // 
            this.GroupcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.GroupcomboBox.Location = new System.Drawing.Point(122, 71);
            this.GroupcomboBox.Name = "GroupcomboBox";
            this.GroupcomboBox.Size = new System.Drawing.Size(204, 39);
            this.GroupcomboBox.TabIndex = 37;
            this.GroupcomboBox.SelectedIndexChanged += new System.EventHandler(this.GroupcomboBox2_SelectedIndexChanged);
            // 
            // Grouplabel2
            // 
            this.Grouplabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.Grouplabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.Grouplabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Grouplabel2.Location = new System.Drawing.Point(12, 71);
            this.Grouplabel2.Name = "Grouplabel2";
            this.Grouplabel2.Size = new System.Drawing.Size(104, 39);
            this.Grouplabel2.TabIndex = 36;
            this.Grouplabel2.Text = "Группа";
            this.Grouplabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StudentcomboBox
            // 
            this.StudentcomboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.StudentcomboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.StudentcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StudentcomboBox.Location = new System.Drawing.Point(195, 116);
            this.StudentcomboBox.Name = "StudentcomboBox";
            this.StudentcomboBox.Size = new System.Drawing.Size(650, 39);
            this.StudentcomboBox.TabIndex = 35;
            this.StudentcomboBox.SelectedIndexChanged += new System.EventHandler(this.StudentcomboBox_SelectedIndexChanged);
            // 
            // Studentlabel
            // 
            this.Studentlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.Studentlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.Studentlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Studentlabel.Location = new System.Drawing.Point(12, 116);
            this.Studentlabel.Name = "Studentlabel";
            this.Studentlabel.Size = new System.Drawing.Size(177, 39);
            this.Studentlabel.TabIndex = 34;
            this.Studentlabel.Text = "Студент";
            this.Studentlabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // authorizationPanel
            // 
            this.authorizationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(1)))), ((int)(((byte)(15)))));
            this.authorizationPanel.Controls.Add(this.NavigationLabel);
            this.authorizationPanel.Controls.Add(this.SetUpLabel);
            this.authorizationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.authorizationPanel.Location = new System.Drawing.Point(0, 0);
            this.authorizationPanel.Name = "authorizationPanel";
            this.authorizationPanel.Size = new System.Drawing.Size(1006, 64);
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
            this.NavigationLabel.Location = new System.Drawing.Point(780, 42);
            this.NavigationLabel.Name = "NavigationLabel";
            this.NavigationLabel.Size = new System.Drawing.Size(223, 22);
            this.NavigationLabel.TabIndex = 9;
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
            this.SetUpLabel.Size = new System.Drawing.Size(1006, 64);
            this.SetUpLabel.TabIndex = 0;
            this.SetUpLabel.Text = "Курсовые работы";
            this.SetUpLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CourseWorksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 585);
            this.Controls.Add(this.LoginAndPasswordPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CourseWorksForm";
            this.Text = "Курсовые работы";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CourseWorksForm_FormClosed);
            this.LoginAndPasswordPanel.ResumeLayout(false);
            this.LoginAndPasswordPanel.PerformLayout();
            this.authorizationPanel.ResumeLayout(false);
            this.authorizationPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel LoginAndPasswordPanel;
        private System.Windows.Forms.Panel authorizationPanel;
        private System.Windows.Forms.Label SetUpLabel;
        private System.Windows.Forms.ComboBox SemestrComboBox;
        private System.Windows.Forms.Label Semestrlabel2;
        private System.Windows.Forms.Button InsertMarksButton;
        private System.Windows.Forms.ComboBox GroupcomboBox;
        private System.Windows.Forms.Label Grouplabel2;
        private System.Windows.Forms.ComboBox StudentcomboBox;
        private System.Windows.Forms.Label Studentlabel;
        private System.Windows.Forms.ComboBox MarkcomboBox;
        private System.Windows.Forms.Label Marklabel;
        private System.Windows.Forms.Label Themelabel;
        private System.Windows.Forms.TextBox ThemetextBox;
        private System.Windows.Forms.Button Printbutton;
        private System.Windows.Forms.Label NavigationLabel;
        private System.Windows.Forms.ComboBox DisciplinecomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox GroupidcomboBox;
        private System.Windows.Forms.ComboBox StudentidcomboBox;
        private System.Windows.Forms.ComboBox DisciplineidcomboBox;
        private System.Windows.Forms.ComboBox DisciplinePrintidcomboBox;
        private System.Windows.Forms.ComboBox DisciplineprintcomboBox;
        private System.Windows.Forms.Label Disciplinelabel;
    }
}