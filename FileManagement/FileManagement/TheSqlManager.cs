using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using Finisar.SQLite;

// DB Stored in Memory https://www.connectionstrings.com/sqlite/


namespace FileManagement
{
    class TheSqlManager
    {
        private SQLiteConnection sqlite_conn;
        private SQLiteCommand sqlite_cmd;
        private SQLiteDataReader sqlite_datareader;

        string DataBasePath = Application.StartupPath + @"\SqlManager\SQLitePrgrammDatabase.sqlite";
        string DataBasePath2 = @"E:\PortableApps\Security\KeePass 2.35\SQLitePrgrammDatabase.sqlite";

        public void SqlExecute(string command)
        {
            try
            {
                sqlite_conn = new SQLiteConnection("Data Source=" + DataBasePath2 + ";Version=3;New=True;Compress=True;");
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = command;
                sqlite_cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error with SQL Execute", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            finally
            {
                sqlite_conn.Close();
            }
            
        }
    }
}
