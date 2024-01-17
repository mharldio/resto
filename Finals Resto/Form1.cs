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
    public partial class Form1 : Form
    {
        private quantity quantityForm;
        public Form1()
        {
            InitializeComponent();
            quantityForm = new quantity(this);

            // Attach the same event handler to all the panels
            foreach (Control control in Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2Panel panel)
                {
                    panel.Click += Panel_Click;
                }
            }

            // Attach the MouseDown event to the DataGridView
            dataGridView1.MouseDown += DataGridView1_MouseDown;
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            // Get the label text from the clicked panel
            if (sender is Guna.UI2.WinForms.Guna2Panel clickedPanel)
            {
                string labelText = clickedPanel.Controls.Count > 0 && clickedPanel.Controls[0] is Label label ? label.Text : string.Empty;

                // Show the quantityForm and pass the label text
                quantityForm.ShowDialog(labelText);
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void AddToDataGridView(string quantityValue, string priceValue, string labelText)
        {
            decimal quantityDecimal = decimal.TryParse(quantityValue, out decimal quantity) ? quantity : 0;
            decimal priceDecimal = decimal.TryParse(priceValue, out decimal price) ? price : 0;
            decimal subtotal = quantityDecimal * priceDecimal;

            dataGridView1.Rows.Add(labelText, quantityValue, priceValue, subtotal);

            ComputeTotalAmount();

        }

        private void ComputeTotalAmount()
        {
            // Assuming the subtotal column index is 3, adjust it based on your actual DataGridView setup
            int subtotalColumnIndex = 3;

            decimal totalAmount = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Sum(row => row.Cells[subtotalColumnIndex].Value as decimal? ?? 0);

            // Display the total amount payable in label2
            label2.Text =$"Total:   {totalAmount:C}";
        }

        private void DataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the right mouse button is clicked
            if (e.Button == MouseButtons.Right)
            {
                // Get the clicked row
                DataGridView.HitTestInfo hitTest = dataGridView1.HitTest(e.X, e.Y);

                if (hitTest.Type == DataGridViewHitTestType.Cell)
                {
                    int rowIndex = hitTest.RowIndex;

                    // Remove the row from the DataGridView after confirmation
                    if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
                    {
                        DialogResult result = MessageBox.Show("Remove item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            dataGridView1.Rows.RemoveAt(rowIndex);
                            ComputeTotalAmount(); // Update total amount after removal
                        }
                    }
                }
            }
        }



        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to reset all items?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear all rows from the DataGridView
                dataGridView1.Rows.Clear();

                // Update the total amount payable label
                ComputeTotalAmount();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Accept_Payment acceptPaymentForm = new Accept_Payment();

            acceptPaymentForm.TotalAmount = GetTotalAmount();

            acceptPaymentForm.ShowDialog();
        }

        private decimal GetTotalAmount()
{
    // Assuming the total amount is stored in label2 as currency text
    string totalAmountText = label2.Text.Replace("Total:", "").Trim();
    decimal totalAmount;
    
    // Parse the total amount from the label text
    if (decimal.TryParse(totalAmountText, System.Globalization.NumberStyles.Currency, null, out totalAmount))
    {
        return totalAmount;
    }
    
    return 0;
    }

    }
}