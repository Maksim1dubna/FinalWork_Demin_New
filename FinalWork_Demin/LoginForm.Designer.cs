
namespace FinalWork_Demin
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.LoginAndPasswordPanel = new System.Windows.Forms.Panel();
            this.DirectorradioButton = new System.Windows.Forms.RadioButton();
            this.LecturerradioButton = new System.Windows.Forms.RadioButton();
            this.StudentradioButton = new System.Windows.Forms.RadioButton();
            this.RegistationLabel = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.PassField = new System.Windows.Forms.TextBox();
            this.picPassword = new System.Windows.Forms.PictureBox();
            this.loginField = new System.Windows.Forms.TextBox();
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.authorizationPanel = new System.Windows.Forms.Panel();
            this.authorizationLabel = new System.Windows.Forms.Label();
            this.AdminradioButton = new System.Windows.Forms.RadioButton();
            this.LoginAndPasswordPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            this.authorizationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginAndPasswordPanel
            // 
            this.LoginAndPasswordPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.LoginAndPasswordPanel.Controls.Add(this.DirectorradioButton);
            this.LoginAndPasswordPanel.Controls.Add(this.LecturerradioButton);
            this.LoginAndPasswordPanel.Controls.Add(this.StudentradioButton);
            this.LoginAndPasswordPanel.Controls.Add(this.RegistationLabel);
            this.LoginAndPasswordPanel.Controls.Add(this.buttonLogin);
            this.LoginAndPasswordPanel.Controls.Add(this.PassField);
            this.LoginAndPasswordPanel.Controls.Add(this.picPassword);
            this.LoginAndPasswordPanel.Controls.Add(this.loginField);
            this.LoginAndPasswordPanel.Controls.Add(this.picLogin);
            this.LoginAndPasswordPanel.Controls.Add(this.authorizationPanel);
            this.LoginAndPasswordPanel.Controls.Add(this.AdminradioButton);
            this.LoginAndPasswordPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginAndPasswordPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginAndPasswordPanel.Name = "LoginAndPasswordPanel";
            this.LoginAndPasswordPanel.Size = new System.Drawing.Size(334, 311);
            this.LoginAndPasswordPanel.TabIndex = 0;
            // 
            // DirectorradioButton
            // 
            this.DirectorradioButton.AutoSize = true;
            this.DirectorradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DirectorradioButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DirectorradioButton.Location = new System.Drawing.Point(10, 250);
            this.DirectorradioButton.Name = "DirectorradioButton";
            this.DirectorradioButton.Size = new System.Drawing.Size(94, 24);
            this.DirectorradioButton.TabIndex = 30;
            this.DirectorradioButton.TabStop = true;
            this.DirectorradioButton.Text = "Уч.часть";
            this.DirectorradioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DirectorradioButton.UseVisualStyleBackColor = true;
            // 
            // LecturerradioButton
            // 
            this.LecturerradioButton.AutoSize = true;
            this.LecturerradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LecturerradioButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LecturerradioButton.Location = new System.Drawing.Point(108, 222);
            this.LecturerradioButton.Name = "LecturerradioButton";
            this.LecturerradioButton.Size = new System.Drawing.Size(150, 24);
            this.LecturerradioButton.TabIndex = 28;
            this.LecturerradioButton.TabStop = true;
            this.LecturerradioButton.Text = "Преподаватель";
            this.LecturerradioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LecturerradioButton.UseVisualStyleBackColor = true;
            // 
            // StudentradioButton
            // 
            this.StudentradioButton.AutoSize = true;
            this.StudentradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StudentradioButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StudentradioButton.Location = new System.Drawing.Point(10, 222);
            this.StudentradioButton.Name = "StudentradioButton";
            this.StudentradioButton.Size = new System.Drawing.Size(92, 24);
            this.StudentradioButton.TabIndex = 27;
            this.StudentradioButton.TabStop = true;
            this.StudentradioButton.Text = "Студент";
            this.StudentradioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StudentradioButton.UseVisualStyleBackColor = true;
            // 
            // RegistationLabel
            // 
            this.RegistationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RegistationLabel.AutoSize = true;
            this.RegistationLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegistationLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistationLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RegistationLabel.Location = new System.Drawing.Point(6, 277);
            this.RegistationLabel.Name = "RegistationLabel";
            this.RegistationLabel.Size = new System.Drawing.Size(129, 22);
            this.RegistationLabel.TabIndex = 6;
            this.RegistationLabel.Text = "Регистрация";
            this.RegistationLabel.Visible = false;
            this.RegistationLabel.Click += new System.EventHandler(this.RegistationLabel_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonLogin.Location = new System.Drawing.Point(192, 261);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(138, 45);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Войти";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // PassField
            // 
            this.PassField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PassField.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PassField.Location = new System.Drawing.Point(73, 154);
            this.PassField.Name = "PassField";
            this.PassField.Size = new System.Drawing.Size(249, 62);
            this.PassField.TabIndex = 4;
            this.PassField.UseSystemPasswordChar = true;
            // 
            // picPassword
            // 
            this.picPassword.Image = global::FinalWork_Demin.Properties.Resources.password;
            this.picPassword.Location = new System.Drawing.Point(3, 154);
            this.picPassword.Name = "picPassword";
            this.picPassword.Size = new System.Drawing.Size(64, 64);
            this.picPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPassword.TabIndex = 3;
            this.picPassword.TabStop = false;
            // 
            // loginField
            // 
            this.loginField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginField.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginField.Location = new System.Drawing.Point(73, 70);
            this.loginField.Name = "loginField";
            this.loginField.Size = new System.Drawing.Size(249, 62);
            this.loginField.TabIndex = 2;
            // 
            // picLogin
            // 
            this.picLogin.Image = global::FinalWork_Demin.Properties.Resources.login;
            this.picLogin.Location = new System.Drawing.Point(3, 70);
            this.picLogin.Name = "picLogin";
            this.picLogin.Size = new System.Drawing.Size(64, 64);
            this.picLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogin.TabIndex = 1;
            this.picLogin.TabStop = false;
            // 
            // authorizationPanel
            // 
            this.authorizationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(1)))), ((int)(((byte)(15)))));
            this.authorizationPanel.Controls.Add(this.authorizationLabel);
            this.authorizationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.authorizationPanel.Location = new System.Drawing.Point(0, 0);
            this.authorizationPanel.Name = "authorizationPanel";
            this.authorizationPanel.Size = new System.Drawing.Size(334, 64);
            this.authorizationPanel.TabIndex = 0;
            // 
            // authorizationLabel
            // 
            this.authorizationLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(98)))), ((int)(((byte)(159)))));
            this.authorizationLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.authorizationLabel.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authorizationLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.authorizationLabel.Location = new System.Drawing.Point(0, 0);
            this.authorizationLabel.Name = "authorizationLabel";
            this.authorizationLabel.Size = new System.Drawing.Size(334, 64);
            this.authorizationLabel.TabIndex = 0;
            this.authorizationLabel.Text = "Авторизация";
            this.authorizationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AdminradioButton
            // 
            this.AdminradioButton.AutoSize = true;
            this.AdminradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AdminradioButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AdminradioButton.Location = new System.Drawing.Point(108, 250);
            this.AdminradioButton.Name = "AdminradioButton";
            this.AdminradioButton.Size = new System.Drawing.Size(78, 24);
            this.AdminradioButton.TabIndex = 29;
            this.AdminradioButton.TabStop = true;
            this.AdminradioButton.Text = "Админ";
            this.AdminradioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AdminradioButton.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.LoginAndPasswordPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "LoginForm";
            this.Text = "Авторизация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.LoginAndPasswordPanel.ResumeLayout(false);
            this.LoginAndPasswordPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            this.authorizationPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LoginAndPasswordPanel;
        private System.Windows.Forms.Panel authorizationPanel;
        private System.Windows.Forms.Label authorizationLabel;
        private System.Windows.Forms.PictureBox picLogin;
        private System.Windows.Forms.TextBox loginField;
        private System.Windows.Forms.TextBox PassField;
        private System.Windows.Forms.PictureBox picPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label RegistationLabel;
        private System.Windows.Forms.RadioButton LecturerradioButton;
        private System.Windows.Forms.RadioButton StudentradioButton;
        private System.Windows.Forms.RadioButton AdminradioButton;
        private System.Windows.Forms.RadioButton DirectorradioButton;
    }
}