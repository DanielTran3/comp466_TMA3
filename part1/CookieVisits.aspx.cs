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
        HttpCookie visitCookie = Request.Cookies["visitCount"];
        if (visitCookie == null)
        {
            visitCookie = new HttpCookie("visitCount");
            visitCookie.Values.Add("numVisits", "0");
            visitCookie.Expires = DateTime.Now.AddHours(24);
            Response.Cookies.Add(visitCookie);
        }
        else
        {
            if (!string.IsNullOrEmpty(visitCookie.Values["numVisits"]))
            {
                int numCounts = int.Parse(visitCookie.Values["numVisits"]);
                numCounts++;
                visitCookie.Values.Set("numVisits", numCounts.ToString());
                Response.Cookies.Add(visitCookie);
            }
        }
        NumberOfVisitsCountLabel.Text = visitCookie.Values["numVisits"];
        ClientIPAddressLabel.Text = GetIPAddress();
    }

    //https://stackoverflow.com/questions/735350/how-to-get-a-users-client-ip-address-in-asp-net
    protected string GetIPAddress()
    {
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

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