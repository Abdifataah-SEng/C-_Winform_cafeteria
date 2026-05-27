using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS_Assment_Cafateria_C_
{
    public partial class payment : Form
    {
        SqlConnection con = new SqlConnection(@"Server=(localdb)\ProjectModels;Database=Cafeteria_management_C_DB; Integrated Security = true;");
        public payment()
        {
            InitializeComponent();
        }
       void clear()
        {
            txt_py_id.Clear();
            txt_Order_id.Clear();
            txtAmount.Clear();
            cb_py_method.SelectedIndex = -1;
            guna2DateTimePicker1.Value = DateTime.Now;
            cb_status.SelectedIndex = -1;
        }
       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from payment where payment_id=@payment_id", con);
                    cmd.Parameters.AddWithValue("@payment_id", txt_py_id.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("delete seccessfuly");
                    clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void guna2GradientTileButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                if (string.IsNullOrWhiteSpace(txt_py_id.Text))
                {
                    MessageBox.Show("Please enter Payment ID to update.");
                    return;
                }

                decimal amountValue;
                if (!decimal.TryParse(txtAmount.Text, out amountValue))
                {
                    MessageBox.Show("Invalid amount. Please enter a valid number.");
                    return;
                }

                SqlCommand cmd = new SqlCommand("Update payment Set order_id=@order_id, amount=@amount, payment_method=@payment_method, payment_date=@payment_date, status=@status Where payment_id=@payment_id", con);
                cmd.Parameters.AddWithValue("@payment_id", txt_py_id.Text);
                cmd.Parameters.AddWithValue("@order_id", txt_Order_id.Text);
                cmd.Parameters.AddWithValue("@amount", amountValue);
                cmd.Parameters.AddWithValue("@payment_method", cb_py_method.Text);
                cmd.Parameters.AddWithValue("@payment_date", guna2DateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@status", cb_status.Text);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Update successful");
                    clear();
                }
                else
                {
                    MessageBox.Show("No record updated. Please check the Payment ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                // Basic validation
                if (string.IsNullOrWhiteSpace(txt_Order_id.Text))
                {
                    MessageBox.Show("Please enter Order ID.");
                    return;
                }

                decimal amountValue;
                if (!decimal.TryParse(txtAmount.Text, out amountValue))
                {
                    MessageBox.Show("Invalid amount. Please enter a valid number.");
                    return;
                }

                string orderId = txt_Order_id.Text;
                string paymentMethod = cb_py_method.Text;
                string status = cb_status.Text;
                DateTime payDate = guna2DateTimePicker1.Value;

                // If payment_id is empty, assume DB may auto-generate it and don't include it in INSERT
                string query;
                SqlCommand cmd;
                if (string.IsNullOrWhiteSpace(txt_py_id.Text))
                {
                    query = "INSERT INTO payment (order_id, amount, payment_method, payment_date, status) VALUES (@order_id, @amount, @payment_method, @payment_date, @status)";
                    cmd = new SqlCommand(query, con);
                }
                else
                {
                    query = "INSERT INTO payment (payment_id, order_id, amount, payment_method, payment_date, status) VALUES (@payment_id, @order_id, @amount, @payment_method, @payment_date, @status)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@payment_id", txt_py_id.Text);
                }

                cmd.Parameters.AddWithValue("@order_id", orderId);
                cmd.Parameters.AddWithValue("@amount", amountValue);
                cmd.Parameters.AddWithValue("@payment_method", paymentMethod);
                cmd.Parameters.AddWithValue("@payment_date", payDate);
                cmd.Parameters.AddWithValue("@status", status);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Payment added successfully");
                    clear();
                }
                else
                {
                    MessageBox.Show("No rows were inserted. Please check your input and try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientTileButton4_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                if (string.IsNullOrWhiteSpace(txt_py_id.Text))
                {
                    MessageBox.Show("Please enter Payment ID");
                    return;
                }

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from payment where payment_id=@payment_id", con);
                    cmd.Parameters.AddWithValue("@payment_id", txt_py_id.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txt_Order_id.Text = reader["order_id"].ToString();
                        txtAmount.Text = reader["amount"].ToString();
                        cb_py_method.Text = reader["payment_method"].ToString();
                        guna2DateTimePicker1.Value = Convert.ToDateTime(reader["payment_date"]);
                        cb_status.Text = reader["status"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("Payment not found");
                    }
                }
            
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void payment_Load(object sender, EventArgs e)
        {

        }
    }
}
