using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
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

            using (MySqlCommand checkCredentialsCommand = new MySqlCommand("SELECT username, password FROM users WHERE username=@username AND password=@password", con))
            {
                checkCredentialsCommand.Parameters.AddWithValue("@username", this.UsernameTextbox.Text);
                checkCredentialsCommand.Parameters.AddWithValue("@password", this.PasswordTextBox.Text);
                using (MySqlDataReader reader = checkCredentialsCommand.ExecuteReader())
                {
                    checkCredentialsCommand.Dispose();
                    if (reader.Read())
                    {
                        this.LoginErrorLabel.Text = string.Empty;
                        this.LoginErrorLabel.Visible = false;
                        Session.Add("username", this.UsernameTextbox.Text);
                        Session.Add("password", this.PasswordTextBox.Text);
                        Session.Timeout = 120;
                        HyperLink link = this.Master.FindControl("LoginLogoutLink") as HyperLink;
                        con.Close();
                        Response.Redirect("~/Cart.aspx");
                    }
                    else
                    {
                        this.LoginErrorLabel.Text = "Invalid Username or Password";
                        this.LoginErrorLabel.Visible = true;
                        con.Close();
                        return;
                    }
                }
            }
        }
    }