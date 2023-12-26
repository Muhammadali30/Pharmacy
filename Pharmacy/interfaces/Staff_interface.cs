using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.interfaces
{
    interface Staff_interface
    {
        void picstore();
        DataTable GetPic();
        DataTable GetPicbyid(int id);
        void AddStaff();
        void delete(int pic_id);
        void update(int pic_id);
        DataTable GetStaff();
    }
}
