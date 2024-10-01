namespace DealershipSoftware
{
    public partial class FormClientInsert : Form
    {
        bool IsEdit;
        Client ClientToAdd;
        public FormClientInsert()
        {
            ClientToAdd = new Client();
            InitializeComponent();
        }
        public FormClientInsert(Client clientToEdit)
        {
            IsEdit = true;
            ClientToAdd = clientToEdit;
            InitializeComponent();
            this.Text = "Редактиране на клиент";
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text.Length == 0 || textBoxLastName.Text.Length == 0 || textBoxTelephone.Text.Length == 0)
            {
                MessageBox.Show("Липсват данни!");
                return;
            }
            ClientToAdd.FirstName = textBoxFirstName.Text;
            ClientToAdd.LastName = textBoxLastName.Text;
            ClientToAdd.Telephone = textBoxTelephone.Text;
            if (IsEdit)
            {
                if (Database.UpdateClient(ClientToAdd))
                {
                    Database.LoadDBTables(loadClients: true);
                    MessageBox.Show("Успешно обновен запис на клиент");
                }
                else
                {
                    MessageBox.Show("Грешка повреме на обноване на запис на клиент");
                }
            }
            else
            {
                if (Database.InsertClient(ClientToAdd))
                {
                    Database.LoadDBTables(loadClients: true);
                    MessageBox.Show("Успешно вмъкнат запис на клиент");
                }
                else
                {
                    MessageBox.Show("Грешка повреме на записване на клиент");
                }
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormClientInsert_Load(object sender, EventArgs e)
        {
            if(IsEdit)
            {
                textBoxFirstName.Text = ClientToAdd.FirstName;
                textBoxLastName.Text = ClientToAdd.LastName;
                textBoxTelephone.Text = ClientToAdd.Telephone;
                this.Name = "Редакция на клиент";
            }
        }
    }
}
