using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = false;
        // If there is a user logged in for this session, redirect them to the cart page.
        if (Session["username"] != null)
        {
            Response.Redirect("~/Cart.aspx");
        }
    }

    /// <summary>
    /// When the login button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        // Create a connection to the DigitalElectronicsDB database
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            // Query to see if the username exists in the database. If not, display the "Username does not exist message"
            using (MySqlCommand checkUsernameCommand = new MySqlCommand("SELECT username FROM users WHERE username=@inputtedUsername", con))
            {
                checkUsernameCommand.Parameters.AddWithValue("@inputtedUsername", this.UsernameTextbox.Text);
                string usernameExists = (string)checkUsernameCommand.ExecuteScalar();
                if (usernameExists == null)
                {
                    this.LoginErrorLabel.Text = "Username Does Not Exist";
                    this.LoginErrorLabel.Visible = true;
                    checkUsernameCommand.Dispose();
                    con.Close();
                    return;
                }
            }

            // Username exists, query to see if the username and password combination exists in the database
            using (MySqlCommand checkCredentialsCommand = new MySqlCommand("SELECT username FROM users WHERE username=@username AND password=@password", con))
            {
                checkCredentialsCommand.Parameters.AddWithValue("@username", this.UsernameTextbox.Text);
                checkCredentialsCommand.Parameters.AddWithValue("@password", this.PasswordTextBox.Text);

                string validLoginUsername = (string)checkCredentialsCommand.ExecuteScalar();

                // Login was valid, save the username in the session and set the session to last for 2 hours. Redirect user to Cart page
                if (validLoginUsername != null)
                {
                    this.LoginErrorLabel.Text = string.Empty;
                    this.LoginErrorLabel.Visible = false;
                    Session.Add("username", validLoginUsername);
                    Session.Timeout = 120;
                    con.Close();
                    Response.Redirect("~/Cart.aspx");
                }
                else
                {
                    this.LoginErrorLabel.Text = "Invalid Username or Password";
                    this.LoginErrorLabel.Visible = true;
                    con.Close();
                }
            }
        }
    }

    /// <summary>
    /// Redirect user to the ForgetPassword page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ForgotPasswordLink_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/ForgotPassword.aspx");
    }
}
