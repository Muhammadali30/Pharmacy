using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    interface IMedicine
    {
        void AddMedicine();
        DataTable autoload(string query);
        void update(string med_id);
        DataTable searchmed(string txt, string typ);
    }
}
