namespace DealershipSoftware
{
    partial class FormDataGridView
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            buttonEdit = new Button();
            buttonDelete = new Button();
            dateTimePickerFrom = new DateTimePicker();
            dateTimePickerUntil = new DateTimePicker();
            labelFrom = new Label();
            labelUntil = new Label();
            buttonPurchaseSearchByDate = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(12, 127);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1324, 582);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // buttonEdit
            // 
            buttonEdit.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEdit.Location = new Point(12, 10);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(200, 100);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "Редакция";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDelete.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDelete.Location = new Point(1136, 12);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(200, 100);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Изтриване";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Checked = false;
            dateTimePickerFrom.Enabled = false;
            dateTimePickerFrom.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerFrom.Location = new Point(487, 33);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(198, 32);
            dateTimePickerFrom.TabIndex = 3;
            dateTimePickerFrom.Visible = false;
            // 
            // dateTimePickerUntil
            // 
            dateTimePickerUntil.Enabled = false;
            dateTimePickerUntil.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerUntil.Location = new Point(487, 66);
            dateTimePickerUntil.Name = "dateTimePickerUntil";
            dateTimePickerUntil.Size = new Size(198, 32);
            dateTimePickerUntil.TabIndex = 4;
            dateTimePickerUntil.Visible = false;
            // 
            // labelFrom
            // 
            labelFrom.AutoSize = true;
            labelFrom.Enabled = false;
            labelFrom.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelFrom.Location = new Point(451, 36);
            labelFrom.Name = "labelFrom";
            labelFrom.Size = new Size(30, 23);
            labelFrom.TabIndex = 5;
            labelFrom.Text = "От";
            labelFrom.Visible = false;
            // 
            // labelUntil
            // 
            labelUntil.AutoSize = true;
            labelUntil.Enabled = false;
            labelUntil.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelUntil.Location = new Point(451, 69);
            labelUntil.Name = "labelUntil";
            labelUntil.Size = new Size(32, 23);
            labelUntil.TabIndex = 6;
            labelUntil.Text = "До";
            labelUntil.Visible = false;
            // 
            // buttonPurchaseSearchByDate
            // 
            buttonPurchaseSearchByDate.Enabled = false;
            buttonPurchaseSearchByDate.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            buttonPurchaseSearchByDate.Location = new Point(12, 10);
            buttonPurchaseSearchByDate.Name = "buttonPurchaseSearchByDate";
            buttonPurchaseSearchByDate.Size = new Size(200, 100);
            buttonPurchaseSearchByDate.TabIndex = 7;
            buttonPurchaseSearchByDate.Text = "Търсене по дата";
            buttonPurchaseSearchByDate.UseVisualStyleBackColor = true;
            buttonPurchaseSearchByDate.Visible = false;
            buttonPurchaseSearchByDate.Click += buttonPurchaseSearchByDate_Click;
            // 
            // FormDataGridView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1348, 721);
            Controls.Add(labelUntil);
            Controls.Add(labelFrom);
            Controls.Add(dateTimePickerUntil);
            Controls.Add(dateTimePickerFrom);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(dataGridView1);
            Controls.Add(buttonPurchaseSearchByDate);
            Name = "FormDataGridView";
            Text = "Табличен изглед";
            Load += FormDataGridView_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonEdit;
        private Button buttonDelete;
        private DateTimePicker dateTimePickerFrom;
        private DateTimePicker dateTimePickerUntil;
        private Label labelFrom;
        private Label labelUntil;
        private Button buttonPurchaseSearchByDate;
    }
}