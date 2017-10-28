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
        if (Session["username"] != null)
        {
            Response.Redirect("~/Cart.aspx");
        }
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

            using (MySqlCommand checkCredentialsCommand = new MySqlCommand("SELECT username, password FROM users WHERE username=@username", con))
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

        //FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

        //string continueUrl = RegisterUser.ContinueDestinationPageUrl;
        //if (String.IsNullOrEmpty(continueUrl))
        //{
        //    continueUrl = "~/";
        //}
        //Response.Redirect(continueUrl);
    }

}
