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
            this.TotalCartPriceLabel.Visible = false;
        }
        else
        {
            this.EmptyCartLabel.Visible = false;
            this.EmptyCartSubtitleLabel.Visible = false;
            this.CartGridView.Visible = true;
            this.TotalCartPriceLabel.Visible = true;

            this.CartGridView.DataSource = Session["cart"] as List<PreBuiltSystem>;

            double totalPrice = 0;

            foreach (PreBuiltSystem pbs in Session["cart"] as List<PreBuiltSystem>)
            {
                totalPrice += PreBuiltSystem.GetPrice(pbs.Price);
            }

            this.TotalCartPriceLabel.Text = "Total Cost: $" + totalPrice.ToString();

            this.CartGridView.DataBind();
        }
    }

    protected void CartGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        List<PreBuiltSystem> cartList = Session["cart"] as List<PreBuiltSystem>;
        PreBuiltSystem pbs = cartList[e.NewEditIndex];
        Session.Add(pbs.ProcessorPart.GetSessionName(), pbs.ProcessorPart);
        Session.Add(pbs.RamPart.GetSessionName(), pbs.RamPart);
        Session.Add(pbs.HardDrivePart.GetSessionName(), pbs.HardDrivePart);
        Session.Add(pbs.DisplayPart.GetSessionName(), pbs.DisplayPart);
        Session.Add(pbs.OperatingSystemPart.GetSessionName(), pbs.OperatingSystemPart);
        Session.Add(pbs.SoundCardPart.GetSessionName(), pbs.SoundCardPart);
        Session.Add("totalPrice", Convert.ToDouble(pbs.Price.Replace("$", "")));
        Session.Add("EditingRow", e.NewEditIndex);
        Response.Redirect("SwapParts.aspx");
    }
}