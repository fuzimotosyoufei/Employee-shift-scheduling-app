using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taguma
{
    public class ShiftTableBuilder
    {
        // DataTable生成用メソッド
        private DataTable table;
        public DataTable BuildShiftTable(int year, int month, DataTable staffData, DataTable shiftData)
        {

            DataTable table = new DataTable();


            // 名前列
            table.Columns.Add("名前");


            // 2025年9月を例に

            table.Rows.Add("");
            DateTime firstDay = new DateTime(year, month, 1);//DataTimeクラスは(年,月,日)を2025/09/01みたいに firstDayに代入している
            int daysInMonth = DateTime.DaysInMonth(year, month);//DataTime.DaysInMonth(年、月)を指定すればその月の日数を取得できるこの場合(30)
            //table.Rows.Add("");

            // 日付＋曜日を列に追加
            for (int d = 0; d < daysInMonth; d++)//int dを0から29日まで行う
            {
                DateTime day = firstDay.AddDays(d);//firesDayにd日足した日にちをdayに代入つまりどんどん日にちだけが追加されていく
                string header = $"{day.Month}/{day.Day}({GetDayOfWeekJP(day.DayOfWeek)})";//headerにday.Monthで月 day.Dayで日にち GetDayOfWeekJP(day.DayOfWeek) で英語で取得する曜日を外部メゾットを使用し日本語にして返している
                string header2 = $"({GetDayOfWeekJP(day.DayOfWeek)}";
                table.Columns.Add(header);//table.Coumns.Add(header)でヘッダーに代入している
                //table.Columns.Add("dummy" + d); // 名前列を除いてユニーク名を付与時間があったら
            }

            foreach (DataRow row in staffData.Rows)
            {
                String staffName = row["staff_name"].ToString();//スタッフネームだけを取ってくる
                var newRow = table.NewRow();//新しい行を作っている
                newRow["名前"] = staffName;
                table.Rows.Add(newRow);//新しい行を作っているから列を指定しなくてはならない
            }
            foreach (DataRow shiftRow in shiftData.Rows)//１行を取り出しながらなくなるまで実行している
            {
                String stafNmae = shiftRow["staff_name"].ToString();
                int day = Convert.ToInt32(shiftRow["shift_day"]);
                String shiftType = shiftRow["shift_type"].ToString();

                foreach (DataRow row in table.Rows)//tableに入っている行数
                {
                    if (row["名前"].ToString() == stafNmae)
                    {
                        DateTime targetDate = new DateTime(year, month, day);//判定できるようにyearとmonthを足して作っているここを変えたら応用が利きそう
                        string colName = $"{targetDate.Month}/{targetDate.Day}({GetDayOfWeekJP(targetDate.DayOfWeek)})";
                        string colName2 = (GetDayOfWeekJP(targetDate.DayOfWeek));
                        row[colName] = shiftType;
                        break;
                    }
                }
            }
            for (int i = 0; i < daysInMonth; i++)
            {
                table.Rows[0][i + 1] = i + 1;//改良の余地あり day.Dayが使えるかも
            }




            // DataGridViewに反映

            return table;
        }

        // 曜日を日本語に変換
        private string GetDayOfWeekJP(DayOfWeek dow)
        {

            switch (dow)
            {
                case DayOfWeek.Sunday: return "日";
                case DayOfWeek.Monday: return "月";
                case DayOfWeek.Tuesday: return "火";
                case DayOfWeek.Wednesday: return "水";
                case DayOfWeek.Thursday: return "木";
                case DayOfWeek.Friday: return "金";
                case DayOfWeek.Saturday: return "土";
                default: return "";
            }
        }

    }
}

