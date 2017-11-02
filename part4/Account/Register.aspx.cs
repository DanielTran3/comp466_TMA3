using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class Account_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// Register a new user into the database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RegisterSubmitButton_Click(object sender, EventArgs e)
    {
        // Create a connection to the DigitalElectronicsDB database
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            // Query to see if the username already exists. If it does, display an error message stating that the username exists
            using (MySqlCommand checkUsernameCommand = new MySqlCommand("SELECT username FROM users WHERE username=@inputtedUsername", con))
            {
                checkUsernameCommand.Parameters.AddWithValue("@inputtedUsername", this.UsernameTextbox.Text);
                string usernameExists = (string) checkUsernameCommand.ExecuteScalar();
                if (usernameExists != null)
                {
                    this.UsernameAlreadyExistsLabel.Visible = true;
                    checkUsernameCommand.Dispose();
                    con.Close();
                    return;
                }
                checkUsernameCommand.Dispose();
            }

            // Username does not exist, submit the users credentials into the database.
            using (MySqlCommand addUserCommand = new MySqlCommand(@"INSERT INTO users (username, password, securityQuestion, securityAnswer) 
                                                                    VALUES (@username, @password, @securityQuestion, @securityAnswer)", con))
            {
                addUserCommand.Parameters.AddWithValue("@username", this.UsernameTextbox.Text);
                addUserCommand.Parameters.AddWithValue("@password", this.PasswordTextBox.Text);
                addUserCommand.Parameters.AddWithValue("@securityQuestion", this.SecurityQuestionDropDownList.SelectedValue);
                addUserCommand.Parameters.AddWithValue("@securityAnswer", this.SecurityAnswerTextBox.Text);
                int affectedRows = addUserCommand.ExecuteNonQuery();
                if (affectedRows == 1) // Valid insertion, redirect user to the RegistrationSuccessful page.
                {
                    addUserCommand.Dispose();
                    con.Close();
                    Response.Redirect("RegistrationSuccessful.aspx");
                }
                addUserCommand.Dispose();
            }
            con.Close();
        }
    }
}
