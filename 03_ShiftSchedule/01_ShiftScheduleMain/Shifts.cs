using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taguma.DBaccess;
using Taguma.Taguma.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Taguma.DBaccess.StaffDB;


namespace Taguma
{

    public partial class Shifts : Form
    {
        private DataTable table;
        private readonly StaffDB staffconnct;
        private readonly ShiftTableBuilder builger;
        private readonly ShiftDB GetShift;
        private bool isLoading = true;
        public Shifts()
        {
            InitializeComponent();
            var db = new DBHelper();
            staffconnct = new StaffDB();
            GetShift = new ShiftDB();
            builger = new ShiftTableBuilder();



            //if (db.TestConnection())
            //{
            //    MessageBox.Show("接続成功！");
            //    var dt = db.ExecuteQuery("SELECT * FROM staff");
            //    shiftView.DataSource = dt;

            //}
            //else
            //{
            //    MessageBox.Show("接続失敗…");
            //}
        }


        private void Shifts_Load(object sender, EventArgs e)
        {
            isLoading = true;
            //MonthComboBox.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });//外部クラスComboItemに移動
            //for (int years = 2020; years <= DateTime.Now.Year + 10; years++) { YearComboBox.Items.Add(years); }
            //MonthComboBox.SelectedIndex = DateTime.Now.Month - 1;
            //YearComboBox.SelectedItem = DateTime.Now.Year;
            //int month = (int)MonthComboBox.SelectedItem;
            //int year = (int)YearComboBox.SelectedItem;
           
            ComboBoxHelper.InitYearComboBox(YearComboBox, 2020, 2030);
            ComboBoxHelper.InitMonthComboBox(MonthComboBox);
            shiftView.AutoGenerateColumns = true;//列の自動生成をするようにする
            int year = ComboBoxHelper.GetSelectedValue(YearComboBox);
            int month = ComboBoxHelper.GetSelectedValue(MonthComboBox);
            var builder = new ShiftTableBuilder();
            RefreshShiftDate();
            isLoading = false;
        }
        private void MonthComboBox_SelectedIndexChanged(object sender, EventArgs e)//変わったとき
        {
           
            if (isLoading) return;
            RefreshShiftDate();

        }
        private void YearComboBox_SelectedIndexChanged(object sender, EventArgs e)//変わったとき
        {
            
            if (isLoading) return;
            RefreshShiftDate();

        }
        private void RefreshShiftDate()
        {
            int year = ComboBoxHelper.GetSelectedValue(YearComboBox);
            int month = ComboBoxHelper.GetSelectedValue(MonthComboBox);
            DataTable staffData = new DataTable();//田中 25こんな感じで入る箱を作っている
            DataTable shiftData = new DataTable();
            staffData = staffconnct.Getstaff();
            shiftData = staffconnct.Getshift(year, month);
            //staffData = staffconnct.GetstaffL();
            //shiftData = staffconnct.GetshiftL(year, month);
            table = builger.BuildShiftTable(year, month, staffData, shiftData);
            shiftView.DataSource = table;
        }
        //private string GetDayOfWeekJP(DayOfWeek dow)//英語を日本語に変換している//ShiftTableBuilderクラスに移動
        //{
        //    switch (dow)
        //    {
        //        case DayOfWeek.Sunday: return "日";
        //        case DayOfWeek.Monday: return "月";
        //        case DayOfWeek.Tuesday: return "火";
        //        case DayOfWeek.Wednesday: return "水";
        //        case DayOfWeek.Thursday: return "木";
        //        case DayOfWeek.Friday: return "金";
        //        case DayOfWeek.Saturday: return "土";
        //        default: return "";
        //    }
        //}


        //private void LoadShiftTable(int year,int month)
        //{

        //    string connectionString = "Server=PB-B0024029\\SORIMACHI2022;Database=Taguma;Integrated Security=True;TrustServerCertificate=True;";
        //    DataTable staffData = new DataTable();//田中 25こんな感じで入る箱を作っている
        //    DataTable shiftData = new DataTable();

        //   staffData = staffconnct.Getstaff();
        //   shiftData = staffconnct.Getshift(month);
        //    table = new DataTable();


        //    // 名前列
        //    table.Columns.Add("名前");


        //    // 2025年9月を例に

        //    table.Rows.Add("");
        //    DateTime firstDay = new DateTime(year, month, 1);//DataTimeクラスは(年,月,日)を2025/09/01みたいに firstDayに代入している
        //    int daysInMonth = DateTime.DaysInMonth(year, month);//DataTime.DaysInMonth(年、月)を指定すればその月の日数を取得できるこの場合(30)
        //    //table.Rows.Add("");

