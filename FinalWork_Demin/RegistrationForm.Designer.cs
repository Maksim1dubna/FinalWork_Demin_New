
namespace FinalWork_Demin
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.RegistationLabel = new System.Windows.Forms.Label();
            this.LoginAndPasswordPanel = new System.Windows.Forms.Panel();
            this.NavigationLabel = new System.Windows.Forms.Label();
            this.TypeofJobcomboBox = new System.Windows.Forms.ComboBox();
            this.GroupcomboBox = new System.Windows.Forms.ComboBox();
            this.Ticketlabel = new System.Windows.Forms.Label();
            this.TabelnytextBox = new System.Windows.Forms.TextBox();
            this.FemaleradioButton = new System.Windows.Forms.RadioButton();
            this.MaleradioButton = new System.Windows.Forms.RadioButton();
            this.ФИОlabel = new System.Windows.Forms.Label();
            this.FIOtextBox = new System.Windows.Forms.TextBox();
            this.TypeofJob = new System.Windows.Forms.Label();
            this.Grouplabel = new System.Windows.Forms.Label();
            this.DateOfBornlabel = new System.Windows.Forms.Label();
            this.DateOfBorndateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.buttonRegistation = new System.Windows.Forms.Button();
            this.RegistationPassField = new System.Windows.Forms.TextBox();
            this.picPassword = new System.Windows.Forms.PictureBox();
            this.RegistationLoginField = new System.Windows.Forms.TextBox();
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.authorizationPanel = new System.Windows.Forms.Panel();
            this.LoginAndPasswordPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            this.authorizationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegistationLabel
            // 
            this.RegistationLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(98)))), ((int)(((byte)(159)))));
            this.RegistationLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RegistationLabel.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistationLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.RegistationLabel.Location = new System.Drawing.Point(0, 0);
            this.RegistationLabel.Name = "RegistationLabel";
            this.RegistationLabel.Size = new System.Drawing.Size(1320, 64);
            this.RegistationLabel.TabIndex = 0;
            this.RegistationLabel.Text = "Регистрация";
            this.RegistationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LoginAndPasswordPanel
            // 
            this.LoginAndPasswordPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.LoginAndPasswordPanel.Controls.Add(this.NavigationLabel);
            this.LoginAndPasswordPanel.Controls.Add(this.TypeofJobcomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.GroupcomboBox);
            this.LoginAndPasswordPanel.Controls.Add(this.Ticketlabel);
            this.LoginAndPasswordPanel.Controls.Add(this.TabelnytextBox);
            this.LoginAndPasswordPanel.Controls.Add(this.FemaleradioButton);
            this.LoginAndPasswordPanel.Controls.Add(this.MaleradioButton);
            this.LoginAndPasswordPanel.Controls.Add(this.ФИОlabel);
            this.LoginAndPasswordPanel.Controls.Add(this.FIOtextBox);
            this.LoginAndPasswordPanel.Controls.Add(this.TypeofJob);
            this.LoginAndPasswordPanel.Controls.Add(this.Grouplabel);
            this.LoginAndPasswordPanel.Controls.Add(this.DateOfBornlabel);
            this.LoginAndPasswordPanel.Controls.Add(this.DateOfBorndateTimePicker);
            this.LoginAndPasswordPanel.Controls.Add(this.LoginLabel);
            this.LoginAndPasswordPanel.Controls.Add(this.buttonRegistation);
            this.LoginAndPasswordPanel.Controls.Add(this.RegistationPassField);
            this.LoginAndPasswordPanel.Controls.Add(this.picPassword);
            this.LoginAndPasswordPanel.Controls.Add(this.RegistationLoginField);
            this.LoginAndPasswordPanel.Controls.Add(this.picLogin);
            this.LoginAndPasswordPanel.Controls.Add(this.authorizationPanel);
            this.LoginAndPasswordPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginAndPasswordPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginAndPasswordPanel.Name = "LoginAndPasswordPanel";
            this.LoginAndPasswordPanel.Size = new System.Drawing.Size(1320, 636);
            this.LoginAndPasswordPanel.TabIndex = 1;
            // 
            // NavigationLabel
            // 
            this.NavigationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NavigationLabel.AutoSize = true;
            this.NavigationLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NavigationLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NavigationLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NavigationLabel.Location = new System.Drawing.Point(862, 602);
            this.NavigationLabel.Name = "NavigationLabel";
            this.NavigationLabel.Size = new System.Drawing.Size(109, 22);
            this.NavigationLabel.TabIndex = 67;
            this.NavigationLabel.Text = "Навигация";
            this.NavigationLabel.Click += new System.EventHandler(this.NavigationLabel_Click);
            // 
            // TypeofJobcomboBox
            // 
            this.TypeofJobcomboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TypeofJobcomboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TypeofJobcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.TypeofJobcomboBox.Items.AddRange(new object[] {
            "Студент",
            "Преподаватель"});
            this.TypeofJobcomboBox.Location = new System.Drawing.Point(180, 114);
            this.TypeofJobcomboBox.Name = "TypeofJobcomboBox";
            this.TypeofJobcomboBox.Size = new System.Drawing.Size(452, 39);
            this.TypeofJobcomboBox.TabIndex = 66;
            this.TypeofJobcomboBox.SelectedIndexChanged += new System.EventHandler(this.TypeofJobcomboBox_SelectedIndexChanged);
            this.TypeofJobcomboBox.TextChanged += new System.EventHandler(this.TypeofJobcomboBox_TextChanged);
            // 
            // GroupcomboBox
            // 
            this.GroupcomboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.GroupcomboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.GroupcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.GroupcomboBox.Location = new System.Drawing.Point(331, 291);
            this.GroupcomboBox.Name = "GroupcomboBox";
            this.GroupcomboBox.Size = new System.Drawing.Size(177, 39);
            this.GroupcomboBox.TabIndex = 65;
            this.GroupcomboBox.Visible = false;
            // 
            // Ticketlabel
            // 
            this.Ticketlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.Ticketlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.Ticketlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Ticketlabel.Location = new System.Drawing.Point(12, 247);
            this.Ticketlabel.Name = "Ticketlabel";
            this.Ticketlabel.Size = new System.Drawing.Size(313, 38);
            this.Ticketlabel.TabIndex = 30;
            this.Ticketlabel.Text = "№ зачетки/Табельный";
            this.Ticketlabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TabelnytextBox
            // 
            this.TabelnytextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.TabelnytextBox.Location = new System.Drawing.Point(331, 247);
            this.TabelnytextBox.Name = "TabelnytextBox";
            this.TabelnytextBox.Size = new System.Drawing.Size(276, 38);
            this.TabelnytextBox.TabIndex = 27;
            // 
            // FemaleradioButton
            // 
            this.FemaleradioButton.AutoSize = true;
            this.FemaleradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FemaleradioButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FemaleradioButton.Location = new System.Drawing.Point(545, 203);
            this.FemaleradioButton.Name = "FemaleradioButton";
            this.FemaleradioButton.Size = new System.Drawing.Size(56, 35);
            this.FemaleradioButton.TabIndex = 26;
            this.FemaleradioButton.TabStop = true;
            this.FemaleradioButton.Text = "Ж";
            this.FemaleradioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FemaleradioButton.UseVisualStyleBackColor = true;
            // 
            // MaleradioButton
            // 
            this.MaleradioButton.AutoSize = true;
            this.MaleradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaleradioButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MaleradioButton.Location = new System.Drawing.Point(486, 203);
            this.MaleradioButton.Name = "MaleradioButton";
            this.MaleradioButton.Size = new System.Drawing.Size(54, 35);
            this.MaleradioButton.TabIndex = 25;
            this.MaleradioButton.TabStop = true;
            this.MaleradioButton.Text = "М";
            this.MaleradioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MaleradioButton.UseVisualStyleBackColor = true;
            // 
            // ФИОlabel
            // 
            this.ФИОlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.ФИОlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.ФИОlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ФИОlabel.Location = new System.Drawing.Point(12, 159);
            this.ФИОlabel.Name = "ФИОlabel";
            this.ФИОlabel.Size = new System.Drawing.Size(162, 38);
            this.ФИОlabel.TabIndex = 24;
            this.ФИОlabel.Text = "ФИО";
            this.ФИОlabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FIOtextBox
            // 
            this.FIOtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.FIOtextBox.Location = new System.Drawing.Point(180, 159);
            this.FIOtextBox.Name = "FIOtextBox";
            this.FIOtextBox.Size = new System.Drawing.Size(1128, 38);
            this.FIOtextBox.TabIndex = 23;
            this.FIOtextBox.Enter += new System.EventHandler(this.FIOtextBox_Enter);
            this.FIOtextBox.Leave += new System.EventHandler(this.FIOtextBox_Leave);
            // 
            // TypeofJob
            // 
            this.TypeofJob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.TypeofJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.TypeofJob.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TypeofJob.Location = new System.Drawing.Point(12, 114);
            this.TypeofJob.Name = "TypeofJob";
            this.TypeofJob.Size = new System.Drawing.Size(162, 39);
            this.TypeofJob.TabIndex = 22;
            this.TypeofJob.Text = "Статус";
            this.TypeofJob.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Grouplabel
            // 
            this.Grouplabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.Grouplabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.Grouplabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Grouplabel.Location = new System.Drawing.Point(12, 291);
            this.Grouplabel.Name = "Grouplabel";
            this.Grouplabel.Size = new System.Drawing.Size(313, 39);
            this.Grouplabel.TabIndex = 20;
            this.Grouplabel.Text = "Группа";
            this.Grouplabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Grouplabel.Visible = false;
            // 
            // DateOfBornlabel
            // 
            this.DateOfBornlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(67)))), ((int)(((byte)(151)))));
            this.DateOfBornlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.DateOfBornlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DateOfBornlabel.Location = new System.Drawing.Point(12, 203);
            this.DateOfBornlabel.Name = "DateOfBornlabel";
            this.DateOfBornlabel.Size = new System.Drawing.Size(286, 39);
            this.DateOfBornlabel.TabIndex = 19;
            this.DateOfBornlabel.Text = "Дата рождения";
            this.DateOfBornlabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DateOfBorndateTimePicker
            // 
            this.DateOfBorndateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.DateOfBorndateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.DateOfBorndateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.DateOfBorndateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateOfBorndateTimePicker.Location = new System.Drawing.Point(304, 203);
            this.DateOfBorndateTimePicker.Name = "DateOfBorndateTimePicker";
            this.DateOfBorndateTimePicker.Size = new System.Drawing.Size(176, 38);
            this.DateOfBorndateTimePicker.TabIndex = 18;
            // 
            // LoginLabel
            // 
            this.LoginLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoginLabel.Location = new System.Drawing.Point(8, 602);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(166, 22);
            this.LoginLabel.TabIndex = 7;
            this.LoginLabel.Text = "Войти в систему";
            this.LoginLabel.Click += new System.EventHandler(this.LoginLabel_Click);
            // 
            // buttonRegistation
            // 
            this.buttonRegistation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRegistation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.buttonRegistation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRegistation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistation.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRegistation.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonRegistation.Location = new System.Drawing.Point(977, 579);
            this.buttonRegistation.Name = "buttonRegistation";
            this.buttonRegistation.Size = new System.Drawing.Size(331, 45);
            this.buttonRegistation.TabIndex = 5;
            this.buttonRegistation.Text = "Зарегистрироваться";
            this.buttonRegistation.UseVisualStyleBackColor = false;
            this.buttonRegistation.Click += new System.EventHandler(this.buttonRegistation_Click);
            // 
            // RegistationPassField
            // 
            this.RegistationPassField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegistationPassField.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.RegistationPassField.Location = new System.Drawing.Point(682, 70);
            this.RegistationPassField.Name = "RegistationPassField";
            this.RegistationPassField.Size = new System.Drawing.Size(626, 38);
            this.RegistationPassField.TabIndex = 4;
            this.RegistationPassField.UseSystemPasswordChar = true;
            this.RegistationPassField.Enter += new System.EventHandler(this.RegistationPassField_Enter);
            this.RegistationPassField.Leave += new System.EventHandler(this.RegistationPassField_Leave);
            // 
            // picPassword
            // 
            this.picPassword.Image = global::FinalWork_Demin.Properties.Resources.password;
            this.picPassword.Location = new System.Drawing.Point(638, 70);
            this.picPassword.Name = "picPassword";
            this.picPassword.Size = new System.Drawing.Size(38, 38);
            this.picPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPassword.TabIndex = 3;
            this.picPassword.TabStop = false;
            // 
            // RegistationLoginField
            // 
            this.RegistationLoginField.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.RegistationLoginField.Location = new System.Drawing.Point(56, 70);
            this.RegistationLoginField.Name = "RegistationLoginField";
            this.RegistationLoginField.Size = new System.Drawing.Size(576, 38);
            this.RegistationLoginField.TabIndex = 2;
            this.RegistationLoginField.Enter += new System.EventHandler(this.RegistationLoginField_Enter);
            this.RegistationLoginField.Leave += new System.EventHandler(this.RegistationLoginField_Leave);
            // 
            // picLogin
            // 
            this.picLogin.Image = global::FinalWork_Demin.Properties.Resources.login;
            this.picLogin.Location = new System.Drawing.Point(12, 70);
            this.picLogin.Name = "picLogin";
            this.picLogin.Size = new System.Drawing.Size(38, 38);
            this.picLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogin.TabIndex = 1;
            this.picLogin.TabStop = false;
            // 
            // authorizationPanel
            // 
            this.authorizationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(1)))), ((int)(((byte)(15)))));
            this.authorizationPanel.Controls.Add(this.RegistationLabel);
            this.authorizationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.authorizationPanel.Location = new System.Drawing.Point(0, 0);
            this.authorizationPanel.Name = "authorizationPanel";
            this.authorizationPanel.Size = new System.Drawing.Size(1320, 64);
            this.authorizationPanel.TabIndex = 0;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 636);
            this.Controls.Add(this.LoginAndPasswordPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1336, 675);
            this.Name = "RegistrationForm";
            this.Text = "Регистрация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegistrationForm_FormClosed);
            this.LoginAndPasswordPanel.ResumeLayout(false);
            this.LoginAndPasswordPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            this.authorizationPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label RegistationLabel;
        private System.Windows.Forms.Panel LoginAndPasswordPanel;
        private System.Windows.Forms.Button buttonRegistation;
        private System.Windows.Forms.TextBox RegistationPassField;
        private System.Windows.Forms.PictureBox picPassword;
        private System.Windows.Forms.TextBox RegistationLoginField;
        private System.Windows.Forms.PictureBox picLogin;
        private System.Windows.Forms.Panel authorizationPanel;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.DateTimePicker DateOfBorndateTimePicker;
        private System.Windows.Forms.Label DateOfBornlabel;
        private System.Windows.Forms.Label Grouplabel;
        private System.Windows.Forms.Label TypeofJob;
        private System.Windows.Forms.Label ФИОlabel;
        private System.Windows.Forms.TextBox FIOtextBox;
        private System.Windows.Forms.TextBox TabelnytextBox;
        private System.Windows.Forms.RadioButton FemaleradioButton;
        private System.Windows.Forms.RadioButton MaleradioButton;
        private System.Windows.Forms.Label Ticketlabel;
        private System.Windows.Forms.ComboBox GroupcomboBox;
        private System.Windows.Forms.ComboBox TypeofJobcomboBox;
        private System.Windows.Forms.Label NavigationLabel;
    }
}