# DB_Sem4_MV_Verwaltung
Installation der Datenbank:
1) Erstellen Sie einen Microsoft SQL Server
2) Verbinden Sie diesen Server mit MM SQL Management Studio oder einer anderen IDE
3) Lassen Sie auf diesem Server das Script Script_Datenbank_Erstellen.sql laufen
 Es sollte eine Datenbank mit dem Namen MV_Mitgliederverwaltung angelegt werden.

Verbinden der Datenbank mit dem Programm:
1) Öffnen Sie MV_Mitgliederverwaltung.sln mit Visual Studio
2) Öffnen Sie den Server Explorer (strg+Alt+S)
3) Im oberen Menu klicken Sie auf "Mit Datanbank verbinden"
4) Wählen Sie Als Datenquelle "Microsoft SQL Server (SqlClient)" und als Servername geben Sie ihren Servernamen ein (evtl kopieren aus MSSMS)
5) Im unteren Dialog "Mit Datenbank Verbinden" wählen Sie bei "Datenbanknamen auswählen oder eingeben" "MV_Mitgliederverwaltung" aus
6) Unter erweitert Kopieren Sie das untere Feld "DataSource" Hier sollte ungefär so etwas stehen: "Data Source=DESKTOP-D9HO4VH\MV_VERWALTUNG;Initial Catalog=MV_Mitgliederverwaltung;Integrated Security=True"
7) Kopieren Sie diese DataSource in den connectionString in der App.config File

Start des Programms
Drücken Sie einfach auf Start

Bei Fragen zum Aufsetzten des Projekts bitte einfach an mich wenden
