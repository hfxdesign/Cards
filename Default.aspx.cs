using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        DBConnector db = new DBConnector();
        Deck<BlackCard> blackCards = db.getBlackCards();
        Deck<WhiteCard> whiteCards = db.getWhiteCards();

        Player[] players = new Player[5];
        for (int i = 0; i < 5; i++)
            players[i] = new Player(whiteCards);
    }
}