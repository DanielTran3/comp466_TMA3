using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_ForgotPassword : System.Web.UI.Page
{
    /// <summary>
    /// Loads forgotten password information into the page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // If there is no valid username (meaning they have not inputted a username into the form yet
        // Instruct the user to enter a username, disable the password, security question, and security answer textboxes
        if (Session["validUsername"] == null)
        {
            this.PasswordRecoveryLabel.Text = "Please Enter your username and press Submit";
            this.UsernameTextbox.Enabled = true;
            this.PasswordTextBox.Text = "";
            this.PasswordTextBox.Enabled = false;
            this.SecurityQuestionTextbox.Text = "";
            this.SecurityQuestionTextbox.Enabled = false;
            this.SecurityAnswerTextBox.Text = "";
            this.SecurityAnswerTextBox.Enabled = false;
        }
        // A valid username is entered, move to step 2, which disables the username textbox and enables the password and security answer
        // textboxes. Also loads in the username that the user entered, along with the security question they specified upon registration 
        else
        {
            this.PasswordRecoveryLabel.Text = "Please Enter your new password and provide the correct answer for the security question";
            this.UsernameTextbox.Text = Session["validUsername"] as string;
            this.SecurityQuestionTextbox.Text = Session["userSecurityQuestion"] as string;
            this.UsernameTextbox.Enabled = false;
            this.PasswordTextBox.Enabled = true;
            this.SecurityQuestionTextbox.Enabled = false;
            this.SecurityAnswerTextBox.Enabled = true;
        }
    }

    /// <summary>
    /// When the recovery button is checked, has 2 stages, one where there is no username inputted yet and the other where the
    /// username has already been inputted. The first stage verifies that the username is a valid username in the database,
    /// while the second stage allows the user to change their password if the security question is answered correctly.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RecoveryButton_Click(object sender, EventArgs e)
    {
        // Create the connection to the databse
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            // Open the connection
            con.Open(); 

            // Check if there is a valid username. Entering this conditional means the user has not inputted a username yet.
            if (Session["validUsername"] == null)
            {
                // Query for the inputted username to see if it exists in the users table.
                using (MySqlCommand checkUsernameCommand = new MySqlCommand("SELECT username FROM users WHERE username=@username", con))
                {
                    checkUsernameCommand.Parameters.AddWithValue("@username", this.UsernameTextbox.Text);
                    string usernameExists = (string)checkUsernameCommand.ExecuteScalar();
                    // Stop here if the username does not exist. 
                    if (usernameExists == null)
                    {
                        this.PasswordRecoveryErrorLabel.Text = "Username Does Not Exist";
                        this.PasswordRecoveryErrorLabel.Visible = true;
                        checkUsernameCommand.Dispose();
                        con.Close();
                        return;
                    }
                }

                // The username that was entered exists, now query for the security question.
                using (MySqlCommand checkCredentialsCommand = new MySqlCommand("SELECT securityQuestion FROM users WHERE username=@username", con))
                {
                    checkCredentialsCommand.Parameters.AddWithValue("@username", this.UsernameTextbox.Text);
                    using (MySqlDataReader reader = checkCredentialsCommand.ExecuteReader())
                    {
                        // If there is a value returned, display it in the form and save the username and security question into sessions
                        if (reader.Read())
                        {
                            this.PasswordRecoveryErrorLabel.Text = string.Empty;
                            this.PasswordRecoveryErrorLabel.Visible = false;
                            Session.Add("validUsername", this.UsernameTextbox.Text);
                            Session.Timeout = 10;
                            this.PasswordRecoveryLabel.Text = "Please Enter your new password and provide the correct answer for the security question";
                            this.UsernameTextbox.Enabled = false;
                            this.PasswordTextBox.Enabled = true;
                            this.SecurityAnswerTextBox.Enabled = true;
                            this.SecurityQuestionTextbox.Text = reader[0].ToString();
                            Session.Add("userSecurityQuestion", reader[0].ToString());
                            con.Close();
                            checkCredentialsCommand.Dispose();
                        }
                    }
                    
                }
            }
            else // A valid username was entered. Now check to see if the security question was answered correctly.
            {
                // Update the password on the condition that the username, security question, and secutiyy answer match.
                using (MySqlCommand checkCredentialsCommand = new MySqlCommand("UPDATE users SET password=@password WHERE username=@username AND securityQuestion=@securityQuestion AND securityAnswer=@securityAnswer", con))
                {
                    checkCredentialsCommand.Parameters.AddWithValue("@username", this.UsernameTextbox.Text);
                    checkCredentialsCommand.Parameters.AddWithValue("@password", this.PasswordTextBox.Text);
                    checkCredentialsCommand.Parameters.AddWithValue("@securityQuestion", this.SecurityQuestionTextbox.Text);
                    checkCredentialsCommand.Parameters.AddWithValue("@securityAnswer", this.SecurityAnswerTextBox.Text);
                    int affectedRows = checkCredentialsCommand.ExecuteNonQuery();
                    if (affectedRows == 0) // Security question wasn't answered correctly so query was not performed
                    {
                        this.PasswordRecoveryErrorLabel.Text = "Invalid Security Question Answer";
                        this.PasswordRecoveryErrorLabel.Visible = true;
                        checkCredentialsCommand.Dispose();
                        con.Close();
                    }
                    // Security question was answered corectly so the query updated the users password. Reset the form and move to the success screen
                    else
                    {
                        Session["validUsername"] = null;
                        Session["userSecurityQuestion"] = null;
                        Session["validRecovery"] = "valid";
                        this.PasswordRecoveryErrorLabel.Visible = false;
                        checkCredentialsCommand.Dispose();
                        con.Close();
                        Response.Redirect("~/Account/ForgotPasswordSuccessful.aspx");
                    }
                }
            }
        }
    }

    /// <summary>
    /// If the reset link is pressed, clear the session of valid user and security question and
    /// reset the form to the initial state
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void PasswordRecoveryResetLink_Click(object sender, EventArgs e)
    {
        Session["validUsername"] = null;
        Session["userSecurityQuestion"] = null;
        this.UsernameTextbox.Text = "";
        this.UsernameTextbox.Enabled = true;
        this.PasswordTextBox.Text = "";
        this.PasswordTextBox.Enabled = false;
        this.SecurityQuestionTextbox.Text = "";
        this.SecurityQuestionTextbox.Enabled = false;
        this.SecurityAnswerTextBox.Text = "";
        this.SecurityAnswerTextBox.Enabled = false;
        this.PasswordRecoveryLabel.Visible = false;
    }
}