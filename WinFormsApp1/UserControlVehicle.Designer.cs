namespace DealershipSoftware
{
    partial class UserControlVehicle
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
            buttonNewVehicle = new Button();
            buttonViewVehicles = new Button();
            buttonNewVehicleType = new Button();
            buttonViewManufacturers = new Button();
            buttonNewManufacturer = new Button();
            buttonViewVehicleType = new Button();
            SuspendLayout();
            // 
            // buttonNewVehicle
            // 
            buttonNewVehicle.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonNewVehicle.Location = new Point(515, 95);
            buttonNewVehicle.Name = "buttonNewVehicle";
            buttonNewVehicle.Size = new Size(200, 300);
            buttonNewVehicle.TabIndex = 1;
            buttonNewVehicle.Text = "Нов внос на превозно средство";
            buttonNewVehicle.UseVisualStyleBackColor = true;
            buttonNewVehicle.Click += buttonNewVehicle_Click;
            // 
            // buttonViewVehicles
            // 
            buttonViewVehicles.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonViewVehicles.Location = new Point(140, 95);
            buttonViewVehicles.Name = "buttonViewVehicles";
            buttonViewVehicles.Size = new Size(200, 300);
            buttonViewVehicles.TabIndex = 4;
            buttonViewVehicles.Text = "Преглед на превозни средства";
            buttonViewVehicles.UseVisualStyleBackColor = true;
            buttonViewVehicles.Click += buttonViewVehicles_Click;
            // 
            // buttonNewVehicleType
            // 
            buttonNewVehicleType.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonNewVehicleType.Location = new Point(890, 505);
            buttonNewVehicleType.Name = "buttonNewVehicleType";
            buttonNewVehicleType.Size = new Size(200, 300);
            buttonNewVehicleType.TabIndex = 5;
            buttonNewVehicleType.Text = "Добавяне на тип на превозно средство";
            buttonNewVehicleType.UseVisualStyleBackColor = true;
            buttonNewVehicleType.Click += buttonNewVehicleType_Click;
            // 
            // buttonViewManufacturers
            // 
            buttonViewManufacturers.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonViewManufacturers.Location = new Point(140, 505);
            buttonViewManufacturers.Name = "buttonViewManufacturers";
            buttonViewManufacturers.Size = new Size(200, 300);
            buttonViewManufacturers.TabIndex = 6;
            buttonViewManufacturers.Text = "Преглед на производители";
            buttonViewManufacturers.UseVisualStyleBackColor = true;
            buttonViewManufacturers.Click += buttonViewManufacturers_Click;
            // 
            // buttonNewManufacturer
            // 
            buttonNewManufacturer.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonNewManufacturer.Location = new Point(515, 505);
            buttonNewManufacturer.Name = "buttonNewManufacturer";
            buttonNewManufacturer.Size = new Size(200, 300);
            buttonNewManufacturer.TabIndex = 7;
            buttonNewManufacturer.Text = "Добавяне на производител";
            buttonNewManufacturer.UseVisualStyleBackColor = true;
            buttonNewManufacturer.Click += buttonNewManufacturer_Click;
            // 
            // buttonViewVehicleType
            // 
            buttonViewVehicleType.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonViewVehicleType.Location = new Point(890, 95);
            buttonViewVehicleType.Name = "buttonViewVehicleType";
            buttonViewVehicleType.Size = new Size(200, 300);
            buttonViewVehicleType.TabIndex = 8;
            buttonViewVehicleType.Text = "Преглед на типове превозни средства";
            buttonViewVehicleType.UseVisualStyleBackColor = true;
            buttonViewVehicleType.Click += buttonViewVehicleType_Click;
            // 
            // UserControlVehicle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonViewVehicleType);
            Controls.Add(buttonNewManufacturer);
            Controls.Add(buttonViewManufacturers);
            Controls.Add(buttonNewVehicleType);
            Controls.Add(buttonViewVehicles);
            Controls.Add(buttonNewVehicle);
            Name = "UserControlVehicle";
            Size = new Size(1234, 895);
            Load += UserControlVehicle_Load;
            Resize += UserControlVehicle_Resize;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonNewVehicle;
        private Button buttonViewVehicles;
        private Button buttonNewVehicleType;
        private Button buttonViewManufacturers;
        private Button buttonNewManufacturer;
        private Button buttonViewVehicleType;
    }
}
