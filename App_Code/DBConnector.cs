using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

public class DBConnector {
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    public DBConnector() {
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

    public Deck<BlackCard> getBlackCards() {
        Deck<BlackCard> newDeck = new Deck<BlackCard>();
        string query = "SELECT `card`, `draw`, `pick` FROM `blackcards` ORDER BY `id` ASC";

        if (OpenConnection()) {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            uint id = 0;
            while (dataReader.Read()) {
                newDeck.addCard(
                    new BlackCard(
                        id++,
                        dataReader["card"] + "",
                        Convert.ToInt32(dataReader["draw"] + ""),
                        Convert.ToInt32(dataReader["pick"] + "")
                ));
            }

            dataReader.Close();
            CloseConnection();
        }
        return newDeck;
    }

    public Deck<WhiteCard> getWhiteCards() {
        Deck<WhiteCard> newDeck = new Deck<WhiteCard>();
        string query = "SELECT `card` FROM `whitecards` ORDER BY `id` ASC";

        if (OpenConnection()) {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            uint id = 0;
            while (dataReader.Read()) {
                newDeck.addCard(new WhiteCard(id++, dataReader["card"] + ""));
            }

            dataReader.Close();
            CloseConnection();
        }
        return newDeck;
    }
}