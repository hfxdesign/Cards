/************************************************************************************************************************
 * This is the main interface for the game, where we'll pull the tables from the database and load them into the decks.
 * also handled here are the player's winning card count and a history of winning hands to upload back to the db. 
 * ./NJ/.
 ***********************************************************************************************************************/

public class Game {
    //Connection info for DBConnector
    private string
        server      = "devxt.com",      // Hostname or IP of the server
        database    = "autocore_cards", // Name of the database / schema
        uid         = "autocore_cards", // Username
        password    = "C4rdz!"          // Password
    ;



    public Game(int numberOfPlayers)
    {
        DBConnector db = new DBConnector(server, database, uid, password);
        Deck<BlackCard> blackCards = db.getBlackCards();
        Deck<WhiteCard> whiteCards = db.getWhiteCards();

        Player[] players = new Player[numberOfPlayers];
        for (int i = 0; i < numberOfPlayers; i++)
            players[i] = new Player(whiteCards);
    }
}