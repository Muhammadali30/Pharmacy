using Pharmacy.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class meddetailsform : Form
    {
        public meddetailsform()
        {
            InitializeComponent();
        }

        private void meddetailsform_Load(object sender, EventArgs e)
        {
            Medicine md = new Medicine();
            DataTable dt = md.searchmed(null,null);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Pharmacy.Form1();
            f.Show();
            if (WindowState == FormWindowState.Maximized)
            {
                f.WindowState = FormWindowState.Maximized;
            }
            this.Close();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Medicine md = new Medicine();
            DataTable dt=md.searchmed(textBox1.Text,comboBox1.Text);
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
