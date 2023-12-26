using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes
{
    class Supplier
    {
       public string supplier_name;
      public  string supplier_contact;
        DatabaseConnection db = new DatabaseConnection();
        List<SqlParameter> param;
        void updateparams()
        {
            param = new List<SqlParameter>()
            {
                new SqlParameter("@name",this.supplier_name),
                new SqlParameter("@contact",this.supplier_contact),
            };
        }
       public void create()
        {
            updateparams();
         
            string query = @"insert into supplier(supp_name,supp_contact) 
                           values(@name,@contact)";
            db.connectivity(query, param);
        }
       
       
        public DataTable search(string txt)
        {
            string query;
            if (txt==null) { query = @"select * from supplier"; }
            else {  query = $@"select * from supplier WHERE supp_name LIKE '{txt}%'"; }
  
            DataTable dt = db.connectivity(query, null);
            return dt;
        }
    }
}
