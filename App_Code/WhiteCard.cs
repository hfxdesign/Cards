public class WhiteCard : Card {
    public string text { get; set; }

    public WhiteCard (int id, string text)
        : base(id) {

        this.text = text;
    }

    public WhiteCard (WhiteCard obj) 
        : base(obj.ID) {

        text = obj.text;
    }
}