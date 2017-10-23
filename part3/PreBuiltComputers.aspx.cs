using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PreBuiltComputers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.PreBuiltComputersGridView.DataSource = Session["prebuiltSystems"];
        this.PreBuiltComputersGridView.DataBind();
        if (IsPostBack)
        {

        }
    }

    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView gridView = sender as GridView;
        gridView.PageIndex = e.NewPageIndex;
        gridView.DataBind();
    }

    protected void PreBuiltComputersGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        List<PreBuiltSystem> pbsList = gv.DataSource as List<PreBuiltSystem>;
        PreBuiltSystem pbs = pbsList[gv.SelectedIndex];
        Session.Add("processor", pbs.Processor);
        Session.Add("ram", pbs.Ram);
        Session.Add("hardDrive", pbs.HardDrive);
        Session.Add("display", pbs.Display);
        Session.Add("operatingSystem", pbs.OperatingSystem);
        Session.Add("soundCard", pbs.SoundCard);
        Session.Add("totalPrice", pbs.Price);

        Label totalCostLabel = (Label)Master.FindControl("TotalCostLabel");
        if (totalCostLabel != null)
        {
            totalCostLabel.Text = pbs.Price;
        }
    }
}