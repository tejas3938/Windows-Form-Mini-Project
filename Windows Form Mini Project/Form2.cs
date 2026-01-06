using System;
using System.Windows.Forms;

namespace Windows_Form_Mini_Project
{
    public partial class Registration_Successful : Form
    {
        public Registration_Successful()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login_Page form3 = new Login_Page();
            form3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
