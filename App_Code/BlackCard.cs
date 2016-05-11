using System;

/// <summary>
/// <see cref="BlackCard"/> class for "Cards against Humanity Online"
/// </summary>
[Serializable]
public class BlackCard : WhiteCard {
    public int draw { get; set; }
    public int pick { get; set; }

    /// <summary>
    /// Create a new <see cref="BlackCard"/>
    /// </summary>
    /// <param name="id">ID number of the card</param>
    /// <param name="text">Text (content) of the card</param>
    /// <param name="draw">Number of <see cref="WhiteCard"/>s the <see cref="Player"/> will draw</param>
    /// <param name="pick">Number of <see cref="WhiteCard"/>s the <see cref="Player"/> picks</param>
    public BlackCard(uint id, string text, int draw, int pick)
        : base(id, text) {

        this.draw = draw;
        this.pick = pick;
    }

    /// <summary>
    /// Copy another <see cref="BlackCard"/>
    /// </summary>
    /// <param name="obj">Name of another <see cref="BlackCard"/></param>
    public BlackCard(BlackCard obj)
        : base(obj.ID, obj.cardText) {
        draw = obj.draw;
        pick = obj.pick;
    }
}