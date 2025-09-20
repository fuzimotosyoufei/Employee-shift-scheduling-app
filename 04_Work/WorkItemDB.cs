using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taguma.DBaccess
{
    internal class WorkItemDB
    {
        private readonly String connectionString;
        private ComboBox cmbYear;
        private ComboBox cmbMonth;
        private ComboBox cmbDay;
        private DataGridView workmanagementView;

        private Dictionary<string, (string start, string end, int hours)> shiftPatterns =

            new Dictionary<string, (string start, string end, int hours)>

            {

                { "A", ("08:00", "12:00", 4) },

                { "B", ("12:00", "16:00", 4) },

                { "C", ("16:00", "22:00", 6) }

            };
        public WorkItemDB(ComboBox cmbYear,ComboBox cmbMonth, ComboBox cmbDay, DataGridView workmanagementView)
        {
            this.cmbYear = cmbYear;
            this.cmbMonth = cmbMonth;
            this.cmbDay = cmbDay;
            this.workmanagementView = workmanagementView;
            connectionString = DBHelper.ConnectionString;
        }

        public void LoadShiftData(DateTime targetDate)

        {

            workmanagementView.Rows.Clear();//一回まっさらにする
            using (SqlConnection conn = new SqlConnection(connectionString))

            {

                conn.Open();
                // スタッフ一覧を取得

                string sqlStaff = "SELECT staff_id, staff_name FROM staff";

                SqlCommand cmdStaff = new SqlCommand(sqlStaff, conn);//命令文を作る

                SqlDataAdapter daStaff = new SqlDataAdapter(cmdStaff);//実行してデータグリッドビューとつなげるためのアダプタを作る

                DataTable staffTable = new DataTable();//空のDataTableを作る

                daStaff.Fill(staffTable);//これで結果を流し込む
                                         // 該当日のシフトを取得

                string sqlShift = "SELECT staff_id, shift_type FROM shiftData WHERE shift_day = @day AND shift_month = @month AND shift_year =@year";


                SqlCommand cmdShift = new SqlCommand(sqlShift, conn);

                cmdShift.Parameters.AddWithValue("@day", targetDate.Day);//年＋月＋日」がセットされた 完全な日付
                cmdShift.Parameters.AddWithValue("@month", targetDate.Month);//年＋月＋日」がセットされた 完全な日付
                cmdShift.Parameters.AddWithValue("@year", targetDate.Year);//年＋月＋日」がセットされた 完全な日付
                SqlDataAdapter daShift = new SqlDataAdapter(cmdShift);

                DataTable shiftTable = new DataTable();

                daShift.Fill(shiftTable);
                // 先に従業員の行を作る（空の行）

                foreach (DataRow staff in staffTable.Rows)//先にシフト行を作るここ変更加えたほうがいい

                {

                    string staffName = staff["staff_name"].ToString();

                    workmanagementView.Rows.Add(staffName, "", "", "", "", "");

                }
                // 各スタッフごとにシフトを埋める

                foreach (DataRow staff in staffTable.Rows)//スタッフテーブルの数分行う

                {

                    int staffId = (int)staff["staff_id"];

                    string staffName = staff["staff_name"].ToString();
                    // 追加済みの DataGridViewRow を探す

                    DataGridViewRow row = workmanagementView.Rows

                        .Cast<DataGridViewRow>()

                        .FirstOrDefault(r => r.Cells["StaffName"].Value?.ToString() == staffName);

                    if (row == null) continue;
                    DataRow[] shiftRows = shiftTable.Select($"staff_id = {staffId}");//該当シフト取得は絶対に1件か0かだから成立する
                    if (shiftRows.Length > 0)

                    {

                        string pattern = shiftRows[0]["shift_type"].ToString();//A,B,Cかそれ以外を取り出すここTypeに変える

                        var (start, end, hours) = shiftPatterns.ContainsKey(pattern)//shiftPatternsにTypeを入れて該当するなら  ? shiftPatterns[pattern]該当しないなら : ("-", "-", 0);がvar (start, end, hours)に代入される

                            ? shiftPatterns[pattern]

                            : ("-", "-", 0);
                        row.Cells["WorkType"].Value = "出社";

                        row.Cells["ShiftPattern"].Value = pattern;

                        row.Cells["StartTime"].Value = start;

                        row.Cells["EndTime"].Value = end;

                        row.Cells["WorkHours"].Value = $"{hours}:00";

                    }

                    else

                    {

                        row.Cells["WorkType"].Value = "休日";

                        row.Cells["ShiftPattern"].Value = "-";

                        row.Cells["StartTime"].Value = "-";

                        row.Cells["EndTime"].Value = "-";

                        row.Cells["WorkHours"].Value = "-";

                    }

                }

            }
        }
    }
}
