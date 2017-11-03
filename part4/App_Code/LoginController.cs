using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Static class containing static methods pertaining to user logins
/// </summary>
public static class LoginController
{
    // Checks if a session is available, if not redirect the user to the Login page
    public static void IsUserLoggedIn(System.Web.UI.Page page)
    {
        if (page.Session["username"] == null)
        {
            page.Response.Redirect("~/Account/Login.aspx");
        }
    }
}