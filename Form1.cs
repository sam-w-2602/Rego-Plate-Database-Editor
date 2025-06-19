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
// Delete an existing rego plate.                                       |   COMPLETE
// Edit or update and existing rego plate.                              |   COMPLETE
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
using System.IO;
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
        private List<string> taggedPlates = new List<string>();
        string currentFileName = "";


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

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            licencePlates[listBoxPlateView.SelectedIndex] = textBoxInput.Text;
            textBoxInput.Clear();
            DisplayList();
        }

        private void buttonTag_Click(object sender, EventArgs e)
        {
            listBoxPlateView.SetSelected(listBoxPlateView.SelectedIndex, true);
            string selectedPlate = listBoxPlateView.SelectedItem.ToString();
            if (!taggedPlates.Contains(selectedPlate))
            {
                taggedPlates.Add(selectedPlate);
                MessageBox.Show($"Licence plate {selectedPlate} has been tagged for further investigation.");
            }
            else
            {
                MessageBox.Show($"Licence plate {selectedPlate} is already tagged.");
            }
            DisplayList();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string listsFolder = Path.Combine(Application.StartupPath, "lists");

            // Ensure the folder exists
            if (!Directory.Exists(listsFolder))
            {
                Directory.CreateDirectory(listsFolder);
            }

            SaveFileDialog saveTextFileDialog = new SaveFileDialog();
            saveTextFileDialog.InitialDirectory = listsFolder;
            saveTextFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveTextFileDialog.Title = "Save your text file";

            DialogResult sr = saveTextFileDialog.ShowDialog();
            if (sr == DialogResult.OK)
            {
                SaveTextFile(saveTextFileDialog.FileName);
            }
        }


        //common functions
        private void DisplayList()
        {
            listBoxPlateView.Items.Clear();
            listBoxTaggedPlates.Items.Clear();
            foreach (var plate in licencePlates)
            {
                if (!taggedPlates.Contains(plate))
                {
                    listBoxPlateView.Items.Add(plate);
                }
            }
            foreach (var taggedPlate in taggedPlates)
            {
                listBoxTaggedPlates.Items.Add($"Tagged: {taggedPlate}");
            }
        }

        private void SaveTextFile(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    foreach (var plate in licencePlates)
                    {
                        writer.WriteLine(plate);
                    }
                    foreach (var taggedPlate in taggedPlates)
                    {
                        writer.WriteLine($"Tagged: {taggedPlate}");
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("File NOT saved");
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            string listsFolder = Path.Combine(Application.StartupPath, "lists");

            // Ensure the folder exists
            if (!Directory.Exists(listsFolder))
            {
                Directory.CreateDirectory(listsFolder);
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = listsFolder;
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.Title = "Select a list file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Clear current lists
                    licencePlates.Clear();
                    taggedPlates.Clear();

                    // Read and parse file
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        if (line.StartsWith("Tagged: "))
                        {
                            string plate = line.Substring(8).Trim();
                            taggedPlates.Add(plate);
                        }
                        else if (!string.IsNullOrWhiteSpace(line))
                        {
                            licencePlates.Add(line.Trim());
                        }
                    }
                    DisplayList();
                    MessageBox.Show("File loaded successfully.", "Open", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to read file: " + ex.Message);
                }
            }
        }
    }
}
