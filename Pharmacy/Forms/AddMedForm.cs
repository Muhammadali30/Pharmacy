using Pharmacy.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class AddMedForm : Form
    {
        public AddMedForm()
        {
            InitializeComponent();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void AddMedForm_Load(object sender, EventArgs e)
        {
         
            textBox2.Enabled = false;
            richTextBox1.Enabled = false;
            comboBox4.Hide();
            comboBox5.Hide();
        }

      

      

      


        private void label11_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Supplier sup = new Supplier();
            sup.supplier_name = textBox6.Text;
            sup.supplier_contact = textBox5.Text;
            sup.create();
            panel1.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.cat_name = textBox8.Text;
            cat.create();
            textBox8.Text = "";
        }

        private void label14_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_Click_1(object sender, EventArgs e)
        {
            Medicine Med = new Medicine();
            DataTable dt = Med.autoload("select supp_id,supp_name from supplier");
            comboBox2.DataSource = dt;
            comboBox2.ValueMember = "supp_id";
            comboBox2.DisplayMember = "supp_name";
        }

        private void comboBox1_Click_1(object sender, EventArgs e)
        {
            Category ct = new Category();
            DataTable dt = ct.GetData();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "cat_name";
            comboBox1.ValueMember = "cat_id";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text=="Add New Medicine->")
            {
                textBox2.Enabled = true;
                comboBox3.Enabled = false;
                comboBox3.Text = "";
                richTextBox1.Enabled = true;

                button5.Text = "<-Select Medicine";
            }
           else
            {
                richTextBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox2.Text = "";
                comboBox3.Enabled = true;
                richTextBox1.Enabled = false;
                button5.Text = "Add New Medicine->";
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            string name,msv;
            if (comboBox3.Text=="")
            {
                name = textBox2.Text;
                msv = null;
                purchase p = new purchase(name,msv,comboBox1.Text,comboBox1.SelectedValue.ToString(),textBox1.Text,textBox3.Text,comboBox2.Text,comboBox2.SelectedValue.ToString(),null,null);
                p.Show();
                Medicine med = new Medicine();
                med.med_name = textBox2.Text;
                med.med_desc = richTextBox1.Text;
                med.purch_qty = Convert.ToInt32(textBox1.Text);
                med.med_price = Convert.ToInt32(textBox3.Text);
                med.cat_id =Convert.ToInt32(comboBox1.SelectedValue);
                med.AddMedicine();
            }
            else if(textBox2.Text=="")
            {
                name = comboBox3.Text;
                Medicine med = new Medicine();
                med.med_name = textBox2.Text;
               DataTable dt= med.autoload($"select * from Medicine where med_id = '{comboBox3.SelectedValue.ToString()}'");
                comboBox4.DataSource = dt;
                comboBox4.DisplayMember = "med_qty";
                comboBox5.DataSource = dt;
                comboBox5.DisplayMember = "med_price";
                med.purch_qty = Convert.ToInt32(comboBox4.Text)+Convert.ToInt32(textBox1.Text);
                med.med_price = Convert.ToInt32(textBox3.Text);
                purchase p = new purchase(name, comboBox3.SelectedValue.ToString(), comboBox1.Text, comboBox1.SelectedValue.ToString(), textBox1.Text, textBox3.Text, comboBox2.Text, comboBox2.SelectedValue.ToString(),comboBox4.Text,comboBox5.Text);
                p.Show();
                med.update(comboBox3.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Please Select the Medicine", "Alert!");
            }
           
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            Medicine Med = new Medicine();
            DataTable dt = Med.autoload("select med_id,med_name from Medicine");
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "med_name";
            comboBox3.ValueMember = "med_id";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
