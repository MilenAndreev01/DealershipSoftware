namespace DealershipSoftware
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            groupBoxDebugOperationType = new GroupBox();
            radioButtonSelect = new RadioButton();
            radioButtonInsert = new RadioButton();
            radioButtonEdit = new RadioButton();
            radioButtonDelete = new RadioButton();
            groupBoxDebugTableType = new GroupBox();
            radioButtonManufacturerVehicleType = new RadioButton();
            radioButtonPurchase = new RadioButton();
            radioButtonVehicles = new RadioButton();
            radioButtonClients = new RadioButton();
            radioButtonEmployees = new RadioButton();
            radioButtonTypePayment = new RadioButton();
            radioButtonManufacturers = new RadioButton();
            radioButtonTypeVehicle = new RadioButton();
            dataGridViewTest = new DataGridView();
            buttonDebug = new Button();
            groupBoxDebugOperationType.SuspendLayout();
            groupBoxDebugTableType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTest).BeginInit();
            SuspendLayout();
            // 
            // groupBoxDebugOperationType
            // 
            groupBoxDebugOperationType.Controls.Add(radioButtonSelect);
            groupBoxDebugOperationType.Controls.Add(radioButtonInsert);
            groupBoxDebugOperationType.Controls.Add(radioButtonEdit);
            groupBoxDebugOperationType.Controls.Add(radioButtonDelete);
            groupBoxDebugOperationType.Location = new Point(402, 6);
            groupBoxDebugOperationType.Name = "groupBoxDebugOperationType";
            groupBoxDebugOperationType.Size = new Size(123, 191);
            groupBoxDebugOperationType.TabIndex = 19;
            groupBoxDebugOperationType.TabStop = false;
            groupBoxDebugOperationType.Text = "Operation type";
            // 
            // radioButtonSelect
            // 
            radioButtonSelect.AutoSize = true;
            radioButtonSelect.Checked = true;
            radioButtonSelect.Location = new Point(6, 30);
            radioButtonSelect.Name = "radioButtonSelect";
            radioButtonSelect.Size = new Size(70, 24);
            radioButtonSelect.TabIndex = 3;
            radioButtonSelect.TabStop = true;
            radioButtonSelect.Text = "Select";
            radioButtonSelect.UseVisualStyleBackColor = true;
            // 
            // radioButtonInsert
            // 
            radioButtonInsert.AutoSize = true;
            radioButtonInsert.Location = new Point(6, 59);
            radioButtonInsert.Name = "radioButtonInsert";
            radioButtonInsert.Size = new Size(66, 24);
            radioButtonInsert.TabIndex = 11;
            radioButtonInsert.Text = "Insert";
            radioButtonInsert.UseVisualStyleBackColor = true;
            // 
            // radioButtonEdit
            // 
            radioButtonEdit.AutoSize = true;
            radioButtonEdit.Enabled = false;
            radioButtonEdit.Location = new Point(6, 119);
            radioButtonEdit.Name = "radioButtonEdit";
            radioButtonEdit.Size = new Size(56, 24);
            radioButtonEdit.TabIndex = 12;
            radioButtonEdit.Text = "Edit";
            radioButtonEdit.UseVisualStyleBackColor = true;
            // 
            // radioButtonDelete
            // 
            radioButtonDelete.AutoSize = true;
            radioButtonDelete.Enabled = false;
            radioButtonDelete.Location = new Point(6, 88);
            radioButtonDelete.Name = "radioButtonDelete";
            radioButtonDelete.Size = new Size(74, 24);
            radioButtonDelete.TabIndex = 13;
            radioButtonDelete.Text = "Delete";
            radioButtonDelete.UseVisualStyleBackColor = true;
            // 
            // groupBoxDebugTableType
            // 
            groupBoxDebugTableType.Controls.Add(radioButtonManufacturerVehicleType);
            groupBoxDebugTableType.Controls.Add(radioButtonPurchase);
            groupBoxDebugTableType.Controls.Add(radioButtonVehicles);
            groupBoxDebugTableType.Controls.Add(radioButtonClients);
            groupBoxDebugTableType.Controls.Add(radioButtonEmployees);
            groupBoxDebugTableType.Controls.Add(radioButtonTypePayment);
            groupBoxDebugTableType.Controls.Add(radioButtonManufacturers);
            groupBoxDebugTableType.Controls.Add(radioButtonTypeVehicle);
            groupBoxDebugTableType.Location = new Point(3, 6);
            groupBoxDebugTableType.Name = "groupBoxDebugTableType";
            groupBoxDebugTableType.Size = new Size(321, 236);
            groupBoxDebugTableType.TabIndex = 18;
            groupBoxDebugTableType.TabStop = false;
            groupBoxDebugTableType.Text = "Table type";
            // 
            // radioButtonManufacturerVehicleType
            // 
            radioButtonManufacturerVehicleType.AutoSize = true;
            radioButtonManufacturerVehicleType.Location = new Point(123, 139);
            radioButtonManufacturerVehicleType.Name = "radioButtonManufacturerVehicleType";
            radioButtonManufacturerVehicleType.Size = new Size(190, 24);
            radioButtonManufacturerVehicleType.TabIndex = 18;
            radioButtonManufacturerVehicleType.TabStop = true;
            radioButtonManufacturerVehicleType.Text = "Тип към производител";
            radioButtonManufacturerVehicleType.UseVisualStyleBackColor = true;
            radioButtonManufacturerVehicleType.CheckedChanged += GroupBoxRadioButton_CheckedChanged;
            // 
            // radioButtonPurchase
            // 
            radioButtonPurchase.AutoSize = true;
            radioButtonPurchase.Location = new Point(6, 208);
            radioButtonPurchase.Name = "radioButtonPurchase";
            radioButtonPurchase.Size = new Size(104, 24);
            radioButtonPurchase.TabIndex = 17;
            radioButtonPurchase.Text = "Продажби";
            radioButtonPurchase.UseVisualStyleBackColor = true;
            radioButtonPurchase.CheckedChanged += GroupBoxRadioButton_CheckedChanged;
            // 
            // radioButtonVehicles
            // 
            radioButtonVehicles.AutoSize = true;
            radioButtonVehicles.Location = new Point(6, 179);
            radioButtonVehicles.Name = "radioButtonVehicles";
            radioButtonVehicles.Size = new Size(165, 24);
            radioButtonVehicles.TabIndex = 16;
            radioButtonVehicles.Text = "Превозни средства";
            radioButtonVehicles.UseVisualStyleBackColor = true;
            radioButtonVehicles.CheckedChanged += GroupBoxRadioButton_CheckedChanged;
            // 
            // radioButtonClients
            // 
            radioButtonClients.AutoSize = true;
            radioButtonClients.Location = new Point(6, 150);
            radioButtonClients.Name = "radioButtonClients";
            radioButtonClients.Size = new Size(88, 24);
            radioButtonClients.TabIndex = 15;
            radioButtonClients.Text = "Клиенти";
            radioButtonClients.UseVisualStyleBackColor = true;
            radioButtonClients.CheckedChanged += GroupBoxRadioButton_CheckedChanged;
            // 
            // radioButtonEmployees
            // 
            radioButtonEmployees.AutoSize = true;
            radioButtonEmployees.Location = new Point(6, 119);
            radioButtonEmployees.Name = "radioButtonEmployees";
            radioButtonEmployees.Size = new Size(105, 24);
            radioButtonEmployees.TabIndex = 14;
            radioButtonEmployees.Text = "Служители";
            radioButtonEmployees.UseVisualStyleBackColor = true;
            radioButtonEmployees.CheckedChanged += GroupBoxRadioButton_CheckedChanged;
            // 
            // radioButtonTypePayment
            // 
            radioButtonTypePayment.AutoSize = true;
            radioButtonTypePayment.Location = new Point(6, 88);
            radioButtonTypePayment.Name = "radioButtonTypePayment";
            radioButtonTypePayment.Size = new Size(162, 24);
            radioButtonTypePayment.TabIndex = 13;
            radioButtonTypePayment.Text = "Начин на плащане";
            radioButtonTypePayment.UseVisualStyleBackColor = true;
            radioButtonTypePayment.CheckedChanged += GroupBoxRadioButton_CheckedChanged;
            // 
            // radioButtonManufacturers
            // 
            radioButtonManufacturers.AutoSize = true;
            radioButtonManufacturers.Location = new Point(6, 59);
            radioButtonManufacturers.Name = "radioButtonManufacturers";
            radioButtonManufacturers.Size = new Size(251, 24);
            radioButtonManufacturers.TabIndex = 12;
            radioButtonManufacturers.Text = "Производители на автомобили";
            radioButtonManufacturers.UseVisualStyleBackColor = true;
            radioButtonManufacturers.CheckedChanged += GroupBoxRadioButton_CheckedChanged;
            // 
            // radioButtonTypeVehicle
            // 
            radioButtonTypeVehicle.AutoSize = true;
            radioButtonTypeVehicle.Checked = true;
            radioButtonTypeVehicle.Location = new Point(6, 30);
            radioButtonTypeVehicle.Name = "radioButtonTypeVehicle";
            radioButtonTypeVehicle.Size = new Size(194, 24);
            radioButtonTypeVehicle.TabIndex = 11;
            radioButtonTypeVehicle.TabStop = true;
            radioButtonTypeVehicle.Text = "Вид превозно средство";
            radioButtonTypeVehicle.UseVisualStyleBackColor = true;
            radioButtonTypeVehicle.CheckedChanged += GroupBoxRadioButton_CheckedChanged;
            // 
            // dataGridViewTest
            // 
            dataGridViewTest.AllowUserToAddRows = false;
            dataGridViewTest.AllowUserToDeleteRows = false;
            dataGridViewTest.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewTest.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTest.Location = new Point(3, 250);
            dataGridViewTest.Margin = new Padding(3, 4, 3, 4);
            dataGridViewTest.Name = "dataGridViewTest";
            dataGridViewTest.ReadOnly = true;
            dataGridViewTest.RowHeadersWidth = 51;
            dataGridViewTest.RowTemplate.Height = 25;
            dataGridViewTest.Size = new Size(1227, 644);
            dataGridViewTest.TabIndex = 17;
            // 
            // buttonDebug
            // 
            buttonDebug.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDebug.Location = new Point(827, 3);
            buttonDebug.Name = "buttonDebug";
            buttonDebug.Size = new Size(403, 240);
            buttonDebug.TabIndex = 16;
            buttonDebug.Text = resources.GetString("buttonDebug.Text");
            buttonDebug.UseVisualStyleBackColor = true;
            buttonDebug.Click += buttonDebug_Click;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(groupBoxDebugOperationType);
            Controls.Add(groupBoxDebugTableType);
            Controls.Add(dataGridViewTest);
            Controls.Add(buttonDebug);
            Name = "UserControl1";
            Size = new Size(1234, 895);
            groupBoxDebugOperationType.ResumeLayout(false);
            groupBoxDebugOperationType.PerformLayout();
            groupBoxDebugTableType.ResumeLayout(false);
            groupBoxDebugTableType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTest).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxDebugOperationType;
        private RadioButton radioButtonSelect;
        private RadioButton radioButtonInsert;
        private RadioButton radioButtonEdit;
        private RadioButton radioButtonDelete;
        private GroupBox groupBoxDebugTableType;
        private RadioButton radioButtonPurchase;
        private RadioButton radioButtonVehicles;
        private RadioButton radioButtonClients;
        private RadioButton radioButtonEmployees;
        private RadioButton radioButtonTypePayment;
        private RadioButton radioButtonManufacturers;
        private RadioButton radioButtonTypeVehicle;
        private DataGridView dataGridViewTest;
        private Button buttonDebug;
        private RadioButton radioButtonManufacturerVehicleType;
    }
}
