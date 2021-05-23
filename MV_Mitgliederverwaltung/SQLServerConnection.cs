using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;

namespace MV_Mitgliederverwaltung
{
   public class DbClass
    {
        //Holt sich den Connection String aus dem Konfigurationsmanager (Im App.config)
        private static string GetConnectionStrings()
        {
            string strConString = ConfigurationManager.ConnectionStrings["conString"].ToString();
            return strConString;
        }

        //Öffentliche Variablen
        public static string sql;
        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand("", con);
        public static SqlDataReader rd;
        public static DataTable dt;
        public static SqlDataAdapter da;

        //Öffnet eine Verbindung zur Datenbank unter dem Connection String
        public static void OpenConnetion()
        {
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = GetConnectionStrings();
                    con.Open();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("The system failed to establish a connection." + Environment.NewLine +
                    "Descriptions: " + ex.Message.ToString(), "C# WPF Connect to SQL Server", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Schließt die Verbindung zur Datenbank
        public static void CloseConnection()
        {
            try
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch(Exception ex )
            {
                MessageBox.Show("The system failed to close the connection." + Environment.NewLine +
                   "Descriptions: " + ex.Message.ToString(), "C# WPF Connect to SQL Server", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Übergibt SQL Kommandos an die Datenbank und macht Änderungen an der Datenbank
        public static void ModSQL()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        //public static void SaveToSQL()
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = sql;

        //    da = new SqlDataAdapter(cmd);
        //    dt = new DataTable();
        //    da.Update(dt);       

        //}

        //Ließt daten aus der Datenbank in einen String ein. Wird kein Select in SQL übergeben, kommt eine Fehlermeldung
        public static string ReadSQL()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;

            string dbanswer = null;
            rd = cmd.ExecuteReader();
            // Call Read before accessing data.
            for(int i =0; rd.Read(); i++)
            {
                dbanswer += ReadSingleRow((IDataRecord)rd,i);
            }
            // Call Close when done reading.
            rd.Close();
            return dbanswer;
        }

        private static string ReadSingleRow(IDataRecord record, int iter)
        {
           return String.Format("{"+iter+"}", record[iter]);
        }

    }
}
