using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes
{
    class Medicine: IMedicine
    {
      public  string med_name;
        public string med_desc;
        public int med_price;
        public int purch_qty;
       public int cat_id;
        DatabaseConnection db = new DatabaseConnection();
        List<SqlParameter> param;
        void updateparams()
        {
            param = new List<SqlParameter>()
            {
                  new SqlParameter("@name",this.med_name),              
                  new SqlParameter("@desc",this.med_desc),
                  new SqlParameter("@price",this.med_price),
                   new SqlParameter("@qty",this.purch_qty),
                    new SqlParameter("@cat",this.cat_id),
            };
        }
        public void AddMedicine()
        {
            updateparams();
            string query = "insert into Medicine(med_name,med_description,med_qty,med_price,cat_id)values(@name,@desc,@qty,@price,@cat)";
            db.connectivity(query, param);    
        }
        public DataTable autoload(string query) {
          DataTable dt= db.connectivity(query, null);
            return dt;
        }
        public void update(string med_id)
        {
            updateparams();
            string query = $"update Medicine set med_qty='{purch_qty}',med_price='{med_price}' where med_id='{med_id}'";
            db.Update(query);
        }
       
        public DataTable searchmed(string txt,string typ)
        {
            string query;
            if (typ == string.Empty) { typ = "med_name"; }
            if (txt == null) {
                 query = @"
	select med_id,med_name,med_description,med_qty,med_price,c.cat_name from Medicine m inner join Category c
	on m.cat_id=c.cat_id";
            }
            else {  query = $@"select med_id,med_name,med_description,med_qty,med_price,c.cat_name from Medicine m inner join Category c
	on m.cat_id=c.cat_id
WHERE {typ} LIKE '{txt}%';
	"; }
            DataTable dt = db.connectivity(query, null);
            return dt;
        }
    } 
    }

