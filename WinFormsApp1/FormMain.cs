using DealershipSoftware.Properties;
using System.Diagnostics;
using System.Net.Mail;
using System.Windows.Forms;

namespace DealershipSoftware
{
    public partial class FormMain : Form
    {
        bool isDebug = false;
        DateTime beginTime = DateTime.Now;
        private static int mEmployeeID;
        private static string mEmployeeName = "";
        private static EmployeeType mEmployeeType;
        //private static Employee mEmployee;
        //bool tableHasFreshResults = false;
        public static Bitmap VehiclePictureMissing = Resources.VehiclePictureMissing;
        UserControl1 UserControlAdmin = new UserControl1();
        UserControlClient UserControlClient;// = new UserControlClient();
        UserControlEmployee UserControlEmployee;// = new UserControlEmployee();
        UserControlPurchase UserControlPurchase;// = new UserControlPurchase();
        UserControlVehicle UserControlVehicle;// = new UserControlVehicle();

        enum ErrorCodes
        {
            Unknown = -1,
            NoConnection,
            DatabaseDoesNotExist,
            AccessDenied,
            ConfigError
        }
        public enum EmployeeType
        {
            Unsigned = 0,
            Seller = 1,
            Manager = 2,
            Admin = 3
        }
        public FormMain()
        {
            int errorCode = -1;
            if (!Database.CheckConnection(ref errorCode))
            {
                ErrorCodes error = (ErrorCodes)errorCode;
                if (error == ErrorCodes.Unknown)
                {
                    MessageBox.Show("Базата данни връща непозната грешка!");
                }
                else if (error == ErrorCodes.NoConnection)
                {
                    MessageBox.Show("Няма връзка до базата данни!");
                }
                else if (error == ErrorCodes.DatabaseDoesNotExist)
                {
                    MessageBox.Show("Базата данни не съществува!");
                }
                else if (error == ErrorCodes.AccessDenied)
                {
                    MessageBox.Show("Данните за вход към базата данни не са валидни!");
                }
                else if (error == ErrorCodes.ConfigError)
                {
                    MessageBox.Show("Открит проблем при конфигурационният файл!");
                }
                Environment.Exit(0); //Kill application
            }

            Database.LoadAllDBTables();

            InitializeComponent();
            var lapsedTime = DateTime.Now.Subtract(beginTime).TotalMilliseconds;
            Debug.WriteLine(lapsedTime.ToString());
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            if (!Utilities.IsEmailValid(textBoxEmail.Text))
            {
                MessageBox.Show("Въведеният имейл не е валиден!");
                textBoxEmail.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Двете текстови полета са празни!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Текстовото поле за имейл е празно!");
                textBoxEmail.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Текстовото поле за парола е празно!");
                textBoxPassword.Focus();
                return;
            }

            if (Database.Employees == null || Database.Employees.Count <= 0)
            {
                Database.LoadAllDBTables();
            }
            var employee = Database.Employees.Find(x => x.Email.ToLower() == email.ToLower());

            if (employee != null)
            {
                string passwordToCheck = System.Text.Encoding.UTF8.GetString(employee.Password);
                string inputPassword = textBoxPassword.Text;
                inputPassword = inputPassword + Employee.Pepper;
                string salt = employee.Salt;
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(inputPassword, salt);

                if (passwordToCheck == hashedPassword)
                {
                    FormMain.mEmployeeID = employee.ID;
                    FormMain.mEmployeeName = string.Format("{0} {1}", employee.FirstName, employee.LastName);
                    FormMain.mEmployeeType = (EmployeeType)employee.EmployeeTypeID;

                    string[] lines = { "Сегашен логин:", mEmployeeID.ToString() + ", " + mEmployeeName, mEmployeeType.ToString() };
                    richTextBoxCurrentEmployee.Lines = lines;
                    //richTextBox1.Lines[1] = employeeID + ", " + employeeName;
                    richTextBoxCurrentEmployee.Enabled = true;
                    buttonLogin.Enabled = false;
                    buttonLogout.Enabled = true;

                    SetUserTabAccess(FormMain.mEmployeeType);
                    MessageBox.Show("Успешен логин!");
                    ChangeToMainPage();
                    textBoxEmail.Text = "";
                    textBoxPassword.Text = "";
                }
                else
                {
                    MessageBox.Show("Въведената парола е неправилна!\nОпитайте отново!");                    
                }
            }
            else
            {
                MessageBox.Show("Не е открит потребител с такъв имейл!");
                return;
            }
        }

        private void ChangeToMainPage()
        {
            this.tabControl1.Enabled = true;
            this.tabControl1.Visible = true;
            this.panelLogin.Enabled = false;
            this.panelLogin.Visible = false;
        }
        private void ChangeToLoginPage()
        {
            this.tabControl1.Enabled = false;
            this.tabControl1.Visible = false;
            this.panelLogin.Enabled = true;
            this.panelLogin.Visible = true;
        }


        private void buttonLogout_Click(object sender, EventArgs e)
        {
            mEmployeeID = 0;
            mEmployeeName = "";
            mEmployeeType = EmployeeType.Unsigned;
            string[] lines = { "Сегашен логин:", "Няма логнат служител!" };
            richTextBoxCurrentEmployee.Lines = lines;
            richTextBoxCurrentEmployee.Enabled = false;
            buttonLogout.Enabled = false;
            buttonLogin.Enabled = true;
            SetUserTabAccess(mEmployeeType);
            ChangeToLoginPage();
        }

