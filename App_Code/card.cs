public abstract class Card {
    public virtual int ID { get; set; }

    public Card(int ID) {
        this.ID = ID;
    }

    public Card(Card obj) {
        this.ID = obj.ID;
    }
}