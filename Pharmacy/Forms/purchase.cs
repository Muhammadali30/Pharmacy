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
    public partial class purchase : Form
    {
        string medi,cate,cat_id,sup_id, suppi, qtys, unitpr,med_id,prev_qty,prev_price;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int a;
            bool flag = int.TryParse(textBox1.Text,out a);
            if (textBox1.Text !=string.Empty&&flag==true)
            {
                button1.Enabled = true;
            }
            else if (textBox1.Text=="")
            {
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please Insert Numeric Value","Alert!");
                button1.Enabled = false;
            }
        }
        public purchase(string med, string medid, string cat, string catid, string qty, string unitp, string supp, string supid, string pq, string pp)
        {
            InitializeComponent();
            medi = med; cate = cat; cat_id = catid; qtys = qty; unitpr = unitp; sup_id = supid; suppi = supp; med_id = medid; prev_qty = pq; prev_price = pp;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddMedForm adf = new AddMedForm();
            adf.Show();
            purchaseclass pc = new purchaseclass();
            if (med_id == null)
            {
             comboBox1.DataSource= pc.confirmorder($"select med_id from Medicine where med_name='{medi}'");
                comboBox1.DisplayMember = "med_id";
                pc.med_id =Convert.ToInt32(comboBox1.Text);
                pc.qty= Convert.ToInt32(label5.Text);
                pc.sup_id = Convert.ToInt32(sup_id);
                pc.amount = Convert.ToInt32(textBox1.Text);
                DateTime tme = DateTime.Now;
                pc.date =Convert.ToString(tme);
                pc.store();
            }
            else
            {
                pc.med_id = Convert.ToInt32(med_id);
                pc.qty = Convert.ToInt32(label5.Text);
                pc.sup_id = Convert.ToInt32(sup_id);
                pc.amount = Convert.ToInt32(textBox1.Text);
                DateTime tme = DateTime.Now;
                pc.date = Convert.ToString(tme);
                pc.store();
            }
            this.Close();
        }
         private void button2_Click(object sender, EventArgs e)
        {
            AddMedForm adf = new AddMedForm();
            adf.Show();
            purchaseclass pc = new purchaseclass();
            if (med_id==null)
            {
                pc.cancelorder($"delete from Medicine where med_name='{medi}'");
                
            }
            else
            {
                pc.cancelorder($"update Medicine set med_qty='{prev_qty}',med_price='{prev_price}' where med_id='{med_id}'"); this.Close();
            }
            this.Close();
        }
        private void purchase_Load(object sender, EventArgs e)
        {
            comboBox1.Hide();
            label12.Text = medi;
            label2.Text = cate;
            label5.Text = qtys.ToString();
            label7.Text = unitpr.ToString();
            label10.Text = suppi;
            button1.Enabled = false;     
        }
    }
}
