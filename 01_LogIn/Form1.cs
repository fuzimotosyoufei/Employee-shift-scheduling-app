using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taguma.DBaccess;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Taguma.DBaccess.adminDB;


namespace Taguma
{
    public partial class Form1 : Form//パスワードとIDでログインを行う
    {
        private readonly adminDB adminLogIn;
        private int count = 0;
        public Form1()
        {
            InitializeComponent();
            adminLogIn = new adminDB();
            passTB.PasswordChar = '*';
            //DbInitializer.Initialize();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Dashboard dasyu = new Dashboard();
            //dasyu.Show();
            String PasswordLogin = passTB.Text;
            String IDLogin = idTB.Text;
            object result = adminLogIn.GetPassword(IDLogin);//adminDBのadminLogInを呼び出している

            if (result != null)//エラーが出たらそもそも実行しない
            {

                string dbPasswordHash = result.ToString();//実行した内容をStringで上げる

                // 平文ならそのまま比較（ハッシュ化しているならVerify関数で照合）
                if (dbPasswordHash == PasswordLogin)//自分が入力したパスワードと出力されたパスワードが同じかを確かめる
                {
                    MessageBox.Show("ログイン成功（管理者）");
                    Dashboard dasyu = new Dashboard();
                    dasyu.Show();
                    this.Hide();
                    this.count = 0;
                }

                else
                {
                    MessageBox.Show("パスワードが違います");
                    this.count++;
                }
            }
            else
            {
                MessageBox.Show("そのログインIDは存在しません");
                this.count++;
            }
            if (this.count == 3)
            {
                this.Close();
            }
        }


    }
    }



