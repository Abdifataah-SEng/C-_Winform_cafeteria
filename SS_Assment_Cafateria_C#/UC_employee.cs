using Guna.UI2.WinForms;
using SS_Assessment_Cafateria_C_;
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

namespace SS_Assment_Cafateria_C_
{
    public partial class UC_employee : UserControl
    {
            SqlConnection con = new SqlConnection(@"Server=(localdb)\ProjectModels;Database=Cafeteria_management_C_DB; Integrated Security = true;");
            
            
            
            void loadDGV()
            {

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from employees", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
        
        public UC_employee()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UC_employee_Load(object sender, EventArgs e)
        {
           loadDGV();
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT  employee_id, first_name, last_name, position FROM employees WHERE first_name LIKE @filter OR last_name LIKE @filter", con);
                    cmd.Parameters.AddWithValue("@filter", "%" + txtfilter.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("error: " + ex.Message);
            }
            finally
            {
                                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadDGV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            employee em = new employee();
            em.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeVRPcs vp = new EmployeeVRPcs();
            vp.ShowDialog();
        }
    }
}
