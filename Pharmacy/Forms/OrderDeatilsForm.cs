using Pharmacy.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class OrderDeatilsForm : Form
    {
        public OrderDeatilsForm()
        {
            InitializeComponent();
        }
        int oid,ind;
        string date;
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

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
        private void OrderDeatilsForm_Load(object sender, EventArgs e)
        {
            label3.Hide();
            dataGridView2.Hide();
            Thread t = new Thread(() => {
                Thread.Sleep(200);
                Order od = new Order();
                dataGridView1.Invoke((MethodInvoker)(()=> dataGridView1.DataSource = od.Order_details()));
                
            });
            t.Start(); 
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
             ind = e.RowIndex;
            oid = Convert.ToInt32(dataGridView1.Rows[ind].Cells[0].Value);
            date= Convert.ToString(dataGridView1.Rows[ind].Cells[4].Value);
            Order odr = new Order();
           dataGridView2.DataSource= odr.Order_details(Convert.ToInt32(dataGridView1.Rows[ind].Cells[0].Value));
            printPreviewControl1.Document = printDocument1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Datee")
            {
                label3.Show();
            }
            else
            {
                label3.Hide();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Pharmacy", new Font("Arial", 30, FontStyle.Bold), Brushes.Black, new PointF(315, 10));
            e.Graphics.DrawString("Order No ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, 50));
            e.Graphics.DrawString(Convert.ToString(oid), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(150, 50));
            e.Graphics.DrawString(date, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(530, 50));
            e.Graphics.DrawString("______________________________________________________________________________________________________", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, 60));
            e.Graphics.DrawString("Med_name ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, 100));
            e.Graphics.DrawString("Qty ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(200, 100));
            e.Graphics.DrawString("Price ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(400, 100));
            e.Graphics.DrawString("Total ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(600, 100));
            e.Graphics.DrawString("______________________________________________________________________________________________________", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, 110));
            int Y_axis = 150, X_axis = 0,qty=0,amo=0;
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    switch (j)
                    {
                        case 1:
                            qty = Convert.ToInt32(dataGridView2.Rows[i].Cells[j].Value);
                            break;
                        case 2:
                            amo = Convert.ToInt32(dataGridView2.Rows[i].Cells[j].Value);
                            break;
                    }
                   
                    if (j < 3)
                    {
                        e.Graphics.DrawString(Convert.ToString(dataGridView2.Rows[i].Cells[j].Value), new Font("Arial", 15), Brushes.Black, new PointF(X_axis, Y_axis));
                    }
                    else
                    {
                        e.Graphics.DrawString(Convert.ToString(amo*qty), new Font("Arial", 15), Brushes.Black, new PointF(X_axis, Y_axis));

                    }
                    X_axis += 200;
                }
                Y_axis += 50;
                X_axis = 0;
            }
            e.Graphics.DrawString("______________________________________________________________________________________________________", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, Y_axis - 40));
            e.Graphics.DrawString("Sub_Total", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, Y_axis + 20));
            e.Graphics.DrawString(Convert.ToString(dataGridView1.Rows[ind].Cells[1].Value), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(700, Y_axis + 20));
            e.Graphics.DrawString("TAX", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, Y_axis + 70));
            e.Graphics.DrawString(Convert.ToString(dataGridView1.Rows[ind].Cells[2].Value), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(700, Y_axis + 70));
            e.Graphics.DrawString("Total", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, Y_axis + 120));
            e.Graphics.DrawString(Convert.ToString(Convert.ToInt32(dataGridView1.Rows[ind].Cells[1].Value)+ Convert.ToInt32(dataGridView1.Rows[ind].Cells[2].Value)), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(700, Y_axis + 120));
            e.Graphics.DrawString("Discount", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, Y_axis + 170));
            e.Graphics.DrawString(Convert.ToString(dataGridView1.Rows[ind].Cells[3].Value), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(700, Y_axis + 170));
            e.Graphics.DrawString("Net_Total", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(0, Y_axis + 220));
            e.Graphics.DrawString((Convert.ToString((Convert.ToInt32(dataGridView1.Rows[ind].Cells[1].Value) + Convert.ToInt32(dataGridView1.Rows[ind].Cells[2].Value))- Convert.ToInt32(dataGridView1.Rows[ind].Cells[3].Value))), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(700, Y_axis + 220));
            e.Graphics.DrawString("Thank You for Your Visit", new Font("Arial", 20, FontStyle.Bold), Brushes.Red, new PointF(250, Y_axis + 270));
        }
    }
}
