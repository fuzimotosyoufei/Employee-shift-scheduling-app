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
    public partial class ShiftHope : Form//スタッフ用のアプリから遅れれてくるシフト希望を見る画面スタッフ用のアプリは作っておらず何も機能を持っていない
    {
        public ShiftHope()
        {
            InitializeComponent();
        }

       

        private void ReturnButton_Click2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {

        }
    }
}
