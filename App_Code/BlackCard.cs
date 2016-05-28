using System;

/// <summary>
/// <see cref="BlackCard"/> class for "Cards against Humanity Online"
/// </summary>
[Serializable]
public class BlackCard : WhiteCard {
    public int draw;
    public int pick;

    /// <summary>
    /// Create a new <see cref="BlackCard"/>
    /// </summary>
    /// <param name="id">ID number of the card</param>
    /// <param name="text">Text (content) of the card</param>
    /// <param name="draw">Number of <see cref="WhiteCard"/>s the <see cref="Player"/> will draw</param>
    /// <param name="pick">Number of <see cref="WhiteCard"/>s the <see cref="Player"/> picks</param>
    public BlackCard(int id, string text, int draw, int pick)
        : base(id, text) {
        this.draw = draw;
        this.pick = pick;
    }

    /// <summary>
    /// Create a new <see cref="BlackCard"/>
    /// </summary>
    /// <param name="id">ID number of the card</param>
    /// <param name="text">Text (content) of the card</param>
    /// <param name="draw">Number of <see cref="WhiteCard"/>s the <see cref="Player"/> will draw</param>
    /// <param name="pick">Number of <see cref="WhiteCard"/>s the <see cref="Player"/> picks</param>
    public BlackCard(string id, string text, string draw, string pick)
        : base(id, text) {
        this.draw = Convert.ToInt32(draw);
        this.pick = Convert.ToInt32(pick);
    }

    /// <summary>
    /// Copy another <see cref="BlackCard"/>
    /// </summary>
    /// <param name="obj">Name of other object</param>
    public BlackCard(BlackCard obj)
        : base(obj.ID, obj.cardText) {
        draw = obj.draw;
        pick = obj.pick;
    }
}