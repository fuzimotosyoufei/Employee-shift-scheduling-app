using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taguma.DBaccess;

namespace Taguma
{
    public partial class StaffRegistration : Form//スタッフの登録を行う画面
    {
        private StaffRegistrationDB StaffIn;
        public StaffRegistration()
        {
            InitializeComponent();
            StaffIn = new StaffRegistrationDB( this.NameBox, this.TellBox, this.e_mailBox, this.bankBox, this.AddressBox, this.how);
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       

        private void AddButton_Click(object sender, EventArgs e)
        {
            StaffIn.StaffInDB();
        }

    }
}
