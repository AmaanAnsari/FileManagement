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

namespace FileManagement
{
    public partial class Form1 : Form
    {
        // Klassenvariablen
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;
        private FolderBrowserDialog folderBrowserScanDialog;
        private FolderBrowserDialog folderBrowserBasePfadDialog;
        // Ort bzw Pfad:
        string FilemanegerLaufPath = Path.GetTempPath() + @"FilemanegerLaufPath.mang"; // Die Datei wo der Pfad gespeichert wird
        string GesammtDataPfad; // Der ganze Datenbank Pfad [mit \Sql.db]
        string DataPfad; // Nur der Datenbank Pfad [ohne \Sql.db]
        string ScanPfad; // Der pfad der gescant wird
        //
        string Drivename;
        int ID;
        static string CreateIndexMD5 = "CREATE INDEX Sc_MD5 ON ScanTabelle (ChecksumeMD5) ";
        static string CreateIndexName = "CREATE INDEX Sc_Name ON ScanTabelle (Name) ";
        static string CreateIndexPfad = "CREATE INDEX Sc_Pfad ON ScanTabelle (ScanPfad) ";
        static string CreateTable = "CREATE TABLE ScanTabelle (Name varchar(100), Grosse int(100), Aenderungsdatum varchar(100), Drivename varchar(100), ChecksumeMD5 varchar(100), ScanPfad varchar(100));";
        // End

        public void ScanFolder(string ScanPfad, string Drivename)
        {
            //"Klassenvariablen" Variablen der Methode ScanFolder
            DirectoryInfo ParentDirectory = new DirectoryInfo(ScanPfad);
            // End ;
            // [ Foreach Scan nach Dateien] 

                foreach (FileInfo f in ParentDirectory.GetFiles())
            {
                // Checksumme errechnen 
                byte[] inputBytes = System.Text.Encoding.Default.GetBytes(ScanPfad + @"\" + f.Name);
                MD5CryptoServiceProvider myMD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                byte[] hash = myMD5CryptoServiceProvider.ComputeHash(inputBytes);
                string Checksume = "";
                foreach (byte b in hash)
                {
                    Checksume += b.ToString("X2");
                }
                // End; // Returns Checksumme             
                // Checksumme Datenbank schreiben ,first Verbindung etc aufbauen
                ID++;
                if (!SQSelectCheck("SELECT * FROM ScanTabelle where ChecksumeMD5 = '"+ Checksume + "'"))
                    SQWriteScan(f.Name,Convert.ToInt32(f.Length), f.LastWriteTime , Drivename, Checksume, ScanPfad); // string Name, int Groesse, string Aenderungsdatum, string Drivename, string Checksume, string ScanPfad
                // End;

            }
            // [Foreach Scan nach Folders]
            foreach (System.IO.DirectoryInfo d in ParentDirectory.GetDirectories())
            {
                SQWriteScan(d.Name, 0, d.LastWriteTime , Drivename, "", ScanPfad); 
                ScanFolder(ScanPfad + @"\" + d.Name, Drivename);
                // Ordner in Datenbank schreiben
                // End ;
            }

        }

        // --- Anfang Objekte
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine(String.Format("{0:yyyy-MM-dd hh:mm:ss}", new DateTime(2016,3,12)));
            CreateCheckDataBase();
        }

        private void btn_pfad_Click(object sender, EventArgs e) // ScanPfad
        {
            this.folderBrowserScanDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserScanDialog.Description = "Select the directory that you want to Scan...";
            this.folderBrowserScanDialog.ShowNewFolderButton = false;
            DialogResult result = folderBrowserScanDialog.ShowDialog();
            ScanPfad = folderBrowserScanDialog.SelectedPath;
            txt_output.Text = ("Selected ScanFolder :" + ScanPfad);
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Scanning: " + ScanPfad);
            txt_drivename.ReadOnly = true;
            txt_output.Text = "Scanning Folder and Files , please wait ...";
            Drivename = txt_drivename.Text;
            ScanFolder(ScanPfad, Drivename);
            txt_drivename.ReadOnly = false;
            txt_output.Text = "Scan finished ...";
        }

        private void btn_dataPfad_Click(object sender, EventArgs e) // Datenbank
        {
            //sqlite_conn.Close();
            // Console.WriteLine("Datenbank geschlossen");

            this.folderBrowserBasePfadDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserBasePfadDialog.Description = "Select the directory that you want to use for your Database...";
            this.folderBrowserBasePfadDialog.ShowNewFolderButton = false;
            DialogResult result = folderBrowserBasePfadDialog.ShowDialog();
            DataPfad = folderBrowserBasePfadDialog.SelectedPath;
            File.WriteAllText(FilemanegerLaufPath, DataPfad);
            Console.WriteLine("Set DataBase Pfad to: " + DataPfad);
            txt_output.Text = "Set DataBase Pfad to: " + DataPfad;
            CreateCheckDataBase();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlite_conn.Close();
            Console.WriteLine("Datenbank geschlossen");

        }

        public void SQWriteScan(string Name, int Groesse, DateTime Aenderungsdatum, string Drivename, string Checksume, string ScanPfad)
        {
            string sql;
            sql = "INSERT INTO ScanTabelle (Name, Grosse, Aenderungsdatum, Drivename, ChecksumeMD5, ScanPfad)" + 
                  " VALUES ('" + Name + "', '" + Groesse + "','" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", Aenderungsdatum) + "', '" + Drivename + "','" + Checksume + "', '" + ScanPfad + "');";
            sqlite_cmd.CommandText = sql;
            sqlite_cmd.ExecuteNonQuery();
            Console.WriteLine("SQBefehl abgesetzt:" + sql);
        
        }

        public void SQExecute(string sql, string msg)
        {
            sqlite_cmd.CommandText = sql;
            sqlite_cmd.ExecuteNonQuery();
            Console.WriteLine(msg == "" ? "Sql: " + sql : "Msg: " + msg);
        }


        public bool SQSelectCheck(string sql)
        {
            bool isDa = false;
            // But how do we read something out of our table ?
            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = sql;

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                isDa = true;
                // Print out the content of the text field:
                System.Console.WriteLine("  {0}/{1}", sqlite_datareader["ScanPfad"],sqlite_datareader["Name"]);
                grid_DataView.DataSource = sqlite_datareader["ScanPfad"];

            }
            sqlite_datareader.Close();
            return isDa;

        }


