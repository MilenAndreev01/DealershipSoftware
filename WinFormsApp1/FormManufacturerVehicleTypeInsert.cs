using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace DealershipSoftware
{
    public partial class FormManufacturerVehicleTypeInsert : Form
    {
        List<Manufacturer> manufacturers = Database.Manufacturers.OrderBy(x => x.Name).ToList();
        List<VehicleType> vehicleTypes = Database.VehicleTypes.OrderBy(x => x.TypeBG).ToList();
        //List<ManufacturerVehicleType> manufacturerVehicleTypes = Database.ManufacturerVehicleTypes.OrderBy(x => x.Manufacturer.Name).ToList();
        bool IsEdit = false;
        string ManufacturerName = string.Empty;

        public FormManufacturerVehicleTypeInsert()
        {
            InitializeComponent();
        }
        public FormManufacturerVehicleTypeInsert(string paramManufacturerName)
        {
            if (manufacturers.Any(x => x.Name == paramManufacturerName))
            {
                InitializeComponent();
                IsEdit = true;
                ManufacturerName = paramManufacturerName;
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
            }
        }



        private void FormManufacturerVehicleTypeInsert_Load(object sender, EventArgs e)
        {
            foreach (var manufacturer in manufacturers)
            {
                comboBoxManufacturer.Items.Add(manufacturer.Name);
            }
            foreach (var vehicleType in vehicleTypes)
            {
                checkedListBoxVehicleTypes.Items.Add(vehicleType.TypeBG);
            }
            if(IsEdit)
            {
                comboBoxManufacturer.SelectedIndex = manufacturers.FindIndex(x => x.Name == ManufacturerName);
                comboBoxManufacturer.Enabled = false;
            }
            else
            {
                comboBoxManufacturer.SelectedIndex = 0;
            }

        }
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            //Note to self: make stored procedure that first clears all.
            //Update to self: What an absolute moronic idea!
            //I am suffering from brain food dehydration,
            //therefore I shall be leaving immediately to Nepal where I intend to live as a goat...
            //Reaction from self: I need to stop smoking the zaza
            //Respond to self: Take LSD for good measure.
            //Notice to the outside world: RUN!
            bool successfulOperation = false;
            int manufacturerID = manufacturers[comboBoxManufacturer.SelectedIndex].ID;
            successfulOperation = Database.DeleteManufacturerVehicleTypeByManufacturer(manufacturerID);
            if(successfulOperation) 
            {
                foreach (var item in checkedListBoxVehicleTypes.CheckedItems)
                {
                    int vehicleTypeID = vehicleTypes.Find(x => x.TypeBG == item).ID;

                    successfulOperation= Database.InsertManufacturerVehicleType(manufacturerID, vehicleTypeID);
                }

                if (successfulOperation)
                {
                    if (!IsEdit)
                    {
                        DialogResult dialogResult = Utilities.MessageBoxCustomYesNo("Въпрос", "Продължаване на редакции?", "Да", "Не");
                        if (dialogResult == DialogResult.Yes)
                        {
                            Database.LoadDBTables(loadManufacturerVehicleTypes: true);

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            Database.LoadDBTables(loadManufacturerVehicleTypes: true);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Успешно изпълнена редакция!");
                        this.Close();
                    } 
                }
                else
                {
                    MessageBox.Show("Установена грешка повреме на операция");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Установена грешка повреме на операция");
                this.Close();
            }

        }

        private void comboBoxManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            while (checkedListBoxVehicleTypes.CheckedIndices.Count > 0)
            {
                checkedListBoxVehicleTypes.SetItemChecked(checkedListBoxVehicleTypes.CheckedIndices[0], false);
            }
            Manufacturer manufacturer = manufacturers.Find(x => x.Name == comboBoxManufacturer.GetItemText(comboBoxManufacturer.SelectedItem));

            if (manufacturer != null)
            {
                for (int i = 0; i < vehicleTypes.Count; i++)
                {
                    if (manufacturer.VehicleTypes.Any(x => x.TypeBG == vehicleTypes[i].TypeBG))
                    {
                        checkedListBoxVehicleTypes.SetItemChecked(i, true);
                    }
                }
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
