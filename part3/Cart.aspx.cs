using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ConfigureCartPage();
        this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = false;
    }

    protected void CartGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView gv = sender as GridView;
        List<PreBuiltSystem> pbsList = Session["cart"] as List<PreBuiltSystem>;
        pbsList.RemoveAt(e.RowIndex);
        gv.DataBind();

        Session["cart"] = pbsList;
        ConfigureCartPage();
    }

    public void ConfigureCartPage()
    {
        if ((Session["cart"] == null) || ((Session["cart"] as List<PreBuiltSystem>).Count == 0))
        {
            this.EmptyCartLabel.Visible = true;
            this.EmptyCartSubtitleLabel.Visible = true;
            this.CartGridView.Visible = false;
        }
        else
        {
            this.EmptyCartLabel.Visible = false;
            this.EmptyCartSubtitleLabel.Visible = false;
            this.CartGridView.Visible = true;

            this.CartGridView.DataSource = Session["cart"] as List<PreBuiltSystem>;
            this.CartGridView.DataBind();
        }
    }
}