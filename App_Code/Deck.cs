using System;
using System.Collections.Generic;

public class Deck<T> where T : Card {
    public List<T> cardsList;
    public Stack<T> cardsStack;

    public bool isEmpty() {
        return (cardsList.Count > 0 ? false : true);
    }

    public void Shuffle() {
        Random rng = new Random();

        while (cardsList.Count > 1) {
            int i = rng.Next(cardsList.Count - 1);
            cardsStack.Push(cardsList[i]);
            cardsList.Remove(cardsList[i]);
        }
    }

    //Ctor for pulling entire T[] array
    public Deck(T[] cardTable) {
        cardsList.AddRange(cardTable);
        Shuffle();
    }

    //Ctor to specify a set deck size
    public Deck(T[] cardTable, int deckSize) {
        for (int i = 0; i < deckSize; i++)
            cardsList.Add(cardTable[i]);
        Shuffle();
    }
}