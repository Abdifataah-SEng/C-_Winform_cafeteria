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
    public partial class ui_Dashbourd : UserControl
    {
        SqlConnection con = new SqlConnection(@"Server=(localdb)\ProjectModels;Database=Cafeteria_management_C_DB; Integrated Security = true;");
        public ui_Dashbourd()
        {
            InitializeComponent();
        }

        void laodTotal()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from AbouvTotal", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
               lblsalary.Text = dr[1].ToString();
               lblpayment.Text = dr[3].ToString();
                lblOrder.Text = dr[0].ToString();
                lblemployee.Text = dr[2].ToString();


            }
            dr.Close();
            con.Close();
        }
        void loadchart()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct category, COUNT(*) as Totals from Orderall group by category", con);
            SqlDataReader dr = cmd.ExecuteReader();
            chart2.Series["Series1"].Points.Clear();

            while (dr.Read())
            {
                string drink = dr[0].ToString();
                string food = dr[1].ToString();
                chart2.Series["Series1"].Points.AddXY(drink, food);
            }
            chart2.Series["Series1"].Label = "#PERCENT";
            chart2.Series["Series1"].LegendText = "#VALX";
            dr.Close();

            con.Close();
        }
        void loadclm()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct payment_method, COUNT(*) as Totals from payment group by payment_method", con);
            SqlDataReader dr = cmd.ExecuteReader();
            chart1.Series["Series1"].Points.Clear();
            while (dr.Read())
            {
                string x = dr[0].ToString();
                string y = dr[1].ToString();
                
                chart1.Series["Series1"].Points.AddXY(x, y);

            }
            dr.Close();
            con.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ui_Dashbourd_Load(object sender, EventArgs e)
        {
            laodTotal();
            loadchart();
            loadclm();
        }
    }
}
