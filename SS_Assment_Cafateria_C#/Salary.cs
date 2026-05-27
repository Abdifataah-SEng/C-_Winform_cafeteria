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
using System.Xml.Linq;

namespace SS_Assment_Cafateria_C_
{
    public partial class Salary : Form
    {
        SqlConnection con = new SqlConnection(@"Server=(localdb)\ProjectModels;Database=Cafeteria_management_C_DB; Integrated Security = true;");
       
        public Salary()
        {
            InitializeComponent();
        }
        void clear()
        {
            txtID.Clear();
            txtEmp_id.Clear();
            txtBase_sl.Clear();
            txtBonuses.Clear();
            txtDesd.Clear();
            txtnote.Clear();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2GradientTileButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please enter a valid Salary ID.");
                    
                }
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Salary where salary_id=@salary_id", con);
                    cmd.Parameters.AddWithValue("@salary_id", txtID.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtEmp_id.Text = reader["employee_id"].ToString();
                        guna2DateTimePicker1.Value = Convert.ToDateTime(reader["salary_month"]);
                        txtBase_sl.Text = reader["base_salary"].ToString();
                        txtBonuses.Text = reader["bonuses"].ToString();
                        txtDesd.Text = reader["deductions"].ToString();
                        guna2DateTimePicker2.Value = Convert.ToDateTime(reader["payment_date"]);
                        txtnote.Text = reader["notes"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Salary record not found.");
                    }
                }
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

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Salary(employee_id , salary_month, base_salary, bonuses, deductions, payment_date, notes) VALUES (@employee_id , @salary_month, @base_salary, @bonuses, @deductions, @payment_date, @notes)", con);
                    
                    cmd.Parameters.AddWithValue("@employee_id", txtEmp_id.Text);
                    cmd.Parameters.AddWithValue("@salary_month", guna2DateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@base_salary", txtBase_sl.Text);
                    cmd.Parameters.AddWithValue("@bonuses", txtBonuses.Text);
                    cmd.Parameters.AddWithValue("@deductions", txtDesd.Text);
                    cmd.Parameters.AddWithValue("@payment_date", guna2DateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@notes", txtnote.Text);
                    
                    clear();

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Salary record added successfully.");
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
                    SqlCommand cmd = new SqlCommand("Update Salary set employee_id=@employee_id, salary_month=@salary_month, base_salary=@base_salary, bonuses=@bonuses, deductions=@deductions, payment_date=@payment_date, notes=@notes where salary_id=@salary_id", con);
                    cmd.Parameters.AddWithValue("@salary_id", txtID.Text);
                    cmd.Parameters.AddWithValue("@employee_id", txtEmp_id.Text);
                    cmd.Parameters.AddWithValue("@salary_month", guna2DateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@base_salary", txtBase_sl.Text);
                    cmd.Parameters.AddWithValue("@bonuses", txtBonuses.Text);
                    cmd.Parameters.AddWithValue("@deductions", txtDesd.Text);
                    cmd.Parameters.AddWithValue("@payment_date", guna2DateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@notes", txtnote.Text);
                    
                    clear();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Salary record updated successfully.");
                }
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
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Salary where salary_id=@salary_id", con);
                    cmd.Parameters.AddWithValue("@salary_id", txtID.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Salary record deleted successfully.");
                    
                    clear();
                }
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

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmp_id_Validated(object sender, EventArgs e)
        {
            
        }
    }
}
