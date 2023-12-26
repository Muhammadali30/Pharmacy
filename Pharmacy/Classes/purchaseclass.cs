using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes
{
    class purchaseclass
    {
       public int med_id,sup_id,qty;
      public  double amount;
        public string date;
        DatabaseConnection db = new DatabaseConnection();
        public DataTable confirmorder(string query)
        {
            DataTable dt= db.connectivity(query, null);
            return dt;
        }
       public void cancelorder(string query)
        {
            db.Update(query);
        }
        List<SqlParameter> param;
        void updatedetailsparams()
        {
            param = new List<SqlParameter>()
            {
                  new SqlParameter("@id",this.med_id),
                  new SqlParameter("@pq",this.qty),
                  new SqlParameter("@sid",this.sup_id),
                  new SqlParameter("@pa",this.amount),
                  new SqlParameter("@d",this.date),

            };
        }
        public void store()
        {
            updatedetailsparams();
             db.connectivity("insert into Purchase(med_id,purchase_qty,supp_id,purchase_amount,date)Values(@id,@pq,@sid,@pa,@d)", param);
           
        }
    }
}
