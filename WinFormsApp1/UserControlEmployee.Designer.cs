namespace DealershipSoftware
{
    partial class UserControlEmployee
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
            buttonViewEmployees = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // buttonViewEmployees
            // 
            buttonViewEmployees.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonViewEmployees.Location = new Point(142, 205);
            buttonViewEmployees.Name = "buttonViewEmployees";
            buttonViewEmployees.Size = new Size(400, 500);
            buttonViewEmployees.TabIndex = 0;
            buttonViewEmployees.Text = "Преглед на служители";
            buttonViewEmployees.UseVisualStyleBackColor = true;
            buttonViewEmployees.Click += buttonViewEmployees_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(687, 205);
            button1.Name = "button1";
            button1.Size = new Size(400, 500);
            button1.TabIndex = 1;
            button1.Text = "Добавяне на служител";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UserControlEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(buttonViewEmployees);
            Name = "UserControlEmployee";
            Size = new Size(1234, 895);
            Load += UserControlEmployee_Load;
            Resize += UserControlEmployee_Resize;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonViewEmployees;
        private Button button1;
    }
}
