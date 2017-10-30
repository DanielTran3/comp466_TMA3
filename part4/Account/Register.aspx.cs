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
        //if (!this.IsPostBack)
        //{
        //string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        //using (MySqlConnection con = new MySqlConnection(constr))
        //{
        //    con.Open();
        //    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO users (username, password) VALUES (@test, @test2)", con))
        //    {
        //        using (MySqlDataAdapter sda = new MySqlDataAdapter())
        //        {
        //            //cmd.Connection = con;
        //            //sda.InsertCommand = cmd;
        //            cmd.Parameters.AddWithValue("@test", "test");
        //            cmd.Parameters.AddWithValue("@test2", "test2");
        //            int result = cmd.ExecuteNonQuery();
        //            cmd.Dispose();
        //        }
        //    }
        //    con.Close();
        //}
        //}
    }

    protected void RegisterSubmitButton_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
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

            using (MySqlCommand addUserCommand = new MySqlCommand(@"INSERT INTO users (username, password, securityQuestion, securityAnswer) 
                                                                    VALUES (@username, @password, @securityQuestion, @securityAnswer)", con))
            {
                addUserCommand.Parameters.AddWithValue("@username", this.UsernameTextbox.Text);
                addUserCommand.Parameters.AddWithValue("@password", this.PasswordTextBox.Text);
                addUserCommand.Parameters.AddWithValue("@securityQuestion", this.SecurityQuestionDropDownList.SelectedValue);
                addUserCommand.Parameters.AddWithValue("@securityAnswer", this.SecurityAnswerTextBox.Text);
                int affectedRows = addUserCommand.ExecuteNonQuery();
                if (affectedRows == 1)
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
