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

        //
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

            //add the licence plate to the list box
            listBoxPlateView.Items.Add(textBoxInput.Text);
            //clear the text box
            textBoxInput.Clear();
            textBoxInput.Focus();

        }
    }
}
