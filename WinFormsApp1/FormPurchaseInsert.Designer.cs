namespace DealershipSoftware
{
    partial class FormPurchaseInsert
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
            comboBoxClient = new ComboBox();
            buttonAccept = new Button();
            buttonCancel = new Button();
            comboBoxVehicle = new ComboBox();
            comboBoxPaymentType = new ComboBox();
            checkBoxDateTimeNow = new CheckBox();
            dateTimePickerDate = new DateTimePicker();
            dateTimePickerTime = new DateTimePicker();
            labelClient = new Label();
            labelVehicle = new Label();
            labelPaymentType = new Label();
            label1 = new Label();
            labelFinalPrice = new Label();
            textBoxFinalPrice = new TextBox();
            comboBoxEmployee = new ComboBox();
            labelEmployee = new Label();
            SuspendLayout();
            // 
            // comboBoxClient
            // 
            comboBoxClient.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClient.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxClient.FormattingEnabled = true;
            comboBoxClient.Location = new Point(229, 12);
            comboBoxClient.Name = "comboBoxClient";
            comboBoxClient.Size = new Size(391, 33);
            comboBoxClient.TabIndex = 0;
            // 
            // buttonAccept
            // 
            buttonAccept.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAccept.Location = new Point(13, 244);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(200, 100);
            buttonAccept.TabIndex = 1;
            buttonAccept.Text = "Потвърждаване";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCancel.Location = new Point(420, 244);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(200, 100);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Отказ";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // comboBoxVehicle
            // 
            comboBoxVehicle.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVehicle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxVehicle.FormattingEnabled = true;
            comboBoxVehicle.Location = new Point(229, 51);
            comboBoxVehicle.Name = "comboBoxVehicle";
            comboBoxVehicle.Size = new Size(391, 33);
            comboBoxVehicle.TabIndex = 3;
            // 
            // comboBoxPaymentType
            // 
            comboBoxPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPaymentType.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxPaymentType.FormattingEnabled = true;
            comboBoxPaymentType.Location = new Point(229, 90);
            comboBoxPaymentType.Name = "comboBoxPaymentType";
            comboBoxPaymentType.Size = new Size(391, 33);
            comboBoxPaymentType.TabIndex = 4;
            // 
            // checkBoxDateTimeNow
            // 
            checkBoxDateTimeNow.AutoSize = true;
            checkBoxDateTimeNow.Checked = true;
            checkBoxDateTimeNow.CheckState = CheckState.Checked;
            checkBoxDateTimeNow.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxDateTimeNow.Location = new Point(550, 132);
            checkBoxDateTimeNow.Name = "checkBoxDateTimeNow";
            checkBoxDateTimeNow.Size = new Size(76, 27);
            checkBoxDateTimeNow.TabIndex = 5;
            checkBoxDateTimeNow.Text = "Сега?";
            checkBoxDateTimeNow.UseVisualStyleBackColor = true;
            checkBoxDateTimeNow.CheckedChanged += checkBoxDateTimeNow_CheckedChanged;
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Enabled = false;
            dateTimePickerDate.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDate.Location = new Point(229, 129);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(204, 32);
            dateTimePickerDate.TabIndex = 6;
            // 
            // dateTimePickerTime
            // 
            dateTimePickerTime.Enabled = false;
            dateTimePickerTime.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerTime.Format = DateTimePickerFormat.Time;
            dateTimePickerTime.Location = new Point(439, 129);
            dateTimePickerTime.Name = "dateTimePickerTime";
            dateTimePickerTime.ShowUpDown = true;
            dateTimePickerTime.Size = new Size(105, 32);
            dateTimePickerTime.TabIndex = 7;
            // 
            // labelClient
            // 
            labelClient.AutoSize = true;
            labelClient.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelClient.Location = new Point(13, 17);
            labelClient.Name = "labelClient";
            labelClient.Size = new Size(65, 23);
            labelClient.TabIndex = 8;
            labelClient.Text = "Клиент";
            // 
            // labelVehicle
            // 
            labelVehicle.AutoSize = true;
            labelVehicle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelVehicle.Location = new Point(12, 56);
            labelVehicle.Name = "labelVehicle";
            labelVehicle.Size = new Size(163, 23);
            labelVehicle.TabIndex = 9;
            labelVehicle.Text = "Превозно средство";
            // 
            // labelPaymentType
            // 
            labelPaymentType.AutoSize = true;
            labelPaymentType.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelPaymentType.Location = new Point(12, 95);
            labelPaymentType.Name = "labelPaymentType";
            labelPaymentType.Size = new Size(160, 23);
            labelPaymentType.TabIndex = 10;
            labelPaymentType.Text = "Начин на плащане";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(13, 133);
            label1.Name = "label1";
            label1.Size = new Size(169, 23);
            label1.TabIndex = 11;
            label1.Text = "Време на продажба";
            // 
            // labelFinalPrice
            // 
            labelFinalPrice.AutoSize = true;
            labelFinalPrice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelFinalPrice.Location = new Point(13, 172);
            labelFinalPrice.Name = "labelFinalPrice";
            labelFinalPrice.Size = new Size(111, 23);
            labelFinalPrice.TabIndex = 12;
            labelFinalPrice.Text = "Крайна цена";
            // 
            // textBoxFinalPrice
            // 
            textBoxFinalPrice.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxFinalPrice.Location = new Point(229, 167);
            textBoxFinalPrice.Name = "textBoxFinalPrice";
            textBoxFinalPrice.Size = new Size(391, 32);
            textBoxFinalPrice.TabIndex = 13;
            textBoxFinalPrice.KeyPress += textBoxFinalPrice_KeyPress;
            // 
            // comboBoxEmployee
            // 
            comboBoxEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEmployee.Enabled = false;
            comboBoxEmployee.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxEmployee.FormattingEnabled = true;
            comboBoxEmployee.Location = new Point(229, 205);
            comboBoxEmployee.Name = "comboBoxEmployee";
            comboBoxEmployee.Size = new Size(391, 33);
            comboBoxEmployee.TabIndex = 14;
            comboBoxEmployee.Visible = false;
            // 
            // labelEmployee
            // 
            labelEmployee.AutoSize = true;
            labelEmployee.Enabled = false;
            labelEmployee.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmployee.Location = new Point(13, 210);
            labelEmployee.Name = "labelEmployee";
            labelEmployee.Size = new Size(86, 23);
            labelEmployee.TabIndex = 15;
            labelEmployee.Text = "Служител";
            labelEmployee.Visible = false;
            // 
            // FormPurchaseInsert
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 356);
            Controls.Add(labelEmployee);
            Controls.Add(comboBoxEmployee);
            Controls.Add(textBoxFinalPrice);
            Controls.Add(labelFinalPrice);
            Controls.Add(label1);
            Controls.Add(labelPaymentType);
            Controls.Add(labelVehicle);
            Controls.Add(labelClient);
            Controls.Add(dateTimePickerTime);
            Controls.Add(dateTimePickerDate);
            Controls.Add(checkBoxDateTimeNow);
            Controls.Add(comboBoxPaymentType);
            Controls.Add(comboBoxVehicle);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAccept);
            Controls.Add(comboBoxClient);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormPurchaseInsert";
            Text = "Продажба на Превозно средство";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxClient;
        private Button buttonAccept;
        private Button buttonCancel;
        private ComboBox comboBoxVehicle;
        private ComboBox comboBoxPaymentType;
        private CheckBox checkBoxDateTimeNow;
        private DateTimePicker dateTimePickerDate;
        private DateTimePicker dateTimePickerTime;
        private Label labelClient;
        private Label labelVehicle;
        private Label labelPaymentType;
        private Label label1;
        private Label labelFinalPrice;
        private TextBox textBoxFinalPrice;
        private ComboBox comboBoxEmployee;
        private Label labelEmployee;
    }
}