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
    public partial class UserControlClient : UserControl
    {
        private int mEmployeeID;
        private Size mDefaultSize = (Size)new Point(1241, 907);
        private List<Button> mButtons = new List<Button>();
        private List<Rectangle> mInitialRects = new List<Rectangle>();
        bool mValuesStored = false;
        public UserControlClient(int employeeID)
        {
            mEmployeeID = employeeID;
            InitializeComponent();
            StoreInitialSizesAndPositions();
        }

        private void buttonViewClients_Click(object sender, EventArgs e)
        {
            FormDataGridView form = new FormDataGridView(FormDataGridView.TableToLoad.Client);
            form.ShowDialog();
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            FormClientInsert form = new FormClientInsert();
            form.ShowDialog();
        }

        private void UserControlClient_Load(object sender, EventArgs e)
        {
            
        }

        private void UserControlClient_Resize(object sender, EventArgs e)
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
    }
}
