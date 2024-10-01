using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DealershipSoftware
{
    public partial class UserControlPurchase : UserControl
    {
        private int mEmployeeID;
        private Size mDefaultSize = (Size)new Point(1241, 907);
        private List<Button> mButtons = new List<Button>();
        private List<Rectangle> mInitialRects = new List<Rectangle>();
        bool mValuesStored = false;
        public UserControlPurchase(int employeeID)
        {
            mEmployeeID = employeeID;
            InitializeComponent();
            ConfigureButtons();
            StoreInitialSizesAndPositions();
        }

        private void buttonViewPurchases_Click(object sender, EventArgs e)
        {
            FormDataGridView form = new FormDataGridView(FormDataGridView.TableToLoad.Purchase, employeeID: mEmployeeID);
            form.ShowDialog();
        }

        private void buttonNewPurchase_Click(object sender, EventArgs e)
        {
            FormPurchaseInsert form = new FormPurchaseInsert(mEmployeeID);
            form.ShowDialog();
        }

        private void UserControlPurchase_Load(object sender, EventArgs e)
        {
            
            
        }
        private void ConfigureButtons()
        {
            FormMain.EmployeeType employeeType = (FormMain.EmployeeType)Database.Employees.Find(x => x.ID == mEmployeeID).EmployeeTypeID;
            if (employeeType == FormMain.EmployeeType.Seller)
            {
                buttonNewPaymentType.Enabled = false;
                buttonNewPaymentType.Visible = false;
                buttonViewPaymentType.Enabled = false;
                buttonViewPaymentType.Visible = false;

                buttonViewPurchases.Size = new Size(400, 500);
                buttonViewPurchases.Location = new Point(142, 205);
                buttonNewPurchase.Size = new Size(400, 500);
                buttonNewPurchase.Location = new Point(687, 205);
            }
        }

        private void buttonViewPaymentType_Click(object sender, EventArgs e)
        {
            FormDataGridView form = new FormDataGridView(FormDataGridView.TableToLoad.PaymentType, employeeID: mEmployeeID);
            form.ShowDialog();
        }

        private void buttonNewPaymentType_Click(object sender, EventArgs e)
        {
            string paymentTypeEN = string.Empty;
            string paymentTypeBG = string.Empty;
            if (Utilities.InputBox("Добавяне на начин на плащане", "Въведете наименованието", ref paymentTypeEN, ref paymentTypeBG) == DialogResult.OK)
            {
                if (Database.InsertPaymentType(paymentTypeEN, paymentTypeBG))
                {
                    MessageBox.Show("Успешно добавен запис!");
                    Database.LoadDBTables(loadPaymentTypes: true);
                }
                else
                {
                    MessageBox.Show("Проблем при изпълняване на функцията!");
                }
            }
        }

        private void UserControlPurchase_Resize(object sender, EventArgs e)
        {
            ResizeButtons();
            
        }
        private void StoreInitialSizesAndPositions()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    mButtons.Add(button);
                    mInitialRects.Add(new Rectangle(button.Location, button.Size));
                }
            }
            mValuesStored = true;
        }
        private void ResizeButtons()
        {
            if (mValuesStored)
            {
                float widthRatio = (float)this.ClientSize.Width / mDefaultSize.Width;
                float heightRatio = (float)this.ClientSize.Height / mDefaultSize.Height;

                for (int i = 0; i < mButtons.Count; i++)
                {
                    Button button = mButtons[i];
                    Rectangle initialRect = mInitialRects[i];

                    int newWidth = (int)(initialRect.Width * widthRatio);
                    int newHeight = (int)(initialRect.Height * heightRatio);
                    int newX = (int)(initialRect.X * widthRatio);
                    int newY = (int)(initialRect.Y * heightRatio);

                    button.Size = new Size(newWidth, newHeight);
                    button.Location = new Point(newX, newY);
                } 
            }
        }

    }
}
