using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CardStack
/// </summary>
public class Deck {
    private System.Data.Odbc.OdbcConnection mySQL = new OdbcConnection("Dsn=CaH");
    public List<Card> cards;
    public Stack<Card> shuffledCards;
    public HashSet<int> usedCardIDs;

    public Boolean isEmpty() {
        return (this.cards.Count > 0 ? false : true);
    }

    public void Shuffle() {
        Random rng = new Random();
        int deckSize;

        if (!this.isEmpty()) {

            while (shuffledCards.Count > 0)
                cards.Add(shuffledCards.Pop());

            deckSize = cards.Count;

            while (deckSize > 1) {
                --deckSize;
                int i = rng.Next(deckSize);
                shuffledCards.Push(cards.ElementAt(i));
                cards.Remove(cards.ElementAt(i));
            }
        }
    }

    public Deck(int stackSize) {
        mySQL.Open();
        OdbcCommand cmd = new OdbcCommand("select id, card from whitecards", mySQL);
        OdbcDataReader retData = cmd.ExecuteReader();
        int i = 0;
        while (retData.Read() && stackSize <= cards.Count) {
            cards.Add(new Card(Convert.ToInt32(retData[0].ToString()), Card.color.WHITE, retData[1].ToString()));
        }
        mySQL.Close();
    }
}