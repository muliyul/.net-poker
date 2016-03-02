using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website.GameReference;

namespace Website
{
    public partial class Profile : System.Web.UI.Page
    {
        GameClient gc;
        public Player player;

        protected void Page_Load(object sender, EventArgs e)
        {
            gc = Session["GameClient"] as GameClient;
            player = Session["User"] as Player;
            if (player == null)
                Server.Transfer("login.aspx");
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["User"] = null;
            Server.Transfer("index.aspx");
        }
    }
}