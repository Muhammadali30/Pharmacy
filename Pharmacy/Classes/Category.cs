using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes
{
    class Category:ICategory
    {
        public string cat_name;
        DatabaseConnection db = new DatabaseConnection();
        List<SqlParameter> param;
        void updateparams()
        {
            param = new List<SqlParameter>()
            {
                new SqlParameter("@name",this.cat_name),
            };
        }
        public void create()
        {
            updateparams();
            string query = @"insert into Category(cat_name) 
                           values(@name)";
            db.connectivity(query, param);
        }
        public DataTable GetData()
        {
          return  db.connectivity("select * from Category", null);
        }
    }
}
