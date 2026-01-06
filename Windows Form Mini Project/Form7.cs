using System;
using System.Windows.Forms;

namespace Windows_Form_Mini_Project
{
    public partial class Forgot : Form
    {
        public Forgot()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Forgot_Username form8 = new Forgot_Username();
            form8.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Forgot_Password form9 = new Forgot_Password();
            form9.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login_Page form3 = new Login_Page();
            form3.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
    }
}
