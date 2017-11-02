using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CookieVisits : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //https://stackoverflow.com/questions/3140341/how-to-create-persistent-cookies-in-asp-net
        // Request a cookie from the user
        HttpCookie visitCookie = Request.Cookies["visitCount"];

        // If there is no cookie called visitCount
        if (visitCookie == null)
        {
            // Make a new cookie and set the numVisits value to 0
            visitCookie = new HttpCookie("visitCount");
            visitCookie.Values.Add("numVisits", "0");
            // Set the cookie's expiry date for a day
            visitCookie.Expires = DateTime.Now.AddHours(24);
            // Add the cookie to the client's cookies
            Response.Cookies.Add(visitCookie);
        }
        else // A cookie called visitCount exists
        {
            // Check the visitCookie's numVisits value
            if (!string.IsNullOrEmpty(visitCookie.Values["numVisits"]))
            {
                // Increment the numVisits count and save it back to cookie
                int numCounts = int.Parse(visitCookie.Values["numVisits"]);
                numCounts++;
                visitCookie.Values.Set("numVisits", numCounts.ToString());
                Response.Cookies.Add(visitCookie);
            }
        }
        // Display the numVisits value to label.
        NumberOfVisitsCountLabel.Text = visitCookie.Values["numVisits"];

        // Display the IP text label.
        ClientIPAddressLabel.Text = GetIPAddress();
    }

    //https://stackoverflow.com/questions/735350/how-to-get-a-users-client-ip-address-in-asp-net
    // Get's the IP address of the user on the server side.
    protected string GetIPAddress()
    {
        // Get the current context
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        // If the IP address is available, return it
        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
                return addresses[0];
            }
        }

        return context.Request.ServerVariables["REMOTE_ADDR"];
    }
}