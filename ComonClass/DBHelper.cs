using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taguma
{
    internal class DBHelper
    {
        private readonly String _connectionString;

        public DBHelper()
        {
            _connectionString = "Server=PB-B0024029\\SORIMACHI2022;Database=taguma;User ID=sa;Password=shoo0127;TrustServerCertificate=True;";
            //_connectionString = "Server=PB-B0024029\\SORIMACHI2022;Database=Taguma;Integrated Security=True;TrustServerCertificate=True;";
            //_connectionString = "Data Source=Taguma.db;";
            //_connectionString=  "Server=192.168.1.10\\SORIMACHI2022;Database=Taguma;User Id=appuser;Password=password123;TrustServerCertificate=True;";
        }
        public static string ConnectionString
        {
            get
            {
                //return  "Server=192.168.1.10\\SORIMACHI2022;Database=Taguma;User Id=appuser;Password=password123;TrustServerCertificate=True;";
                return "Server=PB-B0024029\\SORIMACHI2022;Database=taguma;User ID=sa;Password=shoo0127;TrustServerCertificate=True;";
                //    return "Server=PB-B0024029\\SORIMACHI2022;Database=Taguma;Integrated Security=True;TrustServerCertificate=True;";
                //    return "Data Source=Taguma.db;";
            }
        }

        public bool TestConnection()
        {
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public DataTable ExecuteQuery(string sql)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // INSERT/UPDATE/DELETE 実行
        public int ExecuteNonQuery(string sql)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
