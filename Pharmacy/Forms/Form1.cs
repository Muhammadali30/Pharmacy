using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacy.Classes;
using System.Threading;

namespace Pharmacy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Point mouselocation;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        void Loading()
        {
            Thread.Sleep(300);
            DatabaseConnection db = new DatabaseConnection();
            label16.Invoke((MethodInvoker)(() => label16.Text = Convert.ToString(db.count("select count(*) from Medicine"))));                          
            label14.Invoke((MethodInvoker)(() => label14.Text = Convert.ToString(db.count("select count(*) from Medicine where med_qty<=0"))));
            label22.Invoke((MethodInvoker)(() => label22.Text = Convert.ToString(db.count("select count(*) from supplier"))));
            label8.Invoke((MethodInvoker)(() => label8.Text = Convert.ToString(db.count("select count(*) from Purchase"))));
            label26.Invoke((MethodInvoker)(() => label26.Text = Convert.ToString(db.count("select count(*) from staff"))));
            label18.Invoke((MethodInvoker)(() => label18.Text = Convert.ToString(db.count("select count(*) from orders"))));
            DateTime a = DateTime.Now;
            label24.Invoke((MethodInvoker)(() => label24.Text = Convert.ToString(db.count($"select count(*) from Purchase where date like '{a.Month.ToString() + "/" + a.Day.ToString()}%'"))));
            label20.Invoke((MethodInvoker)(() => label20.Text = Convert.ToString(db.count($"select count(*) from orders where Datee like '{a.Month.ToString() + "/" + a.Day.ToString()}%'"))));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(Loading);
            t.Start();

        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void label16_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

      
        private void panel4_Click(object sender, EventArgs e)
        {
            
            OrderForm of = new OrderForm();
            
            if (WindowState == FormWindowState.Maximized)
            {
                of.WindowState = FormWindowState.Maximized;
            }
            of.Show();
            this.Close();
        }

   
        private void pictureBox15_Click_1(object sender, EventArgs e)
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

        private void pictureBox13_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            userForm uf = new userForm();
            uf.Show();
                   if (WindowState == FormWindowState.Maximized)
            {
                uf.WindowState = FormWindowState.Maximized;
            }
            uf.Show();
            this.Close();
        }


        private void newmedicine_Click(object sender, EventArgs e)
        {
            AddMedForm amf = new AddMedForm();
            if (WindowState == FormWindowState.Maximized)
            {
                amf.WindowState = FormWindowState.Maximized;
            }
            amf.Show();
            this.Close();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

       

       

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            meddetailsform mdf = new meddetailsform();
            if (WindowState == FormWindowState.Maximized)
            {
                mdf.WindowState = FormWindowState.Maximized;
            }
            mdf.Show();
            this.Close();
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            suppliersform sf = new suppliersform();
            if (WindowState == FormWindowState.Maximized)
            {
                sf.WindowState = FormWindowState.Maximized;
            }
            sf.Show();
            this.Close();
        }

        private void panel13_Click(object sender, EventArgs e)
        {
            staffdetailsform sf = new staffdetailsform();
            if (WindowState == FormWindowState.Maximized)
            {
                sf.WindowState = FormWindowState.Maximized;
            }
            sf.Show();
            this.Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            OrderDeatilsForm odf = new OrderDeatilsForm();
            if (WindowState == FormWindowState.Maximized)
            {
                odf.WindowState = FormWindowState.Maximized;
            }
            odf.Show();
            this.Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {
           
            this.Close();
            Form2 f2 = new Form2();
            f2.Show();
        }


        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouselocation = new Point(-e.X, -e.Y);
        }
        private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouselocation.X, mouselocation.Y);
                Location = mousePose;
            }
        }

      
    }
}
