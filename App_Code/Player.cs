﻿using System.Collections.Generic;

/// <summary>
/// Object used for storing winning hands. <para />
/// Consists of 1 <see cref="BlackCard"/> and 3 <see cref="WhiteCard"/>s
/// </summary>
class winningHand {
    BlackCard blackCard;
    WhiteCard[] whiteCards = new WhiteCard[3];
}

public class Player {
    private const int HANDSIZE = 10;
    private List<WhiteCard> hand = new List<WhiteCard>();
    private LinkedList<winningHand> winningHands = new LinkedList<winningHand>();
    private int handsWon = 0, handsLost = 0;
    private int pickCount = 0;

    public void addWin(BlackCard blackCard) {
        ++handsWon;
    }

    public void addLoss() {
        ++handsLost;
    }

    /// <summary>
    /// Create a new player and link the <see cref="Deck{T}"/> <para />
    /// Draw 10 cards from the linked <see cref="Deck{T}"/>
    /// </summary>
    /// <param name="whiteDeck"></param>
    public Player(Deck<WhiteCard> whiteDeck) {
        for (int i = 0; i < HANDSIZE; i++)
            hand.Add(whiteDeck.drawCard());
    }
}