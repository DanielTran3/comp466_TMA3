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
        if (Session["prebuiltSystems"] != null)
        {
            this.PreBuiltComputersGridView.DataSource = Session["prebuiltSystems"];
        }
        else
        {
            this.PreBuiltComputersGridView.DataSource = PreBuiltSystem.GetAllPreBuiltSystems();
            Session.Add("prebuiltSystems", this.PreBuiltComputersGridView.DataSource);
        }

        Label totalCostLabel = (Label)Master.FindControl("TotalCostLabel");
        if (totalCostLabel != null && Session["totalPrice"] != null)
        {
            totalCostLabel.Text = "$" + Session["totalPrice"].ToString();
        }

        this.PreBuiltComputersGridView.DataBind();
    }

    protected void PreBuiltComputersGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        List<PreBuiltSystem> pbsList = gv.DataSource as List<PreBuiltSystem>;
        PreBuiltSystem pbs = pbsList[gv.SelectedIndex];
        pbs.PreBuiltIndex = gv.SelectedIndex;
        Session.Add(pbs.ProcessorPart.GetSessionName(), pbs.ProcessorPart);
        Session.Add(pbs.RamPart.GetSessionName(), pbs.RamPart);
        Session.Add(pbs.HardDrivePart.GetSessionName(), pbs.HardDrivePart);
        Session.Add(pbs.DisplayPart.GetSessionName(), pbs.DisplayPart);
        Session.Add(pbs.OperatingSystemPart.GetSessionName(), pbs.OperatingSystemPart);
        Session.Add(pbs.SoundCardPart.GetSessionName(), pbs.SoundCardPart);
        // Keep the totalPrice stored as a double
        Session.Add("totalPrice", Convert.ToDouble(pbs.Price.Replace("$","")));

        Label totalCostLabel = (Label)Master.FindControl("TotalCostLabel");
        if (totalCostLabel != null)
        {
            totalCostLabel.Text = pbs.Price;
        }
    }
}