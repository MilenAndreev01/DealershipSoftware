namespace DealershipSoftware
{
    partial class UserControlClient
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
            buttonViewClients = new Button();
            buttonAddClient = new Button();
            SuspendLayout();
            // 
            // buttonViewClients
            // 
            buttonViewClients.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonViewClients.Location = new Point(142, 205);
            buttonViewClients.Name = "buttonViewClients";
            buttonViewClients.Size = new Size(400, 500);
            buttonViewClients.TabIndex = 0;
            buttonViewClients.Text = "Преглед на клиентите";
            buttonViewClients.UseVisualStyleBackColor = true;
            buttonViewClients.Click += buttonViewClients_Click;
            // 
            // buttonAddClient
            // 
            buttonAddClient.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAddClient.Location = new Point(687, 205);
            buttonAddClient.Name = "buttonAddClient";
            buttonAddClient.Size = new Size(400, 500);
            buttonAddClient.TabIndex = 2;
            buttonAddClient.Text = "Добавяне на клиент";
            buttonAddClient.UseVisualStyleBackColor = true;
            buttonAddClient.Click += buttonAddClient_Click;
            // 
            // UserControlClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonAddClient);
            Controls.Add(buttonViewClients);
            Name = "UserControlClient";
            Size = new Size(1234, 895);
            Load += UserControlClient_Load;
            Resize += UserControlClient_Resize;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonViewClients;
        private Button buttonAddClient;
    }
}
