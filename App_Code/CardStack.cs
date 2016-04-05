using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CardStack
/// </summary>
public class CardStack {
    private System.Data.Odbc.OdbcConnection mySQL = new OdbcConnection("Dsn=CaH");
    public List<Card> cards;
    public CardStack(int stackSize) {
        mySQL.Open();
        OdbcCommand cmd = new OdbcCommand("select id, card from whitecards", mySQL);
        OdbcDataReader retData = cmd.ExecuteReader();
        int i = 0;
        while (retData.Read()) { //Check to see if cardstack > stacksize, and only add cards that haven't been used.
            cards.Add(new Card(Card.color.WHITE, retData[1].ToString()));
        }
        mySQL.Close();
    }
}