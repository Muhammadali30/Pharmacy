using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    interface ICategory
    {
        void create();
        DataTable GetData();
    }
}
