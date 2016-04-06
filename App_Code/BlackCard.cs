using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BlackCard : Card {
    public int draw { get; set; }
    public int pick { get; set; }
   
    public BlackCard(int id, int draw, int pick, string text) : base(id, text) {
        this.draw = draw;
        this.pick = pick;
    }
}