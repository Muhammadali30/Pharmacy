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
    public partial class staffdetailsform : Form
    {
        public staffdetailsform()
        {
            InitializeComponent();
        }
        int pid;
        void get()
        {
            staff s = new staff();
            DataTable dt = s.GetStaff();
            dataGridView1.DataSource = dt;
        }
        private void staffdetailsform_Load(object sender, EventArgs e)
        {
            get();
            comboBox1.Hide();
            tableLayoutPanel6.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tableLayoutPanel6.Show();
            int index = e.RowIndex;
            textBox2.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
            pid =Convert.ToInt32(dataGridView1.Rows[index].Cells[7].Value);
            staff s = new Classes.staff();
           DataTable dt= s.GetPicbyid(pid);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "pic_name";
            string pname = comboBox1.Text;
            pictureBox1.Image = new Bitmap(@"C:\Pharmacy\Images\"+pname);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            staff s = new staff();
            s.delete(pid);
            get();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            staff s = new staff();
            s.name = textBox2.Text;
            s.age = Convert.ToInt32(textBox3.Text);
            s.email = textBox5.Text;
            s.gender = textBox4.Text;
            s.phone = textBox6.Text;
            s.update(pid);
            get();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int a;
            bool flag = int.TryParse(textBox3.Text,out a);
            if (flag!=true)
            {
                MessageBox.Show("Please insert numeric values","Alert!");
            }
            else
            {

            }
        }
    }
}
