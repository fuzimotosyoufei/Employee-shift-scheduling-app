using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taguma
{
    using System;
    using System.Windows.Forms;

    namespace Taguma.Utils
    {
        // ComboBox用の表示と値を持つクラス
        public class ComboItem//コンボボックスの中身を指定する共通クラス
        {
            public int Value { get; set; }      // 実際に使う数字
            public string Text { get; set; }    // 表示用
            //表示したい内容と中にもう値を分かる場合get setを使わなくてはならない
            public override string ToString() => Text; // ComboBoxに表示される文字
        }

        // 年・月 ComboBox 初期化用ヘルパー
        public static class ComboBoxHelper
        {
            // 月の初期化
            public static void InitDayComboBox(ComboBox dayComboBox,int? year,int? month)//?入るかもしれない
            {
                dayComboBox.Items.Clear();

                if (!year.HasValue || !month.HasValue)
                {
                    MessageBox.Show("年と月を先に選択してください");
                    return; // 年月が選ばれていなければ何もしない
                }
                int Day=DateTime.DaysInMonth(year.Value, month.Value);//Valueがいる外部クラスで判定するときに便利
                for (int i = 1; i <= Day; i++)
                {
                    dayComboBox.Items.Add(new ComboItem { Value = i, Text = i + "日" });
                }
                dayComboBox.SelectedIndex = DateTime.Now.Day - 1;
            }
            public static void InitMonthComboBox(ComboBox monthComboBox)
            {
                monthComboBox.Items.Clear();
                for (int i = 1; i <= 12; i++)
                {
                    monthComboBox.Items.Add(new ComboItem { Value = i, Text = i + "月" });
                }
                monthComboBox.SelectedIndex = DateTime.Now.Month-1;
            }

            // 年の初期化
            public static void InitYearComboBox(ComboBox yearComboBox, int startYear, int yearsAhead)
            {
                yearComboBox.Items.Clear();
                ComboItem selectedItem = null;

                for (int y = startYear; y <= DateTime.Now.Year + yearsAhead; y++)
                {
                    var item = new ComboItem { Value = y, Text = y + "年" };
                    yearComboBox.Items.Add(item);

                    // 現在の年と一致するComboItemを保持
                    if (y == DateTime.Now.Year)
                        selectedItem = item;
                }

                if (selectedItem != null)
                    yearComboBox.SelectedItem = selectedItem; // ComboItem を選択
            }

            // ComboBoxから数字を取得する便利メソッド
            public static int GetSelectedValue(ComboBox comboBox)
            {
                if (comboBox.SelectedItem is ComboItem item)
                    return item.Value;
                return 9; // 取得できなかった場合
            }
        }
    }

}
