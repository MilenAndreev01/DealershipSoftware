namespace DealershipSoftware
{
    partial class FormVehicleInsert
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
            textBoxModel = new TextBox();
            buttonChangePicture = new Button();
            buttonAccept = new Button();
            labelModel = new Label();
            openFileDialog1 = new OpenFileDialog();
            pictureBox1 = new PictureBox();
            comboBoxManufacturers = new ComboBox();
            labelVehicleType = new Label();
            comboBoxVehicleTypes = new ComboBox();
            labelManufacturer = new Label();
            labelMakeYear = new Label();
            labelPrice = new Label();
            textBoxPrice = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            buttonCancel = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBoxModel
            // 
            textBoxModel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxModel.Location = new Point(141, 51);
            textBoxModel.Name = "textBoxModel";
            textBoxModel.Size = new Size(416, 32);
            textBoxModel.TabIndex = 1;
            // 
            // buttonChangePicture
            // 
            buttonChangePicture.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttonChangePicture.Location = new Point(563, 324);
            buttonChangePicture.Name = "buttonChangePicture";
            buttonChangePicture.Size = new Size(150, 100);
            buttonChangePicture.TabIndex = 5;
            buttonChangePicture.Text = "Промяна на изображение";
            buttonChangePicture.UseVisualStyleBackColor = true;
            buttonChangePicture.Click += buttonBrowseFiles_Click;
            // 
            // buttonAccept
            // 
            buttonAccept.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAccept.Location = new Point(12, 324);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(200, 100);
            buttonAccept.TabIndex = 6;
            buttonAccept.Text = "Потвърждаване";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // labelModel
            // 
            labelModel.AutoSize = true;
            labelModel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelModel.Location = new Point(12, 56);
            labelModel.Name = "labelModel";
            labelModel.Size = new Size(62, 23);
            labelModel.TabIndex = 5;
            labelModel.Text = "Модел";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.jfif;*.bmp;";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(563, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(306, 306);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // comboBoxManufacturers
            // 
            comboBoxManufacturers.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxManufacturers.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxManufacturers.FormattingEnabled = true;
            comboBoxManufacturers.Location = new Point(141, 12);
            comboBoxManufacturers.Name = "comboBoxManufacturers";
            comboBoxManufacturers.Size = new Size(416, 33);
            comboBoxManufacturers.TabIndex = 0;
            comboBoxManufacturers.SelectedIndexChanged += comboBoxManufacturers_SelectedIndexChanged;
            // 
            // labelVehicleType
            // 
            labelVehicleType.AutoSize = true;
            labelVehicleType.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelVehicleType.Location = new Point(12, 132);
            labelVehicleType.Name = "labelVehicleType";
            labelVehicleType.Size = new Size(53, 23);
            labelVehicleType.TabIndex = 9;
            labelVehicleType.Text = "Шаси";
            // 
            // comboBoxVehicleTypes
            // 
            comboBoxVehicleTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVehicleTypes.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxVehicleTypes.FormattingEnabled = true;
            comboBoxVehicleTypes.Location = new Point(141, 127);
            comboBoxVehicleTypes.Name = "comboBoxVehicleTypes";
            comboBoxVehicleTypes.Size = new Size(416, 33);
            comboBoxVehicleTypes.TabIndex = 4;
            // 
            // labelManufacturer
            // 
            labelManufacturer.AutoSize = true;
            labelManufacturer.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelManufacturer.Location = new Point(12, 17);
            labelManufacturer.Name = "labelManufacturer";
            labelManufacturer.Size = new Size(123, 23);
            labelManufacturer.TabIndex = 11;
            labelManufacturer.Text = "Производител";
            // 
            // labelMakeYear
            // 
            labelMakeYear.AutoSize = true;
            labelMakeYear.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelMakeYear.Location = new Point(12, 94);
            labelMakeYear.Name = "labelMakeYear";
            labelMakeYear.Size = new Size(205, 23);
            labelMakeYear.TabIndex = 12;
            labelMakeYear.Text = "Година на производство";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelPrice.Location = new Point(12, 171);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(51, 23);
            labelPrice.TabIndex = 13;
            labelPrice.Text = "Цена";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPrice.Location = new Point(141, 166);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(416, 32);
            textBoxPrice.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(223, 89);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(81, 32);
            dateTimePicker1.TabIndex = 2;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCancel.Location = new Point(310, 324);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(200, 100);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отказ";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(719, 324);
            button1.Name = "button1";
            button1.Size = new Size(150, 100);
            button1.TabIndex = 14;
            button1.Text = "Премахване на изображение";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormVehicleInsert
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(875, 433);
            Controls.Add(button1);
            Controls.Add(buttonCancel);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBoxPrice);
            Controls.Add(labelPrice);
            Controls.Add(labelMakeYear);
            Controls.Add(labelManufacturer);
            Controls.Add(comboBoxVehicleTypes);
            Controls.Add(labelVehicleType);
            Controls.Add(comboBoxManufacturers);
            Controls.Add(pictureBox1);
            Controls.Add(labelModel);
            Controls.Add(buttonAccept);
            Controls.Add(buttonChangePicture);
            Controls.Add(textBoxModel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormVehicleInsert";
            Text = "Внос на автомобил";
            Load += FormVehicleInsert_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxModel;
        private Button buttonChangePicture;
        private Button buttonAccept;
        private Label labelModel;
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBox1;
        private ComboBox comboBoxManufacturers;
        private Label labelVehicleType;
        private ComboBox comboBoxVehicleTypes;
        private Label labelManufacturer;
        private Label labelMakeYear;
        private Label labelPrice;
        private TextBox textBoxPrice;
        private DateTimePicker dateTimePicker1;
        private Button buttonCancel;
        private Button button1;
    }
}