using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taguma.DBaccess
{
  
    internal class StaffRegistrationDB
    {
        private readonly String connectionString;
        private TextBox NameBox;
        private TextBox TellBox;
        private TextBox e_mailBox;
        private TextBox bankBox;
        private TextBox AddressBox;
        private ComboBox how;

        public StaffRegistrationDB(TextBox NameBox , TextBox TellBox, TextBox e_mailBox, TextBox bankBox, TextBox AddressBox,ComboBox how)
        {
            connectionString = DBHelper.ConnectionString;
            this.NameBox = NameBox;
            this.TellBox = TellBox;
            this.e_mailBox = e_mailBox;
            this.bankBox = bankBox;
            this.AddressBox = AddressBox;
            this.how = how;

        }
        public void StaffInDB()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                MessageBox.Show("s");
                String insertStaff = "INSERT INTO staff (staff_name ,tell,e_mail,bank_account,address,how) VALUES(@staff_name,@tell,@e_mail,@bank_account,@address,@how)";
                SqlCommand insertCmd = new SqlCommand(insertStaff, conn);
                insertCmd.Parameters.AddWithValue("@staff_name", NameBox.Text);
                insertCmd.Parameters.AddWithValue("@tell", TellBox.Text);
                insertCmd.Parameters.AddWithValue("@e_mail", e_mailBox.Text);
                insertCmd.Parameters.AddWithValue("@bank_account", bankBox.Text);
                insertCmd.Parameters.AddWithValue("@address", AddressBox.Text);
                insertCmd.Parameters.AddWithValue("@how", how.Text);
                insertCmd.ExecuteNonQuery();



            }

        }
    }
}
