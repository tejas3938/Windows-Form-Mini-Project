using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Windows_Form_Mini_Project
{
    public partial class Login_Page : Form
    {
        public Login_Page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username;
            string password;
            username = textBox2.Text;
            password = textBox7.Text;

            using (SqlConnection connection = new SqlConnection("data source= TEJAS\\SQL2025; database = .netSQL;user id = sa; password = 3938"))
            {
                connection.Open();
                string query = "SELECT count(*) FROM wfproject WHERE username=@username AND password=@password";
                
                SqlCommand command = new SqlCommand(query, connection);
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    
                    if (count !=0)
                    {
                        View_Page form4 = new View_Page();
                        form4.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password");
                        textBox2.Clear();
                        textBox7.Clear();
                        textBox7.Focus();
                        return;
                    }
                }
                connection.Close();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Forgot up = new Forgot();
            up.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Registration form1 = new Registration();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
