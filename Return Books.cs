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
    public partial class Return_Books : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-8NJIN7L;Initial Catalog=maktaba;Integrated Security=True");
        public Return_Books()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 main = new Form3();
            main.Show();

        }

        private void Return_Books_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("insert into StudentTbl values()");
            cmd.ExecuteNonQuery();
            MessageBox.Show("librarian added successfully");
            Con.Close();
           
        }
    }
    }
}
