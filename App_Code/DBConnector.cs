using MySql.Data.MySqlClient;
using System;

public class DBConnector {
    private MySqlConnection connection;

    /// <summary>
    /// Open a connection to the database
    /// </summary>
    /// <param name="server">(<see cref="string"/>) Hostname or IP address of the server</param>
    /// <param name="database">(<see cref="string"/>) Name of the schema / database</param>
    /// <param name="uid">(<see cref="string"/>) Username</param>
    /// <param name="password">(<see cref="string"/>) Password</param>
    public DBConnector(string server, string database, string uid, string password) {
        string connectionString =
        "SERVER="   + server    + ";" +
        "DATABASE=" + database  + ";" +
        "UID="      + uid       + ";" +
        "PASSWORD=" + password  + ";";

        connection = new MySqlConnection(connectionString);
    }

    /// <summary>
    /// Attempts to open a conection to the server specified in the constructor
    /// </summary>
    /// <returns>
    ///   <see cref="true"/> if a connection is established <para/>
    ///   <see cref="false"/> otherwise
    /// </returns>
    private bool OpenConnection() {
        try {
            connection.Open();
            return true;
        } catch (MySqlException ex) {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Attempts to close an open connection
    /// </summary>
    /// <returns>
    ///   <see cref="true"/> if the connection could be closed <para />
    ///   <see cref="false"/> otherwise
    /// </returns>
    private bool CloseConnection() {
        try {
            connection.Close();
            return true;
        } catch (MySqlException ex) {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Retrieve all black cards from the database
    /// </summary>
    /// <returns>Returns a <see cref="Deck{T}"/> of all <see cref="BlackCard"/>s in the database</returns>
    public Deck<BlackCard> getBlackCards() {
        Deck<BlackCard> newDeck = new Deck<BlackCard>();
        string query = "SELECT `id`, `card`, `draw`, `pick` FROM `blackcards` ORDER BY `id` ASC";

        if (OpenConnection()) {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read()) {
                newDeck.addCard(
                    new BlackCard(
                        dataReader["id"] + "",
                        dataReader["card"] + "",
                        dataReader["draw"] + "",
                        dataReader["pick"] + ""
                ));
            }

            dataReader.Close();
            CloseConnection();
        }
        return newDeck;
    }

    /// <summary>
    /// Retrieve all white cards from the database
    /// </summary>
    /// <returns>Returns a <see cref="Deck{T}"/> of all <see cref="WhiteCard"/>s in the database</returns>
    public Deck<WhiteCard> getWhiteCards() {
        Deck<WhiteCard> newDeck = new Deck<WhiteCard>();
        string query = "SELECT `id`, `card` FROM `whitecards` ORDER BY `id` ASC";

        if (OpenConnection()) {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read()) {
                newDeck.addCard(
                    new WhiteCard(
                        dataReader["id"] + "",
                        dataReader["card"] + ""
                ));
            }

            dataReader.Close();
            CloseConnection();
        }
        return newDeck;
    }
}