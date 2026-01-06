using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Windows_Form_Mini_Project
{
    public partial class Alignment_Page : Form
    {
        public Alignment_Page()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Left;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Right;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Red;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Green;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Blue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
