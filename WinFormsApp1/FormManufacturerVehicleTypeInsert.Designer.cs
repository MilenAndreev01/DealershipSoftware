namespace DealershipSoftware
{
    partial class FormManufacturerVehicleTypeInsert
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
            checkedListBoxVehicleTypes = new CheckedListBox();
            comboBoxManufacturer = new ComboBox();
            labelManufacturer = new Label();
            label2 = new Label();
            buttonAccept = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // checkedListBoxVehicleTypes
            // 
            checkedListBoxVehicleTypes.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            checkedListBoxVehicleTypes.FormattingEnabled = true;
            checkedListBoxVehicleTypes.Location = new Point(141, 51);
            checkedListBoxVehicleTypes.Name = "checkedListBoxVehicleTypes";
            checkedListBoxVehicleTypes.Size = new Size(455, 247);
            checkedListBoxVehicleTypes.TabIndex = 0;
            // 
            // comboBoxManufacturer
            // 
            comboBoxManufacturer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxManufacturer.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxManufacturer.FormattingEnabled = true;
            comboBoxManufacturer.Location = new Point(141, 12);
            comboBoxManufacturer.Name = "comboBoxManufacturer";
            comboBoxManufacturer.Size = new Size(455, 33);
            comboBoxManufacturer.TabIndex = 1;
            comboBoxManufacturer.SelectedIndexChanged += comboBoxManufacturer_SelectedIndexChanged;
            // 
            // labelManufacturer
            // 
            labelManufacturer.AutoSize = true;
            labelManufacturer.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelManufacturer.Location = new Point(12, 17);
            labelManufacturer.Name = "labelManufacturer";
            labelManufacturer.Size = new Size(123, 23);
            labelManufacturer.TabIndex = 2;
            labelManufacturer.Text = "Производител";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 46);
            label2.Name = "label2";
            label2.Size = new Size(110, 193);
            label2.TabIndex = 3;
            label2.Text = "Видове превозни средства";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonAccept
            // 
            buttonAccept.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAccept.Location = new Point(12, 338);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(200, 100);
            buttonAccept.TabIndex = 4;
            buttonAccept.Text = "Потвърждаване";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCancel.Location = new Point(395, 338);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(200, 100);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отказ";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormManufacturerVehicleTypeInsert
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(607, 450);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAccept);
            Controls.Add(label2);
            Controls.Add(labelManufacturer);
            Controls.Add(comboBoxManufacturer);
            Controls.Add(checkedListBoxVehicleTypes);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormManufacturerVehicleTypeInsert";
            Text = "Видове превозни средства на производител";
            Load += FormManufacturerVehicleTypeInsert_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBoxVehicleTypes;
        private ComboBox comboBoxManufacturer;
        private Label labelManufacturer;
        private Label label2;
        private Button buttonAccept;
        private Button buttonCancel;
    }
}