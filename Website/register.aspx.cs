using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website.GameReference;

namespace Website
{
    public partial class Register : System.Web.UI.Page
    {
        GameClient gc;

        protected void Page_Load(object sender, EventArgs e)
        {
            gc = Session["GameClient"] as GameClient;
        }

        protected void Submit(object sender, EventArgs e)
        {
            if (passwordTF.Text != passwordTF2.Text)
            {
                errorLbl.Text = "Passwords must match!";
                return;
            }
            try
            {
                gc.Register(usernameTF.Text, passwordTF.Text);
                Server.Transfer("Login.aspx", true);
            }
            catch (Exception err)
            {
                errorLbl.Text = err.Message;
            }
        }
    }
}