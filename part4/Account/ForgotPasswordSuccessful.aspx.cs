using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_ForgotPasswordSuccessful : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Show the page only coming from the ForgetPassword page. Anyother page gets redirected to the login screen.
        if (Session["validRecovery"] != null)
        {
            Session["validRecovery"] = null;
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}