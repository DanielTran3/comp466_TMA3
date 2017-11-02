using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginController.IsUserLoggedIn(this);
        this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = false;

        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            using (MySqlCommand feedbackCommand = new MySqlCommand(@"SELECT username, feedbackText FROM feedback", con))
            {
                using (MySqlDataReader reader = feedbackCommand.ExecuteReader())
                {
                    this.FeedbackGridView.DataSource = reader;
                    this.FeedbackGridView.DataBind();
                    reader.Dispose();
                }
                feedbackCommand.Dispose();

            }
            con.Close();
        }
        this.UsernameTextbox.Text = Session["username"].ToString();

        this.NoFeedbackLabel.Visible = this.FeedbackGridView.Rows.Count == 0 ? true : false;
    }

    protected void FeedbackSubmitButton_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["DigitalElectronicsDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            using (MySqlCommand feedbackCommand = new MySqlCommand(@"INSERT INTO feedback(username, feedbackText) 
                                                                     VALUES(@username, @feedbackText)", con))
            {
                feedbackCommand.Parameters.AddWithValue("@username", Session["username"]);
                feedbackCommand.Parameters.AddWithValue("@feedbackText", this.FeedbackTextbox.Text);
                int affectedRows = feedbackCommand.ExecuteNonQuery();
            }

            using (MySqlCommand feedbackCommand = new MySqlCommand(@"SELECT username, feedbackText FROM feedback", con))
            {
                using (MySqlDataReader reader = feedbackCommand.ExecuteReader())
                {
                    this.FeedbackGridView.DataSource = reader;
                    this.FeedbackGridView.DataBind();
                    reader.Dispose();
                }
                feedbackCommand.Dispose();

            }
        }

        this.UsernameTextbox.Text = string.Empty;
        this.FeedbackTextbox.Text = string.Empty;
    }
}