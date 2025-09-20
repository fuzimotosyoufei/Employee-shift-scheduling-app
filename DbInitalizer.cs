using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

namespace Taguma
{
    public static class DbInitializer
    {
        public static void Initialize()
        {
            // DB ファイルが存在しなければ自動作成
            if (!System.IO.File.Exists("Taguma.db"))
            {
                SQLiteConnection.CreateFile("Taguma.db");
            }

            using (var conn = new SQLiteConnection(DBHelper.ConnectionString))
            {
                conn.Open();

                // staff テーブル
                string staffTable = @"
                CREATE TABLE IF NOT EXISTS staff (
                    staff_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    staff_name TEXT NOT NULL,
                    tell TEXT NOT NULL,
                    e_mail TEXT NOT NULL,
                    bank_account TEXT NOT NULL,
                    address TEXT NOT NULL,
                    how TEXT NOT NULL
                );";

                // shiftData テーブル
                string shiftTable = @"
                CREATE TABLE IF NOT EXISTS shiftData (
                    shift_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    staff_id INTEGER NOT NULL,
                    shift_day INTEGER NOT NULL,
                    shift_month INTEGER NOT NULL,
                    shift_year INTEGER NOT NULL,
                    shift_type TEXT,
                    FOREIGN KEY (staff_id) REFERENCES staff(staff_id)
                );";

                // admin テーブル
                string adminTable = @"
                CREATE TABLE IF NOT EXISTS admin (
                    admin_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    admin_password TEXT NOT NULL,
                    staff_id INTEGER NOT NULL,
                    created_at TEXT DEFAULT (datetime('now','localtime')),
                    FOREIGN KEY (staff_id) REFERENCES staff(staff_id)
                );";

                using (var cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = staffTable; cmd.ExecuteNonQuery();
                    cmd.CommandText = shiftTable; cmd.ExecuteNonQuery();
                    cmd.CommandText = adminTable; cmd.ExecuteNonQuery();
                    cmd.CommandText = @"
                INSERT INTO admin (admin_password, staff_id)
                SELECT 'password123', 1
                WHERE NOT EXISTS (SELECT 1 FROM admin);";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
