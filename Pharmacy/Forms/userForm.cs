using Pharmacy.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class userForm : Form
    {
        public userForm()
        {
            InitializeComponent();
        }
        string imgfilepath,imgname,imgext,name;
     
    

        private void pictureBox15_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox14_Click_1(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 f = new Pharmacy.Form1();
            f.Show();
            if (WindowState == FormWindowState.Maximized)
            {
                f.WindowState = FormWindowState.Maximized;
            }
            this.Close();
        }

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Images Files(*.jpg;)|*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                
                imgfilepath = open.FileName;
                imgext = Path.GetExtension(open.FileName);
                imgname = Path.GetFileNameWithoutExtension(open.FileName);
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OrderHeading_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                this.SelectNextControl(textBox1, true, true, true, true);
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                

                this.SelectNextControl(textBox2, true, true, true, true);
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                this.SelectNextControl(textBox3, true, true, true, true);
            }
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                this.SelectNextControl(textBox5, true, true, true, true);
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            comboBox3.Hide();
        }
        public Point mouselocation;
        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            mouselocation = new Point(-e.X, -e.Y);
        }

        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouselocation.X, mouselocation.Y);
                Location = mousePose;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            Salary s = new Salary();
            DataTable dt=s.GetSalary();
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "salary";
            comboBox2.ValueMember = "salary_id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" &&
               comboBox2.Text != "" && textBox5.Text != "" &&
               comboBox1.Text != "")
                {
                    DirectoryInfo dir = new DirectoryInfo(@"C:\Pharmacy");
                    DirectoryInfo diri = new DirectoryInfo(@"C:\Pharmacy\Images");
                    DateTime a = DateTime.Now;

                    if (dir.Exists)
                    {
                        if (diri.Exists)
                        {
                            File.Copy(imgfilepath, Path.Combine(@"C:\Pharmacy\Images", Path.GetFileName(imgfilepath)), true);
                        }
                        else
                        {
                            diri.Create();
                            File.Copy(imgfilepath, Path.Combine(@"C:\Pharmacy\Images", Path.GetFileName(imgfilepath)), true);
                        }
                    }
                    else
                    {
                        dir.Create();
                        diri.Create();
                        File.Copy(imgfilepath, Path.Combine(@"C:\Pharmacy\Images", Path.GetFileName(imgfilepath)), true);
                    }
                    if (imgfilepath != "")
                    {
                        name = textBox1.Text + a.Millisecond + imgext;
                        File.Move(@"C:\Pharmacy\Images\" + imgname + imgext, @"C:\Pharmacy\Images\" + name);
                    }
                    staff s = new staff();
                    s.pic = name;
                    s.picstore();
                    DataTable pid = s.GetPic();
                    comboBox3.DataSource = pid;
                    comboBox3.DisplayMember = "pic_id";

                    s.name = textBox1.Text;
                    s.email = textBox2.Text;
                    s.phone = textBox3.Text;
                    s.age = Convert.ToInt32(textBox5.Text);
                    s.gender = comboBox1.Text;
                    s.pic_id = Convert.ToInt32(comboBox3.Text);
                    s.sal_id = Convert.ToInt32(comboBox2.SelectedValue);
                    s.AddStaff();
                }
                else
                {
                    MessageBox.Show("Plzz fill all fields");
                }
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert!");
            }
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
