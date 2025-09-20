using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taguma
{
    public partial class Dashboard : Form//シフト作成、勤怠管理、ログアウトを選ぶ画面
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void ShiftViewButton_Click(object sender, EventArgs e)//シフト作成画面に行く
        {
            Shifts shifts = new Shifts();
            shifts.Show();
            this.Hide();
        }
        private void WorkViewButton_Click(object sender, EventArgs e)//勤怠管理画面に行く
        {
            Work work = new Work();
            work.Show();
            this.Hide();

        }

        private void LogoutButton_Click(object sender, EventArgs e)//ログイン画面に戻る
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

      
    }
}
