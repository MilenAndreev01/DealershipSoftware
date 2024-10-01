namespace DealershipSoftware
{
    partial class FormClientInsert
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
            textBoxFirstName = new TextBox();
            textBoxTelephone = new TextBox();
            labelFirstName = new Label();
            labelTelephone = new Label();
            buttonAccept = new Button();
            buttonCancel = new Button();
            labelLastName = new Label();
            textBoxLastName = new TextBox();
            SuspendLayout();
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxFirstName.Location = new Point(136, 12);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(334, 32);
            textBoxFirstName.TabIndex = 0;
            // 
            // textBoxTelephone
            // 
            textBoxTelephone.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxTelephone.Location = new Point(136, 88);
            textBoxTelephone.MaxLength = 10;
            textBoxTelephone.Name = "textBoxTelephone";
            textBoxTelephone.Size = new Size(334, 32);
            textBoxTelephone.TabIndex = 2;
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelFirstName.Location = new Point(12, 15);
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
            labelTelephone.Size = new Size(97, 23);
            labelTelephone.TabIndex = 3;
            labelTelephone.Text = "Тел. номер";
            // 
            // buttonAccept
            // 
            buttonAccept.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAccept.Location = new Point(12, 141);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(200, 100);
            buttonAccept.TabIndex = 3;
            buttonAccept.Text = "Потвърждаване";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCancel.Location = new Point(270, 141);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(200, 100);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "Отказ";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelLastName.Location = new Point(12, 55);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(118, 23);
            labelLastName.TabIndex = 7;
            labelLastName.Text = "Фамилно име";
            // 
            // textBoxLastName
            // 
            textBoxLastName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLastName.Location = new Point(136, 50);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(334, 32);
            textBoxLastName.TabIndex = 1;
            // 
            // FormClientInsert
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(482, 253);
            Controls.Add(labelLastName);
            Controls.Add(textBoxLastName);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAccept);
            Controls.Add(labelTelephone);
            Controls.Add(labelFirstName);
            Controls.Add(textBoxTelephone);
            Controls.Add(textBoxFirstName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormClientInsert";
            Text = "Добавяне на клиент";
            Load += FormClientInsert_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFirstName;
        private TextBox textBoxTelephone;
        private Label labelFirstName;
        private Label labelTelephone;
        private Button buttonAccept;
        private Button buttonCancel;
        private Label labelLastName;
        private TextBox textBoxLastName;
    }
}