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
    public partial class Accept_Payment : Form
    {
        public decimal TotalAmount { get; set; }

        public Accept_Payment()
        {
            InitializeComponent();
        }

        private void Accept_Payment_Load(object sender, EventArgs e)
        {
             guna2TextBox2.Text = $"Total: {TotalAmount:C}";
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            // Close the Accept_Payment form unconditionally
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(guna2TextBox1.Text, out decimal paidAmount))
            {
                // Check if the paid amount is less than the total amount
                if (paidAmount < TotalAmount)
                {
                    MessageBox.Show("Error: Paid amount is less than the total amount payable. Please enter a sufficient amount.");
                    return;
                }

                // Compute the change
                decimal changeAmount = paidAmount - TotalAmount;

                // Display the change in the change form
                change changeForm = new change();
                changeForm.SetChangeAmount(changeAmount);
                changeForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid numeric value in the amount received field.");
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

