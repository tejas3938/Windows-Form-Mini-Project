using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Windows_Form_Mini_Project
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string gender = string.Empty;
            string age = string.Empty;
            string country = string.Empty;
            string language = string.Empty;

            using (SqlConnection connection = new SqlConnection("Data Source = TEJAS\\SQL2025; database = .netSQL; user id = sa; password = 3938"))
            {
                string query = "insert into wfproject values(@user_id, @first_name, @last_name, @username, @email_id, @password, @confirm_password, @phone_no, @address, @gender, @age, @language, @country)";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (radioButton1.Checked == true)
                    {
                        gender = radioButton1.Text;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        gender = radioButton2.Text;
                    }

                    if (checkBox1.Checked == true)
                    {
                        language = language + checkBox1.Text + " , ";
                    }

                    if (checkBox2.Checked == true)
                    {
                        language = language + checkBox2.Text + " , ";
                    }

                    if (checkBox3.Checked == true)
                    {
                        language = language + checkBox3.Text + " , ";
                    }

                    if (checkBox4.Checked == true)
                    {
                        language = language + checkBox4.Text + " , ";
                    }

                    if (checkBox5.Checked == true)
                    {
                        language = language + checkBox5.Text + " , ";
                    }

                    if (checkBox6.Checked == true)
                    {
                        language = language + checkBox6.Text + " , ";
                    }

                    if (language.EndsWith(" , "))
                    {
                        int length = language.Length;
                        language = language.Substring(0, length - 2);
                    }

                    if (textBox1.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter User ID");
                        return;
                    }

                    if (textBox2.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter First Name");
                        return;
                    }

                    if (textBox3.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter Last Name");
                        return;
                    }

                    if (textBox4.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter Username");
                        return;
                    }

                    if (textBox9.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter Email ID");
                        return;
                    }

                    if (radioButton1.Checked == false && radioButton2.Checked == false)
                    {
                        MessageBox.Show("Please select one gender");
                        return;
                    }

                    if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false &&
                    checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false)
                    {
                        MessageBox.Show("Please select atleast one language");
                        return;
                    }

                    if (textBox5.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter Password");
                        return;
                    }

                    if (textBox6.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter Confirm Password");
                        return;
                    }

                    if (textBox5.Text != textBox6.Text)
                    {
                        MessageBox.Show("Password not matched");
                        return;
                    }

                    if (comboBox2.Text == string.Empty)
                    {
                        MessageBox.Show("Please select country code");
                        return;
                    }

                    if (textBox7.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter Phone Number");
                        return;
                    }

                    if (textBox8.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter Address");
                        return;
                    }

                    if (comboBox1.Text == string.Empty)
                    {
                        MessageBox.Show("Please select age");
                        return;
                    }

                    if (comboBox3.Text == string.Empty)
                    {
                        MessageBox.Show("Please select country");
                        return;
                    }

                    command.Parameters.AddWithValue("@user_id", textBox1.Text);
                    command.Parameters.AddWithValue("@first_name", textBox2.Text);
                    command.Parameters.AddWithValue("@last_name", textBox3.Text);
                    command.Parameters.AddWithValue("@username", textBox4.Text);
                    command.Parameters.AddWithValue("@email_id", textBox9.Text);
                    command.Parameters.AddWithValue("@password", textBox5.Text);
                    command.Parameters.AddWithValue("@confirm_password", textBox6.Text);
                    command.Parameters.AddWithValue("@phone_no", (comboBox2.Text + " " + textBox7.Text));
                    command.Parameters.AddWithValue("@address", textBox8.Text);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@age", comboBox1.Text);
                    command.Parameters.AddWithValue("@language", language);
                    command.Parameters.AddWithValue("@country", comboBox3.Text);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Registration_Successful form2 = new Registration_Successful();
                        form2.Show();
                        this.Hide();

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox4.Clear();
                        textBox7.Clear();
                        textBox8.Clear();
                        textBox9.Clear();
                        comboBox1.SelectedIndex = -1;
                        comboBox2.SelectedIndex = -1;
                        comboBox3.SelectedIndex = -1;
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;
                        checkBox3.Checked = false;
                        checkBox4.Checked = false;
                        checkBox5.Checked = false;
                        checkBox6.Checked = false;
                    }
                    connection.Close();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Login_Page form3 = new Login_Page();
            form3.Show();
            this.Hide();
        }
    }
}