using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes
{
  sealed class DatabaseConnection
    {
        string con = "Data Source=DESKTOP-D7PJBST;Initial Catalog=pharmacy;Integrated Security=True";
        public DataTable connectivity(string query,List<SqlParameter> param){
            try
            {
                SqlConnection conn = new SqlConnection(con);
                SqlCommand camd = new SqlCommand(query, conn);
                if (param == null)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = camd;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
                else
                {
                    conn.Open();
                    camd.Parameters.AddRange(param.ToArray());
                    camd.ExecuteNonQuery();
                    conn.Close();
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception("Connection Error");
            }
        }
        public void Update(string query)
        {
            SqlConnection conn = new SqlConnection(con);
            SqlCommand camd = new SqlCommand(query, conn);
            conn.Open();
            camd.ExecuteNonQuery();
            conn.Close();
        }

        public double count(string query)
        {
            SqlConnection conn = new SqlConnection(con);
            SqlCommand camd = new SqlCommand(query, conn);
            conn.Open();
            var c=camd.ExecuteScalar();
            conn.Close();
            return Convert.ToDouble(c);
        }
        public DataTable connectivitysp(string query, List<SqlParameter> param)
        {
            try
            {
 SqlConnection conn = new SqlConnection(con);
            SqlCommand camd = new SqlCommand(query, conn);
            camd.CommandType = CommandType.StoredProcedure;
            camd.Parameters.AddRange(param.ToArray());
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = camd;
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception)
            {
                throw new Exception("Connection Error");
            } 
        }
    }
}
