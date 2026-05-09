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
    public partial class UC_order : UserControl
    {

        SqlConnection con = new SqlConnection(@"Server=(localdb)\ProjectModels;Database=Cafeteria_management_C_DB; Integrated Security = true;");
        public UC_order()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            order_bn or = new order_bn();
            or.Show();
            
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.orderallTableAdapter.Fill(this.cafeteria_management_C_DBDataSet.Orderall);
        }
    }
}
