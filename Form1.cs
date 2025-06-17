// Samuel Williams, 30119279
// Date: 2025-06-16
// Version: 1.0
// Application: Licence Plate Manager
// Description: A simple Windows Forms application to manage a list of licence plates.
// --------------------------------------------------------------------------------------------------------------------
// PROGRAM FUNCTIONALITIES                                              |   STATUS. BLANK = NOT COMPLETE
// Open text file and load data.                                        |   
// Save data to text file.                                              |   
// Add new rego plate.                                                  |   COMPLETE
// Delete an existing rego plate.                                       |   
// Edit or update and existing rego plate.                              |   
// Linear Search for a specific rego plate.                             |   
// Binary Search for a specific rego plate.                             |   
// Tag a specific rego plate for further investigation.                 |   
// A reset button to remove all rego plate data from the List<>.        |   
// ---------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace at3_c_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Create array for licence plates
        private List<string> licencePlates = new List<string>();


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //check if the text box is empty
            if (string.IsNullOrWhiteSpace(textBoxInput.Text))
            {
                MessageBox.Show("Please enter a licence plate.");
                return;
            }

            //check if the licence plate already exists
            if (listBoxPlateView.Items.Contains(textBoxInput.Text))
            {
                MessageBox.Show("This licence plate already exists.");
                return;
            }
            licencePlates.Add(textBoxInput.Text);
            DisplayList();
            textBoxInput.Clear();
            textBoxInput.Focus();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            listBoxPlateView.SetSelected(listBoxPlateView.SelectedIndex, true);
            licencePlates.RemoveAt(listBoxPlateView.SelectedIndex);
            DisplayList();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {

        }

        //common functions
        private void DisplayList()
        {
            listBoxPlateView.Items.Clear();
            foreach (var plate in licencePlates)
            {
                listBoxPlateView.Items.Add(plate);
            }
        }
    }
}
