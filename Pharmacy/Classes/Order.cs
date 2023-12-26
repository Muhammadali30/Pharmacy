using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes
{
    class Order
    {
       public int amount, discount,tax,oid,mid,qty;
      public  string Date;
        DatabaseConnection db = new DatabaseConnection();
        List<SqlParameter> param;
        void updateparams()
        {
            param = new List<SqlParameter>()
            {
                  new SqlParameter("@amo",this.amount),
                  new SqlParameter("@tax",this.tax),
                  new SqlParameter("@discount",this.discount),
                   new SqlParameter("@Date",this.Date),
               
            };
        }
        public void GetOrder()
        {
            updateparams();
            db.connectivity("insert into orders(amount,tax,discount,Datee)values(@amo,@tax,@discount,@Date)", param);
        }
        public DataTable getid()
        {
          DataTable dt=  db.connectivity($"select order_id from orders where Datee='{Date}'", null);
            return dt;
        }
        public DataTable GetMedID(string name)
        {
            Medicine md = new Medicine();
            DataTable dt= md.autoload($"select med_id from Medicine where med_name='{name}'");
            return dt;
        }
        void updatedetailsparams()
        {
            param = new List<SqlParameter>()
            {
                  new SqlParameter("@oid",this.oid),
                  new SqlParameter("@mid",this.mid),
                  new SqlParameter("@qty",this.qty),
            };
        }
        public void GetOrder_details()
        {
            updatedetailsparams();
            db.connectivity("insert into order_details(order_id,med_id,quantity)values(@oid,@mid,@qty)", param);
        }
        public DataTable Order_details()
        {
            DataTable dt = db.connectivity($"select * from orders",null);
            return dt;
        }
        public DataTable Order_details(int id)
        {
            DataTable dt = db.connectivity($@"
    select med_name, quantity,med_price from order_details od inner
      join Medicine m on od.med_id = m.med_id   where order_id='{id}'", null);
            return dt;
        }
        public void update(string name,int qty)
        {
            DataTable dt = db.connectivity($@"
    update Medicine set med_qty='{qty}'  where med_name='{name}'", null);
        }
    }
}
