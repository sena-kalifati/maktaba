using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ff
{
    public partial class Issue_Books : Form
    {
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
    }
}
