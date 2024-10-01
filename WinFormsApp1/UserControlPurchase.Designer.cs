namespace DealershipSoftware
{
    partial class UserControlPurchase
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
            buttonNewPurchase = new Button();
            buttonViewPurchases = new Button();
            buttonViewPaymentType = new Button();
            buttonNewPaymentType = new Button();
            SuspendLayout();
            // 
            // buttonNewPurchase
            // 
            buttonNewPurchase.Anchor = AnchorStyles.Right;
            buttonNewPurchase.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonNewPurchase.Location = new Point(690, 95);
            buttonNewPurchase.Name = "buttonNewPurchase";
            buttonNewPurchase.Size = new Size(400, 300);
            buttonNewPurchase.TabIndex = 0;
            buttonNewPurchase.Text = "Нова продажба";
            buttonNewPurchase.UseVisualStyleBackColor = true;
            buttonNewPurchase.Click += buttonNewPurchase_Click;
            // 
            // buttonViewPurchases
            // 
            buttonViewPurchases.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonViewPurchases.Location = new Point(140, 95);
            buttonViewPurchases.Name = "buttonViewPurchases";
            buttonViewPurchases.Size = new Size(400, 300);
            buttonViewPurchases.TabIndex = 2;
            buttonViewPurchases.Text = "Преглед на продажби";
            buttonViewPurchases.UseVisualStyleBackColor = true;
            buttonViewPurchases.Click += buttonViewPurchases_Click;
            // 
            // buttonViewPaymentType
            // 
            buttonViewPaymentType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonViewPaymentType.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonViewPaymentType.Location = new Point(140, 505);
            buttonViewPaymentType.Name = "buttonViewPaymentType";
            buttonViewPaymentType.Size = new Size(400, 300);
            buttonViewPaymentType.TabIndex = 3;
            buttonViewPaymentType.Text = "Преглед на начини на плащане";
            buttonViewPaymentType.UseVisualStyleBackColor = true;
            buttonViewPaymentType.Click += buttonViewPaymentType_Click;
            // 
            // buttonNewPaymentType
            // 
            buttonNewPaymentType.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonNewPaymentType.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonNewPaymentType.Location = new Point(690, 505);
            buttonNewPaymentType.Name = "buttonNewPaymentType";
            buttonNewPaymentType.Size = new Size(400, 300);
            buttonNewPaymentType.TabIndex = 4;
            buttonNewPaymentType.Text = "Добавяне на начин на плащане";
            buttonNewPaymentType.UseVisualStyleBackColor = true;
            buttonNewPaymentType.Click += buttonNewPaymentType_Click;
            // 
            // UserControlPurchase
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonNewPaymentType);
            Controls.Add(buttonViewPaymentType);
            Controls.Add(buttonViewPurchases);
            Controls.Add(buttonNewPurchase);
            Name = "UserControlPurchase";
            Size = new Size(1234, 895);
            Load += UserControlPurchase_Load;
            Resize += UserControlPurchase_Resize;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonNewPurchase;
        private Button buttonViewPurchases;
        private Button buttonViewPaymentType;
        private Button buttonNewPaymentType;
    }
}
