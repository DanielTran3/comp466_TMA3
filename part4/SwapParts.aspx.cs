using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SwapParts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        //using (MySqlConnection con = new MySqlConnection(constr))
        //{
        //    con.Open();
        //    using (MySqlCommand processorCommand = new MySqlCommand("SELECT * FROM processor", con))
        //    {
        //        this.ProcessorGridView.DataSource = processorCommand.ExecuteReader();
        //        this.ProcessorGridView.DataBind();
        //        con.Close();
        //    }
        //}

        if (DoesUserHaveOrder())
        {
            BindDatabaseToGridview("processor", this.ProcessorGridView);
            BindDatabaseToGridview("ram", this.RAMGridView);
            BindDatabaseToGridview("hardDrive", this.HardDriveGridView);
            BindDatabaseToGridview("operatingSystem", this.OperatingSystemGridView);
            BindDatabaseToGridview("display", this.DisplayGridView);
            BindDatabaseToGridview("soundCard", this.SoundCardGridView);
            if (!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    con.Open();
                    SelectCurrentComponent("processor", con, this.ProcessorGridView);
                    SelectCurrentComponent("ram", con, this.RAMGridView);
                    SelectCurrentComponent("hardDrive", con, this.HardDriveGridView);
                    SelectCurrentComponent("operatingSystem", con, this.OperatingSystemGridView);
                    SelectCurrentComponent("display", con, this.DisplayGridView);
                    SelectCurrentComponent("soundCard", con, this.SoundCardGridView);
                    con.Close();
                }
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




        //if (Session["processor"] != null && Session["ram"] != null && Session["hardDrive"] != null &&
        //    Session["display"] != null && Session["operatingSystem"] != null && Session["soundCard"] != null && 
        //    Session["totalPrice"] != null)
        //{
        //    List<Components> listOfProcessors = ComponentsFactory.GetAllProcessors();
        //    this.ProcessorGridView.DataSource = listOfProcessors;
        //    this.ProcessorGridView.DataBind();

        //    List<Components> listOfRAMs = ComponentsFactory.GetAllRAMs();
        //    this.RAMGridView.DataSource = listOfRAMs;
        //    this.RAMGridView.DataBind();

        //    List<Components> listOfHardDrives = ComponentsFactory.GetAllHardDrives();
        //    this.HardDriveGridView.DataSource = listOfHardDrives;
        //    this.HardDriveGridView.DataBind();

        //    List<Components> listOfOSs = ComponentsFactory.GetAllOperatingSystems();
        //    this.OperatingSystemGridView.DataSource = listOfOSs;
        //    this.OperatingSystemGridView.DataBind();

        //    List<Components> listOfDisplays = ComponentsFactory.GetAllDisplays();
        //    this.DisplayGridView.DataSource = listOfDisplays;
        //    this.DisplayGridView.DataBind();

        //    List<Components> listOfSoundCards = ComponentsFactory.GetAllSoundCards();
        //    this.SoundCardGridView.DataSource = listOfSoundCards;
        //    this.SoundCardGridView.DataBind();

        //    UpdateTotalCostLabel();

        //    if (!IsPostBack)
        //    {
        //        this.ProcessorGridView.SelectRow(Components.GetIndexOfComponent(Session["processor"] as Processor, listOfProcessors));
        //        this.RAMGridView.SelectRow(Components.GetIndexOfComponent(Session["ram"] as RAM, listOfRAMs));
        //        this.HardDriveGridView.SelectRow(Components.GetIndexOfComponent(Session["hardDrive"] as HardDrive, listOfHardDrives));
        //        this.OperatingSystemGridView.SelectRow(Components.GetIndexOfComponent(Session["operatingSystem"] as OperatingSystem, listOfOSs));
        //        this.DisplayGridView.SelectRow(Components.GetIndexOfComponent(Session["display"] as Display, listOfDisplays));
        //        this.SoundCardGridView.SelectRow(Components.GetIndexOfComponent(Session["soundCard"] as SoundCard, listOfSoundCards));
        //    }
        //    this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = true;
        //    this.SelectPreBuiltComputerFirstLabel.Visible = false;
        //    this.ProcessorLabel.Visible = true;
        //    this.RAMLabel.Visible = true;
        //    this.HardDriveLabel.Visible = true;
        //    this.OSLabel.Visible = true;
        //    this.DisplayLabel.Visible = true;
        //    this.SoundCardLabel.Visible = true;
        //    this.AddToCartButton.Visible = true;
        //}
        //else
        //{
        //    this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = false;
        //    this.SelectPreBuiltComputerFirstLabel.Visible = true;
        //    this.ProcessorLabel.Visible = false;
        //    this.RAMLabel.Visible = false;
        //    this.HardDriveLabel.Visible = false;
        //    this.OSLabel.Visible = false;
        //    this.DisplayLabel.Visible = false;
        //    this.SoundCardLabel.Visible = false;
        //    this.AddToCartButton.Visible = false;
        //}
    }

    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView gridView = sender as GridView;
        gridView.PageIndex = e.NewPageIndex;
        gridView.DataBind();

        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            if (gridView == this.ProcessorGridView)
            {
                SelectCurrentComponent("processor", con, gridView);
            }
            else if (gridView == this.RAMGridView)
            {
                SelectCurrentComponent("ram", con, gridView);
            }
            else if (gridView == this.HardDriveGridView)
            {
                SelectCurrentComponent("hardDrive", con, gridView);
            }
            else if (gridView == this.OperatingSystemGridView)
            {
                SelectCurrentComponent("operatingSystem", con, gridView);
            }
            else if (gridView == this.DisplayGridView)
            {
                SelectCurrentComponent("display", con, gridView);
            }
            else if (gridView == this.SoundCardGridView)
            {
                SelectCurrentComponent("soundCard", con, gridView);
            }
        }
    }

    protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridView gv = sender as GridView;
            Components component = gv.DataSource as Components;
            if (gv.SelectedIndex >= 0)
            {
                if (gv.SelectedIndex != -1)
                {
                    string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {
                        con.Open();
                        if (gv == this.ProcessorGridView)
                        {
                            UpdateCurrentSelection("processor", con, gv);
                        }
                        else if (gv == this.RAMGridView)
                        {
                            UpdateCurrentSelection("ram", con, gv);
                        }
                        else if (gv == this.HardDriveGridView)
                        {
                            UpdateCurrentSelection("hardDrive", con, gv);
                        }
                        else if (gv == this.OperatingSystemGridView)
                        {
                            UpdateCurrentSelection("operatingSystem", con, gv);
                        }
                        else if (gv == this.DisplayGridView)
                        {
                            UpdateCurrentSelection("display", con, gv);
                        }
                        else if (gv == this.SoundCardGridView)
                        {
                            UpdateCurrentSelection("soundCard", con, gv);
                        }
                        con.Close();
                    }

                    //// Get the real selected index
                    //int index = gv.SelectedIndex + (gv.PageSize * gv.PageIndex);
                    //Components component = componentList[index];
                    //Components oldComponent = Session[component.GetSessionName()] as Components;

                    //double totalPrice = (double)Session["totalPrice"];
                    //totalPrice -= oldComponent.GetPrice();
                    //totalPrice += component.GetPrice();

                    //Session.Add(component.GetSessionName(), component);
                    //Session.Add("totalPrice", totalPrice);
                    //UpdateTotalCostLabel();
                }
            }
        }
        catch { }
    }

    protected void AddToCartButton_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            using (MySqlCommand saveOrderCommand = new MySqlCommand(@"INSERT INTO orders (username, prebuiltSystem, display, hardDrive, operatingSystem, processor, ram, soundCard, totalPrice)
                                                                      SELECT username, prebuiltSystem, display, hardDrive, operatingSystem, processor, ram, soundCard, totalPrice
                                                                      FROM currentOrder 
                                                                      WHERE username=@username", con))
            {
                saveOrderCommand.Parameters.AddWithValue("@username", Session["username"]);
                int affectedRow = saveOrderCommand.ExecuteNonQuery();
                saveOrderCommand.Dispose();
            }

            using (MySqlCommand deleteCurrentOrderCommand = new MySqlCommand(@"DELETE FROM currentOrder WHERE username=@username", con))
            {
                deleteCurrentOrderCommand.Parameters.AddWithValue("@username", Session["username"]);
                int affectedRow = deleteCurrentOrderCommand.ExecuteNonQuery();
                deleteCurrentOrderCommand.Dispose();
            }
            con.Close();
        }
        //if (Session["processor"] != null && Session["ram"] != null && Session["hardDrive"] != null &&
        //    Session["display"] != null && Session["operatingSystem"] != null && Session["soundCard"] != null &&
        //    Session["totalPrice"] != null)
        //{
        //PreBuiltSystem newSystem = new PreBuiltSystem(Session["processor"] as Components, Session["ram"] as Components,
        //                                          Session["hardDrive"] as Components, Session["display"] as Components,
        //                                          Session["operatingSystem"] as Components, Session["soundCard"] as Components);
        //if (Session["cart"] == null)
        //{
        //    Session.Clear();
        //    Session["cart"] = new List<PreBuiltSystem>() { newSystem };
        //}
        //else
        //{
        //    List<PreBuiltSystem> cartContents = Session["cart"] as List<PreBuiltSystem>;
        //    if (Session["EditingRow"] != null)
        //    {
        //        int rowToEdit = (int) Session["EditingRow"];
        //        Session.Clear();
        //        cartContents[rowToEdit] = newSystem;
        //        Session["cart"] = cartContents;
        //    }
        //    else
        //    {
        //        Session.Clear();
        //        cartContents.Add(newSystem);
        //        Session["cart"] = cartContents;
        //    }
        //}
        //}
        Response.Redirect("Cart.aspx");
    }

    public void UpdateTotalCostLabel()
    {
        double totalPrice = 0;
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            using (MySqlCommand totalPriceCommand = new MySqlCommand("SELECT totalPrice FROM currentOrder WHERE username=@username ", con))
            {
                totalPriceCommand.Parameters.AddWithValue("@username", Session["username"]);
                string totalPriceString = totalPriceCommand.ExecuteScalar().ToString();
                totalPrice = Convert.ToDouble(totalPriceString.Replace("$", ""));
            }
            con.Close();
        }

        Label totalCostLabel = (Label)Master.FindControl("TotalCostLabel");
        if (totalCostLabel != null)
        {
            totalCostLabel.Text = "$" + totalPrice;
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

    public void BindDatabaseToGridview(string tableName, GridView gridview)
    {
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            //using (MySqlCommand tableRows = new MySqlCommand("SELECT * FROM " + tableName, con))
            //{
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM " + tableName, con))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    //gridview.Columns[0].Visible = true;
                    gridview.DataSource = tempTable;
                    gridview.DataBind();
                    //gridview.Columns[0].Visible = false;
                    con.Close();
                }
            //}
        }
    }

    public void SelectCurrentComponent(string component, MySqlConnection con, GridView gv)
    {
        int componentRowIndex = -1;
        using (MySqlCommand getRowIndexCommand = new MySqlCommand("SELECT " + component + 
                                                                 @" FROM currentOrder 
                                                                    WHERE username=@username", con))
        {
            getRowIndexCommand.Parameters.AddWithValue("@username", Session["username"]);
            componentRowIndex = Convert.ToInt32(getRowIndexCommand.ExecuteScalar().ToString());
            getRowIndexCommand.Dispose();
        }

        int rowIndex = -1;
        foreach (GridViewRow gvr in gv.Rows)
        {
            if (Convert.ToInt32(gvr.Cells[1].Text) == componentRowIndex)
            {
                rowIndex = gvr.RowIndex;
                break;
            }
        }
        gv.SelectRow(rowIndex);
    }

    public void UpdateCurrentSelection(string component, MySqlConnection con, GridView gv)
    {
        double oldPrice = 0.0;
        double totalPrice = 0.0;
        using (MySqlCommand totalPriceCommand = new MySqlCommand("SELECT totalPrice FROM currentOrder WHERE username=@username", con))
        {
            totalPriceCommand.Parameters.AddWithValue("@username", Session["username"]);
            string totalPriceString = totalPriceCommand.ExecuteScalar().ToString();
            totalPrice = Convert.ToDouble(totalPriceString.Replace("$", ""));
            totalPriceCommand.Dispose();
        }
        using (MySqlCommand getOldPriceCommand = new MySqlCommand("SELECT Price " + 
                                                                  "FROM (SELECT " + component + @" as oldId
                                                                          FROM currentOrder 
                                                                          WHERE username=@username) oldIDTable, "
                                                                    + component + " componentTable" +  
                                                                    " WHERE componentTable.id=oldIDTable.oldId", con))
        {
            getOldPriceCommand.Parameters.AddWithValue("@username", Session["username"]);
            string oldPriceString = getOldPriceCommand.ExecuteScalar().ToString();
            oldPrice = Convert.ToDouble(oldPriceString.Replace("$", ""));
            getOldPriceCommand.Dispose();
        }

        // The price is always in the last column
        double newPrice = Convert.ToDouble(gv.SelectedRow.Cells[gv.Columns.Count].Text.Replace("$", ""));
        totalPrice = totalPrice - oldPrice + newPrice;

        using (MySqlCommand updateOrderCommand = new MySqlCommand("UPDATE currentOrder SET " + component + "=@component, totalPrice=@newTotal WHERE username=@username", con))
        {
            updateOrderCommand.Parameters.AddWithValue("@username", Session["username"]);
            updateOrderCommand.Parameters.AddWithValue("@component", gv.SelectedRow.Cells[1].Text);
            updateOrderCommand.Parameters.AddWithValue("@newTotal", "$" + totalPrice);
            int affectedRows = updateOrderCommand.ExecuteNonQuery();
            updateOrderCommand.Dispose();
        }
        UpdateTotalCostLabel();
    }

    public bool DoesUserHaveOrder()
    {
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            using (MySqlCommand findUserCommand = new MySqlCommand("SELECT * FROM currentOrder WHERE username=@username", con))
            {
                findUserCommand.Parameters.AddWithValue("@username", Session["username"]);
                using (MySqlDataReader reader = findUserCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        con.Close();
                        findUserCommand.Dispose();
                        return true;
                    }
                    findUserCommand.Dispose();
                }
            }
            con.Close();
        }
        return false;
    }
}