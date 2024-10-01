namespace DealershipSoftware
{
    partial class FormEmployeeInsert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmployeeInsert));
            buttonAccept = new Button();
            buttonCancel = new Button();
            labelFirstName = new Label();
            labelTelephone = new Label();
            labelEmail = new Label();
            labelDOB = new Label();
            labelPassword = new Label();
            textBoxEmail = new TextBox();
            textBoxFirstName = new TextBox();
            textBoxTelephone = new TextBox();
            textBoxPassword = new TextBox();
            dateTimePickerDOB = new DateTimePicker();
            textBoxLastName = new TextBox();
            labelLastName = new Label();
            SuspendLayout();
            // 
            // buttonAccept
            // 
            buttonAccept.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAccept.Location = new Point(12, 249);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(200, 100);
            buttonAccept.TabIndex = 6;
            buttonAccept.Text = "Потвърждаване";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCancel.Location = new Point(301, 249);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(200, 100);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отказ";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelFirstName.Location = new Point(12, 17);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(97, 23);
            labelFirstName.TabIndex = 2;
            labelFirstName.Text = "Първо име";
            // 
            // labelTelephone
            // 
            labelTelephone.AutoSize = true;
            labelTelephone.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTelephone.Location = new Point(12, 93);
            labelTelephone.Name = "labelTelephone";
            labelTelephone.Size = new Size(153, 23);
            labelTelephone.TabIndex = 3;
            labelTelephone.Text = "Телефонен номер";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmail.Location = new Point(12, 131);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(58, 23);
            labelEmail.TabIndex = 4;
            labelEmail.Text = "E-mail";
            // 
            // labelDOB
            // 
            labelDOB.AutoSize = true;
            labelDOB.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelDOB.Location = new Point(12, 172);
            labelDOB.Name = "labelDOB";
            labelDOB.Size = new Size(145, 23);
            labelDOB.TabIndex = 5;
            labelDOB.Text = "Дата на раждане";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelPassword.Location = new Point(12, 207);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(69, 23);
            labelPassword.TabIndex = 6;
            labelPassword.Text = "Парола";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmail.Location = new Point(171, 126);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(330, 32);
            textBoxEmail.TabIndex = 3;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxFirstName.Location = new Point(171, 12);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(330, 32);
            textBoxFirstName.TabIndex = 0;
            // 
            // textBoxTelephone
            // 
            textBoxTelephone.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxTelephone.Location = new Point(171, 88);
            textBoxTelephone.Name = "textBoxTelephone";
            textBoxTelephone.Size = new Size(330, 32);
            textBoxTelephone.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPassword.Location = new Point(171, 202);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(330, 32);
            textBoxPassword.TabIndex = 5;
            // 
            // dateTimePickerDOB
            // 
            dateTimePickerDOB.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDOB.Location = new Point(171, 164);
            dateTimePickerDOB.Name = "dateTimePickerDOB";
            dateTimePickerDOB.Size = new Size(330, 32);
            dateTimePickerDOB.TabIndex = 4;
            dateTimePickerDOB.ValueChanged += dateTimePickerDOB_ValueChanged;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLastName.Location = new Point(171, 50);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(330, 32);
            textBoxLastName.TabIndex = 1;
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelLastName.Location = new Point(12, 55);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(118, 23);
            labelLastName.TabIndex = 13;
            labelLastName.Text = "Фамилно име";
            // 
            // FormEmployeeInsert
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(513, 361);
            Controls.Add(textBoxLastName);
            Controls.Add(labelLastName);
            Controls.Add(dateTimePickerDOB);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxTelephone);
            Controls.Add(textBoxFirstName);
            Controls.Add(textBoxEmail);
            Controls.Add(labelPassword);
            Controls.Add(labelDOB);
            Controls.Add(labelEmail);
            Controls.Add(labelTelephone);
            Controls.Add(labelFirstName);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAccept);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormEmployeeInsert";
            Text = "Добавяне на служител";
            Load += FormEmployeeInsert_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAccept;
        private Button buttonCancel;
        private Label labelFirstName;
        private Label labelTelephone;
        private Label labelEmail;
        private Label labelDOB;
        private Label labelPassword;
        private TextBox textBoxEmail;
        private TextBox textBoxFirstName;
        private TextBox textBoxTelephone;
        private TextBox textBoxPassword;
        private DateTimePicker dateTimePickerDOB;
        private TextBox textBoxLastName;
        private Label labelLastName;
    }
}