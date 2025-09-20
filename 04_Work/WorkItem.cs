using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taguma.DBaccess;
using Taguma.Taguma.Utils;


namespace Taguma
{
    internal class WorkItem
    {
        private ComboBox cmbMonth;
        private ComboBox cmbDay;
        private ComboBox cmbYear;
        private DataGridView workmanagementView;
        WorkItemDB workItem;
        public WorkItem(ComboBox cmbYear ,ComboBox cmbMonth, ComboBox cmbDay, DataGridView workmanagementView)
        {
            this.cmbYear = cmbYear;
            this.cmbMonth = cmbMonth;
            this.cmbDay = cmbDay;
            this.workmanagementView = workmanagementView;
            
            workItem = new WorkItemDB(cmbYear,cmbMonth,cmbDay,workmanagementView);
        }
        public void InitializeComboBoxes()//年月日にちを指定するコンボボックスの中身を指定する
        {
           
            ComboBoxHelper.InitYearComboBox(cmbYear, 2020, 2030);
            ComboBoxHelper.InitMonthComboBox(cmbMonth);
            int year = ComboBoxHelper.GetSelectedValue(cmbYear);
            int month = ComboBoxHelper.GetSelectedValue(cmbMonth);
            ComboBoxHelper.InitDayComboBox(cmbDay,year,month);

           
            cmbYear.SelectedIndexChanged += (s, e) => TryLoadShiftData();
            cmbMonth.SelectedIndexChanged += (s, e) => TryLoadShiftData();

            cmbDay.SelectedIndexChanged += (s, e) => TryLoadShiftData();

            DateTime today = DateTime.Now;
           
        }
        public void InitializeGrid()//データグリッドビューの中身を指定

        {

            workmanagementView.Columns.Clear();

            workmanagementView.AutoGenerateColumns = false;
            workmanagementView.Columns.Add(new DataGridViewTextBoxColumn()

            {

                Name = "StaffName",

                HeaderText = "スタッフ名",

                ReadOnly = true

            });
            workmanagementView.Columns.Add(new DataGridViewTextBoxColumn()

            {

                Name = "WorkType",

                HeaderText = "勤務区分",

                ReadOnly = true

            });
            workmanagementView.Columns.Add(new DataGridViewTextBoxColumn()

            {

                Name = "ShiftPattern",

                HeaderText = "勤務パターン",

                ReadOnly = true

            });
            workmanagementView.Columns.Add(new DataGridViewTextBoxColumn()

            {

                Name = "StartTime",

                HeaderText = "出社時間",

                ReadOnly = true

            });
            workmanagementView.Columns.Add(new DataGridViewTextBoxColumn()

            {

                Name = "EndTime",

                HeaderText = "退社時間",

                ReadOnly = true

            });
            workmanagementView.Columns.Add(new DataGridViewTextBoxColumn()

            {

                Name = "WorkHours",

                HeaderText = "実働時間",

                ReadOnly = true

            });

        }
        private void TryLoadShiftData()//コンボボックスの値からどの日のシフト表を表示するか指定する

        {

            if (cmbYear.SelectedIndex<0 ||cmbMonth.SelectedIndex < 0 || cmbDay.SelectedIndex < 0) return;//絶対に数字が入るから成立する月も日も両方選ばれてないとダメ

            int year = ComboBoxHelper.GetSelectedValue(cmbYear);
            int month = ComboBoxHelper.GetSelectedValue(cmbMonth);
            int day = ComboBoxHelper.GetSelectedValue(cmbDay);

            try

            {

                DateTime targetDate = new DateTime(year, month, day);//DateTime型にしてシフト取得の時に取り出すため

                workItem.LoadShiftData(targetDate);//シフトを取得するために引数を渡している

            }

            catch//そんな月が存在しなっかった時のトライキャッチ文

            {

                workmanagementView.Rows.Clear();//Rows.Clear()表示中のシフトをまっさらにする

                MessageBox.Show("存在しない日付が選択されています。");

            }

        }
    }
}
