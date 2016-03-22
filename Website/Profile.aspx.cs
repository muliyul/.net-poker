using System;
using System.Collections.Generic;
using System.Data;
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
        public PlayerData player;

        protected void Page_Load(object sender, EventArgs e)
        {
            gc = Session["GameClient"] as GameClient;
            player = Session["User"] as PlayerData;
            if (player == null)
            {
                Server.Transfer("login.aspx");
                return;
            }
            SqlDataSource1.SelectCommand =
                string.Format("SELECT Games.PlayedOn, Games.Winnings, Games.Blackjacks, Games.WonHands, Games.LostHands " +
                "FROM Games INNER JOIN Players ON Games.PlayerId = Players.Id AND Players.Username = '{0}'", player.Username);
            SqlDataSource1.DataBind();
            GridView1.DataBind();
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["User"] = null;
            Server.Transfer("index.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the data row bound to the grid view row
                DataRowView drv = (DataRowView)e.Row.DataItem;

                //Find the label in question
                Label lbl = e.Row.FindControl("wlr") as Label;

                //Perform your needed calculation
                try
                {
                    int wins = (int)drv["WonHands"];
                    double total = wins + (int)drv["LostHands"];
                    lbl.Text = wins / total * 100 + "%";
                }
                catch
                {
                    lbl.Text = "Inf.";
                }
            }
        }
    }
}