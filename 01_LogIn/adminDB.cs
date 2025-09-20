using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
namespace Taguma.DBaccess
{

    internal class adminDB
    {
        private readonly String connectionString;
        private readonly bool useSQLite;
        public adminDB()//データベースにログインする文章を作る毎回使うからメゾットで作っている
        {
            //this.useSQLite = useSQLite;//自分のPC以外でも動かしたかった
            //if (useSQLite)
            //    connectionString = "Data Source=Taguma.db;";
            //else
            //    connectionString = "Server=PB-B0024029\\SORIMACHI2022;Database=Taguma;Integrated Security=True;TrustServerCertificate=True;";
            connectionString = DBHelper.ConnectionString;
        }


        //    public object GetPassword(string IDLogin)//自分のPC以外でも動かしたかった
        //    {
        //        try
        //        {
        //            if (useSQLite)
        //            {
        //                using (var conn = new System.Data.SQLite.SQLiteConnection(connectionString))
        //                {
        //                    using (var cmd = new System.Data.SQLite.SQLiteCommand("SELECT admin_password FROM admin WHERE staff_id = @staff_id", conn))
        //                    {
        //                        cmd.Parameters.AddWithValue("@staff_id", IDLogin);
        //                        conn.Open();
        //                        return cmd.ExecuteScalar();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                using (var conn = new System.Data.SqlClient.SqlConnection(connectionString))
        //                {
        //                    using (var cmd = new System.Data.SqlClient.SqlCommand("SELECT admin_password FROM admin WHERE staff_id = @staff_id", conn)) 
        //                    {
        //                        cmd.Parameters.AddWithValue("@staff_id", IDLogin);
        //                        conn.Open();
        //                        return cmd.ExecuteScalar();
        //                    }
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //}


        public object GetPassword(String IDLogin)//
        {
            using (var conn = new SqlConnection(connectionString))//コンストラクタでcoonectionStringは絶対に作っているからないのはあり得ない
            using (var cmd = new SqlCommand("SELECT admin_password FROM admin WHERE staff_id = @staff_id", conn))
            {
                conn.Open();
                try
                {
                    cmd.Parameters.AddWithValue("@staff_id", IDLogin);//ログインIDを埋める
                    object result = cmd.ExecuteScalar(); // 実行するidがないとエラーが出る
                    return result;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

    }
}
    
