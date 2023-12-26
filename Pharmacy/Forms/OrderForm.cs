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
    public partial class OrderForm : Form
    {
        int val = 0;
        public OrderForm()
        {
            InitializeComponent();
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

        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }
        void calculate()
        {
            int total = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                total += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
            }
            textBox7.Text = Convert.ToString(total);
            textBox10.Text = Convert.ToString(Convert.ToDecimal(total / 100) * 10);
            textBox3.Text = Convert.ToString(Convert.ToInt32(textBox7.Text) + Convert.ToInt32(textBox10.Text));

            textBox11.Text = Convert.ToString(Convert.ToInt32(textBox7.Text) + Convert.ToInt32(textBox10.Text));

        }
        private void deletebutton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 1) { 
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowindex);
                if (dataGridView1.RowCount < 2)
                {
                    button2.Enabled = false;
                    textBox8.Enabled = false;
                }
                calculate();
        }
        }

        private void Addmore_Click(object sender, EventArgs e)
        {
            string[] row = { comboBox1.Text, Convert.ToString(numericUpDown1.Value),textBox1.Text, textBox4.Text, textBox5.Text };
            dataGridView1.Rows.Add(row);
            numericUpDown1.Value = 0;
            comboBox1.Text = "";
            if (dataGridView1.RowCount > 1)
            {
                button2.Enabled = true;
                textBox8.Enabled = true;
            }
            calculate();
            }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Order odr = new Order();
            odr.amount = Convert.ToInt32(textBox7.Text);
            odr.tax = Convert.ToInt32(textBox10.Text);
            if (textBox8.Text == "")
            {
                textBox8.Text = "0";
            }
            odr.discount = Convert.ToInt32(textBox8.Text);
            DateTime dt = DateTime.Now;
            odr.Date = Convert.ToString(dt); 
            odr.GetOrder();
            DataTable dtble = odr.getid();
            comboBox2.DataSource = dtble;
            comboBox2.DisplayMember = "order_id";
            odr.oid =Convert.ToInt32(comboBox2.Text);
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                odr.update(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value));
            }
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                DataTable dt1 = odr.GetMedID(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value));
                comboBox3.DataSource = dt1;
                comboBox3.DisplayMember = "med_id";
               odr.mid= Convert.ToInt32(comboBox3.Text);
                odr.qty = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                odr.GetOrder_details();
            }
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

         private void OrderForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
            Addmore.Enabled = false;
            button2.Enabled = false;
            comboBox2.Hide();
            comboBox3.Hide();
            comboBox4.Hide();
            textBox8.Enabled = false;
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

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox13_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            Medicine Med = new Medicine();
            DataTable dt = Med.autoload("select * from Medicine where med_qty > 0");
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "med_name";
            comboBox1.ValueMember = "med_price";
            comboBox4.DataSource = dt;
            comboBox4.DisplayMember = "med_qty";
            textBox4.Text = comboBox1.SelectedValue.ToString();
            numericUpDown1.Enabled = true;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = comboBox1.SelectedValue.ToString();
           
            if (textBox4.Text != "System.Data.DataRowView")
            {
                val = Convert.ToInt32(textBox4.Text);
           }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text =Convert.ToString(Convert.ToDecimal(comboBox4.Text) - numericUpDown1.Value);
            if (numericUpDown1.Value>Convert.ToDecimal(comboBox4.Text))
            {
                MessageBox.Show("You dont have enough Quantity","Alert!");
                numericUpDown1.Value = Convert.ToDecimal(comboBox4.Text);
            }
            if (numericUpDown1.Value!=0)
            {
                Addmore.Enabled = true;
            }
            else
            {
                Addmore.Enabled = false;
            }
            textBox5.Text = Convert.ToString(numericUpDown1.Value * val);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text!=string.Empty)
            {
               int i;
               bool flag= int.TryParse(textBox8.Text,out i);
            if (flag==false)
            {
                    textBox8.Text = "";
                    MessageBox.Show("Please insert Numeric value","Alert!");
            }
            }
           
            int chk=0;

            if (textBox8.Text!="") {
                chk = Convert.ToInt32(textBox8.Text);
                textBox11.Text = Convert.ToString((Convert.ToInt32(textBox7.Text)+ Convert.ToInt32(textBox10.Text)) - Convert.ToInt32(textBox8.Text));
        }
            else
            {
                textBox11.Text = Convert.ToString(Convert.ToInt32(textBox7.Text) + Convert.ToInt32(textBox10.Text));
            }
            int excep = Convert.ToInt32(textBox7.Text) + Convert.ToInt32(textBox10.Text);
           
            if (chk > excep)
            {
                textBox8.Text = "";
                MessageBox.Show("Discount Amount Should be less than Total Amount","Alert!");
            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int total=0;
            for(int i=0;i<dataGridView1.RowCount-1; i++)
            {
                total +=Convert.ToInt32( dataGridView1.Rows[i].Cells[3].Value);
            }
            textBox7.Text = Convert.ToString(total);
            textBox10.Text = Convert.ToString((total/100)*10);
            textBox11.Text = Convert.ToString(Convert.ToInt32(textBox7.Text)+ Convert.ToInt32(textBox10.Text));

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Pharmacy", new Font("Arial", 25, FontStyle.Bold), Brushes.Black, new PointF(315, 10));
            e.Graphics.DrawString("Order No ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, 50));
            DateTime d = DateTime.Now;
            e.Graphics.DrawString(comboBox2.Text, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(150, 50));
            e.Graphics.DrawString(Convert.ToString(d), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(400, 50));
            e.Graphics.DrawString("______________________________________________________________________________________________________", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, 60));
            e.Graphics.DrawString("Med_name ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, 100));
            e.Graphics.DrawString("Qty ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(200, 100));
            e.Graphics.DrawString("Price ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(400, 100));
            e.Graphics.DrawString("Total ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(600, 100));
            e.Graphics.DrawString("______________________________________________________________________________________________________", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, 110));
            int Y_axis = 150, X_axis = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j==2)
                    {
                        continue;
                    }
                    e.Graphics.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[j].Value), new Font("Arial", 15), Brushes.Black, new PointF(X_axis, Y_axis));
                    X_axis += 200;
                }
                Y_axis += 50;
                X_axis = 0;
            }
            e.Graphics.DrawString("______________________________________________________________________________________________________", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, Y_axis -40));
            e.Graphics.DrawString("Sub_Total", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, Y_axis + 20));
            e.Graphics.DrawString(textBox7.Text, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(700, Y_axis + 20));
            e.Graphics.DrawString("TAX", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, Y_axis + 70));
            e.Graphics.DrawString(textBox10.Text, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(700, Y_axis + 70));
            e.Graphics.DrawString("Total", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, Y_axis + 120));
            e.Graphics.DrawString(textBox3.Text, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(700, Y_axis + 120));
            e.Graphics.DrawString("Discount", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, Y_axis + 170));
            e.Graphics.DrawString(textBox8.Text, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(700, Y_axis + 170));
            e.Graphics.DrawString("Net_Total", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, Y_axis + 220));
            e.Graphics.DrawString(textBox11.Text, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(700, Y_axis + 220));
            e.Graphics.DrawString("Thank You for Your Visit", new Font("Arial", 20, FontStyle.Bold), Brushes.Red, new PointF(250, Y_axis + 270));

        }
    }
}
