using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ff
{
    public partial class Form6 : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-8NJIN7L;Initial Catalog=maktaba;Integrated Security=True");
        public Form6()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 main = new Form3();
            main.Show();

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            populate();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from librarianTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            LibrarianDGV.DataSource = ds.Tables[0];
           
            Con.Close();
            populate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("insert into librarianTbl values(" + LibId.Text + ",'" + LibName.Text +"','"+ LibPass.Text+ "','" + LibPhone.Text+"')",Con);
            cmd.ExecuteNonQuery();
                MessageBox.Show("librarian added successfully");
                Con.Close();
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            Con.Close();
            populate();
        }

        private void LibId_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void LibName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         

        }

        private void LibrarianDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
    }
}
