using System;
using System.Collections.Generic;

public class Deck<T> where T : Card {
    private List<T> cards;

    public bool isEmpty() {
        return (cards.Count > 0 ? false : true);
    }

    public T drawCard() {
        T tempCard;
        int i = 0;

        while (cards.Count > 1) {
            i = new Random(cards.Count - 1).Next();
        }
        tempCard = cards[i];
        cards.RemoveAt(i);
        return tempCard;
    }

    //Ctor for pulling entire T[] array
    public Deck(T[] cardTable) {
        for (int i = 0; i < cardTable.Length; i++)
            cards.Add(cardTable[i]);
    }

    //Ctor to specify a set deck size
    public Deck(T[] cardTable, int deckSize) {
        if (cardTable.Length >= deckSize) {
            for (int i = 0; i < deckSize; i++)
                cards[i] = cardTable[i];
        }
        else
            //Make sure they can't create a deck larger than the table
            throw new IndexOutOfRangeException();
    }
}