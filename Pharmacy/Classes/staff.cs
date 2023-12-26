using Pharmacy.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes
{
    class staff:Staff_interface
    {
        public string name, email, gender, phone,pic;
       public int age, sal_id,pic_id;
        DatabaseConnection db = new DatabaseConnection();
        List<SqlParameter> param;
        void updateparams()
        {
            param = new List<SqlParameter>()
            {
                  new SqlParameter("@name",this.name),
                  new SqlParameter("@email",this.email),
                  new SqlParameter("@gender",this.gender),
                   new SqlParameter("@phone",this.phone),
                    new SqlParameter("@age",this.age),
                    new SqlParameter("@sal_id",this.sal_id),
                    new SqlParameter("@pic",this.pic_id),
            };
        }
        void picupdateparams()
        {
            param = new List<SqlParameter>()
            {
                  new SqlParameter("@pic",this.pic),
            };
        }
        public void picstore()
        {
            picupdateparams();
            DataTable dt = db.connectivity($"insert into pictures(pic_name)values(@pic)", param);
        }
        public  DataTable  GetPic()
        {
          DataTable dt=  db.connectivity($"select * from pictures where pic_name='{pic}'",null);
            return dt;
        }
        public DataTable GetPicbyid(int id)
        {
            DataTable dt = db.connectivity($"select * from pictures where pic_id='{id}'", null);
            return dt;
        }
        public void AddStaff()
        {
            updateparams();
            db.connectivity("insert into staff(staff_name,age,phoneno,email,salary_id,pic_id,gender)values(@name,@age,@phone,@email,@sal_id,@pic,@gender)", param);
        }
        public DataTable GetStaff()
        {
            DataTable dt = db.connectivity($@"select staff_id, staff_name, age,gender, email,phoneno, s.salary,pic_id from staff st inner
join salary s on st.salary_id = s.salary_id", null);
            return dt;
        }
        public void delete(int pic_id)
        {
             db.connectivity($@"delete from staff where pic_id='{pic_id}'", null);         
        }

        List<SqlParameter> p;
        void updatep()
        {
            p = new List<SqlParameter>()
            {
                  new SqlParameter("@name",this.name),
                  new SqlParameter("@email",this.email),
                  new SqlParameter("@gender",this.gender),
                   new SqlParameter("@phone",this.phone),
                    new SqlParameter("@age",this.age),
            };
        }
        public void update(int pic_id)
        {
            updatep();
            db.connectivity($@"update staff set staff_name=@name,age=@age,phoneno=@phone,email=@email,gender=@gender where pic_id='{pic_id}'", p);
        }
    }

}
