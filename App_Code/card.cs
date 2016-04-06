using System;

public class Card
{
    public virtual int ID { get; set; }
    public virtual string text { get; set; }

    public Card(int ID, string text) {
        this.ID = ID;
        this.text = text;
    }
}