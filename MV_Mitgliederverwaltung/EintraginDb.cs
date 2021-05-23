using System;
using System.Data.SqlClient;
using System.Windows;


namespace MV_Mitgliederverwaltung
{
    public class EintraginDb
    {
        public static bool AddVerein(string vereinsname)
        {
            {
                DbClass.OpenConnetion();
                DbClass.sql = "INSERT into dbo.Verein (Verein) VALUES ('" + vereinsname + "');";
                try
                {
                    DbClass.ModSQL();
                }
                catch(Exception ex)
                {
                    // Prüft, ob Dopplung des Unique Keys die Hauptursache ist
                    if (ex.GetBaseException().GetType() == typeof(SqlException))
                    {
                        //Abspeichern des Errorcodes
                        Int32 ErrorCode = ((SqlException)ex).Number;
                        switch (ErrorCode)
                        {
                            case 2627:  // Unique constraint error
                                return false; //Unique KEY Verletzung -> Verein nicht hinzufügen
                            case 547:   // Constraint check violation
                                break;
                            case 2601:  // Duplicated key row error
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Es ist ein Fehler aufgetreten!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                MessageBox.Show("Der Verein " + vereinsname + " wurde hinzugefügt", "Bestätigung", MessageBoxButton.OK, MessageBoxImage.Information);
                DbClass.CloseConnection();
                return true;
            }
        }



        //ähnliches Vorgehen wie beim Verein, auch hier bei der Sparte
        public static void AddSparte(string spartenname, string adminName)
        {

            {
                DbClass.OpenConnetion();
                DbClass.sql = "INSERT into dbo.Sparte (Sparte) VALUES ('" + spartenname + "');";
                try
                {
                    DbClass.ModSQL();
                }
                catch (Exception ex)
                {
                    if (ex.GetBaseException().GetType() == typeof(SqlException))
                    {
                        Int32 ErrorCode = ((SqlException)ex).Number;
                        switch (ErrorCode)
                        {
                            case 2627:  // Unique constraint error
                                break;
                            case 547:   // Constraint check violation
                                break;
                            case 2601:  // Duplicated key row error
                                return;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Es ist ein Fehler aufgetreten!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                //nach dem Hinzufügen der Sparte, muss die sparte noch mit dem Verein und dem Admin verbunden werden
                DbClass.sql = "INSERT INTO dbo.Connector_Sparte_Verein VALUES ((SELECT TOP 1 (ID) FROM dbo.Verein ORDER BY ID DESC), (SELECT ID FROM dbo.Sparte WHERE Sparte = '"+ spartenname +"'));";
                DbClass.ModSQL();

                DbClass.sql = "INSERT INTO dbo.Admin__Connector_Sparte_PW VALUES ((SELECT TOP 1 (ID) FROM dbo.Connector_Sparte_Verein ORDER BY ID DESC),1,(SELECT ID FROM dbo.Password WHERE Username = '"+ adminName +"'));";
                DbClass.ModSQL();
                DbClass.CloseConnection();
                MessageBox.Show("Die Sparte " + spartenname + " wurde hinzugefügt", "Bestätigung", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }


        //gleiches Vorgehen wie bei den obenen Add Funktionen. Auch hier wird auf Dopplung gepfrüft
        public static void AddUser(string username, string password)
        {
            DbClass.OpenConnetion();

            DbClass.sql = "INSERT into dbo.Password VALUES ('" + username + "', '"+ password +"');";
            try
            {
                DbClass.ModSQL();
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().GetType() == typeof(SqlException))
                {
                    Int32 ErrorCode = ((SqlException)ex).Number;
                    switch (ErrorCode)
                    {
                        case 2627:  // Unique constraint error
                            MessageBox.Show("Diesen User gibt es bereits!");
                            return;
                        case 547:   // Constraint check violation
                            break;
                        case 2601:  // Duplicated key row error
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Es ist ein Fehler aufgetreten!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            MessageBox.Show("Der Nutzer " + username + " wurde hinzugefügt", "Bestätigung", MessageBoxButton.OK, MessageBoxImage.Information);

            DbClass.CloseConnection();
        }

       
    }
}
