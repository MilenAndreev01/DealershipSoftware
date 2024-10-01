using DealershipSoftware.Properties;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System.Data;
using System.Globalization;

namespace DealershipSoftware
{
    public partial class FormVehicleInsert : Form
    {
        bool isPictureInserted = false, isEdit = false;
        List<Manufacturer> manufacturers = Database.Manufacturers;
        List<VehicleType> vehicleTypes = Database.VehicleTypes;
        //List<ManufacturerVehicleType> manufacturerVehicleTypes = Database.ManufacturerVehicleTypes;
        Vehicle vehicle = new Vehicle();

        public FormVehicleInsert()
        {
            InitializeComponent();
        }

        public FormVehicleInsert(Vehicle vehicleToEdit)
        {            
            isEdit = true;
            vehicle = vehicleToEdit;
            this.Name = "Редакция на внос на автомобил";
            InitializeComponent();
        }

        private void FormVehicleInsert_Load(object sender, EventArgs e)
        {
            manufacturers = manufacturers.Where(x => x.VehicleTypes.Count > 0).ToList();
            manufacturers = manufacturers.OrderBy(x => x.Name).ToList();
            
            foreach (var manufacturer in manufacturers)
            {
                if (manufacturer.VehicleTypes.Count > 0)
                {                    
                    comboBoxManufacturers.Items.Add(manufacturer.Name);
                }                
            }
            vehicleTypes = vehicleTypes.OrderBy(x => x.TypeBG).ToList();
            /*foreach (var vehicleType in vehicleTypes)
            {
                comboBoxVehicleTypes.Items.Add(vehicleType.TypeBG);
            }*/
            //---------------------------
            if (isEdit)
            {
                string manufacturerName = manufacturers.Find(x => x.ID == vehicle.Manufacturer.ID).Name;
                if (comboBoxManufacturers.FindStringExact(manufacturerName) >= 0)
                {
                    comboBoxManufacturers.SelectedIndex = comboBoxManufacturers.FindStringExact(manufacturerName);
                }
                string vehicleTypeTypeBG = vehicleTypes.Find(x => x.ID == vehicle.VehicleType.ID).TypeBG;
                if (comboBoxVehicleTypes.FindStringExact(vehicleTypeTypeBG) >= 0)
                {
                    comboBoxVehicleTypes.SelectedIndex = comboBoxVehicleTypes.FindStringExact(vehicleTypeTypeBG);
                }
                
                
                textBoxModel.Text = vehicle.Model;
                textBoxPrice.Text = vehicle.Price.ToString();
                DateTime dt;
                if (DateTime.TryParseExact(vehicle.MakeYear.ToString(), "yyyy",
                                          CultureInfo.InvariantCulture,
                                          DateTimeStyles.None, out dt))
                {
                    dateTimePicker1.Value = dt;
                }
                if (vehicle.Image.Length > 0)
                {
                    pictureBox1.Image = Utilities.GetImageFromByteArray(vehicle.Image);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    isPictureInserted = true;
                }                
            }            
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if(comboBoxManufacturers.SelectedIndex == -1)
            {
                MessageBox.Show("Не е избран производител!");
                comboBoxManufacturers.Focus();
                return;

            }
            else if(string.IsNullOrWhiteSpace(textBoxModel.Text))
            {
                MessageBox.Show("Текстовото поле за модел е празно!");
                textBoxModel.Focus();
                return;
            }
            else if(comboBoxVehicleTypes.SelectedIndex == -1) 
            {
                MessageBox.Show("Не е избран тип на превозно средство!");
                comboBoxVehicleTypes.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBoxPrice.Text))
            {
                MessageBox.Show("Текстовото поле за цена е празно!");
                textBoxPrice.Focus();
                return;
            }

            vehicle.Manufacturer = manufacturers.Find(x => x.Name == comboBoxManufacturers.SelectedItem.ToString());
            decimal price;
            string inputPrice = textBoxPrice.Text;
            if (!decimal.TryParse(inputPrice, out price))
            {
                if (inputPrice.Contains('.'))
                {
                    inputPrice = inputPrice.Replace('.', ',');
                }
                else if (inputPrice.Contains(','))
                {
                    inputPrice = inputPrice.Replace(',', '.');
                }
                if (!decimal.TryParse(inputPrice, out price))
                {
                    MessageBox.Show("Неправилно въведена стойност!");
                    textBoxPrice.Focus();
                    return;
                }
            }

            vehicle.Price = price;
            
            vehicle.Model = textBoxModel.Text;
            vehicle.MakeYear = dateTimePicker1.Value.Year;
            vehicle.VehicleType = vehicleTypes.Find(x => x.TypeBG == comboBoxVehicleTypes.SelectedItem.ToString());
            if (isPictureInserted)
            {
                vehicle.Image = Utilities.GetByteArrayFromImage(pictureBox1.Image);
            }
            if (isEdit)
            {
                if (Database.UpdateVehicle(vehicle))
                {
                    Database.LoadDBTables(loadVehicles: true);
                    MessageBox.Show("Успешно обновен запис на превозно средство");
                }
                else
                {
                    MessageBox.Show("Грешка повреме на обноване на запис на превозно средство");
                }
            }
            else
            {
                if (Database.InsertVehicle(vehicle))
                {
                    Database.LoadDBTables(loadVehicles: true);
                    MessageBox.Show("Успешно вмъкнат запис на превозно средство");                    
                }
                else
                {
                    MessageBox.Show("Грешка повреме на записване на превозно средство");
                }
            }
            this.Close();

        }

        private void buttonBrowseFiles_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Resources
                    string fileName = openFileDialog1.FileName;
                    pictureBox1.Image = new Bitmap(fileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    isPictureInserted = true;
                }
                catch (Exception ex)
                {
                    LogWriter logWriter = new(ex.Message);
                    MessageBox.Show("Открита грешка повреме на операция!");
                }
            }
            //textBoxFileName.Text = openFileDialog1.FileName;
        }

        private void comboBoxManufacturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*while (checkedListBoxVehicleTypes.CheckedIndices.Count > 0)
            {
                checkedListBoxVehicleTypes.SetItemChecked(checkedListBoxVehicleTypes.CheckedIndices[0], false);
            }*/
            comboBoxVehicleTypes.Items.Clear();
            Manufacturer manufacturer = manufacturers.Find(x => x.Name == comboBoxManufacturers.GetItemText(comboBoxManufacturers.SelectedItem));

            if (manufacturer != null)
            {
                for (int i = 0; i < vehicleTypes.Count; i++)
                {
                    if (manufacturer.VehicleTypes.Any(x => x.TypeBG == vehicleTypes[i].TypeBG))
                    {
                        //checkedListBoxVehicleTypes.SetItemChecked(i, true);
                        comboBoxVehicleTypes.Items.Add(vehicleTypes[i].TypeBG);
                    }
                }
                comboBoxVehicleTypes.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            isPictureInserted = false;
        }
    }
}
