using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label label = this.LoginLogoutLabel as Label;
        LinkButton link = this.LoginLogoutLink as LinkButton;
        if (Session["username"] == null)
        {
            label.Text = "Not Logged in?";
            link.Text = "[Login]";
            link.PostBackUrl = "~/Account/Login.aspx";
        }
        else
        {
            label.Text = "Welcome, " + Session["Username"].ToString();
            link.Text = "[Logout]";
            link.PostBackUrl = "~/Default.aspx";
        }
    }

    protected void LoginLogoutLink_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Response.Redirect(Page.Request.Url.ToString(), true);
    }
}
