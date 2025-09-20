using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Taguma.DBaccess
{
    internal class ShiftDB
    {
        private readonly String connectionString;
    
        public ShiftDB()
        {
            connectionString = DBHelper.ConnectionString;
        }
        public void AddShiftDB(String staffName,DateTime targetDate,String shiftType)
        {
             using (SqlConnection conn = new SqlConnection(connectionString))//SQLのデータベースに接続したやつをconnに代入している
            {
                conn.Open();

                // staff_id を staffName から取得
                string getStaffIdSql = "SELECT staff_id FROM staff  WHERE staff_name = @name ";
                SqlCommand getStaffIdCmd = new SqlCommand(getStaffIdSql, conn);//SqlCoomandには まずgetStaffIdSqlに代入した実行するSQL文とconnで指定したデータベースと@nameみたいなまだ値の入ってないやつが入る
                getStaffIdCmd.Parameters.AddWithValue("@name", staffName);//ここで@nameが何なのかを指定しているstaff_idのstaffNameで指定した名前のstaff_idから取ってくる
                int staffId = (int)getStaffIdCmd.ExecuteScalar();//整数でidを受け取っている

                // すでにその日付のシフトがあるか確認
                string checkSql = "SELECT COUNT(*) FROM shiftData WHERE staff_id = @id AND shift_day = @day AND shift_month = @month AND shift_year = @year";
                SqlCommand checkCmd = new SqlCommand(checkSql, conn);//SqlCommnadSQL文が実行される
                checkCmd.Parameters.AddWithValue("@id", staffId);//SQL文が実行されるからSelectCommandがいらない
                checkCmd.Parameters.AddWithValue("@year", targetDate.Year);
                checkCmd.Parameters.AddWithValue("@day", targetDate.Day);
                checkCmd.Parameters.AddWithValue("@month", targetDate.Month);
                int count = (int)checkCmd.ExecuteScalar();//実行したプログラムの結果を代入//COUNTでSELECT文に対応するデータベースの行数が出てくる1ならもう同じのがあり0ならない

                if (count > 0)
                {
                    // 更新
                    string updateSql = "UPDATE shiftData SET shift_type = @type WHERE staff_id = @id AND shift_day = @day AND shift_month = @month AND shift_year = @year";
                    SqlCommand updateCmd = new SqlCommand(updateSql, conn);
                    updateCmd.Parameters.AddWithValue("@type", shiftType);
                    updateCmd.Parameters.AddWithValue("@id", staffId);
                    updateCmd.Parameters.AddWithValue("@year", targetDate.Year);
                    updateCmd.Parameters.AddWithValue("@day", targetDate.Day);
                    updateCmd.Parameters.AddWithValue("month",targetDate.Month);
                    updateCmd.ExecuteNonQuery();//実行された列を返す　実行されたかを確かめるためにある
                }
                else
                {
                    // 追加
                    string insertSql = "INSERT INTO shiftData (staff_id, shift_day, shift_type,shift_month,shift_year) VALUES (@id, @day, @type,@month,@year)";
                    SqlCommand insertCmd = new SqlCommand(insertSql, conn);
                    insertCmd.Parameters.AddWithValue("@id", staffId);
                    insertCmd.Parameters.AddWithValue("@year", targetDate.Year);
                    insertCmd.Parameters.AddWithValue("@day", targetDate.Day);
                    insertCmd.Parameters.AddWithValue("@type", shiftType);
                    insertCmd.Parameters.AddWithValue("@month",targetDate.Month);
                    insertCmd.ExecuteNonQuery();
                    
                }
            }
        }
        public void DeleteShiftDB(string stafName,DateTime targetDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String getStaffIdSql = "SELECT staff_id FROM staff WHERE staff_name = @name";
                SqlCommand getStaffIdComd = new SqlCommand(getStaffIdSql, conn);
                getStaffIdComd.Parameters.AddWithValue("@name", stafName);
                int staffId = (int)getStaffIdComd.ExecuteScalar();//値を返す



                String deleteSql = "DELETE FROM shiftData  WHERE staff_id = @id　AND shift_month = @month AND shift_day = @day AND shift_year = @year ";
                SqlCommand deleteCmd = new SqlCommand(deleteSql, conn);
                deleteCmd.Parameters.AddWithValue("@id", staffId);
                deleteCmd.Parameters.AddWithValue("@year", targetDate.Year);
                deleteCmd.Parameters.AddWithValue("@month", targetDate.Month);
                deleteCmd.Parameters.AddWithValue("@day", targetDate.Day);
                deleteCmd.ExecuteNonQuery();//行数を教える
            }
        }
        


    }
}
