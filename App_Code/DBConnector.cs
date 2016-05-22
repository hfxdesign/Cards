using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

class DBConnect {
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    public DBConnect() {
        Initialize();
    }

    private void Initialize() {
        server      = "devxt.com";
        database    = "autocore_cards";
        uid         = "autocore_cards";
        password    = "C4rdz!";
        string connectionString = 
            "SERVER="   + server    + ";" + 
            "DATABASE=" + database  + ";" +
            "UID="      + uid       + ";" +
            "PASSWORD=" + password  + ";";

        connection = new MySqlConnection(connectionString);
    }

    private bool OpenConnection() {
        try {
            connection.Open();
            return true;
        } catch (MySqlException ex) {
            switch (ex.Number) {
                case 0:
                    Console.WriteLine("Cannot connect to server.  Contact administrator");
                    break;

                case 1045:
                    Console.WriteLine("Invalid username/password, please try again");
                    break;
            }
            return false;
        }
    }

    private bool CloseConnection() {
        try {
            connection.Close();
            return true;
        } catch (MySqlException ex) {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public LinkedList<WhiteCard> getWhiteDeck() {
        string query = "SELECT * FROM whiteCards"
    }
}