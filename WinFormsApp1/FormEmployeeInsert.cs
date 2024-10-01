using BCrypt.Net;
using System.Diagnostics;
using System.Text;

namespace DealershipSoftware
{
    public partial class FormEmployeeInsert : Form
    {
        bool IsEdit = false;
        Employee EmployeeToAdd;
        public FormEmployeeInsert()
        {
            EmployeeToAdd = new Employee();
            InitializeComponent();
        }
        public FormEmployeeInsert(Employee employee)
        {
            IsEdit = true;
            EmployeeToAdd = employee;
            InitializeComponent();
            this.Name = "Редактиране на служител";
        }

        private void FormEmployeeInsert_Load(object sender, EventArgs e)
        {
            if (IsEdit)
            {
                textBoxFirstName.Text = EmployeeToAdd.FirstName;
                textBoxLastName.Text = EmployeeToAdd.LastName;
                textBoxEmail.Text = EmployeeToAdd.Email;
                textBoxTelephone.Text = EmployeeToAdd.Telephone;
                dateTimePickerDOB.Value = EmployeeToAdd.DateOfBirth.Date;                
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Length == 0)
            {
                MessageBox.Show("Моля въведете парола!");
                textBoxPassword.Focus();
                return;
            }
            if (textBoxFirstName.Text.Length == 0 || textBoxLastName.Text.Length == 0 || textBoxEmail.Text.Length == 0)
            {
                MessageBox.Show("Липсват данни!");
                return;
            }
            EmployeeToAdd.FirstName = textBoxFirstName.Text;
            EmployeeToAdd.LastName = textBoxLastName.Text;
            EmployeeToAdd.Email = textBoxEmail.Text;
            EmployeeToAdd.Telephone = textBoxTelephone.Text;
            EmployeeToAdd.DateOfBirth = dateTimePickerDOB.Value;
            string salt = string.Empty;
            Employee.GenerateSalt(ref salt);
            EmployeeToAdd.Salt = salt;
            string password = textBoxPassword.Text + Employee.Pepper;
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            //string hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(password, 10, HashType.SHA512);

            EmployeeToAdd.Password = Encoding.UTF8.GetBytes(hashedPassword);
            if (IsEdit)
            {
                if (Database.UpdateEmployee(EmployeeToAdd))
                {
                    Database.LoadDBTables(loadEmployees: true);
                    MessageBox.Show("Успешно обновен запис на служител");
                }
                else
                {
                    MessageBox.Show("Грешка повреме на обноване на запис на служител");
                }

            }
            else
            {
                //ATTENTION! Shit code here!
                EmployeeToAdd.EmployeeTypeID = 1;
                if (Database.InsertEmployee(EmployeeToAdd))
                {
                    Database.LoadDBTables(loadEmployees: true);
                    MessageBox.Show("Успешно вмъкнат запис на служител");
                }
                else
                {
                    MessageBox.Show("Грешка повреме на записване на служител");
                }
            }
            this.Close();
        }

        private void dateTimePickerDOB_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
