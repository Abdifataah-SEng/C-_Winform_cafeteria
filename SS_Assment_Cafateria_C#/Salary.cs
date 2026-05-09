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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2GradientTileButton4_Click(object sender, EventArgs e)
        {
            try
            {
                //if (con.State != ConnectionState.Open)
                //    con.Open();
                //SqlCommand cmd = new SqlCommand(" select * from Salary where  SalesID=@SalesID", con);

                //cmd.Parameters.AddWithValue("@SalesID", txt.Text);
                //SqlDataReader dr = cmd.ExecuteReader();
                //if (dr.Read())
                //{

                //    txtname.Text = dr[1].ToString();       // Name
                //    txtquantity.Text = dr[2].ToString();     // Designation
                //    txtprice.Text = dr[3].ToString();      // Phone

                //    txtdate.Value = Convert.ToDateTime(dr[4]); // DateOfBirth




                //}

                //else
                //    MessageBox.Show("no match found");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            finally
            {
                //con.Close();
            }
        }
    }
}
