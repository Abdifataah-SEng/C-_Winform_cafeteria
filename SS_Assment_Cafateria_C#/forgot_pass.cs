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
using SS_Assessment_Cafateria_C_;

namespace SS_Assment_Cafateria_C_
{
    public partial class forgot_pass : Form
    {
        SqlConnection con = new SqlConnection(@"Server=(localdb)\ProjectModels;Database=Cafeteria_management_C_DB; Integrated Security = true;");
        public forgot_pass()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login ln = new login();
            ln.Show();
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from userlogin where username=@Username and email=@Email and fullname=@Fullname", con);
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Fullname", txtFullname.Text);

            SqlDataReader dr = cmd.ExecuteReader();
            try
            {

                if (dr.Read())
                {
                    MessageBox.Show("varified");
                    groupBox2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Invalid username, email or fullname.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }

        private void guna2GradientTileButton2_Click(object sender, EventArgs e)
        {
            if (txtnewpasswor.Text == txtconpassword.Text)
            {


                con.Open();
                SqlCommand cmd = new SqlCommand("Update userlogin set password_hash=@Password from Users where username=@Username", con);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtconpassword.Text);



                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("password reseted");

                    this.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    Dashbourd dashbourd = new Dashbourd();
                    dashbourd.Show();
                    this.Hide();

                }
            }
            else
            {
                MessageBox.Show("Password does not match.");
            }
        }
    }
}
