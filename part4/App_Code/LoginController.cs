using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for LoginController
/// </summary>
public static class LoginController
{
    public static void IsUserLoggedIn(System.Web.UI.Page page)
    {
        if (page.Session["username"] == null)
        {
            page.Response.Redirect("~/Account/Login.aspx");
        }
    }
}