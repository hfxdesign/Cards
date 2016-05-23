using System;

/// <summary>
/// <see cref="WhiteCard"/> class for "Cards against Humanity Online"
/// </summary>
[Serializable]
public class WhiteCard : IComparable {
    public uint ID { get; set; }
    public string cardText { get; set; }

    /// <summary>
    /// Create a new <see cref="WhiteCard"/>
    /// </summary>
    /// <param name="ID"><see cref="uint"/>ID number of the card</param>
    /// <param name="cardText"><see cref="string"/>Text (content) of the card</param>
    public WhiteCard(uint ID, string cardText) {
        this.ID = ID;
        this.cardText = cardText;
    }

    /// <summary>
    /// Copy another <see cref="WhiteCard"/>
    /// </summary>
    /// <param name="obj">Name of another <see cref="WhiteCard"/></param>
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
