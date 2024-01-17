using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals_Resto
{
    public partial class quantity : Form
    {
        private Form1 mainForm; // Reference to the main form
        private string labelTextFromPanel;

        public quantity(Form1 mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;

            btn.Click += BtnExitQuantity_Click;
            guna2Button1.Click += BtnAddToForm1_Click;
        }

        public void ShowDialog(string labelText)
        {
            labelTextFromPanel = labelText;
           
            base.ShowDialog();
        }

        private void BtnExitQuantity_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void BtnAddToForm1_Click(object sender, EventArgs e)
        {
            string quantityValue = textBox1.Text;
            string priceValue = textBox2.Text;

            // Validate that quantity and price are not empty
            if (string.IsNullOrEmpty(quantityValue) || string.IsNullOrEmpty(priceValue))
            {
                MessageBox.Show("Please enter both quantity and price.");
                return;
            }

            // Add the values to the DataGridView in the main form along with the label text
            mainForm.AddToDataGridView(quantityValue, priceValue, labelTextFromPanel);

            // Close the quantity form
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void quantity_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {

        }
    }
}