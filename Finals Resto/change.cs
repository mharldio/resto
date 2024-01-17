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
    public partial class change : Form
    {
        public change()
        {
            InitializeComponent();
        }

        public void SetChangeAmount(decimal changeAmount)
        {
            // Display the computed change in guna2TextBox2
            guna2TextBox2.Text = $"Change: {changeAmount:C}";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
