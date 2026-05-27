using Bunifu.UI.WinForms.Helpers.Transitions;
using SS_Assessment_Cafateria_C_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS_Assment_Cafateria_C_
{
    public partial class login : Form
    {

        SqlConnection con = new SqlConnection(@"Server=(localdb)\ProjectModels;Database=Cafeteria_management_C_DB; Integrated Security = true;");
        public login()
        {
            InitializeComponent();
        }
        
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgot_pass forgot = new forgot_pass();
            forgot.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from userlogin where username=@user and password_hash=@pass", con);
                cmd.Parameters.AddWithValue("@user", txtname.Text);
                cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Dashbourd dash1 = new Dashbourd();
                    dash1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect");
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           txtpass.UseSystemPasswordChar = !cboxshow.Checked;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = true;
        }
    }
}
