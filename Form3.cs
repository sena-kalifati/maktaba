using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ff
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 main = new Form4();
            main.Show();

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 main = new Form5();
            main.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 main = new Form6();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
           Issue_Books main = new Issue_Books();
            main.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
           Return_Books main = new Return_Books();
            main.Show();
       
    }
    } }

