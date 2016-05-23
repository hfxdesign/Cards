using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        Game thisGame = new Game(5);
    }
}