using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginController.IsUserLoggedIn(this);
        ConfigureCartPage();
        this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = false;
    }

    protected void CartGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView gv = sender as GridView;


        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            using (MySqlCommand deleteOrderCommand = new MySqlCommand(@"DELETE FROM orders WHERE 
                                                                        username=@username AND 
                                                                        id=@id", con))
            {
                deleteOrderCommand.Parameters.AddWithValue("@username", Session["username"]);
                deleteOrderCommand.Parameters.AddWithValue("@id", gv.Rows[e.RowIndex].Cells[1].Text);
                int affectedRows = deleteOrderCommand.ExecuteNonQuery();
            }
        }

        //List<PreBuiltSystem> pbsList = Session["cart"] as List<PreBuiltSystem>;
        //pbsList.RemoveAt(e.RowIndex);
        //gv.DataBind();

        //Session["cart"] = pbsList;
        ConfigureCartPage();
    }

    public void ConfigureCartPage()
    {
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            using (MySqlCommand getOrdersCommand = new MySqlCommand(@"SELECT cpu.brand, cpu.model, cpu.clock, cpu.cache, cpu.socket, cpu.price, 
                                                                    ram.brand, ram.model, ram.speed, ram.memoryType, ram.price, 
                                                                    hd.brand, hd.model, hd.type, hd.size, hd.readSpeed, hd.writeSpeed, hd.price,
                                                                    d.brand, d.model, d.size, d.resolution, d.responseTime, d.price,
                                                                    os.brand, os.version, os.price,
                                                                    sc.brand, sc.model, sc.price,
                                                                    o.id
                                                                    FROM display d, harddrive hd, operatingSystem os, processor cpu, ram, soundCard sc, orders o
                                                                    WHERE o.display = d.ID AND
                                                                    o.hardDrive = hd.ID AND
                                                                    o.operatingSystem = os.ID AND
                                                                    o.processor = cpu.ID AND
                                                                    o.ram = ram.ID AND
                                                                    o.soundCard = sc.ID AND
                                                                    o.username = @username
                                                                    ORDER BY o.id", con))
            {
                getOrdersCommand.Parameters.AddWithValue("@username", Session["username"]);
                List<PreBuiltSystem> listOfSystems = new List<PreBuiltSystem>();
                using (MySqlDataReader reader = getOrdersCommand.ExecuteReader())
                {
                    DataTable tempTable = new DataTable();
                    tempTable.Columns.Add(new DataColumn("ID", typeof(int)));
                    tempTable.Columns.Add(new DataColumn("System", typeof(string)));
                    tempTable.Columns.Add(new DataColumn("Price", typeof(string)));

                    while (reader.Read())
                    {

                        Processor processor = new Processor(reader[0].ToString(), reader[1].ToString(),
                                                            reader[2].ToString(), reader[3].ToString(),
                                                            reader[4].ToString(), reader[5].ToString());

                        RAM ram = new RAM(reader[6].ToString(), reader[7].ToString(), reader[8].ToString(),
                                          reader[9].ToString(), reader[10].ToString());
                        HardDrive hardDrive = new HardDrive(reader[11].ToString(), reader[12].ToString(),
                                                            reader[13].ToString(), reader[14].ToString(),
                                                            reader[15].ToString(), reader[16].ToString(),
                                                            reader[17].ToString());
                        Display display = new Display(reader[18].ToString(), reader[19].ToString(),
                                                      reader[20].ToString(), reader[21].ToString(),
                                                      reader[22].ToString(), reader[23].ToString());
                        OperatingSystem os = new OperatingSystem(reader[24].ToString(), reader[25].ToString(),
                                                                 reader[26].ToString());
                        SoundCard soundCard = new SoundCard(reader[27].ToString(), reader[28].ToString(),
                                                            reader[29].ToString());

                        PreBuiltSystem computer = new PreBuiltSystem(reader[30].ToString(), processor, ram, hardDrive,
                                                                     display, os, soundCard);
                        listOfSystems.Add(computer);

                    }
                    getOrdersCommand.Dispose();
                }
                if (listOfSystems.Count == 0)
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

                    double total = 0;
                    using (MySqlCommand totalPriceCommand = new MySqlCommand(@"SELECT totalPrice 
                                                                                FROM orders 
                                                                                WHERE username=@username", con))
                    {
                        totalPriceCommand.Parameters.AddWithValue("@username", Session["username"]);
                        using (MySqlDataReader reader = totalPriceCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                total += Convert.ToDouble(reader[0].ToString().Replace("$", ""));
                            }
                        }
                        totalPriceCommand.Dispose();
                    }
                    this.TotalCartPriceLabel.Text = "Total Cost: $" + total;
                    this.CartGridView.DataSource = listOfSystems;
                    this.CartGridView.DataBind();
                    //this.CartGridView.Columns[0].Visible = false;
                }
            }
            con.Close();
        }
        //if ((Session["cart"] == null) || ((Session["cart"] as List<PreBuiltSystem>).Count == 0))
        //{
        //    this.EmptyCartLabel.Visible = true;
        //    this.EmptyCartSubtitleLabel.Visible = true;
        //    this.CartGridView.Visible = false;
        //    this.TotalCartPriceLabel.Visible = false;
        //}
        //else
        //{
        //    this.EmptyCartLabel.Visible = false;
        //    this.EmptyCartSubtitleLabel.Visible = false;
        //    this.CartGridView.Visible = true;
        //    this.TotalCartPriceLabel.Visible = true;

        //    this.CartGridView.DataSource = Session["cart"] as List<PreBuiltSystem>;

        //    double totalPrice = 0;

        //    foreach (PreBuiltSystem pbs in Session["cart"] as List<PreBuiltSystem>)
        //    {
        //        totalPrice += PreBuiltSystem.GetPrice(pbs.Price);
        //    }

        //    this.TotalCartPriceLabel.Text = "Total Cost: $" + totalPrice.ToString();

        //    this.CartGridView.DataBind();
        //}
    }

    protected void CartGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            using (MySqlCommand editOrderCommand = new MySqlCommand(@"INSERT INTO currentOrder (username, prebuiltSystem, display, hardDrive, operatingSystem, processor, ram, soundCard, totalPrice) 
                                                                      SELECT o.username, o.prebuiltSystem, o.display, o.hardDrive, o.operatingSystem, o.processor, o.ram, o.soundCard, o.totalPrice
                                                                      FROM orders o WHERE username=@username AND id=@id
                                                                      ON DUPLICATE KEY UPDATE username=o.username, prebuiltSystem=o.prebuiltSystem, display=o.display, hardDrive=o.hardDrive, 
                                                                      operatingSystem=o.operatingSystem, processor=o.processor, ram=o.ram, soundCard=o.soundCard, totalPrice=o.totalPrice", con))
            {
                editOrderCommand.Parameters.AddWithValue("@username", Session["username"]);
                editOrderCommand.Parameters.AddWithValue("@id", this.CartGridView.Rows[e.NewEditIndex].Cells[1].Text);
                int affectedRows = editOrderCommand.ExecuteNonQuery();
            }
            con.Close();
        }
        //List<PreBuiltSystem> cartList = Session["cart"] as List<PreBuiltSystem>;
        //PreBuiltSystem pbs = cartList[e.NewEditIndex];
        //Session.Add(pbs.ProcessorPart.GetSessionName(), pbs.ProcessorPart);
        //Session.Add(pbs.RamPart.GetSessionName(), pbs.RamPart);
        //Session.Add(pbs.HardDrivePart.GetSessionName(), pbs.HardDrivePart);
        //Session.Add(pbs.DisplayPart.GetSessionName(), pbs.DisplayPart);
        //Session.Add(pbs.OperatingSystemPart.GetSessionName(), pbs.OperatingSystemPart);
        //Session.Add(pbs.SoundCardPart.GetSessionName(), pbs.SoundCardPart);
        //Session.Add("totalPrice", Convert.ToDouble(pbs.Price.Replace("$", "")));
        //Session.Add("selectedPreBuiltComputerRowIndex", pbs.PreBuiltIndex);
        //Session.Add("EditingRow", e.NewEditIndex);
        Response.Redirect("SwapParts.aspx");
    }
}