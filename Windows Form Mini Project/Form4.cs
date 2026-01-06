using System;
using System.Windows.Forms;

namespace Windows_Form_Mini_Project
{
    public partial class View_Page : Form
    {
        public View_Page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Grid_View form5 = new Grid_View();
            form5.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
