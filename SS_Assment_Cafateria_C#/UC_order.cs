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
    public partial class UC_order : UserControl
    {

        SqlConnection con = new SqlConnection(@"Server=(localdb)\ProjectModels;Database=Cafeteria_management_C_DB; Integrated Security = true;");
        public UC_order()
        {
            InitializeComponent();
        }
            void loadDGV()
            {
               
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("Select * from Orderall", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    guna2DataGridView1.DataSource = dt;
                    con.Close();
                
        }
        void loadComboBox()
        {
            cboxfilter.Items.Clear();
            cboxfilter.Items.Add("Drink");
            cboxfilter.Items.Add("Food");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            order_bn or = new order_bn();
            or.Show();
            
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // Typed TableAdapter not present in this workspace; refresh via SQL instead
           loadDGV();
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Orderall WHERE order_id LIKE '%" + txtfilter.Text + "%' OR item_name LIKE '%" + txtfilter.Text + "%' OR quantity LIKE '%" + txtfilter.Text + "%'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    guna2DataGridView1.DataSource = dt;
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

        private void UC_order_Load(object sender, EventArgs e)
        {
            loadDGV();
            loadComboBox();
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Orderall WHERE category = @category", con);
                da.SelectCommand.Parameters.AddWithValue("@category", selectedMethod);
                DataTable dt = new DataTable();
                da.Fill(dt);
                guna2DataGridView1.DataSource = dt;




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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderVRP ov = new OrderVRP();
            ov.ShowDialog();
        }
    }
}
