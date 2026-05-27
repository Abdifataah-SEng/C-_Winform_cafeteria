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
    public partial class BackUp : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=Cafeteria_management_C_DB;Integrated Security=True");
        public BackUp()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Backup File (.bak)|.bak";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = sfd.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "BACKUP DATABASE [Cafeteria_management_C_DB] TO DISK='" + txtPath.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Database Backup Successfully");
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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Backup File (.bak)|*.bak";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string restorePath = ofd.FileName;
                    string query = "RESTORE DATABASE [Cafeteria_management_C_DB] FROM DISK='" + restorePath + "'";
                    
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandTimeout = 300;
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    
                    MessageBox.Show("Database Restored Successfully", "Restore Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Restore Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Backup File (.bak)|*.bak";
                if (opf.ShowDialog() == DialogResult.OK)
                {
                txtpathR.Text = opf.FileName;
                }
        }
    }
}
