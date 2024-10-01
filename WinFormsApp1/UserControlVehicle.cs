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
    public partial class UserControlVehicle : UserControl
    {
        int mEmployeeID;
        private Size mDefaultSize = (Size)new Point(1241, 907);
        private List<Button> mButtons = new List<Button>();
        private List<Rectangle> mInitialRects = new List<Rectangle>();
        bool mValuesStored = false;
        public UserControlVehicle(int employeeID)
        {
            this.mEmployeeID = employeeID;
            InitializeComponent();
            ConfigureButtons();
            StoreInitialSizesAndPositions();
        }

        private void buttonViewVehicles_Click(object sender, EventArgs e)
        {
            FormDataGridView form = new FormDataGridView(FormDataGridView.TableToLoad.Vehicle);
            form.ShowDialog();
        }

        private void buttonNewVehicle_Click(object sender, EventArgs e)
        {
            FormVehicleInsert form = new FormVehicleInsert();
            form.ShowDialog();
        }

        private void buttonNewManufacturer_Click(object sender, EventArgs e)
        {
            string manufacturer = string.Empty;
            if (Utilities.InputBox("Добавяне на производител на превозни средства", "Въведете наименованието", ref manufacturer) == DialogResult.OK)
            {
                Database.InsertManufacturer(manufacturer);
                Database.LoadDBTables(loadManufacturers: true);
            }

        }

        private void buttonNewVehicleType_Click(object sender, EventArgs e)
        {
            string vehicleTypeEN = string.Empty;
            string vehicleTypeBG = string.Empty;
            if (Utilities.InputBox("Добавяне на тип превозно средство", "Въведете наименованието", ref vehicleTypeEN, ref vehicleTypeBG) == DialogResult.OK)
            {
                if(Database.InsertVehicleType(vehicleTypeEN, vehicleTypeBG))
                {
                    MessageBox.Show("Успешно добавен запис!");
                    Database.LoadDBTables(loadVehicleTypes: true);
                }
                else
                {
                    MessageBox.Show("Грешка повреме на изпълнение!");
                }                
            }
        }

        private void buttonViewManufacturers_Click(object sender, EventArgs e)
        {
            FormDataGridView form = new FormDataGridView(FormDataGridView.TableToLoad.Manufacturer);
            form.ShowDialog();
        }

        private void UserControlVehicle_Load(object sender, EventArgs e)
        {

        }
        private void ConfigureButtons()
        {
            FormMain.EmployeeType employeeType = (FormMain.EmployeeType)Database.Employees.Find(x => x.ID == mEmployeeID).EmployeeTypeID;
            if (employeeType == FormMain.EmployeeType.Seller)
            {
                buttonNewManufacturer.Enabled = false;
                buttonNewManufacturer.Visible = false;
                buttonNewVehicleType.Enabled = false;
                buttonNewVehicleType.Visible = false;
                buttonViewManufacturers.Enabled = false;
                buttonViewManufacturers.Visible = false;
                buttonViewVehicleType.Enabled = false;
                buttonViewVehicleType.Visible = false;

                buttonViewVehicles.Size = new Size(400, 500);
                buttonViewVehicles.Location = new Point(142, 205);
                buttonNewVehicle.Size = new Size(400, 500);
                buttonNewVehicle.Location = new Point(687, 205);
            }
        }
        private void UserControlVehicle_Resize(object sender, EventArgs e)
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

                    // Calculate new size and position
                    int newWidth = (int)(initialRect.Width * widthRatio);
                    int newHeight = (int)(initialRect.Height * heightRatio);
                    int newX = (int)(initialRect.X * widthRatio);
                    int newY = (int)(initialRect.Y * heightRatio);

                    button.Size = new Size(newWidth, newHeight);
                    button.Location = new Point(newX, newY);
                }
            }
        }

        private void buttonViewVehicleType_Click(object sender, EventArgs e)
        {
            FormDataGridView form = new FormDataGridView(FormDataGridView.TableToLoad.VehicleType);
            form.ShowDialog();
        }
    }
}
