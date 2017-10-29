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
    protected void Page_Load(object sender, EventArgs e)
    {
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

    protected void RecoveryButton_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            if (Session["validUsername"] == null)
            {
                using (MySqlCommand checkUsernameCommand = new MySqlCommand("SELECT username FROM users WHERE username=@username", con))
                {
                    checkUsernameCommand.Parameters.AddWithValue("@username", this.UsernameTextbox.Text);
                    string usernameExists = (string)checkUsernameCommand.ExecuteScalar();
                    if (usernameExists == null)
                    {
                        this.PasswordRecoveryErrorLabel.Text = "Username Does Not Exist";
                        this.PasswordRecoveryErrorLabel.Visible = true;
                        checkUsernameCommand.Dispose();
                        con.Close();
                        return;
                    }
                }

                using (MySqlCommand checkCredentialsCommand = new MySqlCommand("SELECT securityQuestion, securityAnswer FROM users WHERE username=@username", con))
                {
                    checkCredentialsCommand.Parameters.AddWithValue("@username", this.UsernameTextbox.Text);
                    using (MySqlDataReader reader = checkCredentialsCommand.ExecuteReader())
                    {
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
            else
            {
                using (MySqlCommand checkCredentialsCommand = new MySqlCommand("UPDATE users SET password=@password WHERE username=@username AND securityQuestion=@securityQuestion AND securityAnswer=@securityAnswer", con))
                {
                    checkCredentialsCommand.Parameters.AddWithValue("@username", this.UsernameTextbox.Text);
                    checkCredentialsCommand.Parameters.AddWithValue("@password", this.PasswordTextBox.Text);
                    checkCredentialsCommand.Parameters.AddWithValue("@securityQuestion", this.SecurityQuestionTextbox.Text);
                    checkCredentialsCommand.Parameters.AddWithValue("@securityAnswer", this.SecurityAnswerTextBox.Text);
                    int affectedRows = checkCredentialsCommand.ExecuteNonQuery();
                    if (affectedRows == 0)
                    {
                        this.PasswordRecoveryErrorLabel.Text = "Invalid Security Question Answer";
                        this.PasswordRecoveryErrorLabel.Visible = true;
                        checkCredentialsCommand.Dispose();
                        con.Close();
                    }
                    else
                    {
                        Session["validUsername"] = null;
                        Session["userSecurityQuestion"] = null;
                        Session["validRecovery"] = true;
                        this.PasswordRecoveryErrorLabel.Visible = false;
                        checkCredentialsCommand.Dispose();
                        con.Close();
                        Response.Redirect("~/Account/ForgotPasswordSuccessful.aspx");
                    }
                }
            }
        }
    }

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