using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ff
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int stat = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
             stat +=1;

            timer1.Enabled = true;
            progressBar1.Increment(1);
            label6.Text = "%" + stat;
            if (progressBar1.Value==100)
            {
                timer1.Enabled =false;
                Form1 form

                    = new Form1();
                form.Show();
                this.Hide();

                
            }
    }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
