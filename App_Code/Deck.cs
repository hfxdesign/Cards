using System;
using System.Collections.Generic;
using System.Data.Odbc;

public class Deck {
    private OdbcConnection mySQL = new OdbcConnection("Dsn=CaH");
    public List<Card> cardsList;
    public Stack<Card> cardsStack;

    public bool isEmpty() {
        return (cardsList.Count > 0 ? false : true);
    }

    public void getDeck(Card.color deckColor) {
        mySQL.Open();
        OdbcCommand cmd = (deckColor == Card.color.BLACK)
            ? new OdbcCommand("SELECT `id`, `card` FROM `whitecards`", mySQL)
            : new OdbcCommand("SELECT `id`, `card` FROM `blackcards`", mySQL);
        OdbcDataReader retData = cmd.ExecuteReader();

        while (retData.Read()) {
            cardsList.Add(new Card(Convert.ToInt32(retData[0].ToString()), Card.color.WHITE, retData[1].ToString()));
        }
        mySQL.Close();
    }

    public void getDeck(Card.color deckColor, int deckSize) {
        mySQL.Open();
        OdbcCommand cmd = new OdbcCommand("select id, card from whitecards", mySQL);
        OdbcDataReader retData = cmd.ExecuteReader();

        while (retData.Read() && cardsList.Count <= deckSize) {
            cardsList.Add(new Card(Convert.ToInt32(retData[0].ToString()), Card.color.WHITE, retData[1].ToString()));
        }
        mySQL.Close();
    }

    public void Shuffle() {
        Random rng = new Random();

        while (cardsList.Count > 1) {
            int i = rng.Next(cardsList.Count - 1);
            cardsStack.Push(cardsList[i]);
            cardsList.Remove(cardsList[i]);
        }
    }

    public Deck(Card.color deckColor) {
        getDeck(deckColor);
    }

    public Deck(Card.color deckColor, int deckSize) {
        getDeck(deckColor, deckSize);
    }
}