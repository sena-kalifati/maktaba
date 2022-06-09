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
    public partial class Form5 : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-8NJIN7L;Initial Catalog=maktaba;Integrated Security=True");
        public Form5()
        {
            InitializeComponent();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 main = new Form3();
            main.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("insert into BookTbl values(" + BookName.Text + ",'" + Author.Text + "','" + Publisher.Text + "','" + Price.Text + "','" + Qty.Text + "')", Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("librarian added successfully");
            Con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = " update BookTbl set BookName='" + BookName.Text + "',Author='" + Author.Text + "',Publisher='" + Publisher.Text + "',Price='" + Price.Text + "'where Qty=" + Qty + ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("librarian seccessfully updeted");

            Con.Close();///mt
        }
        gd
        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            populate();

        }
        public void populate()
        {
            Con.Open();
            string query = "select * from StudentTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            BookDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
