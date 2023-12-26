using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pharmacy
{
    public partial class Form2 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
(
    int nLeftRect, // x-coordinate of upper-left corner
    int nTopRect, // y-coordinate of upper-left corner
    int nRightRect, // x-coordinate of lower-right corner
    int nBottomRect, // y-coordinate of lower-right corner
    int nWidthEllipse, // height of ellipse
    int nHeightEllipse // width of ellipse
 );
        public Form2()
        {
            InitializeComponent();
            loadcredentials();
            textBox2.UseSystemPasswordChar = true;
            button1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 25, 25));
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void RemoveError()
        {
            label3.Text = "";
        }
        void Savecredentials()
        {
            if (checkBox1.Checked==true)
            {
                Properties.Settings.Default.username = textBox1.Text;
                Properties.Settings.Default.password = textBox2.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.username = "";
                Properties.Settings.Default.password = "";
                Properties.Settings.Default.Save();
            }
        }
        void loadcredentials()
        {
            if (Properties.Settings.Default.username != "")
            {
                textBox1.Text = Properties.Settings.Default.username;
                textBox2.Text = Properties.Settings.Default.password;
                checkBox1.Checked = true;
            }
        }int count=0;
        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                if (count == 3)
                {
                    count = 0;
                    button1.Visible = false;
                    timer1.Start();
                }
                authentication a = new authentication();
                a.uname = textBox1.Text;
                a.pass = textBox2.Text;
                DataTable dt = a.login();
                if (dt.Rows.Count > 0)
                {
                    count = 0;
                    Savecredentials();
                    Form1 from = new Form1();
                    from.Show();
                    this.Close();
                }
                else
                {
                    count++;
                    label3.Text = "Incorrect Username Or Password";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Alert!");
            }
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text!=""&&textBox2.Text!="")
                {
                    button1.PerformClick();
                }
                this.SelectNextControl(textBox1,true,true,true,true);
            }
        }
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RemoveError();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            RemoveError();
        }

      

        private void Form2_Load(object sender, EventArgs e)
        {
            button1.Location = new Point(-193,button1.Location.Y);
            timer2.Start();
            label3.Text = "";
          
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked==true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;

            }
        }int c = 30;
        void increment()
        {
            c--;
            label3.Text = "Your Account is Disabled for "+Convert.ToString(c)+" Sec";
            if (c==0)
            {
                timer1.Stop();
                button1.Visible = true;
                label3.Text = "";
                c=30;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            increment();
        }
       public Point mouselocation;
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            mouselocation = new Point(-e.X, -e.Y);
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouselocation.X, mouselocation.Y);
                Location = mousePose;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button1.Location = new Point(button1.Location.X+30,button1.Location.Y);
            if (button1.Location.X==107)
            {
                timer2.Stop();
            }
        }
    }
}