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

namespace SS_Assessment_Cafateria_C_
{
    
    public partial class employee : Form
    {
        SqlConnection con = new SqlConnection(@"Server=(localdb)\ProjectModels;Database=Cafeteria_management_C_DB; Integrated Security = true;");
        public employee()
        {
            InitializeComponent();
        }
        void clear()
        {
            txtEmp_id.Clear();
            txtUserlg_id.Clear();
            txtFname.Clear();
            txtLname.Clear();
            
            guna2DateTimePicker1.Value = DateTime.Now;
            txtemail.Clear();
            txtPhone.Clear();
            txtHourly.Clear();
            txtM_Salary.Clear();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
              try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO employees(userlogin_id, first_name, last_name, position, hire_date, email, phone, hourly_rate, monthly_salary) VALUES (@userlogin_id, @first_name, @last_name, @position, @hire_date, @email, @phone, @hourly_rate, @monthly_salary)", con))
                {
                    cmd.Parameters.AddWithValue("@userlogin_id", txtUserlg_id.Text);
                    cmd.Parameters.AddWithValue("@first_name", txtFname.Text);
                    cmd.Parameters.AddWithValue("@last_name", txtLname.Text);
                    cmd.Parameters.AddWithValue("@position", cbox_position.Text);
                    cmd.Parameters.AddWithValue("@hire_date", guna2DateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@hourly_rate", txtHourly.Text);
                    cmd.Parameters.AddWithValue("@monthly_salary", txtM_Salary.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Save successfully");
                }

                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
                    con.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE employees SET userlogin_id=@userlogin_id, first_name=@first_name, last_name=@last_name, position=@position, hire_date=@hire_date, email=@email, phone=@phone, hourly_rate=@hourly_rate, monthly_salary=@monthly_salary WHERE employee_id=@employee_id", con))
                {
                    cmd.Parameters.AddWithValue("@employee_id", txtEmp_id.Text);
                    cmd.Parameters.AddWithValue("@userlogin_id", txtUserlg_id.Text);
                    cmd.Parameters.AddWithValue("@first_name", txtFname.Text);
                    cmd.Parameters.AddWithValue("@last_name", txtLname.Text);
                    cmd.Parameters.AddWithValue("@position", cbox_position.Text);
                    cmd.Parameters.AddWithValue("@hire_date", guna2DateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@hourly_rate", txtHourly.Text);
                    cmd.Parameters.AddWithValue("@monthly_salary", txtM_Salary.Text);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Employee updated successfully");
                    else
                        MessageBox.Show("No matching employee found to update.");
                }

                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM employees WHERE employee_id=@employee_id", con))
                {
                    cmd.Parameters.AddWithValue("@employee_id", txtEmp_id.Text);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Employee deleted successfully");
                    else
                        MessageBox.Show("No matching employee found to delete.");
                }

                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void guna2GradientTileButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM employees WHERE employee_id=@employee_id", con);
                    cmd.Parameters.AddWithValue("@employee_id", txtEmp_id.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtUserlg_id.Text = reader["userlogin_id"].ToString();
                        txtFname.Text = reader["first_name"].ToString();
                        txtLname.Text = reader["last_name"].ToString();
                        cbox_position.Text = reader["position"].ToString();
                        
                        txtemail.Text = reader["email"].ToString();
                        txtPhone.Text = reader["phone"].ToString();
                        txtHourly.Text = reader["hourly_rate"].ToString();
                        txtM_Salary.Text = reader["monthly_salary"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No employee found with the given ID.");
                    }

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
    }
}
