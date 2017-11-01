using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PreBuiltComputers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginController.IsUserLoggedIn(this);

        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            // Specifying each column in the select statement to ensure order of output
            using (MySqlCommand fillPBSCommand = new MySqlCommand(@"SELECT cpu.brand, cpu.model, cpu.clock, cpu.cache, cpu.socket, cpu.price, 
                                                                ram.brand, ram.model, ram.speed, ram.memoryType, ram.price, 
                                                                hd.brand, hd.model, hd.type, hd.size, hd.readSpeed, hd.writeSpeed, hd.price,
                                                                d.brand, d.model, d.size, d.resolution, d.responseTime, d.price,
                                                                os.brand, os.version, os.price,
                                                                sc.brand, sc.model, sc.price,
                                                                pbs.id
                                                                FROM display d, harddrive hd, operatingSystem os, processor cpu, ram, soundCard sc, prebuiltSystem pbs
                                                                WHERE pbs.display = d.ID AND
                                                                pbs.hardDrive = hd.ID AND
                                                                pbs.operatingSystem = os.ID AND
                                                                pbs.processor = cpu.ID AND
                                                                pbs.ram = ram.ID AND
                                                                pbs.soundCard = sc.ID", con))
            {
                using (MySqlDataReader reader = fillPBSCommand.ExecuteReader())
                {
                    DataTable tempTable = new DataTable();
                    tempTable.Columns.Add(new DataColumn("System", typeof(string)));
                    tempTable.Columns.Add(new DataColumn("Price", typeof(string)));

                    List<PreBuiltSystem> listOfSystems = new List<PreBuiltSystem>();
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
                    this.PreBuiltComputersGridView.DataSource = listOfSystems;
                    this.PreBuiltComputersGridView.DataBind();
                    this.PreBuiltComputersGridView.Columns[0].Visible = false;
                }

                if (!IsPostBack)
                {
                    using (MySqlCommand getTotalPriceCommand = new MySqlCommand(@"SELECT totalPrice 
                                                                                  FROM currentOrder 
                                                                                  WHERE username=@username", con))
                    {
                        getTotalPriceCommand.Parameters.AddWithValue("@username", Session["username"]);
                        object tempPrice = getTotalPriceCommand.ExecuteScalar();
                        string totalPrice = string.Empty;
                        if (tempPrice != null)
                        {
                            totalPrice = tempPrice.ToString();
                        }
                        Label totalCostLabel = (Label)Master.FindControl("TotalCostLabel");
                        if (totalCostLabel != null)
                        {
                            totalCostLabel.Text = totalPrice;
                        }
                        getTotalPriceCommand.Dispose();
                    }

                    //int componentRowIndex = -1;
                    //using (MySqlCommand getRowIndexCommand = new MySqlCommand(@"SELECT prebuiltSystem
                    //                                                            FROM currentOrder 
                    //                                                            WHERE username=@username", con))
                    //{
                    //    getRowIndexCommand.Parameters.AddWithValue("@username", Session["username"]);
                    //    object outputRow = getRowIndexCommand.ExecuteScalar();
                    //    if (outputRow != null)
                    //    {
                    //        componentRowIndex = Convert.ToInt32(outputRow.ToString());
                    //        getRowIndexCommand.Dispose();
                    //    }
                    //}

                    //int rowIndex = -1;
                    //foreach (GridViewRow gvr in this.PreBuiltComputersGridView.Rows)
                    //{
                    //    if (Convert.ToInt32(gvr.Cells[1].Text) == componentRowIndex)
                    //    {
                    //        rowIndex = gvr.RowIndex;
                    //        break;
                    //    }
                    //}
                    //this.PreBuiltComputersGridView.SelectRow(rowIndex);
                }
            }

            //using (MySqlCommand tableRows = new MySqlCommand("SELECT * FROM " + tableName, con))
            //{
            //using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM ", con))
            //{
            //    DataTable tempTable = new DataTable();
            //    adapter.Fill(tempTable);
            //    gridview.DataSource = tempTable;
            //    gridview.DataBind();
            //    con.Close();
            //}
            //}
        }

        // CHECK IF "selectedPreBuiltComputerRowIndex" and "prebuiltSystem" exist in the session, if they do load
        // up the correct index and the data
        //if (Session["prebuiltSystem"] != null)
        //{
        //    this.PreBuiltComputersGridView.DataSource = Session["prebuiltSystem"];
        //}
        //else
        //{
        //    this.PreBuiltComputersGridView.DataSource = PreBuiltSystem.GetAllPreBuiltSystems();
        //    Session.Add("prebuiltSystem", this.PreBuiltComputersGridView.DataSource);
        //}
        //if (Session["selectedPreBuiltComputerRowIndex"] != null)
        //{
        //    this.PreBuiltComputersGridView.SelectRow((int)Session["selectedPreBuiltComputerRowIndex"]);
        //}

        //this.PreBuiltComputersGridView.DataBind();
    }

    protected void PreBuiltComputersGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        if (gv.SelectedIndex == -1)
        {
            return;
        }
        List<PreBuiltSystem> pbsList = gv.DataSource as List<PreBuiltSystem>;
        PreBuiltSystem pbs = pbsList[gv.SelectedIndex];
        pbs.PreBuiltIndex = gv.SelectedIndex;

        List<int> componentIndicies = new List<int>();

        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            using (MySqlCommand getComponentIndexCommand = new MySqlCommand(@"SELECT ID, processor, hardDrive, operatingSystem, display, ram, soundCard 
                                                                              FROM prebuiltSystem WHERE ID=@rowId", con))
            {
                // +1 because the AutoIncrementing is 1 indexed
                getComponentIndexCommand.Parameters.AddWithValue("@rowId", pbs.Id);
                using (MySqlDataReader reader = getComponentIndexCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            componentIndicies.Add((int)reader[i]);
                        }
                    }
                }
                getComponentIndexCommand.Dispose();
            }

            using (MySqlCommand updateUserSelectionCommand = new MySqlCommand(@"INSERT INTO currentOrder (username, prebuiltSystem, display, hardDrive, operatingSystem, processor, ram, soundCard, totalPrice) 
                                                                               VALUES (@username, @prebuiltSystem, @display, @hardDrive, @operatingSystem, @processor, @ram, @soundCard, @totalPrice)
                                                                               ON DUPLICATE KEY UPDATE username=@username, prebuiltSystem=@prebuiltSystem, display=@display, hardDrive=@hardDrive, 
                                                                               operatingSystem=@operatingSystem, processor=@processor, ram=@ram, soundCard=@soundCard, totalPrice=@totalPrice", con))
            {
                //updateUserSelectionCommand.Parameters.AddWithValue("@username", Session["username"]);
                //updateUserSelectionCommand.Parameters.AddWithValue("@prebuiltSystem", pbs.ToString());
                //updateUserSelectionCommand.Parameters.AddWithValue("@display", pbs.DisplayPart);
                //updateUserSelectionCommand.Parameters.AddWithValue("@hardDrive", pbs.HardDrivePart);
                //updateUserSelectionCommand.Parameters.AddWithValue("@operatingSystem", pbs.OperatingSystemPart);
                //updateUserSelectionCommand.Parameters.AddWithValue("@processor", pbs.ProcessorPart);
                //updateUserSelectionCommand.Parameters.AddWithValue("@ram", pbs.RamPart);
                //updateUserSelectionCommand.Parameters.AddWithValue("@soundCard", pbs.SoundCardPart);
                //updateUserSelectionCommand.Parameters.AddWithValue("@totalPrice", pbs.Price.Replace("$", ""));
                updateUserSelectionCommand.Parameters.AddWithValue("@username", Session["username"]);
                updateUserSelectionCommand.Parameters.AddWithValue("@prebuiltSystem", componentIndicies[0]);
                updateUserSelectionCommand.Parameters.AddWithValue("@display", componentIndicies[4]);
                updateUserSelectionCommand.Parameters.AddWithValue("@hardDrive", componentIndicies[2]);
                updateUserSelectionCommand.Parameters.AddWithValue("@operatingSystem", componentIndicies[3]);
                updateUserSelectionCommand.Parameters.AddWithValue("@processor", componentIndicies[1]);
                updateUserSelectionCommand.Parameters.AddWithValue("@ram", componentIndicies[5]);
                updateUserSelectionCommand.Parameters.AddWithValue("@soundCard", componentIndicies[6]);
                updateUserSelectionCommand.Parameters.AddWithValue("@totalPrice", pbs.Price.Replace("$", ""));
                int affectedRows = updateUserSelectionCommand.ExecuteNonQuery();
            }
            con.Close();
        }

        //Session.Add(pbs.ProcessorPart.GetSessionName(), pbs.ProcessorPart);
        //Session.Add(pbs.RamPart.GetSessionName(), pbs.RamPart);
        //Session.Add(pbs.HardDrivePart.GetSessionName(), pbs.HardDrivePart);
        //Session.Add(pbs.DisplayPart.GetSessionName(), pbs.DisplayPart);
        //Session.Add(pbs.OperatingSystemPart.GetSessionName(), pbs.OperatingSystemPart);
        //Session.Add(pbs.SoundCardPart.GetSessionName(), pbs.SoundCardPart);
        // Keep the totalPrice stored as a double
        //Session.Add("totalPrice", Convert.ToDouble(pbs.Price.Replace("$","")));

        Label totalCostLabel = (Label)Master.FindControl("TotalCostLabel");
        if (totalCostLabel != null)
        {
            totalCostLabel.Text = pbs.Price;
        }

        //Session.Add("selectedPreBuiltComputerRowIndex", pbs.PreBuiltIndex);
    }
}

//double price = Convert.ToDouble(reader[5].ToString().Replace("$","")) +
//               Convert.ToDouble(reader[10].ToString().Replace("$", "")) +
//               Convert.ToDouble(reader[17].ToString().Replace("$", "")) +
//               Convert.ToDouble(reader[23].ToString().Replace("$", "")) +
//               Convert.ToDouble(reader[26].ToString().Replace("$", "")) +
//               Convert.ToDouble(reader[29].ToString().Replace("$", ""));
//string processor = "Processor: ";
//for (int i = 0; i < 5; i++)
//{
//    processor += reader[i].ToString() + " ";
//}
//string ram = "RAM: ";
//for (int i = 6; i < 10; i++)
//{
//    ram += reader[i].ToString() + " ";
//}
//string hardDrive = "Hard Drive: ";
//for (int i = 11; i < 17; i++)
//{
//    hardDrive += reader[i].ToString() + " ";
//}
//string display = "Display: ";
//for (int i = 18; i < 23; i++)
//{
//    display += reader[i].ToString() + " ";
//}
//string operatingSystem = "Operating System: " + reader[24].ToString() + reader[25].ToString();
//string soundCard = "Sound Card: " + reader[27].ToString() + reader[28].ToString();
//string system = processor + "<br />" + ram + "<br />" + hardDrive + "<br />" + 
//                display + "<br />" + operatingSystem + "<br />" + soundCard;

//DataRow row = tempTable.NewRow();
//row[0] = system;
//row[1] = "$" + price;
//tempTable.Rows.Add(row);