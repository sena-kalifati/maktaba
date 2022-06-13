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
       
        public Issue_Books()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-8NJIN7L;Initial Catalog=maktaba;Integrated Security=True");
        
        private void FillStudent()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select StdId from StudentTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("StdId",typeof(int));
            dt.Load(rdr);
            StdCb.ValueMember = "StdId";
            StdCb.DataSource = dt;
            Con.Close();
        }
        private void FillBook()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select BookName from BookTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("BookName", typeof(string));
            dt.Load(rdr);
            BookIssued.ValueMember = "BookName";
            BookIssued.DataSource = dt;
            Con.Close();
        }

        private void fetchstddate()
        {
            Con.Open();
            string query = "select * from StudentTbl where StdId=" + StdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                StdName.Text = dr["StdName"].ToString();
                StdDep.Text = dr["StdDep"].ToString();
                StdPhone.Text = dr["StdPhone"].ToString();
            }
            Con.Close();
        }


        private void Issue_Books_Load(object sender, EventArgs e)
        {
            FillStudent();
            FillBook();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 main = new Form3();
            main.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IssueNum.Text == "" || StdName.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            { string date = IssueDate.Value.Day.ToString() + IssueDate.Value.Month.ToString() + IssueDate.Value.Year.ToString() ;

                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into IssueTbl values(" + IssueNum.Text + "," + StdCb.SelectedValue.ToString()+ ",'" + StdName.Text + "','" + StdDep.Text + "','" + StdPhone.Text + "','" + BookIssued.SelectedValue.ToString() + "','" + date + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book successfully Issued");
                Con.Close();
                populate();
            }
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "update IssueTbl set IssueNum='" + IssueNum.Text + ",StdId'" + StdCb.Text + "',StdName'" + StdName.Text + "',StdDept'" + StdDep.Text + "',StdPhone'" + BookIssued.Text + "',BookIssued'" + StdPhone.Text + "',IssueDate'" + IssueDate.Text +  ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Issue seccessfully updeted");

            Con.Close();
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "delete from IssueTbl where StdId =" + StdCb.Text + "";
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
            StdCb.Text = IssueDGV.SelectedRows[0].Cells[0].Value.ToString();
            StdName.Text = IssueDGV.SelectedRows[0].Cells[0].Value.ToString();
            StdDep.Text = IssueDGV.SelectedRows[0].Cells[0].Value.ToString();
            BookIssued.Text = IssueDGV.SelectedRows[0].Cells[0].Value.ToString();
            StdPhone.Text = IssueDGV.SelectedRows[0].Cells[0].Value.ToString();
            IssueDate.Text = IssueDGV.SelectedRows[0].Cells[0].Value.ToString();

        
        }

        private void StdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchstddate();
        }

        private void StdCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void book_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
