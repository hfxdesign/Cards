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

    public void Shuffle() {
        Random rng = new Random();

        while (cardsList.Count > 1) {
            int i = rng.Next(cardsList.Count - 1);
            cardsStack.Push(cardsList[i]);
            cardsList.Remove(cardsList[i]);
        }
    }

    public Deck() {
        mySQL.Open();
        OdbcCommand cmd = new OdbcCommand("select id, card from whitecards", mySQL);
        OdbcDataReader retData = cmd.ExecuteReader();

        while (retData.Read()) {
            cardsList.Add(new Card(Convert.ToInt32(retData[0].ToString()), Card.color.WHITE, retData[1].ToString()));
        }
        mySQL.Close();
    }

    public Deck(int stackSize) {
        mySQL.Open();
        OdbcCommand cmd = new OdbcCommand("select id, card from whitecards", mySQL);
        OdbcDataReader retData = cmd.ExecuteReader();

        while (retData.Read() && stackSize <= cardsList.Count) {
            cardsList.Add(new Card(Convert.ToInt32(retData[0].ToString()), Card.color.WHITE, retData[1].ToString()));
        }
        mySQL.Close();
    }
}