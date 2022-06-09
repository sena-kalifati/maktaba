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
    public partial class Issue_Books : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-8NJIN7L;Initial Catalog=maktaba;Integrated Security=True");
        public Issue_Books()
        {
            InitializeComponent();
        }

        private void Issue_Books_Load(object sender, EventArgs e)
        {

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
            SqlCommand cmd = new SqlCommand("insert into IssueTbl values(" + IssueNum.Text + ",'" + StdId.Text + "','" + StdName.Text + "','" + StdDept.Text + "','" + StdPhone.Text + "','" + BookIssued.Text + "','" + IssueDate.Text + "')", Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Issue added successfully");
            Con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "update IssueTbl set IssueNum='" + IssueNum.Text + ",StdId'" + StdId.Text + "',StdName'" + StdName.Text + "',StdDept'" + StdDept.Text + "',StdPhone'" + StdPhone.Text + "',BookIssued'" + BookIssued.Text + "',IssueDate'" + IssueDate.Text +  ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Issue seccessfully updeted");

            Con.Close();
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "delete from IssueTbl where StdId =" + StdId.Text + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("librarian successfuly deleted");
            Con.Close();
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
            IssueDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void IssueDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IssueNum.Text = IssueDGV.SelectedRows[0].Cells[0].Value.ToString();
            StdId.Text = IssueDGV.SelectedRows[0].Cells[0].Value.ToString();
            StdName.Text = IssueDGV.SelectedRows[0].Cells[0].Value.ToString();
            StdDept.Text = IssueDGV.SelectedRows[0].Cells[0].Value.ToString();
            StdPhone.Text = IssueDGV.SelectedRows[0].Cells[0].Value.ToString();
            BookIssued.Text = IssueDGV.SelectedRows[0].Cells[0].Value.ToString();
            IssueDate.Text = IssueDGV.SelectedRows[0].Cells[0].Value.ToString();

        
        }
    }
}
