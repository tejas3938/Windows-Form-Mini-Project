using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Windows_Form_Mini_Project
{
    public partial class Forgot_Username : Form
    {
        public Forgot_Username()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("data source = TEJAS\\SQL2025; database = .netSQL; user id = sa; password = 3938"))
            {
                connection.Open();

                string query = "SELECT username FROM wfproject WHERE user_id = @user_id AND first_name = @first_name AND last_name = @last_name AND email_id = @email_id AND phone_no = @phone_no";
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@user_id", textBox1.Text);
                    command.Parameters.AddWithValue("@First_name", textBox2.Text);
                    command.Parameters.AddWithValue("@Last_name", textBox3.Text);
                    command.Parameters.AddWithValue("@Email_id", textBox9.Text);
                    command.Parameters.AddWithValue("@Phone_no", textBox7.Text);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        string username = result.ToString();
                        MessageBox.Show("Your Username is: " + username, "Username Retrieved");

                        Login_Page form3 = new Login_Page();
                        form3.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No matching record found. Please check your Details.", "Error");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox9.Clear();
                        textBox7.Clear();
                    }
                }
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forgot form7 = new Forgot();
            form7.Show();
            this.Hide();
        }
    }
}
