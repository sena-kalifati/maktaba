using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ff
{
    public partial class DashBord : Form
    {
        public DashBord()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-8NJIN7L;Initial Catalog=maktaba;Integrated Security=True");
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DashBord_Load(object sender, EventArgs e)
        {
            
            Con.Open();
          
            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from BookTbl", Con);
            DataTable dt = new DataTable();
           sda1.Fill(dt);
            booklbl.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from StudentTbl", Con);
            DataTable dt2= new DataTable();
            sda2.Fill(dt2);
            studentlbl.Text = dt2.Rows[0][0].ToString();
            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*) from ReturnTbl", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            returnlbl.Text = dt3.Rows[0][0].ToString();

            SqlDataAdapter sda4= new SqlDataAdapter("select count(*) from IssueTbl", Con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            issuelbl.Text = dt4.Rows[0][0].ToString();
           

            SqlDataAdapter sda5 = new SqlDataAdapter("select count(*) from LibrarianTbl", Con);
            DataTable dt5 = new DataTable();
            sda4.Fill(dt5);
            librarianlbl.Text = dt4.Rows[0][0].ToString();
            Con.Close();
        }
    }
}
