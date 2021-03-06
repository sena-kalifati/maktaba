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
       
        public Return_Books()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-8NJIN7L;Initial Catalog=maktaba;Integrated Security=True");
        public void populate()
        {
            Con.Open();
            string query = "select * from IssueTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            IssueDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        public void populateReturn()
        {
            Con.Open();
            string query = "select * from ReturnTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ReturnDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void FillStudent()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select StdId from StudentTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("StdId", typeof(int));
            dt.Load(rdr);
            StdCb.ValueMember = "StdId";
            StdCb.DataSource = dt;
            Con.Close();
        }
        private void FillBook()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select BookName from BookTbl where Qty >" + 0 + "", Con);
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
            foreach (DataRow dr in dt.Rows)
            {
                StdName.Text = dr["StdName"].ToString();
                StdDep.Text = dr["StdDep"].ToString();
                StdPhone.Text = dr["StdPhone"].ToString();
            }
            Con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 main = new Form3();
            main.Show();

        }
       

        private void Return_Books_Load(object sender, EventArgs e)
        {
            populate();
            FillStudent();
            populateReturn();
            FillBook();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
       


        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // IssueNum.Text = IssueDGV.SelectedRows[0].Cells[0].Value.ToString();
            StdCb.SelectedItem = IssueDGV.SelectedRows[0].Cells[1].Value.ToString();
            StdName.Text = IssueDGV.SelectedRows[0].Cells[2].Value.ToString();
            StdDep.Text = IssueDGV.SelectedRows[0].Cells[3].Value.ToString();
            BookIssued.Text = IssueDGV.SelectedRows[0].Cells[4].Value.ToString();
            StdPhone.Text = IssueDGV.SelectedRows[0].Cells[5].Value.ToString();

        }
        private void UpdateBook()
        {
            int Qty, newQty;
            Con.Open();
            string query = "select * from BookTbl where BookName='" + BookIssued.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Qty = Convert.ToInt32(dr["Qty"].ToString());
                newQty = Qty +1;
                string query1 = "Update BookTbl set Qty=" + newQty + "where BookName='" + BookIssued.SelectedValue.ToString() + "'";
                SqlCommand cmd1 = new SqlCommand(query1, Con);
                cmd1.ExecuteNonQuery();

            }
            Con.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (ReturnNum.Text == "" || StdName.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {

                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into ReturnTbl values(" + ReturnNum.Text + "," + StdCb.SelectedItem.ToString() + ",'" + StdName.Text + "','" + StdDep.Text + "','" + StdPhone.Text + "','" + BookIssued.SelectedValue.ToString() + "','" + issuedate.Text + "','" + returndate.Text + "')", Con);
                cmd.ExecuteNonQuery();  
                MessageBox.Show("Book successfully Returned");
                Con.Close();
                UpdateBook();
                populate();
                populateReturn();

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void IssueNum_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BookIssued_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BookIssued_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void StdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {fetchstddate();

        }
    }
}