        private void buttonCristalization_Click(object sender, EventArgs e)
        {
            //this.InsertPurchase();
            //this.InsertEmployee();
            /*string salt = string.Empty;
            GenerateSalt(ref salt);
            Debug.WriteLine(salt);*/
            //Cristalization();
            ChangeToLoginPage();
        }
        private void GroupBoxRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //tableHasFreshResults = false;
            /*radioButtonSelect.Checked = true;
            radioButtonDelete.Enabled = false;
            radioButtonEdit.Enabled = false;*/
        }
        #region Cristalization
        private void Cristalization()
        {
            MessageBox.Show("Test");

        }
        #endregion

        private void richTextBoxCurrentEmployee_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            UpdateClock();

        }
        private void UpdateClock()
        {
            DateTime now = DateTime.Now;
            labelClock.Text = now.ToString("HH:mm");            
            labelDate.Text = now.ToString("dd.MM.yyyy г.");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }
        private void buttonForgottenPassword_Click(object sender, EventArgs e)
        {
            string email = string.Empty;
            DialogResult dialogResult = Utilities.InputBox("Забравена парола", "Въведете вашият имейл", ref email);
            if (dialogResult == DialogResult.OK)
            {
                if (Utilities.IsEmailValid(email))
                {
                    if (Database.Employees.Any(x => x.Email.ToLower() == email.ToLower()))
                    {
                        MessageBox.Show(string.Format("Системният администратор е уведомен за\nзабравена парола на потребител с имейл:\n{0}", email));                        
                    }
                    else
                    {
                        MessageBox.Show("Не съществува служител с такъв имейл!");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Въведеният имейл не е валиден.\nОпитай отново!");
                    buttonForgottenPassword.PerformClick();
                }                
            }
            else if (dialogResult == DialogResult.TryAgain)
            {
                buttonForgottenPassword.PerformClick();
            }    
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (Utilities.IsEmailValid(textBoxEmail.Text))
            {
                label1.Visible = false;
            }
            else
            {
                label1.Visible = true;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            ChangeToMainPage();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Utilities.MessageBoxCustomYesNo("Въпрос", "Продължаване на редакции?", "Да", "Не");
            FormDataGridView form = new FormDataGridView(FormDataGridView.TableToLoad.VehicleType);
            form.ShowDialog();
        }

        private void buttonVehicleImport_Click(object sender, EventArgs e)
        {
            FormVehicleInsert formVehicleInsert = new FormVehicleInsert();
            formVehicleInsert.ShowDialog();
        }

        private void buttonShowPassword_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = false;
            buttonShowPassword.Text = "🙈";
        }

        private void buttonShowPassword_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            buttonShowPassword.Text = "👁";
        }

        private void buttonShowPassword_Click(object sender, EventArgs e)
        {

        }
        private void ClearTabAccess()
        {
            if (tabControl1.TabPages.Count > 0)
            {
                foreach (Control control in tabControl1.Controls)
                {
                    control.Dispose();
                }
                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    tabControl1.TabPages.Remove(tabPage);
                }
            }

        }
        private void SetUserTabAccess(EmployeeType employeeType)
        {
            if (employeeType == EmployeeType.Unsigned)
            {
                ClearTabAccess();
            }
            else if (employeeType == EmployeeType.Seller)
            {
                AddSellerTabs();
            }
            else if (employeeType == EmployeeType.Manager)
            {
                AddManagerTabs();
            }
            else if (employeeType == EmployeeType.Admin)
            {
                AddAdminTabs();
            }


            // Set the selected tab to the first visible one
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                if (tabPage.Visible)
                {
                    tabControl1.SelectedTab = tabPage;
                    break;
                }
            }
        }

        private void AddSellerTabs()
        {
            UserControlClient = new UserControlClient(FormMain.mEmployeeID);
            UserControlClient.Dock = DockStyle.Fill;
            TabPage tabPageClient = new TabPage();
            tabPageClient.Text = "Клиенти";
            tabPageClient.Controls.Add(UserControlClient);
            tabControl1.TabPages.Add(tabPageClient);

            UserControlPurchase = new UserControlPurchase(FormMain.mEmployeeID);
            UserControlPurchase.Dock = DockStyle.Fill;
            TabPage tabPagePurchase = new TabPage();
            tabPagePurchase.Text = "Продажби";
            tabPagePurchase.Controls.Add(UserControlPurchase);
            tabControl1.TabPages.Add(tabPagePurchase);

            UserControlVehicle = new UserControlVehicle(FormMain.mEmployeeID);
            UserControlVehicle.Dock = DockStyle.Fill;
            TabPage tabPageVehicle = new TabPage();
            tabPageVehicle.Text = "Превозни средства";
            tabPageVehicle.Controls.Add(UserControlVehicle);
            tabControl1.TabPages.Add(tabPageVehicle);


        }
        private void AddManagerTabs()
        {
            AddSellerTabs();
            UserControlEmployee = new UserControlEmployee();
            UserControlEmployee.Dock = DockStyle.Fill;
            TabPage tabPageEmployee = new TabPage();
            tabPageEmployee.Text = "Служители";
            tabPageEmployee.Controls.Add(UserControlEmployee);
            tabControl1.TabPages.Add(tabPageEmployee);
        }
        private void AddAdminTabs()
        {
            AddManagerTabs();
            UserControlAdmin = new UserControl1();
            UserControlAdmin.Dock = DockStyle.Fill;
            TabPage tabPageAdmin = new TabPage();
            tabPageAdmin.Text = "Админ";
            tabPageAdmin.Controls.Add(UserControlAdmin);
            tabControl1.TabPages.Add(tabPageAdmin);
        }

        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                buttonLogin.PerformClick();
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            Debug.WriteLine(this.Size.ToString());
        }
    }
}