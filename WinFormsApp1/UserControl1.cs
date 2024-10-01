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
    public partial class UserControl1 : UserControl
    {
        bool isDebug = false;
        bool tableHasFreshResults = false;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
        private void GroupBoxRadioButton_CheckedChanged(object sender, EventArgs e)
        {
           // tableHasFreshResults = false;
            radioButtonSelect.Checked = true;
            radioButtonDelete.Enabled = false;
            radioButtonEdit.Enabled = false;
        }
        private void buttonDebug_Click(object sender, EventArgs e)
        {
            
            //clients
            if (radioButtonClients.Checked && radioButtonSelect.Checked) { SelectClients(); }
            else if (radioButtonClients.Checked && radioButtonDelete.Checked) { DeleteClient(); }
            else if (radioButtonClients.Checked && radioButtonInsert.Checked) { InsertClient(); }
            else if (radioButtonClients.Checked && radioButtonEdit.Checked) { EditClient(); }
            //vehicle            
            else if (radioButtonVehicles.Checked && radioButtonSelect.Checked) { SelectVehicles(); }
            else if (radioButtonVehicles.Checked && radioButtonDelete.Checked) { DeleteVehicle(); }
            else if (radioButtonVehicles.Checked && radioButtonInsert.Checked) { InsertVehicle(); }
            else if (radioButtonVehicles.Checked && radioButtonEdit.Checked) { EditVehicle(); }
            //employee
            else if (radioButtonEmployees.Checked && radioButtonSelect.Checked) { SelectEmployees(); }
            else if (radioButtonEmployees.Checked && radioButtonDelete.Checked) { DeleteEmployee(); }
            else if (radioButtonEmployees.Checked && radioButtonInsert.Checked) { InsertEmployee(); }
            else if (radioButtonEmployees.Checked && radioButtonEdit.Checked) { EditEmployee(); }
            //Manufacturer
            else if (radioButtonManufacturers.Checked && radioButtonSelect.Checked) { SelectManufacturers(); }
            else if (radioButtonManufacturers.Checked && radioButtonDelete.Checked) { DeleteManufacturer(); }
            else if (radioButtonManufacturers.Checked && radioButtonInsert.Checked) { InsertManufacturer(); }
            else if (radioButtonManufacturers.Checked && radioButtonEdit.Checked) { EditManufacturer(); }
            //purchase
            else if (radioButtonPurchase.Checked && radioButtonSelect.Checked) { SelectPurchase(); }
            else if (radioButtonPurchase.Checked && radioButtonDelete.Checked) { DeletePurchase(); }
            else if (radioButtonPurchase.Checked && radioButtonInsert.Checked) { InsertPurchase(); }
            else if (radioButtonPurchase.Checked && radioButtonEdit.Checked) { EditPurchase(); }
            //type payment
            else if (radioButtonTypePayment.Checked && radioButtonSelect.Checked) { SelectPaymentTypes(); }
            else if (radioButtonTypePayment.Checked && radioButtonDelete.Checked) { DeletePaymentType(); }
            else if (radioButtonTypePayment.Checked && radioButtonInsert.Checked) { InsertPaymentType(); }
            else if (radioButtonTypePayment.Checked && radioButtonEdit.Checked) { EditPaymentType(); }
            //type vehicle
            else if (radioButtonTypeVehicle.Checked && radioButtonSelect.Checked) { SelectVehicleTypes(); }
            else if (radioButtonTypeVehicle.Checked && radioButtonDelete.Checked) { DeleteVehicleType(); }
            else if (radioButtonTypeVehicle.Checked && radioButtonInsert.Checked) { InsertVehicleType(); }
            else if (radioButtonTypeVehicle.Checked && radioButtonEdit.Checked) { EditVehicleType(); }
            //type vehicle
            else if (radioButtonManufacturerVehicleType.Checked && radioButtonSelect.Checked) { SelectManufacturerVehicleType(); }
            else if (radioButtonManufacturerVehicleType.Checked && radioButtonDelete.Checked) { DeleteManufacturerVehicleType(); }
            else if (radioButtonManufacturerVehicleType.Checked && radioButtonInsert.Checked) { InsertManufacturerVehicleType(); }
            else if (radioButtonManufacturerVehicleType.Checked && radioButtonEdit.Checked) { EditManufacturerVehicleType(); }

            if (tableHasFreshResults)
            {
                radioButtonEdit.Enabled = true;
                radioButtonDelete.Enabled = true;
            }
        }

        private void EditManufacturerVehicleType()
        {
            throw new NotImplementedException();
        }

        private void InsertManufacturerVehicleType()
        {
            FormManufacturerVehicleTypeInsert form = new FormManufacturerVehicleTypeInsert();
            form.ShowDialog();
        }

        private void DeleteManufacturerVehicleType()
        {
            throw new NotImplementedException();
        }

        private void SelectClients()
        {
            try
            {
                Database.LoadDBTables(loadClients: true);

                dataGridViewTest.Rows.Clear();
                dataGridViewTest.Columns.Clear();

                if (Database.Clients.Count <= 0)
                {
                    MessageBox.Show("В базата данни няма записи!");
                    return;
                }

                dataGridViewTest.ColumnCount = 4;

                dataGridViewTest.RowCount = Database.Clients.Count;

                dataGridViewTest.Columns[0].HeaderText = "№";
                dataGridViewTest.Columns[0].Width = 50;

                dataGridViewTest.Columns[1].HeaderText = "First Name";
                dataGridViewTest.Columns[1].Width = 300;

                dataGridViewTest.Columns[2].HeaderText = "Last Name";
                dataGridViewTest.Columns[2].Width = 300;

                dataGridViewTest.Columns[3].HeaderText = "Telephone";
                dataGridViewTest.Columns[3].Width = 150;



                for (int i = 0; i < Database.Clients.Count; i++)
                {
                    dataGridViewTest.Rows[i].Cells[0].Value = Database.Clients[i].ID;
                    dataGridViewTest.Rows[i].Cells[1].Value = Database.Clients[i].FirstName;
                    dataGridViewTest.Rows[i].Cells[2].Value = Database.Clients[i].LastName;
                    dataGridViewTest.Rows[i].Cells[3].Value = Database.Clients[i].Telephone;

                }
                tableHasFreshResults = true;
                return;

            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }
        }
        private void SelectManufacturerVehicleType()
        {
            try
            {
                Database.LoadDBTables(loadManufacturerVehicleTypes: true);

                dataGridViewTest.Rows.Clear();
                dataGridViewTest.Columns.Clear();
                
                if (Database.Manufacturers.Count <= 0)
                {
                    MessageBox.Show("В базата данни няма записи!");
                    return;
                }
                /*
                dataGridViewTest.ColumnCount = 4;

                dataGridViewTest.RowCount = Database.ManufacturerVehicleTypes.Count;

                dataGridViewTest.Columns[0].HeaderText = "№";
                dataGridViewTest.Columns[0].Width = 50;

                dataGridViewTest.Columns[1].HeaderText = "First Name";
                dataGridViewTest.Columns[1].Width = 300;

                dataGridViewTest.Columns[2].HeaderText = "Last Name";
                dataGridViewTest.Columns[2].Width = 300;

                dataGridViewTest.Columns[3].HeaderText = "Telephone";
                dataGridViewTest.Columns[3].Width = 150;



                for (int i = 0; i < Database.ManufacturerVehicleTypes.Count; i++)
                {
                    dataGridViewTest.Rows[i].Cells[0].Value = Database.ManufacturerVehicleTypes[i].Manufacturer.Name;
                    //dataGridViewTest.Rows[i].Cells[1].Value = Database.ManufacturerVehicleTypes[i].;
                    //dataGridViewTest.Rows[i].Cells[2].Value = Database.Clients[i].LastName;
                    //dataGridViewTest.Rows[i].Cells[3].Value = Database.Clients[i].Telephone;

                }
                tableHasFreshResults = true;
                return;
                */
            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }
        }
        private void SelectManufacturers()
        {
            try
            {
                Database.LoadDBTables(loadManufacturers: true);

                dataGridViewTest.Rows.Clear();
                dataGridViewTest.ColumnCount = 2;

                if (Database.Manufacturers.Count <= 0)
                {
                    MessageBox.Show("В базата данни няма записи!");
                    return;
                }
                dataGridViewTest.RowCount = Database.Manufacturers.Count;

                dataGridViewTest.Columns[0].HeaderText = "№";
                dataGridViewTest.Columns[0].Width = 50;

                dataGridViewTest.Columns[1].HeaderText = "Name";
                dataGridViewTest.Columns[1].Width = 300;

                for (int i = 0; i < Database.Manufacturers.Count; i++)
                {
                    dataGridViewTest.Rows[i].Cells[0].Value = Database.Manufacturers[i].ID;
                    dataGridViewTest.Rows[i].Cells[1].Value = Database.Manufacturers[i].Name;

                }
                tableHasFreshResults = true;
                return;
            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }


        }
        private void DeleteVehicle()
        {
            if (dataGridViewTest.Rows.Count > 0)
            {
                int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                int vehicleID = (int)dataGridViewTest.Rows[rowIndex].Cells[0].Value;
                DialogResult result =
                    MessageBox.Show(string.Format("Да се изтрие ли превозно средство\nс пореден номер {0}?", vehicleID),
                    "Потвърждение за изтриване", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool fkViolation = false;
                    if (Database.DeleteVehicle(vehicleID, ref fkViolation))
                    {
                        MessageBox.Show("Запис успешно изтрит!");
                        SelectVehicles();
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
        private void DeleteEmployee()
        {
            if (dataGridViewTest.Rows.Count > 0)
            {
                int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                int employeeID = (int)dataGridViewTest.Rows[rowIndex].Cells[0].Value;
                DialogResult result =
                    MessageBox.Show(string.Format("Да се изтрие ли служител\nс пореден номер {0}?", employeeID),
                    "Потвърждение за изтриване", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool fkViolation = false;
                    if (Database.DeleteEmployee(employeeID, ref fkViolation))
                    {
                        MessageBox.Show("Запис успешно изтрит!");
                        SelectEmployees();
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
        private void DeletePurchase()
        {
            if (dataGridViewTest.Rows.Count > 0)
            {
                int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                int purchaseID = (int)dataGridViewTest.Rows[rowIndex].Cells[0].Value;
                DialogResult result =
                    MessageBox.Show(string.Format("Да се изтрие ли продажба\nс пореден номер {0}?", purchaseID),
                    "Потвърждение за изтриване", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (Database.DeletePurchase(purchaseID))
                    {
                        MessageBox.Show("Запис успешно изтрит!");
                        SelectPurchase();
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
            if (dataGridViewTest.Rows.Count > 0)
            {
                int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                int manufacturerID = (int)dataGridViewTest.Rows[rowIndex].Cells[0].Value;
                DialogResult result =
                    MessageBox.Show(string.Format("Да се изтрие ли производител\nс пореден номер {0}?", manufacturerID),
                    "Потвърждение за изтриване", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool fkViolation = false;
                    if (Database.DeleteManufacturer(manufacturerID, ref fkViolation))
                    {
                        MessageBox.Show("Запис успешно изтрит!");
                        SelectManufacturers();
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
        private void DeleteVehicleType()
        {
            if (dataGridViewTest.Rows.Count > 0)
            {
                int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                int vehicleTypeID = (int)dataGridViewTest.Rows[rowIndex].Cells[0].Value;
                DialogResult result =
                    MessageBox.Show(string.Format("Да се изтрие ли производител\nс пореден номер {0}?", vehicleTypeID),
                    "Потвърждение за изтриване", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool fkViolation = false;
                    if (Database.DeleteVehicleType(vehicleTypeID, ref fkViolation))
                    {
                        MessageBox.Show("Запис успешно изтрит!");
                        SelectVehicleTypes();
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
        private void DeletePaymentType()
        {
            if (dataGridViewTest.Rows.Count > 0)
            {
                int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                int paymentTypeID = (int)dataGridViewTest.Rows[rowIndex].Cells[0].Value;
                DialogResult result =
                    MessageBox.Show(string.Format("Да се изтрие ли производител\nс пореден номер {0}?", paymentTypeID),
                    "Потвърждение за изтриване", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool fkViolation = false;
                    if (Database.DeletePaymentType(paymentTypeID, ref fkViolation))
                    {
                        MessageBox.Show("Запис успешно изтрит!");
                        SelectPaymentTypes();
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
        private void InsertPurchase()
        {
            Database.LoadAllDBTables();
            FormPurchaseInsert form = new FormPurchaseInsert(isDebug);
            form.ShowDialog();
            SelectPurchase();
        }
        private void InsertManufacturer()
        {
            string manufacturer = string.Empty;
            if (Utilities.InputBox("Добавяне на производител", "Въведете наименованието", ref manufacturer) == DialogResult.OK)
            {
                Database.InsertManufacturer(manufacturer);
                Database.LoadDBTables(loadManufacturers: true);
                SelectManufacturers();
            }

        }
        private void EditManufacturer()
        {
            try
            {
                if (dataGridViewTest.Rows.Count > 0)
                {
                    int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                    int manufacturerID = (int)dataGridViewTest.Rows[rowIndex].Cells[0].Value;
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
                                SelectManufacturers();
                            }
                            else
                            {
                                MessageBox.Show(
                                    string.Format("Проблем при изпълняване на функцията с номер на производител: {0}!", manufacturerID));
                                return;
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show(
                            string.Format("Проблем при изпълняване на функцията с номер на производител: {0}!", manufacturerID));
                        return;
                    }

                }
            }
            catch(Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
            }
        }
        private void EditVehicleType()
        {
            try
            {
                if (dataGridViewTest.Rows.Count > 0)
                {
                    int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                    int vehicleTypeID = (int)dataGridViewTest.Rows[rowIndex].Cells[0].Value;
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
                                SelectVehicleTypes();
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
            }
            catch(Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
            }
        }
        private void EditPaymentType()
        {
            try
            {
                if (dataGridViewTest.Rows.Count > 0)
                {
                    int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                    int paymentTypeID = (int)dataGridViewTest.Rows[rowIndex].Cells[0].Value;
                    var paymentTypeToEdit = Database.PaymentTypes.Find(x => x.ID == paymentTypeID);
                    if (paymentTypeToEdit != null)
                    {
                        string typeNameEN = paymentTypeToEdit.TypeEN;
                        string typeNameBG = paymentTypeToEdit.TypeBG;
                        if (Utilities.InputBox("Редактиране на производител на превозни средства", "Въведете наименованието", ref typeNameEN, ref typeNameBG) == DialogResult.OK)
                        {
                            paymentTypeToEdit.TypeEN = typeNameEN;
                            paymentTypeToEdit.TypeBG = typeNameBG;
                            if (Database.UpdatePaymentType(paymentTypeToEdit))
                            {
                                MessageBox.Show("Успешно редактиран запис!");
                                Database.LoadDBTables(loadPaymentTypes: true);
                                SelectPaymentTypes();
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
            }
            catch(Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
            }
        }
        private void InsertVehicleType()
        {
            string vehicleTypeEN = string.Empty;
            string vehicleTypeBG = string.Empty;
            if (Utilities.InputBox("Добавяне на тип превозно средство", "Въведете наименованието", ref vehicleTypeEN, ref vehicleTypeBG) == DialogResult.OK)
            {
                Database.InsertVehicleType(vehicleTypeEN, vehicleTypeBG);
                Database.LoadDBTables(loadVehicleTypes: true);
                SelectVehicleTypes();
            }

        }
        private void InsertPaymentType()
        {
            string paymentTypeEN = string.Empty;
            string paymentTypeBG = string.Empty;
            if (Utilities.InputBox("Добавяне на начин на плащане", "Въведете наименованието", ref paymentTypeEN, ref paymentTypeBG) == DialogResult.OK)
            {
                Database.InsertPaymentType(paymentTypeEN, paymentTypeBG);
                Database.LoadDBTables(loadPaymentTypes: true);
                SelectPaymentTypes();
            }

        }
        private void EditPurchase()
        {
            try
            {
                if (dataGridViewTest.Rows.Count > 0)
                {
                    int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                    int purchaseID = (int)dataGridViewTest.Rows[rowIndex].Cells[0].Value;
                    var purchaseToEdit = Database.Purchase.Find(x => x.ID == purchaseID);
                    if (purchaseToEdit != null)
                    {
                        FormPurchaseInsert form = new FormPurchaseInsert(purchaseToEdit, isDebug);
                        form.ShowDialog();
                        SelectPurchase();
                    }
                    else
                    {
                        MessageBox.Show(
                            string.Format("Проблем при изпълняване на функцията с номер на превозно средство: {0}!", purchaseID));
                        return;
                    }

                }
            }
            catch(Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
            }
        }
        private void EditVehicle()
        {
            try
            {
                if (dataGridViewTest.Rows.Count > 0)
                {
                    int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                    int vehicleID = (int)dataGridViewTest.Rows[rowIndex].Cells[0].Value;
                    var vehicleToEdit = Database.Vehicles.Find(x => x.ID == vehicleID);
                    if (vehicleToEdit != null)
                    {
                        FormVehicleInsert formVehicleInsert = new FormVehicleInsert(vehicleToEdit);
                        formVehicleInsert.ShowDialog();
                        SelectVehicles();
                    }
                    else
                    {
                        MessageBox.Show(
                            string.Format("Проблем при изпълняване на функцията с номер на превозно средство: {0}!", vehicleID));
                        return;
                    }

                }
            }
            catch(Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
            }
        }
        private void EditClient()
        {
            try
            {
                if (dataGridViewTest.Rows.Count > 0)
                {
                    int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                    int clientID = (int)dataGridViewTest.Rows[rowIndex].Cells[0].Value;
                    var vehicleToEdit = Database.Clients.Find(x => x.ID == clientID);
                    if (vehicleToEdit != null)
                    {
                        FormClientInsert form = new FormClientInsert(vehicleToEdit);
                        form.ShowDialog();
                        SelectClients();
                    }
                    else
                    {
                        MessageBox.Show(
                            string.Format("Проблем при изпълняване на функцията с номер на клиент: {0}!", clientID));
                        return;
                    }

                }
            }
            catch(Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
            }
        }
        private void InsertEmployee()
        {
            FormEmployeeInsert form = new FormEmployeeInsert();
            form.ShowDialog();
            SelectEmployees();
        }
        private void InsertVehicle()
        {
            FormVehicleInsert form = new FormVehicleInsert();
            form.ShowDialog();
            SelectVehicles();
        }
        private void InsertClient()
        {
            FormClientInsert form = new FormClientInsert();
            form.ShowDialog();
            SelectClients();
        }
        private void EditEmployee()
        {
            try
            {
                if (dataGridViewTest.Rows.Count > 0)
                {
                    int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                    int employeeID = (int)dataGridViewTest.Rows[rowIndex].Cells[0].Value;
                    var employeeToEdit = Database.Employees.Find(x => x.ID == employeeID);
                    if (employeeToEdit != null)
                    {
                        FormEmployeeInsert formEmployee = new FormEmployeeInsert(employeeToEdit);
                        formEmployee.ShowDialog();
                        SelectEmployees();
                    }
                    else
                    {
                        MessageBox.Show(
                            string.Format("Проблем при изпълняване на функцията с номер на превозно средство: {0}!", employeeID));
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
            }
        }

        private void DeleteClient()
        {
            if (dataGridViewTest.Rows.Count > 0)
            {
                int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                int clientID = (int)dataGridViewTest.Rows[rowIndex].Cells[0].Value;
                //string client = (string)dataGridViewTest.Rows[rowIndex].Cells[1].Value;
                DialogResult result =
                    MessageBox.Show(string.Format("Да се изтрие ли клиент\nс пореден номер {0}?", clientID),
                    "Потвърждение за изтриване", MessageBoxButtons.YesNo);
                /*MessageBox.Show(string.Format("Да се изтрие ли {0}\nот лаборатория 196?", client),
                "Потвърждение за изтриване", MessageBoxButtons.YesNo);*/

                if (result == DialogResult.Yes)
                {
                    bool fkViolation = false;
                    if (Database.DeleteClient(clientID, ref fkViolation))
                    {
                        MessageBox.Show("Запис успешно изтрит!");
                        SelectClients();
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

        private void SelectPurchase()
        {
            try
            {
                Database.LoadAllDBTables();


                //Database.SelectPurchase(ref purchases);

                dataGridViewTest.Columns.Clear();
                dataGridViewTest.Rows.Clear();

                if (Database.Purchase.Count == 0)
                {
                    MessageBox.Show("В базата данни няма записи!");
                    return;
                }

                dataGridViewTest.ColumnCount = 7;
                dataGridViewTest.RowCount = Database.Purchase.Count;

                dataGridViewTest.Columns[0].HeaderText = "№";
                dataGridViewTest.Columns[1].HeaderText = "Номер и име на клиент";
                dataGridViewTest.Columns[2].HeaderText = "Номер, марка и модел на превозно средство";
                dataGridViewTest.Columns[3].HeaderText = "Номер и име на служител";
                dataGridViewTest.Columns[4].HeaderText = "Дата на покупка";
                dataGridViewTest.Columns[5].HeaderText = "Финална цена";
                dataGridViewTest.Columns[6].HeaderText = "Вид на плащане";

                for (int i = 0; i < Database.Purchase.Count; i++)
                {
                    dataGridViewTest.Rows[i].Cells[0].Value = Database.Purchase[i].ID;
                    dataGridViewTest.Rows[i].Cells[1].Value = string.Format("{0}, {1} {2}",
                            Database.Purchase[i].Client.ID, Database.Purchase[i].Client.FirstName, Database.Purchase[i].Client.LastName);
                    dataGridViewTest.Rows[i].Cells[2].Value = string.Format("{0}, {1} {2} {3}г.",
                        Database.Purchase[i].Vehicle.ID, Database.Purchase[i].Vehicle.Manufacturer.Name, Database.Purchase[i].Vehicle.Model, Database.Purchase[i].Vehicle.MakeYear);
                    dataGridViewTest.Rows[i].Cells[3].Value = string.Format("{0}, {1} {2}",
                        Database.Purchase[i].Employee.ID, Database.Purchase[i].Employee.FirstName, Database.Purchase[i].Employee.LastName);
                    dataGridViewTest.Rows[i].Cells[4].Value = Database.Purchase[i].DateOfPurchase;
                    dataGridViewTest.Rows[i].Cells[5].Value = string.Format("{0} лв.", Database.Purchase[i].FinalPrice);
                    dataGridViewTest.Rows[i].Cells[6].Value = string.Format("{0}, {1}",
                        Database.Purchase[i].PaymentType.ID, Database.Purchase[i].PaymentType.TypeBG);

                }
                //dataGridView1.Columns.}
                tableHasFreshResults = true;
                return;
            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }


        }
        private void SelectEmployees()
        {
            try
            {
                Database.LoadDBTables(loadEmployees: true);

                dataGridViewTest.Columns.Clear();
                dataGridViewTest.Rows.Clear();

                if (Database.Employees.Count == 0)
                {
                    MessageBox.Show("В базата данни няма записи!");
                    return;
                }

                dataGridViewTest.ColumnCount = 5;

                dataGridViewTest.RowCount = Database.Employees.Count;

                dataGridViewTest.Columns[0].HeaderText = "№";
                dataGridViewTest.Columns[0].Width = 50;

                dataGridViewTest.Columns[1].HeaderText = "First Name";
                dataGridViewTest.Columns[1].Width = 280;

                dataGridViewTest.Columns[2].HeaderText = "Last Name";
                dataGridViewTest.Columns[2].Width = 280;

                dataGridViewTest.Columns[3].HeaderText = "Email";
                dataGridViewTest.Columns[3].Width = 150;

                dataGridViewTest.Columns[4].HeaderText = "Номер на служител";
                dataGridViewTest.Columns[4].Width = 150;

                for (int i = 0; i < Database.Employees.Count; i++)
                {
                    dataGridViewTest.Rows[i].Cells[0].Value = Database.Employees[i].ID;
                    dataGridViewTest.Rows[i].Cells[1].Value = Database.Employees[i].FirstName;
                    dataGridViewTest.Rows[i].Cells[2].Value = Database.Employees[i].LastName;
                    dataGridViewTest.Rows[i].Cells[3].Value = Database.Employees[i].Email;
                    dataGridViewTest.Rows[i].Cells[4].Value = Database.Employees[i].Telephone;

                }
                tableHasFreshResults = true;
                return;
            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }
        }

        private void SelectVehicleTypes()
        {
            try
            {
                Database.LoadDBTables(loadVehicleTypes: true);

                dataGridViewTest.Columns.Clear();
                dataGridViewTest.Rows.Clear();

                if (Database.VehicleTypes.Count == 0)
                {
                    MessageBox.Show("В базата данни няма записи!");
                    return;
                }

                dataGridViewTest.ColumnCount = 3;

                dataGridViewTest.RowCount = Database.VehicleTypes.Count;

                dataGridViewTest.Columns[0].HeaderText = "№";
                dataGridViewTest.Columns[0].Width = 50;

                dataGridViewTest.Columns[1].HeaderText = "Type(English)";
                dataGridViewTest.Columns[1].Width = 300;

                dataGridViewTest.Columns[2].HeaderText = "Type(Bulgarian)";
                dataGridViewTest.Columns[2].Width = 300;

                for (int i = 0; i < Database.VehicleTypes.Count; i++)
                {
                    dataGridViewTest.Rows[i].Cells[0].Value = Database.VehicleTypes[i].ID;
                    dataGridViewTest.Rows[i].Cells[1].Value = Database.VehicleTypes[i].TypeEN;
                    dataGridViewTest.Rows[i].Cells[2].Value = Database.VehicleTypes[i].TypeBG;
                }
                tableHasFreshResults = true;
                return;

            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }
        }
        private void SelectPaymentTypes()
        {
            try
            {
                //List<PaymentType> types = new List<PaymentType>();

                //Database.SelectPaymentType(ref types);

                Database.LoadDBTables(loadPaymentTypes: true);

                dataGridViewTest.Columns.Clear();
                dataGridViewTest.Rows.Clear();

                if (Database.PaymentTypes.Count == 0)
                {
                    MessageBox.Show("В базата данни няма записи!");
                    return;
                }

                dataGridViewTest.ColumnCount = 3;

                dataGridViewTest.RowCount = Database.PaymentTypes.Count;

                dataGridViewTest.Columns[0].HeaderText = "№";
                dataGridViewTest.Columns[0].Width = 50;

                dataGridViewTest.Columns[1].HeaderText = "Type(English)";
                dataGridViewTest.Columns[1].Width = 300;

                dataGridViewTest.Columns[2].HeaderText = "Type(Bulgarian)";
                dataGridViewTest.Columns[2].Width = 300;

                for (int i = 0; i < Database.PaymentTypes.Count; i++)
                {
                    dataGridViewTest.Rows[i].Cells[0].Value = Database.PaymentTypes[i].ID;
                    dataGridViewTest.Rows[i].Cells[1].Value = Database.PaymentTypes[i].TypeEN;
                    dataGridViewTest.Rows[i].Cells[2].Value = Database.PaymentTypes[i].TypeBG;
                }
                tableHasFreshResults = true;
                return;

            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }
        }
        private void SelectVehicles()
        {
            try
            {
                Database.LoadDBTables(loadVehicles: true);

                if (Database.Vehicles.Count <= 0)
                {
                    MessageBox.Show("В базата данни няма записи!");
                    return;
                }

                dataGridViewTest.Rows.Clear();
                dataGridViewTest.ColumnCount = 7;

                dataGridViewTest.RowCount = Database.Vehicles.Count;

                dataGridViewTest.Columns[0].HeaderText = "№";
                dataGridViewTest.Columns[0].Width = 50;

                dataGridViewTest.Columns[1].HeaderText = "Марка";
                dataGridViewTest.Columns[1].Width = 200;

                dataGridViewTest.Columns[2].HeaderText = "Модел";
                dataGridViewTest.Columns[2].Width = 150;

                dataGridViewTest.Columns[3].HeaderText = "Вид превозно средство";
                dataGridViewTest.Columns[3].Width = 150;

                dataGridViewTest.Columns[4].HeaderText = "Година на производство";
                dataGridViewTest.Columns[4].Width = 100;

                dataGridViewTest.Columns[5].HeaderText = "Минимална цена на продажба";
                dataGridViewTest.Columns[5].Width = 100;

                dataGridViewTest.Columns[6].HeaderText = "Продаден ли е автомобила?";
                dataGridViewTest.Columns[6].Width = 100;

                DataGridViewImageColumn vehicleImageColumn = new DataGridViewImageColumn();
                vehicleImageColumn.HeaderText = "Снимка на превозно средство";
                vehicleImageColumn.Width = 200;
                vehicleImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dataGridViewTest.Columns.Add(vehicleImageColumn);

                for (int i = 0; i < Database.Vehicles.Count; i++)
                {
                    dataGridViewTest.Rows[i].Cells[0].Value = Database.Vehicles[i].ID;
                    dataGridViewTest.Rows[i].Cells[1].Value = Database.Vehicles[i].Manufacturer.Name;
                    dataGridViewTest.Rows[i].Cells[2].Value = Database.Vehicles[i].Model;
                    dataGridViewTest.Rows[i].Cells[3].Value = Database.Vehicles[i].VehicleType.TypeEN;
                    dataGridViewTest.Rows[i].Cells[4].Value = Database.Vehicles[i].MakeYear;
                    dataGridViewTest.Rows[i].Cells[5].Value = string.Format("{0} лв.", Database.Vehicles[i].Price);
                    dataGridViewTest.Rows[i].Cells[6].Value = Utilities.BoolToString(Database.Vehicles[i].IsSold);

                    Bitmap bitmap = FormMain.VehiclePictureMissing;
                    if (Database.Vehicles[i].Image.Length > 0)
                    {
                        bitmap = Utilities.GetImageFromByteArray(Database.Vehicles[i].Image);
                    }
                    dataGridViewTest.Rows[i].Height = 150;
                    dataGridViewTest.Rows[i].Cells[7].Value = bitmap;

                }

                tableHasFreshResults = true;

                return;

            }
            catch (Exception ex)
            {
                LogWriter logWriter = new(ex.Message);
                MessageBox.Show("Открита грешка повреме на операция!");
                return;
            }


        }
    }
}
