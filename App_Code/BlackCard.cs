﻿public class BlackCard : Card {
    public int draw { get; set; }
    public int pick { get; set; }
    public string text { get; set; }

    public BlackCard(int id, int draw, int pick, string text)
        : base(id) {

        this.draw = draw;
        this.pick = pick;
        this.text = text;
    }

    public BlackCard(BlackCard obj)
        : base(obj.ID) {

        draw = obj.draw;
        pick = obj.pick;
        text = obj.text;
    }
}