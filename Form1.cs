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
// Tag a specific rego plate for further investigation.                 |   COMPLETE
// A reset button to remove all rego plate data from the List<>.        |   COMPLETE
// ---------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        private bool isModified = false;

        #region Add Delete Edit functions
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string plateInput = textBoxInput.Text.ToUpper();

            //check if the text box is empty
            if (string.IsNullOrWhiteSpace(plateInput))
            {
                toolStripStatusLabel1.Text = "Please enter a valid licence plate";
                return;
            }

            //check if the licence plate already exists
            if (listBoxPlateView.Items.Contains(plateInput))
            {
                toolStripStatusLabel1.Text = "This licence plate already exists.";
                return;
            }
            if (taggedPlates.Contains(plateInput))
            {
                toolStripStatusLabel1.Text = "This licence plate already exists (already in tagged plates)";
                return;
            }
            licencePlates.Add(plateInput);
            toolStripStatusLabel1.Text = $"Licence plate '{plateInput}' has been added to the main list.";
            DisplayList();
            textBoxInput.Clear();
            textBoxInput.Focus();
            isModified = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxPlateView.SelectedIndex;
            int selectedTaggedIndex = listBoxTaggedPlates.SelectedIndex;

            // No selection in either list
            if (selectedIndex == -1 && selectedTaggedIndex == -1)
            {
                toolStripStatusLabel1.Text = "Please select a plate to delete.";
                return;
            }

            string selectedPlate = null;

            if (selectedIndex != -1)
            {
                selectedPlate = listBoxPlateView.SelectedItem.ToString();
            }
            else if (selectedTaggedIndex != -1)
            {
                string selectedWithTag = listBoxTaggedPlates.SelectedItem.ToString();
                const string prefix = "Tagged: ";
                selectedPlate = selectedWithTag.StartsWith(prefix)
                    ? selectedWithTag.Substring(prefix.Length).Trim()
                    : selectedWithTag;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete the licence plate '{selectedPlate}'?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                toolStripStatusLabel1.Text = "Deletion cancelled.";
                return;
            }

            // Proceed with deletion
            if (selectedIndex != -1)
            {
                licencePlates.Remove(selectedPlate);
                toolStripStatusLabel1.Text = $"Licence plate '{selectedPlate}' has been deleted from the main list.";
            }
            else if (selectedTaggedIndex != -1)
            {
                taggedPlates.Remove(selectedPlate);
                toolStripStatusLabel1.Text = $"Licence plate '{selectedPlate}' has been deleted from the tagged list.";
            }

            isModified = true;
            textBoxInput.Clear();
            DisplayList();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxPlateView.SelectedIndex;
            int selectedTaggedIndex = listBoxTaggedPlates.SelectedIndex;
            string plateInput = textBoxInput.Text.ToUpper();

            if (string.IsNullOrWhiteSpace(plateInput))
            {
                toolStripStatusLabel1.Text = "Please enter a valid licence plate.";
                return;
            }
            // Check if a plate is selected
            if (selectedIndex == -1 && selectedTaggedIndex == -1)
            {
                toolStripStatusLabel1.Text = "Please select a licence plate to edit.";
                return;
            }

            // Check if the plate already exists in the list
            if (listBoxPlateView.Items.Contains(plateInput) || taggedPlates.Contains(plateInput))
            {
                toolStripStatusLabel1.Text = "This licence plate already exists.";
                return;
            }
            // If a plate is selected from the main list
            if (selectedIndex != -1)
            {
                // Update the licence plate in the main list
                licencePlates[selectedIndex] = plateInput;
                toolStripStatusLabel1.Text = $"Licence plate at index {selectedIndex} has been updated to '{plateInput}' in the main list.";
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
                toolStripStatusLabel1.Text = $"Licence plate '{oldPlate}' has been updated to '{plateInput}' in the tagged list.";
            }
            textBoxInput.Clear();
            isModified = true;
            DisplayList();
        }

        #endregion add delete edit functions

        #region Tag and reset functions
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
                    toolStripStatusLabel1.Text = $"Licence plate {selectedPlate} has been tagged.";
                }
                else
                {
                    toolStripStatusLabel1.Text = $"Licence plate {selectedPlate} is already tagged.";
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
                    toolStripStatusLabel1.Text = $"Licence plate {selectedPlate} has been untagged.";
                }
                else
                {
                    toolStripStatusLabel1.Text = $"Licence plate {selectedPlate} is not tagged.";
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Please select a licence plate to tag or untag.";
                return;
            }

            isModified = true;
            DisplayList();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            // Show confirmation dialog
            DialogResult result = MessageBox.Show(
                "Are you sure you want to reset all licence plates?",
                "Confirm Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // clear arrays
                licencePlates.Clear();
                taggedPlates.Clear();

                //clear list boxes
                listBoxPlateView.Items.Clear();
                listBoxTaggedPlates.Items.Clear();

                //clear input box
                textBoxInput.Clear();
                textBoxInput.Focus();

                DisplayList();
                isModified = true;
            }
            else
            {
                toolStripStatusLabel1.Text = "Reset cancelled.";
            }
        }
        #endregion Tag and reset functions

        #region File Operations
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

        // opens a text file and reads the contents into the list boxes
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
                    string fileName = Path.GetFileName(filePath);
                    toolStripStatusLabel1.Text = $"File '{fileName}' loaded successfully.";
                    isModified = false;
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.Text = "Failed to read file: " + ex.Message;
                }
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
                toolStripStatusLabel1.Text = "File NOT saved";
            }

            isModified = false; // Reset modified flag after saving
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isModified)
            {
                return; // No unsaved changes, just close the form
            }

            // Prompt user to save changes if there are any unsaved changes
            DialogResult result = MessageBox.Show(
                "Do you want to save changes before exiting?",
                "Confirm Save",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            // If user chooses to cancel, prevent the form from closing
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true; // Cancel closing if user chooses to cancel
                return;
            }
            // If user chooses not to save, just close the form
            else if (result == DialogResult.No)
            {
                return;
            }

            // executed if usesr chooses to save

            // Ensure the folder exists
            string folderPath = Path.Combine(Application.StartupPath, "lists");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Generate a unique file name
            int fileNumber = 1;
            string fileName;
            string filePath;

            do
            {
                fileName = $"day_{fileNumber:D2}.txt";
                filePath = Path.Combine(folderPath, fileName);
                fileNumber++;
            } while (File.Exists(filePath));

            //write data
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (string plate in licencePlates)
                {
                    writer.WriteLine(plate);
                }
                foreach (string taggedPlate in taggedPlates)
                {
                    writer.WriteLine($"Tagged: {taggedPlate}");
                }
            }
            // Notify user of successful save, close once user clicks ok
            toolStripStatusLabel1.Text = $"Data saved to {fileName} successfully.";
        }
        #endregion File Operations

        #region Display and Utility Methods

        private void DisplayList()
        {
            listBoxPlateView.Items.Clear();
            listBoxTaggedPlates.Items.Clear();
            licencePlates.Sort();
            taggedPlates.Sort();

            foreach (var plate in licencePlates.OrderBy(p => p.ToUpper()))
            {
                if (!taggedPlates.Contains(plate))
                {
                    listBoxPlateView.Items.Add(plate);
                }
            }
            foreach (var taggedPlate in taggedPlates.OrderBy(p => p.ToUpper()))
            {
                listBoxTaggedPlates.Items.Add($"Tagged: {taggedPlate}");
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

        #endregion Display and Utility Methods

        #region Search Functions
        private void buttonBinarySearch_Click(object sender, EventArgs e)
        {
            string target = textBoxInput.Text.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(target))
            {
                toolStripStatusLabel1.Text = "Please enter a licence plate to search for.";
                return;
            }

            // Ensure list is sorted before binary search
            licencePlates.Sort(StringComparer.OrdinalIgnoreCase);
            taggedPlates.Sort(StringComparer.OrdinalIgnoreCase);

            // Perform binary search on main list
            int index = licencePlates.BinarySearch(target, StringComparer.OrdinalIgnoreCase);
            if (index >= 0)
            {
                listBoxPlateView.SelectedIndex = index;
                listBoxTaggedPlates.ClearSelected();
                toolStripStatusLabel1.Text = $"'{target}' found in main list at index {index} (Binary Algorithm).";
                return;
            }

            int taggedIndex = taggedPlates.BinarySearch(target, StringComparer.OrdinalIgnoreCase);
            if (taggedIndex >= 0)
            {
                // Build the displayed version (with prefix)
                string displayTagged = "Tagged: " + taggedPlates[taggedIndex];

                // Find the correct index in the ListBox
                int listBoxIndex = listBoxTaggedPlates.Items.IndexOf(displayTagged);
                if (listBoxIndex != -1)
                {
                    listBoxTaggedPlates.SelectedIndex = listBoxIndex;
                    listBoxPlateView.ClearSelected();
                    toolStripStatusLabel1.Text = $"'{target}' found in tagged list at index {taggedIndex} (Binary Algorithm).";
                    return;
                }
            }
            else
            {
                toolStripStatusLabel1.Text = $"'{target}' not found in main list (Binary Algorithm).";
            }
            textBoxInput.Clear();
            textBoxInput.Focus();
        }

        private void buttonLinearSearch_Click(object sender, EventArgs e)
        {
            string target = textBoxInput.Text.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(target))
            {
                toolStripStatusLabel1.Text = "Please enter a licence plate to search for.";
                return;
            }

            // Search in the main list
            for (int i = 0; i < licencePlates.Count; i++)
            {
                if (licencePlates[i].Equals(target, StringComparison.OrdinalIgnoreCase))
                {
                    listBoxPlateView.SelectedIndex = i;
                    listBoxTaggedPlates.ClearSelected(); // Deselect other box
                    toolStripStatusLabel1.Text = $"'{target}' found in main list at index {i} (Linear algorithm).";
                    return;
                }
            }

            // Search in the tagged list
            for (int i = 0; i < taggedPlates.Count; i++)
            {
                if (taggedPlates[i].Equals(target, StringComparison.OrdinalIgnoreCase))
                {
                    // Build the displayed version (with prefix)
                    string displayTagged = "Tagged: " + taggedPlates[i];

                    // Find the correct index in the ListBox
                    int listBoxIndex = listBoxTaggedPlates.Items.IndexOf(displayTagged);

                    if (listBoxIndex != -1)
                    {
                        listBoxTaggedPlates.SelectedIndex = listBoxIndex;
                        listBoxPlateView.ClearSelected(); // Deselect main list
                        toolStripStatusLabel1.Text = $"'{target}' found in tagged list at index {i}. (Linear algorithm)";
                    }
                    return;
                }
            }
            // If not found in either list
            toolStripStatusLabel1.Text = $"'{target}' not found in any list. (Linear algorithm)";
            textBoxInput.Clear();
            textBoxInput.Focus();
        }

        #endregion Search Functions

        #region ListBox Event functions
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

        //double click functions
        private void listBoxPlateView_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxPlateView.SelectedIndex == -1)
                return; // No selection

            string selectedPlate = listBoxPlateView.SelectedItem.ToString();

            // Show confirmation dialog
            DialogResult result = MessageBox.Show(
                $"Do you want to remove licence plate '{selectedPlate}'?",
                "Confirm Removal",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                // Remove from licencePlates list
                licencePlates.Remove(selectedPlate);

                // If the input TextBox has the same text, clear it
                if (textBoxInput.Text.Trim().Equals(selectedPlate, StringComparison.OrdinalIgnoreCase))
                {
                    textBoxInput.Clear();
                }

                toolStripStatusLabel1.Text = $"Licence plate '{selectedPlate}' has been removed from the main list.";
                // Refresh both list boxes
                DisplayList();
            }
        }

        private void listBoxTaggedPlates_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxTaggedPlates.SelectedIndex == -1)
                return; // No plate selected

            string selectedWithPrefix = listBoxTaggedPlates.SelectedItem.ToString();

            // Remove "Tagged: " prefix
            const string prefix = "Tagged: ";
            string selectedPlate = selectedWithPrefix.StartsWith(prefix)
                ? selectedWithPrefix.Substring(prefix.Length).Trim()
                : selectedWithPrefix;

            // Confirm untag
            DialogResult result = MessageBox.Show(
                $"Do you want to untag licence plate '{selectedPlate}'?",
                "Confirm Untag",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                // Remove from tagged list
                taggedPlates.Remove(selectedPlate);

                // Add back to main list if it's not already there
                if (!licencePlates.Contains(selectedPlate))
                {
                    licencePlates.Add(selectedPlate);
                }

                // Clear input if it matches
                if (textBoxInput.Text.Trim().Equals(selectedPlate, StringComparison.OrdinalIgnoreCase))
                {
                    textBoxInput.Clear();
                }

                toolStripStatusLabel1.Text = $"Licence plate '{selectedPlate}' has been untagged and returned to the main list.";

                // Refresh both lists
                DisplayList();
                isModified = true; // Mark as modified
            }
        }

        // load selected plate into input box when selected in list boxes
        private void listBoxPlateView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPlateView.SelectedIndex != -1)
            {
                string selectedPlate = listBoxPlateView.SelectedItem.ToString();
                textBoxInput.Text = selectedPlate;
                textBoxInput.Focus();
                textBoxInput.SelectAll();
            }
        }

        private void listBoxTaggedPlates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTaggedPlates.SelectedIndex != -1)
            {
                string selectedWithPrefix = listBoxTaggedPlates.SelectedItem.ToString();
                const string prefix = "Tagged: ";
                string plate = selectedWithPrefix.StartsWith(prefix)
                    ? selectedWithPrefix.Substring(prefix.Length).Trim()
                    : selectedWithPrefix;

                textBoxInput.Text = plate;
                textBoxInput.Focus();
                textBoxInput.SelectAll();
            }
        }

        #endregion ListBox Event functions
    }
}