using Pharmacy.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class authentication
    {
        public string uname, pass;
        DatabaseConnection db = new DatabaseConnection();
        List<SqlParameter> param;
        void updateparams()
        {
            param = new List<SqlParameter>()
            {
                new SqlParameter("@username",this.uname),
                new SqlParameter("@password",this.pass)
            };
        }
        public DataTable login()
        {
 updateparams();
            DataTable dt = db.connectivitysp("loginuser",param);
            return dt;
           
           
        }
    }
}
