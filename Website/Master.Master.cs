using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website.GameReference;

namespace Website
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["GameClient"] = new GameClient();
            if (Session["User"] != null)
            {
                loginProfileBtn.HRef = "profile.aspx";
                loginProfileBtn.InnerText = "Profile";
            }
        }
    }
}