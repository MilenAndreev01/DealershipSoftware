namespace DealershipSoftware
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            buttonLogout = new Button();
            richTextBoxCurrentEmployee = new RichTextBox();
            tabControl1 = new TabControl();
            panelClock = new Panel();
            labelDate = new Label();
            labelClock = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panelLogin = new Panel();
            buttonShowPassword = new Button();
            buttonForgottenPassword = new Button();
            labelEmail = new Label();
            buttonLogin = new Button();
            label1 = new Label();
            labelPassword = new Label();
            textBoxEmail = new TextBox();
            textBoxPassword = new TextBox();
            panelClock.SuspendLayout();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // buttonLogout
            // 
            buttonLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonLogout.Enabled = false;
            buttonLogout.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLogout.Location = new Point(1314, 760);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(165, 132);
            buttonLogout.TabIndex = 3;
            buttonLogout.Text = "Отписване";
            buttonLogout.UseVisualStyleBackColor = true;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // richTextBoxCurrentEmployee
            // 
            richTextBoxCurrentEmployee.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            richTextBoxCurrentEmployee.Enabled = false;
            richTextBoxCurrentEmployee.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBoxCurrentEmployee.Location = new Point(1267, 523);
            richTextBoxCurrentEmployee.Name = "richTextBoxCurrentEmployee";
            richTextBoxCurrentEmployee.ReadOnly = true;
            richTextBoxCurrentEmployee.Size = new Size(261, 231);
            richTextBoxCurrentEmployee.TabIndex = 4;
            richTextBoxCurrentEmployee.Text = "Сегашен логин:\nНяма логнат служител!";
            richTextBoxCurrentEmployee.TextChanged += richTextBoxCurrentEmployee_TextChanged;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Enabled = false;
            tabControl1.Location = new Point(11, 16);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1249, 940);
            tabControl1.TabIndex = 2;
            tabControl1.Visible = false;
            // 
            // panelClock
            // 
            panelClock.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelClock.BackColor = Color.FromArgb(70, 70, 70);
            panelClock.Controls.Add(labelDate);
            panelClock.Controls.Add(labelClock);
            panelClock.Location = new Point(1269, 16);
            panelClock.Name = "panelClock";
            panelClock.Size = new Size(262, 200);
            panelClock.TabIndex = 5;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Impact", 25F, FontStyle.Regular, GraphicsUnit.Point);
            labelDate.ForeColor = Color.FromArgb(224, 224, 224);
            labelDate.Location = new Point(17, 124);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(230, 52);
            labelDate.TabIndex = 1;
            labelDate.Text = "01.01.1999 г.";
            // 
            // labelClock
            // 
            labelClock.AutoSize = true;
            labelClock.Font = new Font("Impact", 40F, FontStyle.Regular, GraphicsUnit.Point);
            labelClock.ForeColor = Color.FromArgb(224, 224, 224);
            labelClock.Location = new Point(40, 18);
            labelClock.Name = "labelClock";
            labelClock.Size = new Size(193, 82);
            labelClock.TabIndex = 0;
            labelClock.Text = "00:00";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 2000;
            timer1.Tick += timer1_Tick;
            // 
            // panelLogin
            // 
            panelLogin.Anchor = AnchorStyles.None;
            panelLogin.Controls.Add(buttonShowPassword);
            panelLogin.Controls.Add(buttonForgottenPassword);
            panelLogin.Controls.Add(labelEmail);
            panelLogin.Controls.Add(buttonLogin);
            panelLogin.Controls.Add(label1);
            panelLogin.Controls.Add(labelPassword);
            panelLogin.Controls.Add(textBoxEmail);
            panelLogin.Controls.Add(textBoxPassword);
            panelLogin.Location = new Point(321, 285);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(633, 376);
            panelLogin.TabIndex = 12;
            // 
            // buttonShowPassword
            // 
            buttonShowPassword.Location = new Point(575, 127);
            buttonShowPassword.Name = "buttonShowPassword";
            buttonShowPassword.Size = new Size(41, 41);
            buttonShowPassword.TabIndex = 12;
            buttonShowPassword.Text = "👁";
            buttonShowPassword.UseVisualStyleBackColor = true;
            buttonShowPassword.Click += buttonShowPassword_Click;
            buttonShowPassword.MouseDown += buttonShowPassword_MouseDown;
            buttonShowPassword.MouseUp += buttonShowPassword_MouseUp;
            // 
            // buttonForgottenPassword
            // 
            buttonForgottenPassword.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonForgottenPassword.Location = new Point(447, 207);
            buttonForgottenPassword.Name = "buttonForgottenPassword";
            buttonForgottenPassword.Size = new Size(169, 132);
            buttonForgottenPassword.TabIndex = 10;
            buttonForgottenPassword.Text = "Забравена парола";
            buttonForgottenPassword.UseVisualStyleBackColor = true;
            buttonForgottenPassword.Click += buttonForgottenPassword_Click;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmail.Location = new Point(19, 46);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(85, 35);
            labelEmail.TabIndex = 8;
            labelEmail.Text = "Е-mail";
            labelEmail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonLogin
            // 
            buttonLogin.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLogin.Location = new Point(110, 207);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(169, 132);
            buttonLogin.TabIndex = 2;
            buttonLogin.Text = "Вписване";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(110, 86);
            label1.Name = "label1";
            label1.Size = new Size(167, 23);
            label1.TabIndex = 11;
            label1.Text = "Неправилен имейл!";
            label1.Visible = false;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelPassword.Location = new Point(8, 133);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(96, 32);
            labelPassword.TabIndex = 9;
            labelPassword.Text = "Парола";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmail.Location = new Point(110, 43);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(506, 41);
            textBoxEmail.TabIndex = 6;
            textBoxEmail.TextChanged += textBoxEmail_TextChanged;
            textBoxEmail.KeyPress += textBoxPassword_KeyPress;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPassword.Location = new Point(110, 127);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(459, 41);
            textBoxPassword.TabIndex = 7;
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxPassword.KeyPress += textBoxPassword_KeyPress;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1543, 972);
            Controls.Add(panelClock);
            Controls.Add(richTextBoxCurrentEmployee);
            Controls.Add(buttonLogout);
            Controls.Add(panelLogin);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1015, 715);
            Name = "FormMain";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Automotive Sales Software";
            Load += FormMain_Load;
            panelClock.ResumeLayout(false);
            panelClock.PerformLayout();
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private RichTextBox richTextBoxCurrentEmployee;
        private Button buttonLogout;
        private TabControl tabControl1;
        private Label labelUserName;
        private TextBox textBox2;
        private TextBox textBox1;
        private Panel panelClock;
        private Label labelDate;
        private Label labelClock;
        private System.Windows.Forms.Timer timer1;
        private Panel panelLogin;
        private Button buttonForgottenPassword;
        private Label labelEmail;
        private Button buttonLogin;
        private Label label1;
        private Label labelPassword;
        private TextBox textBoxEmail;
        private TextBox textBoxPassword;
        private Button buttonShowPassword;
    }
}