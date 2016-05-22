using System;
using System.Collections.Generic;

public class Deck<T> where T : WhiteCard {
    private int remainingCards;
    private List<T> cards;
    private List<bool> drawn;

    /// <summary>
    /// Clean the deck up.
    /// This will create a new instance of the deck minus the drawn cards.
    /// This should be executed between rounds.
    /// </summary>
    public void cleanupDeck() {
        List<T> newCards = new List<T>(remainingCards);

        for (int i = 0; i < cards.Count; i++) {
            if (!drawn[i])
                newCards.Add(cards[i]);
        }

        cards = newCards;
        drawn = new List<bool> { false };
    }

    /// <summary>
    /// Check to see if the deck is empty.
    /// </summary>
    /// <returns>Returns <see cref="true"/> or <see cref="false"/></returns>
    public bool isEmpty() {
        return (cards.Count > 0 ? false : true);
    }

    /// <summary>
    /// Draw a card from the deck.
    /// This will flag the card as <see cref="drawn"/> and reduce the count of <see cref="remainingCards"/>
    /// </summary>
    /// <returns>Returns a copy of the drawn card</returns>
    public T drawCard() {
        int i = 0;
        if (cards.Count > 1) {
            i = new Random(cards.Count - 1).Next();

            while (drawn[i])
                i = (i == (drawn.Count - 1)) ? i + 1 : 0;
        }
        T tempCard = cards[i];
        drawn[i] = true;
        --remainingCards;
        return tempCard;
    }

    /// <summary>
    /// Construct a new <see cref="Deck{T}"/> from another <see cref="System.Collections"/> type
    /// </summary>
    /// <param name="cardTable">Name of other <see cref="System.Collections"/></param> type
    public Deck(T[] cardTable) {
        for (int i = 0; i < cardTable.Length; i++) {
            cards.Add(cardTable[i]);
            drawn.Add(false);
        }
        remainingCards = cards.Count;
    }

    /// <summary>
    /// Construct a new <see cref="Deck{T}"/> from a plain <see cref="Array"/>
    /// </summary>
    /// <param name="cardTable">Name of the <see cref="Array"/> to copy</param>
    /// <param name="tableSize">size of the <see cref="Array"/ to copy></param>
    public Deck(T[] cardTable, int tableSize) {
        for (int i = 0; i < tableSize - 1; i++) {
            cards[i] = cardTable[i];
            drawn[i] = false;
        }
        remainingCards = cards.Count;
    }

    /// <summary>
    /// Create a copy of another <see cref="Deck{T}"/>
    /// </summary>
    /// <param name="oldDeck">Name of the other <see cref="Deck{T}"/></param>
    public Deck(Deck<T> oldDeck) {
        for (int i = 0; i < oldDeck.cards.Count; i++) {
            cards.Add(oldDeck.cards[i]);
            drawn.Add(oldDeck.drawn[i]);
        }
        remainingCards = cards.Count;
    }
}