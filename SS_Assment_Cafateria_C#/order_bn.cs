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
using System.Xml.Linq;
namespace SS_Assment_Cafateria_C_
{
    public partial class order_bn : Form
    {
            SqlConnection con = new SqlConnection(@"Server=(localdb)\ProjectModels;Database=Cafeteria_management_C_DB; Integrated Security = true;");
        public order_bn()
        {
            InitializeComponent();
        }
        void clear()
        {
            txtorder_id.Clear();
            txtemployee_id.Clear();
            btorder_date.Value = DateTime.Now;
            richTextBox1.Clear();
            txtitem_name.Clear();
            txtcategory.Clear();
            txtitem_price.Clear();
            txtquantity.Clear();
            txtunitprice.Clear();
            txtsubtatol.Clear();
            txttotalamount.Clear();
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Orderall WHERE order_id = @order_id", con);
                    cmd.Parameters.AddWithValue("@order_id", txtorder_id.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("delete seccessfuly");
                    clear();
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

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Orderall(employee_id, order_date, notes, item_name, category, item_price, quantity, unit_price, total_amount) VALUES ( @employee_id, @order_date, @notes, @item_name, @category, @item_price, @quantity, @unit_price, @total_amount)", con);
                    
                    cmd.Parameters.AddWithValue("@employee_id", txtemployee_id.Text);
                    cmd.Parameters.AddWithValue("@order_date", btorder_date.Value);
                    cmd.Parameters.AddWithValue("@notes", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@item_name", txtitem_name.Text);
                    cmd.Parameters.AddWithValue("@category", txtcategory.Text);
                    cmd.Parameters.AddWithValue("@item_price", txtitem_price.Text);
                    cmd.Parameters.AddWithValue("@quantity", txtquantity.Text);
                    cmd.Parameters.AddWithValue("@unit_price", txtunitprice.Text);
                    cmd.Parameters.AddWithValue("@total_amount", txttotalamount.Text);

                    cmd.ExecuteNonQuery();
                    clear();
                    MessageBox.Show("save seccessfuly");
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

        private void guna2GradientTileButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if(con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Orderall SET employee_id = @employee_id, order_date = @order_date, notes = @notes, item_name = @item_name, category = @category, item_price = @item_price, quantity = @quantity, unit_price = @unit_price,  total_amount = @total_amount WHERE order_id = @order_id", con);
                    cmd.Parameters.AddWithValue("@employee_id", txtemployee_id.Text);
                    cmd.Parameters.AddWithValue("@order_date", btorder_date.Value);
                    cmd.Parameters.AddWithValue("@notes", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@item_name", txtitem_name.Text);
                    cmd.Parameters.AddWithValue("@category", txtcategory.Text);
                    cmd.Parameters.AddWithValue("@item_price", txtitem_price.Text);
                    cmd.Parameters.AddWithValue("@quantity", txtquantity.Text);
                    cmd.Parameters.AddWithValue("@unit_price", txtunitprice.Text);
                    cmd.Parameters.AddWithValue("@total_amount", txttotalamount.Text);
                    cmd.ExecuteNonQuery();
                    clear();
                    MessageBox.Show("delete seccessfuly");
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

        private void txtorder_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtemployee_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtitem_price_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtitem_name_KeyDown(object sender, KeyEventArgs e)
        {
                       
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtorder_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsubtatol_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientTileButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd = new SqlCommand(" select * from Orderall where  order_id=@order_id", con);

                cmd.Parameters.AddWithValue("@order_id", txtorder_id.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    txtitem_name.Text = dr["item_name"].ToString();
                    txtcategory.Text = dr["category"].ToString();
                    txtitem_price.Text = dr["item_price"].ToString();
                    txtquantity.Text = dr["quantity"].ToString();
                    txtunitprice.Text = dr["unit_price"].ToString();
                    txttotalamount.Text = dr["total_amount"].ToString();
                    richTextBox1.Text = dr["notes"].ToString();
                    txtemployee_id.Text = dr["employee_id"].ToString();
                    txtsubtatol.Text = dr["total_amount"].ToString();
                    
                }

                else
                    MessageBox.Show("no match found");

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
    }
}
