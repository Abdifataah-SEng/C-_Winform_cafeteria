using Guna.UI2.WinForms;
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
    public partial class UC_payment : UserControl
    {
        SqlConnection con = new SqlConnection(@"Server=(localdb)\ProjectModels;Database=Cafeteria_management_C_DB; Integrated Security = true;");

        
        public UC_payment()
        {
            InitializeComponent();
        }
        void loadDGV()
        {

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from payment", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        void loadComboBox()
        {
            cboxfilter.Items.Clear();
            cboxfilter.Items.Add("cash");
            cboxfilter.Items.Add("card");
            cboxfilter.Items.Add("mobile");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            payment py = new payment();
            py.Show();

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                string selectedMethod = cboxfilter.SelectedItem.ToString();
                SqlDataAdapter da = new SqlDataAdapter("Select * from payment where Payment_method = @method", con);
                da.SelectCommand.Parameters.AddWithValue("@method", selectedMethod);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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

        private void button2_Click(object sender, EventArgs e)
        {
            // Typed TableAdapter not available in this workspace; use loadDGV to refresh
            loadDGV();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_payment_Load(object sender, EventArgs e)
        {
            loadDGV();
            loadComboBox();
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
               if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("Select * from payment where payment_id like '%" + txtfilter.Text + "%'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            pymentVRP pv = new pymentVRP();
            pv.ShowDialog();
        }
    }
}
