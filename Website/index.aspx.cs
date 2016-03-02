using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website.GameReference;

namespace Website.Views
{
    public partial class index : System.Web.UI.Page
    {
        GameClient gc;

        protected void Page_Load(object sender, EventArgs e)
        {
            gc = Session["GameClient"] as GameClient;
        }
    }
}