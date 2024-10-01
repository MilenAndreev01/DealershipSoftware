using System.Runtime.CompilerServices;

namespace DealershipSoftware
{
    public partial class FormPurchaseInsert : Form
    {
        Purchase purchase;
        List<PaymentType> paymentTypes = Database.PaymentTypes;
        List<Client> clients = Database.Clients;
        List<Employee> employees = Database.Employees;
        List<Vehicle> vehicles = Database.Vehicles;

        bool isEdit, isDebug;
        public FormPurchaseInsert(int employeeID)
        {

            purchase = new Purchase();
            purchase.Employee = new Employee { ID = employeeID };
            InitializeComponent();
        }
        public FormPurchaseInsert(bool paramIsDebug)
        {
            isDebug = paramIsDebug;
            purchase = new Purchase();
            InitializeComponent();
        }
        public FormPurchaseInsert(Purchase purchaseToEdit, bool paramIsDebug)
        {
            isDebug = paramIsDebug;
            isEdit = true;
            purchase = purchaseToEdit;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (isDebug)
            {
                labelEmployee.Enabled = true;
                labelEmployee.Visible = true;
                comboBoxEmployee.Enabled = true;
                comboBoxEmployee.Visible = true;

                foreach (var employee in employees)
                {
                    comboBoxEmployee.Items.Add(string.Format("{0}, {1} {2}", employee.ID, employee.FirstName, employee.LastName));
                }
                if (isEdit)
                {
                    int employeeIndex = employees.FindIndex(x => x.ID == purchase.Employee.ID);
                    comboBoxEmployee.SelectedIndex = employeeIndex;
                }
            }
            vehicles = vehicles.FindAll(x => x.IsSold == false);
            foreach (var vehicle in vehicles)
            {
                comboBoxVehicle.Items.Add(string.Format("{0}, {1} {2}", vehicle.ID, vehicle.Manufacturer.Name, vehicle.Model));
            }
            clients = clients.OrderBy(x => x.LastName).ToList();
            foreach (var client in clients)
            {
                comboBoxClient.Items.Add(string.Format("{0}, {1} {2}", client.ID, client.FirstName, client.LastName));
            }


            foreach (var paymentType in paymentTypes)
            {
                comboBoxPaymentType.Items.Add(string.Format("{0}, {1}", paymentType.ID, paymentType.TypeBG));
            }
            //--------------------
            if (isEdit)
            {
                int vehicleIndex = vehicles.FindIndex(x => x.ID == purchase.Vehicle.ID);
                comboBoxVehicle.SelectedIndex = vehicleIndex;
                int clientIndex = clients.FindIndex(x => x.ID == purchase.Client.ID);
                comboBoxClient.SelectedIndex = clientIndex;
                int paymentTypeIndex = paymentTypes.FindIndex(x => x.ID == purchase.PaymentType.ID);
                comboBoxPaymentType.SelectedIndex = paymentTypeIndex;
                dateTimePickerDate.Value = purchase.DateOfPurchase.Date;
                dateTimePickerTime.Value.Add(purchase.DateOfPurchase.TimeOfDay);
                checkBoxDateTimeNow.Checked = false;
                textBoxFinalPrice.Text = ((double)purchase.FinalPrice * 100).ToString();
            }
        }

        private void checkBoxDateTimeNow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDateTimeNow.Checked)
            {
                dateTimePickerDate.Enabled = false;
                dateTimePickerTime.Enabled = false;
            }
            else
            {
                dateTimePickerDate.Enabled = true;
                dateTimePickerTime.Enabled = true;
            }
        }
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (isDebug)
            {
                purchase.Employee = employees[comboBoxEmployee.SelectedIndex];
            }            
            if(comboBoxClient.SelectedIndex == -1)
            {
                MessageBox.Show("Не е избран клиент!");
                comboBoxClient.Focus();
                return;
            }
            else if(comboBoxPaymentType.SelectedIndex == -1) 
            {
                MessageBox.Show("Не е избран начин на плащане!");
                comboBoxPaymentType.Focus();
                return;
            }
            else if(comboBoxVehicle.SelectedIndex == -1)
            {
                MessageBox.Show("Не е избрано превозно средство!");
                comboBoxVehicle.Focus();
                return;
            }    
            else if(string.IsNullOrWhiteSpace(textBoxFinalPrice.Text))
            {
                MessageBox.Show("Текстовото поле за цена е празно!");
                textBoxFinalPrice.Focus();
                return;
            }
            purchase.Client = clients[comboBoxClient.SelectedIndex];
            purchase.Vehicle = vehicles[comboBoxVehicle.SelectedIndex];
            purchase.PaymentType = paymentTypes[comboBoxPaymentType.SelectedIndex];
            
            decimal price;
            string inputFP = textBoxFinalPrice.Text;
            if (!decimal.TryParse(inputFP, out price))
            {
                if (inputFP.Contains('.'))
                {
                    inputFP = inputFP.Replace('.', ',');
                }
                else if (inputFP.Contains(','))
                {
                    inputFP = inputFP.Replace(',', '.');
                }
                if (!decimal.TryParse(inputFP, out price))
                { 
                    MessageBox.Show("Неправилно въведена стойност!");
                    textBoxFinalPrice.Focus();
                    return;
                }
            }
            
            purchase.FinalPrice = price;
            
            if (checkBoxDateTimeNow.Checked)
            {
                purchase.DateOfPurchase = DateTime.Now;
            }
            else
            {
                purchase.DateOfPurchase = dateTimePickerDate.Value.Date;
                purchase.DateOfPurchase.Add(dateTimePickerTime.Value.TimeOfDay);
            }
            if (isEdit)
            {
                if (Database.UpdatePurchase(purchase))
                {
                    Database.LoadDBTables(loadPurchases: true);
                    MessageBox.Show("Успешно редактирана продажба!");
                }
                else
                {
                    MessageBox.Show("Грешка повреме на операцията!");
                }
            }
            else
            {
                if (Database.InsertPurchase(purchase))
                {
                    Database.LoadDBTables(loadPurchases: true);
                    MessageBox.Show("Успешно вмъкната продажба!");                    
                }
                else
                {
                    MessageBox.Show("Грешка повреме на операцията!");
                }
            }
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxFinalPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                // Check if there's a decimal point and if there are already two digits after it
                int decimalPointIndex = textBox.Text.IndexOfAny(new char[] { '.', ',' });
                if (decimalPointIndex != -1 && textBox.SelectionStart > decimalPointIndex)
                {
                    // If the number of digits after the decimal point is two, reject further input
                    if (textBox.Text.Length - decimalPointIndex > 2)
                    {
                        e.Handled = true;
                    }
                }
                return;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                // If the textbox already contains a decimal point, reject the input
                if (textBox.Text.Contains(".") || textBox.Text.Contains(","))
                {
                    e.Handled = true;
                }
                return;
            }

            // Reject any other characters
            e.Handled = true;
        }
    }
    
}
