using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DealershipSoftware
{
    public partial class FormDataGridView : Form
    {
        TableToLoad mLoadedTable = 0;
        int mManufacturerID;
        int mEmployeeID;        
        public enum TableToLoad
        {
            Unknown = 0,
            Client,
            Employee,
            Purchase,
            Vehicle,
            Manufacturer,
            ManufacturerVehicleType,
            VehicleType,
            PaymentType
        }
        public FormDataGridView(TableToLoad paramTable, int manufacturerID = -1, int employeeID = -1)
        {
            mLoadedTable = paramTable;
            InitializeComponent();
            mManufacturerID = manufacturerID;
            mEmployeeID = employeeID;
            //EmployeeType = employeeType;
        }
        private void LoadClientsTable()
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                if (Database.Clients.Count <= 0)
                {
                    Database.LoadDBTables(loadClients: true);
                    if (Database.Clients.Count <= 0)
                    {
                        MessageBox.Show("В базата данни няма записи!");
                        return;
                    }
                }

                dataGridView1.ColumnCount = 4;

                dataGridView1.RowCount = Database.Clients.Count;

                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[0].Width = 50;

                dataGridView1.Columns[1].HeaderText = "Първо име";
                dataGridView1.Columns[1].Width = 500;

                dataGridView1.Columns[2].HeaderText = "Фамилно име";
                dataGridView1.Columns[2].Width = 500;

                dataGridView1.Columns[3].HeaderText = "Телефонен номер";
                dataGridView1.Columns[3].Width = 200;



                for (int i = 0; i < Database.Clients.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = Database.Clients[i].ID;
                    dataGridView1.Rows[i].Cells[1].Value = Database.Clients[i].FirstName;
                    dataGridView1.Rows[i].Cells[2].Value = Database.Clients[i].LastName;
                    dataGridView1.Rows[i].Cells[3].Value = Database.Clients[i].Telephone;

                }


            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }
        }

        private void FormDataGridView_Load(object sender, EventArgs e)
        {
            switch (mLoadedTable)
            {
                case TableToLoad.Client:
                    LoadClientsTable();
                    break;

                case TableToLoad.Employee:
                    LoadEmployeeTable();
                    break;

                case TableToLoad.Purchase:
                    LoadPurchaseComponents();
                    LoadPurchaseTable();
                    break;

                case TableToLoad.Vehicle:
                    LoadVehicleTable();
                    break;

                case TableToLoad.Manufacturer:
                    LoadManufacturerTable();
                    break;

                case TableToLoad.ManufacturerVehicleType:
                    LoadManufacturerVehicleType();
                    break;

                case TableToLoad.VehicleType:
                    LoadVehicleTypeTable();
                    break;

                case TableToLoad.PaymentType:
                    LoadPaymentTypeTable();
                    break;

                default:
                    MessageBox.Show("Неправилна таблица!");
                    break;
            }
        }

        private void LoadPurchaseComponents()
        {
            buttonEdit.Enabled = false;
            buttonEdit.Visible = false;
            buttonPurchaseSearchByDate.Enabled = true;
            buttonPurchaseSearchByDate.Visible = true;
            labelFrom.Enabled = true;
            labelFrom.Visible = true;
            labelUntil.Enabled = true;
            labelUntil.Visible = true;
            dateTimePickerFrom.Enabled = true;
            dateTimePickerFrom.Visible = true;
            dateTimePickerUntil.Enabled = true;
            dateTimePickerUntil.Visible = true;
            buttonDelete.Text = "Сторно операция";
        }

        private void LoadPaymentTypeTable()
        {
            try
            {
                //List<PaymentType> types = new List<PaymentType>();

                //Database.SelectPaymentType(ref types);

                Database.LoadDBTables(loadPaymentTypes: true);

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                if (Database.PaymentTypes.Count == 0)
                {
                    MessageBox.Show("В базата данни няма записи!");
                    return;
                }

                dataGridView1.ColumnCount = 3;

                dataGridView1.RowCount = Database.PaymentTypes.Count;

                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[0].Width = 80;

                dataGridView1.Columns[1].HeaderText = "Тип (Английски)";
                dataGridView1.Columns[1].Width = 500;

                dataGridView1.Columns[2].HeaderText = "Тип (Български)";
                dataGridView1.Columns[2].Width = 500;

                for (int i = 0; i < Database.PaymentTypes.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = Database.PaymentTypes[i].ID;
                    dataGridView1.Rows[i].Cells[1].Value = Database.PaymentTypes[i].TypeEN;
                    dataGridView1.Rows[i].Cells[2].Value = Database.PaymentTypes[i].TypeBG;
                }
                return;

            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }
        }

        private void LoadVehicleTypeTable()
        {
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                if (Database.VehicleTypes.Count == 0)
                {
                    Database.LoadDBTables(loadVehicleTypes: true);
                    if (Database.VehicleTypes.Count == 0)
                    {
                        MessageBox.Show("В базата данни няма записи!");
                        return;
                    }
                }

                dataGridView1.ColumnCount = 3;
                dataGridView1.RowCount = Database.VehicleTypes.Count;

                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[0].Width = 100;

                dataGridView1.Columns[1].HeaderText = "Тип (на английски)";
                dataGridView1.Columns[1].Width = 500;

                dataGridView1.Columns[2].HeaderText = "Тип (на български)";
                dataGridView1.Columns[2].Width = 500;

                for (int i = 0; i < Database.VehicleTypes.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = Database.VehicleTypes[i].ID;
                    dataGridView1.Rows[i].Cells[1].Value = Database.VehicleTypes[i].TypeEN;
                    dataGridView1.Rows[i].Cells[2].Value = Database.VehicleTypes[i].TypeBG;
                }

                return;

            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }
        }
        private void RearrangeFormForMVF()
        {
            this.Size = new Size(500, 500);
            this.dataGridView1.Size = new Size(400, 300);
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Visible = false;
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Visible = false;
            this.dateTimePickerFrom.Enabled = false;
            this.dateTimePickerFrom.Visible = false;
            this.dateTimePickerUntil.Enabled = false;
            this.dateTimePickerUntil.Visible = false;
            this.labelFrom.Enabled = false;
            this.labelFrom.Visible = false;
            this.labelUntil.Enabled = false;
            this.labelUntil.Visible = false;
            this.dataGridView1.Location = new Point(8, 8);
            this.dataGridView1.Size = new Size(465, 435);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }
        private void LoadManufacturerVehicleType()
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                RearrangeFormForMVF();
                int indexID = Database.Manufacturers.FindIndex(x => x.ID == mManufacturerID);
                if (Database.Manufacturers[indexID].VehicleTypes.Count <= 0)
                {
                    Database.LoadDBTables(loadManufacturerVehicleTypes: true);

                    if ((Database.Manufacturers[indexID].VehicleTypes.Count <= 0))
                    {
                        MessageBox.Show("В базата данни няма записи!");
                        this.Close();
                        return;

                    }
                }
                if (Database.VehicleTypes.Count == 0)
                {
                    Database.LoadDBTables(loadVehicleTypes: true);
                    if (Database.VehicleTypes.Count == 0)
                    {
                        MessageBox.Show("В базата данни няма записи!");
                        return;
                    }
                }
                dataGridView1.ColumnCount = 2;
                dataGridView1.ScrollBars = ScrollBars.Both;

                dataGridView1.RowCount = Database.Manufacturers[indexID].VehicleTypes.Count;

                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[0].Width = 60;

                dataGridView1.Columns[1].HeaderText = "Вид превозно средство";
                dataGridView1.Columns[1].Width = 350;

                for (int i = 0; i < Database.Manufacturers[indexID].VehicleTypes.Count; i++)
                {
                    int vehicleTypeID = Database.VehicleTypes.Find(x => x.ID == Database.Manufacturers[indexID].VehicleTypes[i].ID).ID;
                    dataGridView1.Rows[i].Cells[0].Value = vehicleTypeID;
                    string vehicleTypeBG = Database.VehicleTypes.Find(x => x.ID == Database.Manufacturers[indexID].VehicleTypes[i].ID).TypeBG;
                    dataGridView1.Rows[i].Cells[1].Value = vehicleTypeBG;
                    //dataGridView1.Rows[i].Cells[2].Value = Database.Clients[i].LastName;
                    //dataGridView1.Rows[i].Cells[3].Value = Database.Clients[i].Telephone;

                }
                return;

            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }
        }

        private void LoadManufacturerTable()
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                if (Database.Manufacturers.Count <= 0)
                {
                    Database.LoadDBTables(loadManufacturers: true);
                    if (Database.Manufacturers.Count <= 0)
                    {
                        MessageBox.Show("В базата данни няма записи!");
                        return;
                    }
                }
                dataGridView1.ColumnCount = 2;
                dataGridView1.RowCount = Database.Manufacturers.Count;

                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[0].Width = 100;

                dataGridView1.Columns[1].HeaderText = "Име на производител";
                dataGridView1.Columns[1].Width = 750;

                var buttonColumnView = new DataGridViewButtonColumn()
                {
                    Name = "buttonColumnView",
                    HeaderText = "Предлагани типове превозни средства",
                    UseColumnTextForButtonValue = false,
                    Width = 150,
                    DefaultCellStyle = new DataGridViewCellStyle()
                    {
                        NullValue = "Кликни ме!"
                        
                    }
                    
                };
                var buttonColumnEdit = new DataGridViewButtonColumn()
                {
                    Name = "buttonColumnEdit",
                    HeaderText = "Редактиране на предлагани типове превозни средства",
                    UseColumnTextForButtonValue = false,
                    Width = 150,
                    DefaultCellStyle = new DataGridViewCellStyle()
                    {
                        NullValue = "Кникни ме!"
                    }
                };
                dataGridView1.Columns.Add(buttonColumnView);
                dataGridView1.Columns.Add(buttonColumnEdit);

                //dataGridViewButt
                //dataGridView1.Columns[

                for (int i = 0; i < Database.Manufacturers.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = Database.Manufacturers[i].ID;
                    dataGridView1.Rows[i].Cells[1].Value = Database.Manufacturers[i].Name;
                    if (Database.Manufacturers[i].VehicleTypes.Count <= 0)
                    {
                        dataGridView1.Rows[i].Cells[2].Value = "Няма записи!";
                    }

                }
                return;
            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }
        }

        private void LoadVehicleTable()
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                if (Database.Vehicles.Count <= 0)
                {
                    Database.LoadDBTables(loadVehicles: true);
                    if (Database.Vehicles.Count <= 0)
                    {
                        MessageBox.Show("В базата данни няма записи!");
                        return;
                    }
                }
                dataGridView1.ColumnCount = 7;

                dataGridView1.RowCount = Database.Vehicles.Count;

                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[0].Width = 50;

                dataGridView1.Columns[1].HeaderText = "Марка";
                dataGridView1.Columns[1].Width = 200;

                dataGridView1.Columns[2].HeaderText = "Модел";
                dataGridView1.Columns[2].Width = 200;

                dataGridView1.Columns[3].HeaderText = "Вид превозно средство";
                dataGridView1.Columns[3].Width = 150;

                dataGridView1.Columns[4].HeaderText = "Година на производство";
                dataGridView1.Columns[4].Width = 130;

                dataGridView1.Columns[5].HeaderText = "Цена на покупка на автомобил";
                dataGridView1.Columns[5].Width = 100;

                dataGridView1.Columns[6].HeaderText = "Продаден ли е автомобила?";
                dataGridView1.Columns[6].Width = 120;

                DataGridViewImageColumn vehicleImageColumn = new DataGridViewImageColumn();
                vehicleImageColumn.HeaderText = "Снимка на превозно средство";
                vehicleImageColumn.Width = 200;
                vehicleImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dataGridView1.Columns.Add(vehicleImageColumn);

                for (int i = 0; i < Database.Vehicles.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = Database.Vehicles[i].ID;
                    dataGridView1.Rows[i].Cells[1].Value = Database.Vehicles[i].Manufacturer.Name;
                    dataGridView1.Rows[i].Cells[2].Value = Database.Vehicles[i].Model;
                    dataGridView1.Rows[i].Cells[3].Value = Database.Vehicles[i].VehicleType.TypeBG;
                    dataGridView1.Rows[i].Cells[4].Value = Database.Vehicles[i].MakeYear;
                    dataGridView1.Rows[i].Cells[5].Value = string.Format("{0} лв.", Database.Vehicles[i].Price);
                    dataGridView1.Rows[i].Cells[6].Value = Utilities.BoolToString(Database.Vehicles[i].IsSold);

                    Bitmap bitmap = FormMain.VehiclePictureMissing;
                    if (Database.Vehicles[i].Image.Length > 0)
                    {
                        bitmap = Utilities.GetImageFromByteArray(Database.Vehicles[i].Image);
                    }
                    dataGridView1.Rows[i].Height = 150;
                    dataGridView1.Rows[i].Cells[7].Value = bitmap;

                }


                return;

            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }
        }

        private void LoadPurchaseTable(bool IsDateSearch = false)
        {
            try
            {                                
                Database.LoadAllDBTables();

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                if (Database.Purchase.Count == 0)
                {
                    MessageBox.Show("В базата данни няма записи!");
                    return;
                }

                List<Purchase> purchasesList = Database.Purchase;
                if (mEmployeeID != -1)
                {
                    if (Database.Employees.Find(x => x.ID == mEmployeeID).EmployeeTypeID == (int)FormMain.EmployeeType.Seller)
                    {
                        purchasesList = purchasesList.Where(x => x.Employee.ID == mEmployeeID).ToList();
                    }
                }
                purchasesList = purchasesList.Where(x => x.IsValid == true).ToList();

                if (purchasesList.Count == 0)
                {
                    MessageBox.Show("Този потребител не направил продажба!");
                    this.Close();
                    return;
                }

                if (IsDateSearch)
                {
                    if ((dateTimePickerFrom.Value.Ticks / TimeSpan.TicksPerSecond) > (dateTimePickerUntil.Value.Ticks / TimeSpan.TicksPerSecond))
                    {
                        MessageBox.Show("Дата \"От\" е по-голяма от дата \"До\"!");
                        return;
                    }
                    purchasesList = purchasesList.Where
                        (x => x.DateOfPurchase >= dateTimePickerFrom.Value.Date
                        && x.DateOfPurchase <= dateTimePickerUntil.Value.Date).ToList();
                    if (purchasesList.Count <= 0)
                    {
                        MessageBox.Show("Няма записи!");
                        return;
                    }
                }

                dataGridView1.ColumnCount = 7;
                dataGridView1.RowCount = purchasesList.Count();

                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[0].Width = 70;
                dataGridView1.Columns[1].HeaderText = "Номер и имена на клиент";
                dataGridView1.Columns[1].Width = 250;
                dataGridView1.Columns[2].HeaderText = "Номер, марка и модел на превозно средство";
                dataGridView1.Columns[2].Width = 250;
                dataGridView1.Columns[3].HeaderText = "Номер и имена на служител";
                dataGridView1.Columns[3].Width = 220;
                dataGridView1.Columns[4].HeaderText = "Дата на покупка";
                dataGridView1.Columns[4].Width = 195;
                dataGridView1.Columns[5].HeaderText = "Финална цена";
                dataGridView1.Columns[5].Width = 110;
                dataGridView1.Columns[6].HeaderText = "Вид на плащане";
                dataGridView1.Columns[6].Width = 180;

                for (int i = 0; i < purchasesList.Count; i++)
                {
                    var item = purchasesList[i];
                    dataGridView1.Rows[i].Cells[0].Value = item.ID;
                    dataGridView1.Rows[i].Cells[1].Value = string.Format("{0}, {1} {2}",
                        item.Client.ID, item.Client.FirstName, item.Client.LastName);
                    dataGridView1.Rows[i].Cells[2].Value = string.Format("{0}, {1} {2} {3}г.",
                        item.Vehicle.ID, item.Vehicle.Manufacturer.Name, item.Vehicle.Model, item.Vehicle.MakeYear);
                    dataGridView1.Rows[i].Cells[3].Value = string.Format("{0}, {1} {2}",
                        item.Employee.ID, item.Employee.FirstName, item.Employee.LastName);
                    dataGridView1.Rows[i].Cells[4].Value = string.Format("{0} ч.", item.DateOfPurchase);
                    dataGridView1.Rows[i].Cells[5].Value = string.Format("{0} лв.", item.FinalPrice);
                    dataGridView1.Rows[i].Cells[6].Value = string.Format("{0}, {1}",
                        item.PaymentType.ID, item.PaymentType.TypeBG);

                }
                return;
            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }
        }

        private void LoadEmployeeTable()
        {
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                if (Database.Employees.Count == 0)
                {
                    Database.LoadDBTables(loadEmployees: true);
                    if (Database.Employees.Count == 0)
                    {
                        MessageBox.Show("В базата данни няма записи!");
                        return;
                    }
                }

                dataGridView1.ColumnCount = 5;

                dataGridView1.RowCount = Database.Employees.Count;

                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[0].Width = 70;

                dataGridView1.Columns[1].HeaderText = "Първо име";
                dataGridView1.Columns[1].Width = 350;

                dataGridView1.Columns[2].HeaderText = "Фамилно име";
                dataGridView1.Columns[2].Width = 350;

                dataGridView1.Columns[3].HeaderText = "Имейл адрес";
                dataGridView1.Columns[3].Width = 300;

                dataGridView1.Columns[4].HeaderText = "Телефонен номер";
                dataGridView1.Columns[4].Width = 150;

                for (int i = 0; i < Database.Employees.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = Database.Employees[i].ID;
                    dataGridView1.Rows[i].Cells[1].Value = Database.Employees[i].FirstName;
                    dataGridView1.Rows[i].Cells[2].Value = Database.Employees[i].LastName;
                    dataGridView1.Rows[i].Cells[3].Value = Database.Employees[i].Email;
                    dataGridView1.Rows[i].Cells[4].Value = Database.Employees[i].Telephone;

                }
                return;
            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {                
                if (dataGridView1.Rows.Count > 0)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    int itemID = (int)dataGridView1.Rows[rowIndex].Cells[0].Value;

                    switch (mLoadedTable)
                    {
                        case TableToLoad.Client:
                            EditClient(itemID);
                            break;

                        case TableToLoad.Employee:
                            EditEmployee(itemID);
                            break;

                        case TableToLoad.Vehicle:
                            EditVehicle(itemID);
                            break;

                        case TableToLoad.Manufacturer:
                            EditManufacturer(itemID);
                            break;

                        case TableToLoad.ManufacturerVehicleType:                            
                            EditManufacturerVehicleType();
                            break;

                        case TableToLoad.VehicleType:                            
                            EditVehicleType(itemID);
                            break;

                        case TableToLoad.PaymentType:
                            EditPaymentType(itemID);
                            break;

                        default:
                            MessageBox.Show("There is no spoon!");
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
            }
        }

        private void EditClient(int clientID)
        {
            var clientToEdit = Database.Clients.Find(x => x.ID == clientID);
            if (clientToEdit != null)
            {
                FormClientInsert form = new FormClientInsert(clientToEdit);
                form.ShowDialog();
                Database.LoadDBTables(loadClients: true);
                LoadClientsTable();
            }
            else
            {
                MessageBox.Show(
                    string.Format("Проблем при изпълняване на функцията с номер на клиент: {0}!", clientID));

            }
        }

        private void EditEmployee(int employeeID)
        {
            var employeeToEdit = Database.Employees.Find(x => x.ID == employeeID);
            if (employeeToEdit != null)
            {
                FormEmployeeInsert formEmployee = new FormEmployeeInsert(employeeToEdit);
                formEmployee.ShowDialog();
                LoadEmployeeTable();
            }
            else
            {
                MessageBox.Show(
                    string.Format("Проблем при изпълняване на функцията с номер на служител: {0}!", employeeID));

            }
        }

        private void EditPurchase(int purchaseID)
        {
            var purchaseToEdit = Database.Purchase.Find(x => x.ID == purchaseID);
            if (purchaseToEdit != null)
            {
                FormPurchaseInsert form = new FormPurchaseInsert(purchaseToEdit, paramIsDebug: false);
                form.ShowDialog();
                LoadPurchaseTable();
            }
            else
            {
                MessageBox.Show(
                    string.Format("Проблем при изпълняване на функцията с номер на продажба: {0}!", purchaseID));

            }
        }

        private void EditVehicle(int vehicleID)
        {
            var vehicleToEdit = Database.Vehicles.Find(x => x.ID == vehicleID);
            if (vehicleToEdit != null)
            {
                FormVehicleInsert formVehicleInsert = new FormVehicleInsert(vehicleToEdit);
                formVehicleInsert.ShowDialog();
                LoadVehicleTable();
            }
            else
            {
                MessageBox.Show(
                    string.Format("Проблем при изпълняване на функцията с номер на превозно средство: {0}!", vehicleID));

            }
        }
        //Unused!
        private void EditManufacturerVehicleType(int manufacturerID)
        {
            var manufacturerToEdit = Database.Vehicles.Find(x => x.ID == manufacturerID);
            if (manufacturerToEdit != null)
            {
                FormManufacturerVehicleTypeInsert form = new FormManufacturerVehicleTypeInsert(manufacturerToEdit.Manufacturer.Name);
                form.ShowDialog();
                //LoadVehicleTable();
            }
            else
            {
                MessageBox.Show(
                    string.Format("Проблем при изпълняване на функцията с номер на превозно средство: {0}!", manufacturerID));

            }
        }

        private void EditManufacturer(int manufacturerID)
        {
            var manufacturerToEdit = Database.Manufacturers.Find(x => x.ID == manufacturerID);
            if (manufacturerToEdit != null)
            {
                string manufacturerName = manufacturerToEdit.Name;
                if (Utilities.InputBox("Редактиране на производител", "Въведете наименованието", ref manufacturerName) == DialogResult.OK)
                {
                    manufacturerToEdit.Name = manufacturerName;
                    if (Database.UpdateManufacturer(manufacturerToEdit))
                    {
                        MessageBox.Show("Успешно редактиран запис!");
                        Database.LoadDBTables(loadManufacturers: true);
                        LoadManufacturerTable();
                    }
                    else
                    {
                        MessageBox.Show(
                            string.Format("Проблем при изпълняване на функцията с номер на производител: {0}!", manufacturerID));

                    }
                }

            }
            else
            {
                MessageBox.Show(
                    string.Format("Проблем при изпълняване на функцията с номер на производител: {0}!", manufacturerID));

            }
        }


        private void EditPaymentType(int paymentTypeID)
        {
            var paymentTypeToEdit = Database.PaymentTypes.Find(x => x.ID == paymentTypeID);
            if (paymentTypeToEdit != null)
            {
                string typeNameEN = paymentTypeToEdit.TypeEN;
                string typeNameBG = paymentTypeToEdit.TypeBG;
                if (Utilities.InputBox("Редактиране на начин на плащане", "Въведете наименованието", ref typeNameEN, ref typeNameBG) == DialogResult.OK)
                {
                    paymentTypeToEdit.TypeEN = typeNameEN;
                    paymentTypeToEdit.TypeBG = typeNameBG;
                    if (Database.UpdatePaymentType(paymentTypeToEdit))
                    {
                        MessageBox.Show("Успешно редактиран запис!");
                        Database.LoadDBTables(loadPaymentTypes: true);
                        LoadPaymentTypeTable();
                    }
                    else
                    {
                        MessageBox.Show(
                            string.Format("Проблем при изпълняване на функцията с номер на производител: {0}!", paymentTypeID));
                        return;
                    }
                }

            }
            else
            {
                MessageBox.Show(
                    string.Format("Проблем при изпълняване на функцията с номер на производител: {0}!", paymentTypeID));
                return;
            }
        }

        private void EditVehicleType(int vehicleTypeID)
        {
            var vehicleTypeToEdit = Database.VehicleTypes.Find(x => x.ID == vehicleTypeID);
            if (vehicleTypeToEdit != null)
            {
                string typeNameEN = vehicleTypeToEdit.TypeEN;
                string typeNameBG = vehicleTypeToEdit.TypeBG;
                if (Utilities.InputBox("Редактиране на производител на превозни средства", "Въведете наименованието", ref typeNameEN, ref typeNameBG) == DialogResult.OK)
                {
                    vehicleTypeToEdit.TypeEN = typeNameEN;
                    vehicleTypeToEdit.TypeBG = typeNameBG;
                    if (Database.UpdateVehicleType(vehicleTypeToEdit))
                    {
                        MessageBox.Show("Успешно редактиран запис!");
                        Database.LoadDBTables(loadVehicleTypes: true);
                        LoadVehicleTypeTable();
                    }
                    else
                    {
                        MessageBox.Show(
                            string.Format("Проблем при изпълняване на функцията с номер на производител: {0}!", vehicleTypeID));
                        return;
                    }
                }

            }
            else
            {
                MessageBox.Show(
                    string.Format("Проблем при изпълняване на функцията с номер на производител: {0}!", vehicleTypeID));
                return;
            }
        }

        private void EditManufacturerVehicleType()
        {
            throw new NotImplementedException();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                if (mLoadedTable == TableToLoad.Manufacturer)
                {
                    if (e.ColumnIndex == 2)
                    {
                        int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        FormDataGridView form = new FormDataGridView(TableToLoad.ManufacturerVehicleType, manufacturerID: id);
                        form.ShowDialog();
                    }
                    if (e.ColumnIndex == 3)
                    {
                        string manufacturerName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        FormManufacturerVehicleTypeInsert form = new FormManufacturerVehicleTypeInsert(manufacturerName);
                        form.ShowDialog();
                        //MessageBox.Show(string.Format("{0}, {1}",e.ColumnIndex, e.RowIndex));
                    }

                } 
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (mLoadedTable == TableToLoad.Client)
            {
                DeleteClient();
            }
            else if (mLoadedTable == TableToLoad.Employee)
            {
                DeleteEmployee();
            }
            else if (mLoadedTable == TableToLoad.Manufacturer)
            {
                DeleteManufacturer();
            }
            else if (mLoadedTable == TableToLoad.Vehicle)
            {
                DeleteVehicle();
            }
            else if (mLoadedTable == TableToLoad.VehicleType)
            {
                DeleteVehicleType();
            }
            else if (mLoadedTable == TableToLoad.PaymentType)
            {
                DeletePaymentType();
            }
            else if (mLoadedTable == TableToLoad.Purchase)
            {
                StornoPurchase();
            }
        }
        private void DeleteClient()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int clientID = (int)dataGridView1.Rows[rowIndex].Cells[0].Value;
                //string client = (string)dataGridViewTest.Rows[rowIndex].Cells[1].Value;
                /*DialogResult result =
                    MessageBox.Show(string.Format("Да се изтрие ли клиент\nс пореден номер {0}?", clientID),
                    "Потвърждение за изтриване", MessageBoxButtons.YesNo);*/
                DialogResult result = Utilities.MessageBoxCustomYesNo("Потвърждение за изтриване", 
                    string.Format("Да се изтрие ли клиент\nс пореден номер {0}?", clientID), "Да", "Не");
                /*MessageBox.Show(string.Format("Да се изтрие ли {0}\nот лаборатория 196?", client),
                "Потвърждение за изтриване", MessageBoxButtons.YesNo);*/

                if (result == DialogResult.Yes)
                {
                    bool fkViolation = false;
                    if (Database.DeleteClient(clientID, ref fkViolation))
                    {
                        MessageBox.Show("Запис успешно изтрит!");
                        Database.LoadDBTables(loadClients: true);
                        LoadClientsTable();
                    }
                    else if (fkViolation)
                    {
                        MessageBox.Show("Продажба в базата данни използва този клиент!\nИзтриването е невъзможно!");
                    }
                    else
                    {
                        MessageBox.Show("Грешка повреме на изтриване!");
                    }
                }
            }
        }
        private void DeleteEmployee()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int employeeID = (int)dataGridView1.Rows[rowIndex].Cells[0].Value;
                DialogResult result =
                    MessageBox.Show(string.Format("Да се изтрие ли служител\nс пореден номер {0}?", employeeID),
                    "Потвърждение за изтриване", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool fkViolation = false;
                    if (Database.DeleteEmployee(employeeID, ref fkViolation))
                    {
                        MessageBox.Show("Запис успешно изтрит!");
                        Database.LoadDBTables(loadEmployees: true);
                        LoadEmployeeTable();
                    }
                    else if (fkViolation)
                    {
                        MessageBox.Show("Продажба в базата данни използва този служител!\nИзтриването е невъзможно!");
                    }
                    else
                    {
                        MessageBox.Show("Грешка повреме на изтриване!");
                    }
                }
            }
        }
        private void DeleteManufacturer()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int manufacturerID = (int)dataGridView1.Rows[rowIndex].Cells[0].Value;
                DialogResult result =
                    MessageBox.Show(string.Format("Да се изтрие ли производител\nс пореден номер {0}?", manufacturerID),
                    "Потвърждение за изтриване", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool fkViolation = false;
                    if (Database.DeleteManufacturer(manufacturerID, ref fkViolation))
                    {
                        MessageBox.Show("Запис успешно изтрит!");
                        Database.LoadDBTables(loadManufacturers: true);
                        LoadManufacturerTable();
                    }
                    else if (fkViolation)
                    {
                        MessageBox.Show("Превозно средство в базата данни използва този производител!\nИзтриването е невъзможно!");
                    }
                    else
                    {
                        MessageBox.Show("Грешка повреме на изтриване!");
                    }
                }
            }
        }
        private void DeletePaymentType()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int paymentTypeID = (int)dataGridView1.Rows[rowIndex].Cells[0].Value;
                DialogResult result =
                    MessageBox.Show(string.Format("Да се изтрие ли производител\nс пореден номер {0}?", paymentTypeID),
                    "Потвърждение за изтриване", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool fkViolation = false;
                    if (Database.DeletePaymentType(paymentTypeID, ref fkViolation))
                    {
                        MessageBox.Show("Запис успешно изтрит!");
                        Database.LoadDBTables(loadPaymentTypes: true);
                        LoadPaymentTypeTable();
                    }
                    else if (fkViolation)
                    {
                        MessageBox.Show("Продажба в базата данни използва този начин на плащане!\nИзтриването е невъзможно!");
                    }
                    else
                    {
                        MessageBox.Show("Грешка повреме на изтриване!");
                    }
                }
            }
        }
        private void DeleteVehicle()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int vehicleID = (int)dataGridView1.Rows[rowIndex].Cells[0].Value;
                DialogResult result =
                    MessageBox.Show(string.Format("Да се изтрие ли превозно средство\nс пореден номер {0}?", vehicleID),
                    "Потвърждение за изтриване", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool fkViolation = false;
                    if (Database.DeleteVehicle(vehicleID, ref fkViolation))
                    {
                        MessageBox.Show("Запис успешно изтрит!");
                        Database.LoadDBTables(loadVehicles: true);
                        LoadVehicleTable();
                    }
                    else if (fkViolation)
                    {
                        MessageBox.Show("Продажба в базата данни използва това превозно средство!\nИзтриването е невъзможно!");
                    }
                    else
                    {
                        MessageBox.Show("Грешка повреме на изтриване!");
                    }
                }
            }
        }
        private void DeleteVehicleType()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int vehicleTypeID = (int)dataGridView1.Rows[rowIndex].Cells[0].Value;
                DialogResult result =
                    MessageBox.Show(string.Format("Да се изтрие ли производител\nс пореден номер {0}?", vehicleTypeID),
                    "Потвърждение за изтриване", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool fkViolation = false;
                    if (Database.DeleteVehicleType(vehicleTypeID, ref fkViolation))
                    {
                        MessageBox.Show("Запис успешно изтрит!");
                        Database.LoadDBTables(loadVehicleTypes: true);
                        LoadVehicleTypeTable();
                    }
                    else if (fkViolation)
                    {
                        MessageBox.Show("Превозно средство в базата данни използва този тип на превозно средство!\nИзтриването е невъзможно!");
                    }
                    else
                    {
                        MessageBox.Show("Грешка повреме на изтриване!");
                    }
                }
            }
        }
        private void StornoPurchase()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int purchaseID = (int)dataGridView1.Rows[rowIndex].Cells[0].Value;
                Purchase purchase = Database.Purchase.Find(x => x.ID == purchaseID);
                DialogResult result =
                    MessageBox.Show(string.Format("Да се извърши ли стопрно операция на продажба\nс пореден номер {0}?", purchaseID),
                    "Потвърждение за извършване на сторно операция", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    if (Database.StornoPurchase(purchase))
                    {
                        MessageBox.Show("Запис извършена операция!");
                        Database.LoadDBTables(loadPurchases: true, loadVehicles: true);
                        LoadPurchaseTable();
                    }
                    else
                    {
                        MessageBox.Show("Грешка повреме на операция!");
                    }
                }
            }
        }

        private void buttonPurchaseSearchByDate_Click(object sender, EventArgs e)
        {
            if (mLoadedTable == TableToLoad.Purchase)
            {
                LoadPurchaseTable(true);
            }
        }
    }
}