        //    // 日付＋曜日を列に追加
        //    for (int d = 0; d < daysInMonth; d++)//int dを0から29日まで行う
        //    {
        //        DateTime day = firstDay.AddDays(d);//firesDayにd日足した日にちをdayに代入つまりどんどん日にちだけが追加されていく
        //        string header = $"{day.Month}/{day.Day}({GetDayOfWeekJP(day.DayOfWeek)})";//headerにday.Monthで月 day.Dayで日にち GetDayOfWeekJP(day.DayOfWeek) で英語で取得する曜日を外部メゾットを使用し日本語にして返している
        //        string header2 = $"({GetDayOfWeekJP(day.DayOfWeek)}" ;
        //        table.Columns.Add(header);//table.Coumns.Add(header)でヘッダーに代入している
        //        //table.Columns.Add("dummy" + d); // 名前列を除いてユニーク名を付与時間があったら
        //    }

        //    foreach (DataRow row in staffData.Rows)
        //    {
        //        String staffName = row["staff_name"].ToString();//スタッフネームだけを取ってくる
        //        var newRow = table.NewRow();//新しい行を作っている
        //        newRow["名前"] = staffName;
        //        table.Rows.Add(newRow);//新しい行を作っているから列を指定しなくてはならない
        //    }
        //    foreach (DataRow shiftRow in shiftData.Rows)//１行を取り出しながらなくなるまで実行している
        //    {
        //        String stafNmae = shiftRow["staff_name"].ToString();
        //        int day = Convert.ToInt32(shiftRow["shift_day"]);
        //        String shiftType = shiftRow["shift_type"].ToString();

        //        foreach (DataRow row in table.Rows)//tableに入っている行数
        //        {
        //            if (row["名前"].ToString() == stafNmae)
        //            {
        //                DateTime targetDate = new DateTime(year, month, day);//判定できるようにyearとmonthを足して作っているここを変えたら応用が利きそう
        //                string colName = $"{targetDate.Month}/{targetDate.Day}({GetDayOfWeekJP(targetDate.DayOfWeek)})";
        //                string colName2 = ( GetDayOfWeekJP(targetDate.DayOfWeek));
        //                row[colName] = shiftType;
        //                break;
        //            }
        //        }
        //    }
        //    for (int i = 0; i < daysInMonth; i++)
        //    {
        //        table.Rows[0][i + 1] = i + 1;//改良の余地あり day.Dayが使えるかも
        //    }




        //    // DataGridViewに反映
        //    shiftView.AutoGenerateColumns = true;
        //    shiftView.DataSource = table;
        //}

        private void btnSave_Click_1(object sender, EventArgs e)//外部クラスにするのが難しかった
        {
            foreach (DataRow row in table.Rows)//データグリッドビューの行分繰り返す
            {
                if (row == table.Rows[0]) continue;

                string staffName = row["名前"].ToString();//名前を取り出す

                foreach (DataColumn col in table.Columns)//列分繰り返す
                {
                    if (col.ColumnName == "名前") continue; // 名前列は飛ばす

                    string shiftType = row[col.ColumnName].ToString();//colの列の名前を取り出しているここ需要rowで行が固定されてその列つまり曜日だけ移動している row行 Col.COlumnName列名
                    if (!string.IsNullOrEmpty(shiftType))//取り出した列に何かしら文字が入っていたら実行する
                    {

                        int year = ComboBoxHelper.GetSelectedValue(YearComboBox);

                        // 日付部分を取り出す
                        //string[] parts = col.ColumnName.Split('(')[0].Split('/');//列名の分解
                        int month = ComboBoxHelper.GetSelectedValue(MonthComboBox);
                        //int day = int.Parse(parts[1]);//3日
                        int columnIndex = table.Columns.IndexOf(col.ColumnName); // 列番号を取得
                        int day = 0;
                        object cellValue = table.Rows[0][columnIndex]; // 0行目のその列の値
                        if (cellValue != DBNull.Value)
                        {
                            int.TryParse(cellValue.ToString(), out day);
                        }
                        DateTime targetDate = new DateTime(year, month, day);

                        GetShift.AddShiftDB(staffName, targetDate, shiftType);//列名と曜日とAとかBとかCを入れてメゾットの実行
                        //targetDateを月と日だけに分解して入れてもいいかも
                    }
                    else
                    {
                        int columnIndex = table.Columns.IndexOf(col.ColumnName); // 列番号を取得
                        int day = 0;
                        object cellValue = table.Rows[0][columnIndex]; // 0行目のその列の値
                        int year = ComboBoxHelper.GetSelectedValue(YearComboBox);
                        int month = ComboBoxHelper.GetSelectedValue(MonthComboBox);
                        if (cellValue != DBNull.Value)
                        {
                            int.TryParse(cellValue.ToString(), out day);
                        }

                        DateTime targetDate = new DateTime(year, month, day);
                        GetShift.DeleteShiftDB(staffName, targetDate);
                    }
                }
            }

            MessageBox.Show("保存が完了しました！");
        }
        private void DeleteButton_Click(object sender, EventArgs e)//選択したセルの1列を消す
        {

            // セルが選択されているか確認
            if (shiftView.SelectedCells.Count > 0)
            {
                // 選択されている最初のセルを取得
                DataGridViewCell cell = shiftView.SelectedCells[0];

                // そのセルが属する列を取得
                DataGridViewColumn col = cell.OwningColumn;
                if (col.Index == 0)
                {
                    MessageBox.Show("この列は削除できません。");
                    return;
                }

                // 列を削除
                for (int r = 1; r < shiftView.Rows.Count; r++)
                {
                    shiftView.Rows[r].Cells[col.Index].Value = null;
                }
            }
            else
            {
                MessageBox.Show("削除するセルを選択してください。");
            }
        }

