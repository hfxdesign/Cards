using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Card
{
    public enum color { BLACK, WHITE };

    public color cardColor { get; set; }
    public int ID { get; set; }
    public String text { get; set; }
    public Card(int ID, color cardColor, String text)
    {
        this.ID = ID;
        this.cardColor = cardColor;
        this.text = text;
    }
}