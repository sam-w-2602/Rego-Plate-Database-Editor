// Samuel Williams, 30119279
// Date: 2025-06-16
// Version: 1.0
// Application: Licence Plate Manager
// Description: A simple Windows Forms application to manage a list of licence plates.
// --------------------------------------------------------------------------------------------------------------------
// PROGRAM FUNCTIONALITIES                                              |   STATUS. BLANK = NOT COMPLETE
// Open text file and load data.                                        |   COMPLETE
// Save data to text file.                                              |   COMPLETE
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
            string plateInput = textBoxInput.Text.ToUpper();

            //check if the text box is empty
            if (string.IsNullOrWhiteSpace(plateInput))
            {
                MessageBox.Show("Please enter a licence plate.");
                return;
            }

            //check if the licence plate already exists
            if (listBoxPlateView.Items.Contains(plateInput))
            {
                MessageBox.Show("This licence plate already exists.");
                return;
            }
            if (taggedPlates.Contains(plateInput))
            {
                MessageBox.Show("This licence plate already exists (already in tagged plates)");
                return;
            }
            licencePlates.Add(plateInput);
            DisplayList();
            textBoxInput.Clear();
            textBoxInput.Focus();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxPlateView.SelectedIndex;
            int selectedTaggedIndex = listBoxTaggedPlates.SelectedIndex;

            // No selection in either list
            if (selectedIndex == -1 && selectedTaggedIndex == -1)
            {
                MessageBox.Show("Please select a plate to delete.");
                return;
            }

            if (selectedIndex != -1)
            {
                // Delete from licencePlates list
                string selectedPlate = listBoxPlateView.SelectedItem.ToString();
                licencePlates.Remove(selectedPlate);
            }
            else if (selectedTaggedIndex != -1)
            {
                // Delete from taggedPlates list (remove "Tagged: " prefix first)
                string selectedWithTag = listBoxTaggedPlates.SelectedItem.ToString();
                const string prefix = "Tagged: ";
                string plate = selectedWithTag.StartsWith(prefix) ? selectedWithTag.Substring(prefix.Length).Trim() : selectedWithTag;

                taggedPlates.Remove(plate);
            }

            DisplayList();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxPlateView.SelectedIndex;
            int selectedTaggedIndex = listBoxTaggedPlates.SelectedIndex;
            string plateInput = textBoxInput.Text.ToUpper();

            if (string.IsNullOrWhiteSpace(plateInput))
            {
                MessageBox.Show("Please enter a valid licence plate.");
                return;
            }
            // Check if a plate is selected
            if (selectedIndex == -1 && selectedTaggedIndex == -1)
            {
                MessageBox.Show("Please select a licence plate to edit.");
                return;
            }

            // Check if the plate already exists in the list
            if (listBoxPlateView.Items.Contains(plateInput) || taggedPlates.Contains(plateInput))
            {
                MessageBox.Show("This licence plate already exists.");
                return;
            }
            // If a plate is selected from the main list
            if (selectedIndex != -1)
            {
                // Update the licence plate in the main list
                licencePlates[selectedIndex] = plateInput;
            }
            // If a plate is selected from the tagged list
            else if (selectedTaggedIndex != -1)
            {
                // Update the licence plate in the tagged list (remove "Tagged: " prefix first)
                string selectedWithTag = listBoxTaggedPlates.SelectedItem.ToString();
                const string prefix = "Tagged: ";
                string oldPlate = selectedWithTag.StartsWith(prefix) ? selectedWithTag.Substring(prefix.Length).Trim() : selectedWithTag;
                // Remove the old plate and add the new one
                taggedPlates.Remove(oldPlate);
                taggedPlates.Add(plateInput);
            }
            textBoxInput.Clear();
            DisplayList();
        }

        private void buttonTag_Click(object sender, EventArgs e)
        {
            // Tag from the main plates list
            if (listBoxPlateView.SelectedIndex != -1)
            {
                string selectedPlate = listBoxPlateView.SelectedItem.ToString();

                if (!taggedPlates.Contains(selectedPlate))
                {
                    taggedPlates.Add(selectedPlate);
                    licencePlates.Remove(selectedPlate);
                    MessageBox.Show($"Licence plate {selectedPlate} has been tagged.");
                }
                else
                {
                    MessageBox.Show($"Licence plate {selectedPlate} is already tagged.");
                }
            }
            // Untag from the tagged plates list
            else if (listBoxTaggedPlates.SelectedIndex != -1)
            {
                string selectedWithTag = listBoxTaggedPlates.SelectedItem.ToString();

                const string prefix = "Tagged: ";
                string selectedPlate = selectedWithTag.StartsWith(prefix)
                                       ? selectedWithTag.Substring(prefix.Length).Trim()
                                       : selectedWithTag;

                if (taggedPlates.Contains(selectedPlate))
                {
                    taggedPlates.Remove(selectedPlate);
                    licencePlates.Add(selectedPlate);
                    MessageBox.Show($"Licence plate {selectedPlate} has been untagged.");
                }
                else
                {
                    MessageBox.Show($"Licence plate {selectedPlate} is not tagged.");
                }
            }
            else
            {
                MessageBox.Show("Please select a licence plate to tag or untag.");
                return;
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
            openFileDialog.Filter = "Day files (day_*.txt)|day_*.txt";
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

        // saves the text file to the location specified by the user
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

        // allows for enter to add a plate rather than having to press add every time
        private void textBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAdd.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        // only allows for 1 item to be selected (unselects item in one box if other box is selected)
        private void listBoxPlateView_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxPlateView.SelectedIndex != -1)
            {
                listBoxTaggedPlates.ClearSelected();
            }
        }

        private void listBoxTaggedPlates_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxTaggedPlates.SelectedIndex != -1)
            {
                listBoxPlateView.ClearSelected();
            }
        }
    }
}
