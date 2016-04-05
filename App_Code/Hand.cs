using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
public class Hand {
    private List<Card> myHand;

    public void getHand(HashSet<Card> CardBox) {
        /* If empty */
        if (!this.myHand.Any()) {
            for (int i = 0; i < 10; i++) {
                this.myHand.Add(CardBox.ElementAt(0));
                CardBox.Remove(CardBox.ElementAt(0));
            }
        }
        else {
            Console.WriteLine("Error: You don't have an empty hand.");
        }
    }
    public void draw(HashSet<Card> CardBox) {
        if (this.myHand.Count <= 10) {
            this.myHand.Add(CardBox.ElementAt(0));
            CardBox.Remove(CardBox.ElementAt(0));
        }
        else
            Console.WriteLine("Error: You have a full hand.");
    }
    public Hand(HashSet<Card> CardBox) {
        this.getHand(CardBox);
    }
}