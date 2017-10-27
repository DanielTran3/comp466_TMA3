using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SwapParts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["processor"] != null && Session["ram"] != null && Session["hardDrive"] != null &&
            Session["display"] != null && Session["operatingSystem"] != null && Session["soundCard"] != null && 
            Session["totalPrice"] != null)
        {
            List<Components> listOfProcessors = ComponentsFactory.GetAllProcessors();
            this.ProcessorGridView.DataSource = listOfProcessors;
            this.ProcessorGridView.DataBind();

            List<Components> listOfRAMs = ComponentsFactory.GetAllRAMs();
            this.RAMGridView.DataSource = listOfRAMs;
            this.RAMGridView.DataBind();

            List<Components> listOfHardDrives = ComponentsFactory.GetAllHardDrives();
            this.HardDriveGridView.DataSource = listOfHardDrives;
            this.HardDriveGridView.DataBind();

            List<Components> listOfOSs = ComponentsFactory.GetAllOperatingSystems();
            this.OperatingSystemGridView.DataSource = listOfOSs;
            this.OperatingSystemGridView.DataBind();

            List<Components> listOfDisplays = ComponentsFactory.GetAllDisplays();
            this.DisplayGridView.DataSource = listOfDisplays;
            this.DisplayGridView.DataBind();

            List<Components> listOfSoundCards = ComponentsFactory.GetAllSoundCards();
            this.SoundCardGridView.DataSource = listOfSoundCards;
            this.SoundCardGridView.DataBind();

            UpdateTotalCostLabel();

            if (!IsPostBack)
            {
                this.ProcessorGridView.SelectRow(Components.GetIndexOfComponent(Session["processor"] as Processor, listOfProcessors));
                this.RAMGridView.SelectRow(Components.GetIndexOfComponent(Session["ram"] as RAM, listOfRAMs));
                this.HardDriveGridView.SelectRow(Components.GetIndexOfComponent(Session["hardDrive"] as HardDrive, listOfHardDrives));
                this.OperatingSystemGridView.SelectRow(Components.GetIndexOfComponent(Session["operatingSystem"] as OperatingSystem, listOfOSs));
                this.DisplayGridView.SelectRow(Components.GetIndexOfComponent(Session["display"] as Display, listOfDisplays));
                this.SoundCardGridView.SelectRow(Components.GetIndexOfComponent(Session["soundCard"] as SoundCard, listOfSoundCards));
            }
            this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = true;
            this.SelectPreBuiltComputerFirstLabel.Visible = false;
            this.ProcessorLabel.Visible = true;
            this.RAMLabel.Visible = true;
            this.HardDriveLabel.Visible = true;
            this.OSLabel.Visible = true;
            this.DisplayLabel.Visible = true;
            this.SoundCardLabel.Visible = true;
            this.AddToCartButton.Visible = true;
        }
        else
        {
            this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = false;
            this.SelectPreBuiltComputerFirstLabel.Visible = true;
            this.ProcessorLabel.Visible = false;
            this.RAMLabel.Visible = false;
            this.HardDriveLabel.Visible = false;
            this.OSLabel.Visible = false;
            this.DisplayLabel.Visible = false;
            this.SoundCardLabel.Visible = false;
            this.AddToCartButton.Visible = false;
        }
    }

    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView gridView = sender as GridView;
        gridView.PageIndex = e.NewPageIndex;
        gridView.DataBind();

        if (gridView.DataSource as List<Components> != null)
        {
            List<Components> componentList = gridView.DataSource as List<Components>;
            Components component = componentList[0];
            int index = Components.GetIndexOfComponent(Session[component.GetSessionName()] as Components, componentList);

            // Index is within the limits of the current page. Convert the index to an index within the range
            if ((index >= gridView.PageIndex * gridView.PageSize) && (index < (gridView.PageIndex + 1) * gridView.PageSize))
            {
                GetGridViewFromComponent(component).SelectRow(index % gridView.PageSize);
            }
            else
            {
                GetGridViewFromComponent(component).SelectRow(-1);
            }
            Session.Add(component.GetSessionName(), componentList[index]);
        }
    }

    protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridView gv = sender as GridView;
            if (gv.SelectedIndex >= 0)
            {
                List<Components> componentList = gv.DataSource as List<Components>;
                if (gv.SelectedIndex != -1)
                {
                    // Get the real selected index
                    int index = gv.SelectedIndex + (gv.PageSize * gv.PageIndex);
                    Components component = componentList[index];
                    Components oldComponent = Session[component.GetSessionName()] as Components;

                    double totalPrice = (double)Session["totalPrice"];
                    totalPrice -= oldComponent.GetPrice();
                    totalPrice += component.GetPrice();

                    Session.Add(component.GetSessionName(), component);
                    Session.Add("totalPrice", totalPrice);
                    UpdateTotalCostLabel();
                }
            }
        }
        catch { }
    }

    protected void AddToCartButton_Click(object sender, EventArgs e)
    {
        if (Session["processor"] != null && Session["ram"] != null && Session["hardDrive"] != null &&
            Session["display"] != null && Session["operatingSystem"] != null && Session["soundCard"] != null &&
            Session["totalPrice"] != null)
        {
            PreBuiltSystem newSystem = new PreBuiltSystem(Session["processor"] as Components, Session["ram"] as Components,
                                                      Session["hardDrive"] as Components, Session["display"] as Components,
                                                      Session["operatingSystem"] as Components, Session["soundCard"] as Components);
            if (Session["cart"] == null)
            {
                Session.Clear();
                Session["cart"] = new List<PreBuiltSystem>() { newSystem };
            }
            else
            {
                List<PreBuiltSystem> cartContents = Session["cart"] as List<PreBuiltSystem>;
                if (Session["EditingRow"] != null)
                {
                    int rowToEdit = (int) Session["EditingRow"];
                    Session.Clear();
                    cartContents[rowToEdit] = newSystem;
                    Session["cart"] = cartContents;
                }
                else
                {
                    Session.Clear();
                    cartContents.Add(newSystem);
                    Session["cart"] = cartContents;
                }
            }
        }
        Response.Redirect("Cart.aspx");
    }

    public void UpdateTotalCostLabel()
    {
        Label totalCostLabel = (Label)Master.FindControl("TotalCostLabel");
        if (totalCostLabel != null)
        {
            totalCostLabel.Text = "$" + Session["totalPrice"];
        }
    }

    public GridView GetGridViewFromComponent(Components component)
    {
        return (GridView) RecurseControl(this.Master, component.GetGridView());
    }

    public Control RecurseControl(Control root, string Id)
    {
        if (root.ID == Id)
            return root;

        foreach (Control control in root.Controls)
        {
            Control foundControl = RecurseControl(control, Id);
            if (foundControl != null)
                return foundControl;
        }

        return null;
    }
}