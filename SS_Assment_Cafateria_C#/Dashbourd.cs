using SS_Assment_Cafateria_C_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
namespace SS_Assessment_Cafateria_C_
{
    public partial class Dashbourd : Form
    {
        public Dashbourd()
        {
            InitializeComponent();
        }
      
       

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            
            guna2HtmlLabel2.Text = "Dashboard";
            
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Text = "Order";
            UC_order st = new UC_order();
            st.Dock = DockStyle.Fill;
            bunifuPanel2.Controls.Add(st);

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState =FormWindowState.Normal;
            }
            else
            {
                               this.WindowState = FormWindowState.Maximized;
            }
        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            login lg = new login();
            lg.Show();
            this.Hide();

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Text = "Payment";
           
            UC_payment py = new UC_payment();
            py.Dock = DockStyle.Fill;
            bunifuPanel2.Controls.Add(py);
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Text = "Employees";
            
            UC_employee em = new UC_employee();
            em.Dock = DockStyle.Fill;
            bunifuPanel2.Controls.Add(em);
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Text = "Salary";
           
            UC_salary sl = new UC_salary();
            sl.Dock = DockStyle.Fill;
            bunifuPanel2.Controls.Add(sl);
        }
    }
}
