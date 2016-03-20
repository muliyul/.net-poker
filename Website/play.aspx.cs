using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website.GameReference;

namespace Website.Views
{
    public partial class play : System.Web.UI.Page
    {
        GameClient gc;

        protected void Page_Load(object sender, EventArgs e)
        {
            gc = Session["GameClient"] as GameClient;

            fillBlackJackTableList();

        }

        private async void fillBlackJackTableList()
        {
            var tableList = await gc.ListTablesAsync();

            var tableHead = new TableHeaderRow();
            tableHead.CssClass = "text-center";
            var cell = new TableHeaderCell();
            cell.Controls.Add(new Label() { Text = "Id" });
            tableHead.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.Controls.Add(new Label() { Text = "Status" });
            tableHead.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.Controls.Add(new Label() { Text = "Players" });
            tableHead.Controls.Add(cell);


            blackJackTables.Controls.Add(tableHead);
            blackJackTables.CssClass = "table table-striped table-bordered table-hover text-center table-condensed";

            int i = 1;
            foreach (var t in tableList)
            {
                var row = new TableRow();

                var cellBuillder = new TableCell();
                cellBuillder.Controls.Add(new Label() { Text = i++.ToString() });
                row.Controls.Add(cellBuillder);

                cellBuillder = new TableCell();
                cellBuillder.Controls.Add(new Label() { Text = t.InGame ? "Game in progress" : "waiting for playes" });
                row.Controls.Add(cellBuillder);

                cellBuillder = new TableCell();
                cellBuillder.Controls.Add(new Label() { Text = t.Players.Count.ToString() });
                row.Controls.Add(cellBuillder);



                blackJackTables.Controls.Add(row);
            }
        }
    }
}