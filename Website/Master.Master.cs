using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website.App_Data;

namespace Website
{
    public partial class Master : System.Web.UI.MasterPage
    {
        DataClassesDataContext db = new DataClassesDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}