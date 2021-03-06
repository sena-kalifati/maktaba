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
    public partial class Form4 : Form
    {
        
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-8NJIN7L;Initial Catalog=maktaba;Integrated Security=True");
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        public void populate()
        {
            Con.Open();
            string query = "select * from StudentTbl ";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            StudenDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 main = new Form3();
            main.Show();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StdId.Text == "" || StdName.Text == "" || StdDep.Text == "" || StdSem.Text == "" || StdPhone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into StudentTbl values(" + StdId.Text + ",'" + StdName.Text + "','" + StdDep.Text + "'," + StdSem.SelectedItem.ToString() + ",'" + StdPhone.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student added successfully");
                Con.Close();
                populate();
            
        }
    }
        

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            populate();
        }
   
        private void button3_Click(object sender, EventArgs e)
        {
            if (StdId.Text == "" || StdName.Text == "" || StdDep.Text == "" || StdSem.Text == "" || StdPhone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
            string query = "update StudentTbl set StdName='" + StdName.Text + "',StdDep='" + StdDep.Text + "',StdSem=" + StdSem.SelectedItem.ToString() + ",StdPhone='" + StdPhone.Text + "'where StdId=" + StdId.Text + ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("student seccessfully updeted");

            Con.Close();
            populate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (StdId.Text == "")
            {
                MessageBox.Show("Enter The librarian ID");
            }
            else
            {
                Con.Open();
                string query = "delete from StudentTbl  where StdId =" + StdId.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student successfuly deleted");
                Con.Close();
                populate();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StdId.Text = StudenDGV.SelectedRows[0].Cells[0].Value.ToString();
            StdName.Text = StudenDGV.SelectedRows[0].Cells[1].Value.ToString();
            StdDep.Text = StudenDGV.SelectedRows[0].Cells[2].Value.ToString();
            StdSem.Text = StudenDGV.SelectedRows[0].Cells[3].Value.ToString();
            StdPhone.Text = StudenDGV.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
}
