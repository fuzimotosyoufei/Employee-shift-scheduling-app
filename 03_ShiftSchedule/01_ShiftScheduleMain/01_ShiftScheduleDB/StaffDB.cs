using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taguma.DBaccess
{
    internal class StaffDB
    {
        private readonly String connectionString;

        public StaffDB()
        {

            connectionString = DBHelper.ConnectionString;
        }
        public DataTable Getstaff()
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                DataTable staffData = new DataTable();//田中 25こんな感じで入る箱を作っている
                string sqlStaff = "SELECT staff_id, staff_name FROM staff";
                SqlDataAdapter daStaff = new SqlDataAdapter(sqlStaff, con);
                daStaff.Fill(staffData);
                return staffData;
            }
        }
        public DataTable Getshift(int year, int month)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                DataTable shiftData = new DataTable();
                string sqlShift = @"
                    SELECT s.staff_name, sh.shift_day, sh.shift_month,sh.shift_year,sh.shift_type
                    FROM shiftData sh
                    INNER JOIN staff s ON sh.staff_id = s.staff_id
                    WHERE sh.shift_month = @month AND sh.shift_year =@year";
                SqlDataAdapter daShift = new SqlDataAdapter(sqlShift, con);//SqlDataAdapterはSQL文を代入してもらっているだけ
                daShift.SelectCommand.Parameters.AddWithValue("@month", month);//すぐに実行できないから保持するためSelectCommandがいる
                daShift.SelectCommand.Parameters.AddWithValue("@year", year);//すぐに実行できないから保持するためSelectCommandがいる
                daShift.Fill(shiftData);
                return shiftData;
            }
        }
        public DataTable GetstaffL()
        {
            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();
                DataTable staffData = new DataTable();
                string sqlStaff = "SELECT staff_id, staff_name FROM staff";
                using (var daStaff = new SQLiteDataAdapter(sqlStaff, con))
                {
                    daStaff.Fill(staffData);
                }
                return staffData;
            }
        }

        // shiftData 取得
        public DataTable GetshiftL(int year, int month)
        {
            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();
                DataTable shiftData = new DataTable();
                string sqlShift = @"
                    SELECT s.staff_name, sh.shift_day, sh.shift_month, sh.shift_year, sh.shift_type
                    FROM shiftData sh
                    INNER JOIN staff s ON sh.staff_id = s.staff_id
                    WHERE sh.shift_month = @month AND sh.shift_year = @year";

                using (var cmd = new SQLiteCommand(sqlShift, con))
                {
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);

                    using (var daShift = new SQLiteDataAdapter(cmd))
                    {
                        daShift.Fill(shiftData);
                    }
                }

                return shiftData;
            }
        }
    }
}