        //private void SaveShiftToDatabase(string staffName, DateTime date, string shiftType)//ShiftsDBクラスに移動
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))//SQLのデータベースに接続したやつをconnに代入している
        //    {
        //        conn.Open();

        //        // staff_id を staffName から取得
        //        string getStaffIdSql = "SELECT staff_id FROM staff  WHERE staff_name = @name ";
        //        SqlCommand getStaffIdCmd = new SqlCommand(getStaffIdSql, conn);//SqlCoomandには まずgetStaffIdSqlに代入した実行するSQL文とconnで指定したデータベースと@nameみたいなまだ値の入ってないやつが入る
        //        getStaffIdCmd.Parameters.AddWithValue("@name", staffName);//ここで@nameが何なのかを指定しているstaff_idのstaffNameで指定した名前のstaff_idから取ってくる
        //        int staffId = (int)getStaffIdCmd.ExecuteScalar();//整数でidを受け取っている

        //        // すでにその日付のシフトがあるか確認
        //        string checkSql = "SELECT COUNT(*) FROM shiftData WHERE staff_id = @id AND shift_day = @day AND shift_month = @month";
        //        SqlCommand checkCmd = new SqlCommand(checkSql, conn);//SqlCommnadSQL文が実行される
        //        checkCmd.Parameters.AddWithValue("@id", staffId);//SQL文が実行されるからSelectCommandがいらない
        //        checkCmd.Parameters.AddWithValue("@day", date.Day);
        //        checkCmd.Parameters.AddWithValue("@month", date.Month);
        //        int count = (int)checkCmd.ExecuteScalar();//実行したプログラムの結果を代入//COUNTでSELECT文に対応するデータベースの行数が出てくる1ならもう同じのがあり0ならない

        //        if (count > 0)
        //        {
        //            // 更新
        //            string updateSql = "UPDATE shiftData SET shift_type = @type WHERE staff_id = @id AND shift_day = @day AND shift_month = @month";
        //            SqlCommand updateCmd = new SqlCommand(updateSql, conn);
        //            updateCmd.Parameters.AddWithValue("@type", shiftType);
        //            updateCmd.Parameters.AddWithValue("@id", staffId);
        //            updateCmd.Parameters.AddWithValue("@day", date.Day);
        //            updateCmd.Parameters.AddWithValue("month",date.Month);
        //            updateCmd.ExecuteNonQuery();//実行された列を返す　実行されたかを確かめるためにある
        //        }
        //        else
        //        {
        //            // 追加
        //            string insertSql = "INSERT INTO shiftData (staff_id, shift_day, shift_type,shift_month) VALUES (@id, @day, @type,@month)";
        //            SqlCommand insertCmd = new SqlCommand(insertSql, conn);
        //            insertCmd.Parameters.AddWithValue("@id", staffId);
        //            insertCmd.Parameters.AddWithValue("@day", date.Day);
        //            insertCmd.Parameters.AddWithValue("@type", shiftType);
        //            insertCmd.Parameters.AddWithValue("@month",date.Month);
        //            insertCmd.ExecuteNonQuery();

        //        }
        //    }
        //}
        //private void DeleteShiftFromToDatabase(string stafName, int month,int day)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        String getStaffIdSql = "SELECT staff_id FROM staff WHERE staff_name = @name";
        //        SqlCommand getStaffIdComd = new SqlCommand(getStaffIdSql, conn);
        //        getStaffIdComd.Parameters.AddWithValue("@name",stafName);
        //        int staffId = (int)getStaffIdComd.ExecuteScalar() ;//値を返す



        //        String deleteSql = "DELETE FROM shiftData  WHERE staff_id = @id　AND shift_month = @month AND shift_day = @day  ";
        //        SqlCommand deleteCmd = new SqlCommand(deleteSql, conn);
        //        deleteCmd.Parameters.AddWithValue("@id", staffId);
        //        deleteCmd.Parameters.AddWithValue("@month",month);
        //        deleteCmd.Parameters.AddWithValue("@day", day);
        //        deleteCmd.ExecuteNonQuery();//行数を教える
        //    }
        //}



        private void AddButton_Click(object sender, EventArgs e)//スタッフ登録のStaffRegistrationを開く
        {
            // サブフォームを生成
            ShiftHope f2 = new ShiftHope();

            // 親フォームを閉じずに開く
            f2.Show();
        }

        private void Registration_Click(object sender, EventArgs e)//シフト希望確認のShiftHopeを開く
        {
            StaffRegistration registration = new StaffRegistration();
            registration.Show();

        }

        private void ReturnButton_Click(object sender, EventArgs e)//ダッシュボードに戻る
        {
            Dashboard s = new Dashboard();
            s.Show();
            this.Close();
        }



    }
}
