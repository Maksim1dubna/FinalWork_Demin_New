
namespace FinalWork_Demin
{
    partial class NavigationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigationForm));
            this.InsertDataButton = new System.Windows.Forms.Button();
            this.LoginAndPasswordPanel = new System.Windows.Forms.Panel();
            this.Loginlabel = new System.Windows.Forms.Label();
            this.RegistationLabel = new System.Windows.Forms.Label();
            this.ExamsMarksFormlabel = new System.Windows.Forms.Label();
            this.VisitsAndProgresslabel = new System.Windows.Forms.Label();
            this.CourseWorkslabel = new System.Windows.Forms.Label();
            this.AddNewDatalabel = new System.Windows.Forms.Label();
            this.AddLessonsLabel = new System.Windows.Forms.Label();
            this.LoginAndPasswordPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InsertDataButton
            // 
            this.InsertDataButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(3)))), ((int)(((byte)(12)))));
            this.InsertDataButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InsertDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InsertDataButton.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InsertDataButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.InsertDataButton.Location = new System.Drawing.Point(10, 528);
            this.InsertDataButton.Name = "InsertDataButton";
            this.InsertDataButton.Size = new System.Drawing.Size(331, 45);
            this.InsertDataButton.TabIndex = 23;
            this.InsertDataButton.Text = "Записать/Обновить";
            this.InsertDataButton.UseVisualStyleBackColor = false;
            // 
            // LoginAndPasswordPanel
            // 
            this.LoginAndPasswordPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.LoginAndPasswordPanel.Controls.Add(this.Loginlabel);
            this.LoginAndPasswordPanel.Controls.Add(this.RegistationLabel);
            this.LoginAndPasswordPanel.Controls.Add(this.ExamsMarksFormlabel);
            this.LoginAndPasswordPanel.Controls.Add(this.VisitsAndProgresslabel);
            this.LoginAndPasswordPanel.Controls.Add(this.CourseWorkslabel);
            this.LoginAndPasswordPanel.Controls.Add(this.AddNewDatalabel);
            this.LoginAndPasswordPanel.Controls.Add(this.AddLessonsLabel);
            this.LoginAndPasswordPanel.Controls.Add(this.InsertDataButton);
            this.LoginAndPasswordPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginAndPasswordPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginAndPasswordPanel.Name = "LoginAndPasswordPanel";
            this.LoginAndPasswordPanel.Size = new System.Drawing.Size(408, 450);
            this.LoginAndPasswordPanel.TabIndex = 3;
            // 
            // Loginlabel
            // 
            this.Loginlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Loginlabel.AutoSize = true;
            this.Loginlabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Loginlabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Loginlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Loginlabel.Location = new System.Drawing.Point(161, 419);
            this.Loginlabel.Name = "Loginlabel";
            this.Loginlabel.Size = new System.Drawing.Size(244, 22);
            this.Loginlabel.TabIndex = 30;
            this.Loginlabel.Text = "Войти с другим логином";
            this.Loginlabel.Click += new System.EventHandler(this.Loginlabel_Click);
            // 
            // RegistationLabel
            // 
            this.RegistationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RegistationLabel.AutoSize = true;
            this.RegistationLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegistationLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistationLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RegistationLabel.Location = new System.Drawing.Point(3, 419);
            this.RegistationLabel.Name = "RegistationLabel";
            this.RegistationLabel.Size = new System.Drawing.Size(129, 22);
            this.RegistationLabel.TabIndex = 29;
            this.RegistationLabel.Text = "Регистрация";
            this.RegistationLabel.Click += new System.EventHandler(this.RegistrationLabel_Click);
            // 
            // ExamsMarksFormlabel
            // 
            this.ExamsMarksFormlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExamsMarksFormlabel.AutoSize = true;
            this.ExamsMarksFormlabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExamsMarksFormlabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExamsMarksFormlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ExamsMarksFormlabel.Location = new System.Drawing.Point(105, 125);
            this.ExamsMarksFormlabel.Name = "ExamsMarksFormlabel";
            this.ExamsMarksFormlabel.Size = new System.Drawing.Size(200, 22);
            this.ExamsMarksFormlabel.TabIndex = 27;
            this.ExamsMarksFormlabel.Text = "Итоговая аттестация";
            this.ExamsMarksFormlabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ExamsMarksFormlabel.Click += new System.EventHandler(this.ExamsMarksFormlabel_Click);
            // 
            // VisitsAndProgresslabel
            // 
            this.VisitsAndProgresslabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VisitsAndProgresslabel.AutoSize = true;
            this.VisitsAndProgresslabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VisitsAndProgresslabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VisitsAndProgresslabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.VisitsAndProgresslabel.Location = new System.Drawing.Point(126, 84);
            this.VisitsAndProgresslabel.Name = "VisitsAndProgresslabel";
            this.VisitsAndProgresslabel.Size = new System.Drawing.Size(160, 22);
            this.VisitsAndProgresslabel.TabIndex = 26;
            this.VisitsAndProgresslabel.Text = "Посещаемость";
            this.VisitsAndProgresslabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.VisitsAndProgresslabel.Click += new System.EventHandler(this.VisitsAndProgresslabel_Click);
            // 
            // CourseWorkslabel
            // 
            this.CourseWorkslabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CourseWorkslabel.AutoSize = true;
            this.CourseWorkslabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CourseWorkslabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CourseWorkslabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CourseWorkslabel.Location = new System.Drawing.Point(114, 165);
            this.CourseWorkslabel.Name = "CourseWorkslabel";
            this.CourseWorkslabel.Size = new System.Drawing.Size(179, 22);
            this.CourseWorkslabel.TabIndex = 25;
            this.CourseWorkslabel.Text = "Курсовые работы";
            this.CourseWorkslabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CourseWorkslabel.Click += new System.EventHandler(this.CourseWorkslabel_Click);
            // 
            // AddNewDatalabel
            // 
            this.AddNewDatalabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddNewDatalabel.AutoSize = true;
            this.AddNewDatalabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddNewDatalabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddNewDatalabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddNewDatalabel.Location = new System.Drawing.Point(51, 9);
            this.AddNewDatalabel.Name = "AddNewDatalabel";
            this.AddNewDatalabel.Size = new System.Drawing.Size(305, 22);
            this.AddNewDatalabel.TabIndex = 24;
            this.AddNewDatalabel.Text = "Добавление начальных данных";
            this.AddNewDatalabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AddNewDatalabel.Click += new System.EventHandler(this.AddNewDatalabel_Click);
            // 
            // AddLessonsLabel
            // 
            this.AddLessonsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddLessonsLabel.AutoSize = true;
            this.AddLessonsLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddLessonsLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddLessonsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddLessonsLabel.Location = new System.Drawing.Point(86, 46);
            this.AddLessonsLabel.Name = "AddLessonsLabel";
            this.AddLessonsLabel.Size = new System.Drawing.Size(249, 22);
            this.AddLessonsLabel.TabIndex = 7;
            this.AddLessonsLabel.Text = "Занятия и преподаватели";
            this.AddLessonsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AddLessonsLabel.Click += new System.EventHandler(this.AddLessonsLabel_Click);
            // 
            // NavigationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 450);
            this.Controls.Add(this.LoginAndPasswordPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NavigationForm";
            this.Text = "Навигация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NavigationForm_FormClosed);
            this.LoginAndPasswordPanel.ResumeLayout(false);
            this.LoginAndPasswordPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button InsertDataButton;
        private System.Windows.Forms.Panel LoginAndPasswordPanel;
        private System.Windows.Forms.Label CourseWorkslabel;
        private System.Windows.Forms.Label AddNewDatalabel;
        private System.Windows.Forms.Label AddLessonsLabel;
        private System.Windows.Forms.Label ExamsMarksFormlabel;
        private System.Windows.Forms.Label VisitsAndProgresslabel;
        private System.Windows.Forms.Label Loginlabel;
        private System.Windows.Forms.Label RegistationLabel;
    }
}