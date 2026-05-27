using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SS_Assment_Cafateria_C_
{
    public partial class UC_salary : UserControl
    {
        SqlConnection con = new SqlConnection(@"Server=(localdb)\ProjectModels;Database=Cafeteria_management_C_DB; Integrated Security = true;");
        public UC_salary()
        {
            InitializeComponent();
        }
        void loadDGV()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from salary",con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Salary sl = new Salary();
            sl.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Refresh using SQL data adapter when typed TableAdapter is not available
            loadDGV();
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM salary WHERE salary_id LIKE '%" + txtfilter.Text + "%'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void UC_salary_Load(object sender, EventArgs e)
        {
            loadDGV();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SlaryVRP sv = new SlaryVRP();
            sv.ShowDialog();
        }
    }
}
