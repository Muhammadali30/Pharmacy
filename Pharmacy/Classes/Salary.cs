using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes
{
    class Salary
    {
        public DataTable GetSalary()
        {
            DatabaseConnection db = new DatabaseConnection();
            DataTable dt = db.connectivity("select * from salary", null);
            return dt;
        }
    }
}
