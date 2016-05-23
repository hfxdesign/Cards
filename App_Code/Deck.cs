using System;
using System.Collections.Generic;

public class Deck<T> where T : WhiteCard {
    private int remainingCards;
    private List<T> cards;
    private List<bool> drawn;

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

    /// <summary>
    /// Default constructor
    /// </summary>
    public Deck() {
        cards = new List<T>();
        drawn = new List<bool>();
    }

    /// <summary>
    /// Add a new card to the deck
    /// </summary>
    /// <param name="card">Card to be added</param>
    public void addCard(T card) {
        cards.Add(card);
        drawn.Add(false);
        ++remainingCards;
    }

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
        if (cards.Count > 0) {
            i = new Random().Next(cards.Count - 1);

            while (drawn[i])
                i = (i == (drawn.Count - 1)) ? 0 : i + 1;
        }
        T tempCard = cards[i];
        drawn[i] = true;
        --remainingCards;
        return tempCard;
    }
}