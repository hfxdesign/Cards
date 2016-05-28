using System;

/// <summary>
/// <see cref="WhiteCard"/> class for "Cards against Humanity Online"
/// </summary>
[Serializable]
public class WhiteCard : IComparable {
    public int ID;
    public string cardText;

    /// <summary>
    /// Create a new <see cref="WhiteCard"/>
    /// </summary>
    /// <param name="ID">ID number of the card</param>
    /// <param name="cardText">Text (content) of the card</param>
    public WhiteCard(int ID, string cardText) {
        this.ID = ID;
        this.cardText = cardText;
    }

    /// <summary>
    /// Create a new <see cref="WhiteCard"/>
    /// </summary>
    /// <param name="ID">ID number of the card</param>
    /// <param name="cardText">Text (content) of the card</param>
    public WhiteCard(string ID, string cardText) {
        this.ID = Convert.ToInt32(ID);
        this.cardText = cardText;
    }

    /// <summary>
    /// Copy another <see cref="WhiteCard"/>
    /// </summary>
    /// <param name="obj">Name of other object</param>
    public WhiteCard(WhiteCard obj) {
        ID = obj.ID;
        cardText = obj.cardText;
    }

    /// <summary>
    /// Compares the ID of <see cref="this"/> to another <see cref="object"/>
    /// for equality
    /// </summary>
    /// <param name="obj">Name of another object</param>
    public virtual int CompareTo(object obj) {
        return ID.CompareTo(obj);
    }

    /// <summary>
    /// Display the text (content) of this card
    /// </summary>
    public override string ToString() {
        return cardText;
    }
}