        public void CreateTableConnection()
        {
            sqlite_conn = new SQLiteConnection("Data Source=" + GesammtDataPfad + ";Version=3;New=True;Compress=True;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();
            SQExecute(CreateTable, "Datenbank in CreateCheckDataBase wurde erzeugt [Tabelle auch].");
            SQExecute(CreateIndexMD5, "");
     //       SQExecute(CreateIndexName, "");
            SQExecute(CreateIndexPfad, "");
            SQExecute(CreateIndexName, "");

        }



        public void CreateCheckDataBase()
        {
            try
            {
                sqlite_conn.Close();
                Console.WriteLine("Datenbank Conection in CreateCheckDataBase erfolgreich geschlossen.");

            }
            catch
            {
                Console.WriteLine("Datenbank Conection in CreateCheckDataBase wurde schon geschlossen.");
            }
            if (File.Exists(FilemanegerLaufPath))
            {
                 if (File.ReadAllText(FilemanegerLaufPath) != "")
                {
                    DataPfad = File.ReadAllText(FilemanegerLaufPath);
                    GesammtDataPfad = DataPfad + @"\SQLiteManagementFile.sqlite";

                    if (File.Exists(GesammtDataPfad))
                    {
                        Console.WriteLine("Datenbank in CreateCheckDataBase exestiert schon.");
                        sqlite_conn = new SQLiteConnection("Data Source=" + GesammtDataPfad + ";Version=3;New=False;Compress=True;");
                        sqlite_conn.Open();
                        sqlite_cmd = sqlite_conn.CreateCommand();
                    }
                    else
                    {
                        Console.WriteLine("Datenbank in CreateCheckDataBase exestiert nicht. [If Exist GesammtDataPfad]");
                        CreateTableConnection();

                    }

                }
                else
                {
                    Console.WriteLine("Fehlerinformation: GesammtDataPfad Datei ist Leer !");
                }
            }
            else
            {
                DataPfad = Application.StartupPath;
                GesammtDataPfad = DataPfad + @"\SQLiteManagementFile.sqlite";

                Console.WriteLine("Datenbank in CreateCheckDataBase exestiert nicht. [If Exist FilemanegerLaufPath]");
                CreateTableConnection();
            }
            File.WriteAllText(FilemanegerLaufPath, DataPfad);
            Console.WriteLine("Aktuelle Datenbank: " + GesammtDataPfad);
            txt_output.Text = "Aktuelle Datenbank: " + GesammtDataPfad;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string sql = "SELECT Name,Drivename as Bezeichnung,ScanPfad as Pfad FROM ScanTabelle where Name like '%" + txt_keyword.Text + "%'";

            try
            {
                sqlite_cmd.CommandText = sql;
                sqlite_cmd.ExecuteNonQuery();

                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(sqlite_cmd);
                DataTable dt = new DataTable("ScanTabelle");
                dataAdp.Fill(dt);
                grid_DataView.DataSource = dt.DefaultView;
                dataAdp.Update(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grp_search_Enter(object sender, EventArgs e)
        {

        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            TheSqlManager SM = new TheSqlManager();
            SM.SqlExecute(CreateTable);
        }
    }
}
