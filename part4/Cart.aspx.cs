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
        // Check if the user is logged in by seeing if the session exists
        LoginController.IsUserLoggedIn(this);
        // Display the appropriate cart information for the user
        ConfigureCartPage();
        // Hide the cost of configuration label
        this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = false;
    }

    /// <summary>
    /// Event handler for deleting an existing row in the cart
    /// </summary>
    /// <param name="sender">The cart gridview</param>
    /// <param name="e">Deletion event for the gridview</param>
    protected void CartGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the gridview that sent the row delete event
        GridView gv = sender as GridView;

        // Connect to the database
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            // Query the database and perform a delete command on the order where the order ID and username
            // matches a row in the database
            using (MySqlCommand deleteOrderCommand = new MySqlCommand(@"DELETE FROM orders WHERE 
                                                                        username=@username AND 
                                                                        id=@id", con))
            {
                // Add the username (which is stored in the session) to the query
                deleteOrderCommand.Parameters.AddWithValue("@username", Session["username"]);
                // Add the row ID, which is hidden as the second column (first column is the edit/delete
                // selection column.
                deleteOrderCommand.Parameters.AddWithValue("@id", gv.Rows[e.RowIndex].Cells[1].Text);
                // Execute the non-query
                int affectedRows = deleteOrderCommand.ExecuteNonQuery();
            }
        }
        ConfigureCartPage();
    }

    /// <summary>
    /// Displays all orders currently placed in the cart, otherwise displays information detailing that the cart is empty
    /// </summary>
    public void ConfigureCartPage()
    {
        // Create a connection to the DigitalElectronicsDB database
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            // Query for all columns (except the IDs) the the components specified by the rows in the orders table.
            // The select specifies each column directly, rather than using * because the order of the columns is important
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
                // Add the username (stored in a session) into the query
                getOrdersCommand.Parameters.AddWithValue("@username", Session["username"]);
                // List of PreBuiltSystems will be used as the datasource for the CartGridView.
                List<PreBuiltSystem> listOfSystems = new List<PreBuiltSystem>();

                // Execute the query as a reader, where each row of the resulting query will be read and 
                // converted into its respective component for easier handling of each part.
                using (MySqlDataReader reader = getOrdersCommand.ExecuteReader())
                {
                    // While there are rows left to read
                    while (reader.Read())
                    {
                        // Create the Processor component
                        Processor processor = new Processor(reader[0].ToString(), reader[1].ToString(),
                                                            reader[2].ToString(), reader[3].ToString(),
                                                            reader[4].ToString(), reader[5].ToString());

                        // Create the RAM component
                        RAM ram = new RAM(reader[6].ToString(), reader[7].ToString(), reader[8].ToString(),
                                          reader[9].ToString(), reader[10].ToString());

                        // Create the Hard Drive component
                        HardDrive hardDrive = new HardDrive(reader[11].ToString(), reader[12].ToString(),
                                                            reader[13].ToString(), reader[14].ToString(),
                                                            reader[15].ToString(), reader[16].ToString(),
                                                            reader[17].ToString());

                        // Create the Display component
                        Display display = new Display(reader[18].ToString(), reader[19].ToString(),
                                                      reader[20].ToString(), reader[21].ToString(),
                                                      reader[22].ToString(), reader[23].ToString());

                        // Create the Operating System component
                        OperatingSystem os = new OperatingSystem(reader[24].ToString(), reader[25].ToString(),
                                                                 reader[26].ToString());

                        // Create the Sound Card Component
                        SoundCard soundCard = new SoundCard(reader[27].ToString(), reader[28].ToString(),
                                                            reader[29].ToString());

                        // Take each component and construct the PreBuiltSystem, which will be used to 
                        // correctly format the text displayed on the gridview
                        PreBuiltSystem computer = new PreBuiltSystem(reader[30].ToString(), processor, ram, hardDrive,
                                                                     display, os, soundCard);
                        listOfSystems.Add(computer);

                    }
                    getOrdersCommand.Dispose();
                }
                // If there were no rows, then the cart is empty, so display the appropriate labels
                if (listOfSystems.Count == 0)
                {
                    this.EmptyCartLabel.Visible = true;
                    this.EmptyCartSubtitleLabel.Visible = true;
                    this.CartGridView.Visible = false;
                    this.TotalCartPriceLabel.Visible = false;
                }
                // The cart has some items in it, display the GridView and format the page properly
                else
                {
                    this.EmptyCartLabel.Visible = false;
                    this.EmptyCartSubtitleLabel.Visible = false;
                    this.CartGridView.Visible = true;
                    this.TotalCartPriceLabel.Visible = true;

                    // Query for the total price of the user's order
                    double total = 0;
                    using (MySqlCommand totalPriceCommand = new MySqlCommand(@"SELECT totalPrice 
                                                                                FROM orders 
                                                                                WHERE username=@username", con))
                    {
                        // Add the user's name that was stored in the session into the totalPriceCommand
                        totalPriceCommand.Parameters.AddWithValue("@username", Session["username"]);

                        // Read each row of the result, which is a single string (for each row) containing the price
                        // of that row
                        using (MySqlDataReader reader = totalPriceCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Parse the text and retrieve the price value as a double, adding it onto the total price
                                total += Convert.ToDouble(reader[0].ToString().Replace("$", ""));
                            }
                        }
                        totalPriceCommand.Dispose();
                    }
                    // Display the total price and the CartGridView
                    this.TotalCartPriceLabel.Text = "Total Cost: $" + total;
                    // Make the first column of the gridview visible to ensure the ID value is applied to the column
                    this.CartGridView.Columns[0].Visible = true;
                    // Set the datasource and bind the data to apply the changes
                    this.CartGridView.DataSource = listOfSystems;
                    this.CartGridView.DataBind();
                    // Hide the ID column
                    this.CartGridView.Columns[0].Visible = false;
                }
            }
            con.Close();
        }
    }

    /// <summary>
    /// Event handler for editing a row in the cart
    /// </summary>
    /// <param name="sender">The CartGridView</param>
    /// <param name="e">The edit row event</param>
    protected void CartGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Create a connection to the DigitalElectronicsDB database
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            // Create a command to insert the selected row into the current order table under the username stored in the session.
            // If the user already has a current order but wants to edit an existing order in the cart, update the current order table
            // instead of inserting. The editId column is used to specify that an old order is being edited
            using (MySqlCommand editOrderCommand = new MySqlCommand(@"INSERT INTO currentOrder (username, prebuiltSystem, display, hardDrive, operatingSystem, processor, ram, soundCard, totalPrice, editId) 
                                                                      SELECT o.username, o.prebuiltSystem, o.display, o.hardDrive, o.operatingSystem, o.processor, o.ram, o.soundCard, o.totalPrice, o.id
                                                                      FROM orders o WHERE username=@username AND id=@id
                                                                      ON DUPLICATE KEY UPDATE username=o.username, prebuiltSystem=o.prebuiltSystem, display=o.display, hardDrive=o.hardDrive, 
                                                                      operatingSystem=o.operatingSystem, processor=o.processor, ram=o.ram, soundCard=o.soundCard, totalPrice=o.totalPrice, editId=o.id", con))
            {
                // Add the username and ID of the row into the command
                editOrderCommand.Parameters.AddWithValue("@username", Session["username"]);
                editOrderCommand.Parameters.AddWithValue("@id", this.CartGridView.Rows[e.NewEditIndex].Cells[1].Text);
                // Execute the command and load the details from the selected order into the current order
                int affectedRows = editOrderCommand.ExecuteNonQuery();
            }
            con.Close();
        }
        // Redirect the user to the SwapParts page.
        Response.Redirect("SwapParts.aspx");
    }
}