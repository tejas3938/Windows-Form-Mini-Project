using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Windows_Form_Mini_Project
{
    public partial class Grid_View : Form
    {
        public Grid_View()
        {
            InitializeComponent();
        }

        private void Grid_View_Load(object sender, EventArgs e)
        {
            //TODO: This line of code loads data into the '___netSQLDataSet.wfproject' table.You can move, or remove it, as needed.
            this.wfprojectTableAdapter.Fill(this.___netSQLDataSet.wfproject);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source = TEJAS\\SQL2025; database = .netSQL; user id = sa; password = 3938"))
            {
                string query = "select*from wfproject";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable  dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {


            Alignment_Page form6 = new Alignment_Page();
            form6.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
