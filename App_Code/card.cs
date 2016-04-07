public abstract class Card {
    public virtual int ID { get; set; }

    public Card(int ID) {
        this.ID = ID;
    }
}