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

namespace SS_Assment_Cafateria_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void bunifuProgressBar1_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuProgressBar.ProgressChangedEventArgs e)
        {
            
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
          
        }
  
        private void timer1_Tick(object sender, EventArgs e)
        {
         
        }
        int time = 0;
        private void timer1_Tick_1(object sender, EventArgs e)
        {

            time ++;
            bunifuProgressBar1.Value = time;
            if (time == 100)
            {
                timer1.Enabled = false;
                var ln = new login();
                ln.Show();
                this.Hide();
                time = 0;
            }

        }
    }
}
