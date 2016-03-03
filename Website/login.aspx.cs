using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website.GameReference;

namespace Website
{
    public partial class Login : System.Web.UI.Page
    {
        GameClient gc;
        //test
        protected void Page_Load(object sender, EventArgs e)
        {
             gc = Session["GameClient"] as GameClient;
        }

        protected void Submit(object sender, EventArgs e)
        {
            try
            {
                Session["User"] = gc.Login(usernameTF.Text, passwordTF.Text);
                Server.Transfer("profile.aspx", true);
            }
            catch (Exception err)
            {
                errorLbl.Text = err.Message;
            }
        }
    }
}