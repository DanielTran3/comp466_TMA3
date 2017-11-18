using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = false;
        if (Session["feedback"] == null)
        {
            this.NoFeedbackLabel.Visible = true;
        }
        else if ((Session["feedback"] as List<FeedbackComments>).Count == 0)
        {
            this.NoFeedbackLabel.Visible = true;
        }
        else
        {
            this.NoFeedbackLabel.Visible = false;
            List<FeedbackComments> comments = Session["feedback"] as List<FeedbackComments>;
            this.FeedbackGridView.DataSource = comments;
            this.FeedbackGridView.DataBind();
        }
    }

    protected void FeedbackSubmitButton_Click(object sender, EventArgs e)
    {
        if (this.NameTextbox.Text == " " || this.NameTextbox.Text == string.Empty)
        {
            return;
        }
        FeedbackComments fb = new FeedbackComments(this.NameTextbox.Text, this.FeedbackTextbox.Text);
        List<FeedbackComments> listOfComments;

        if (Session["feedback"] == null)
        {
            listOfComments = new List<FeedbackComments>() { fb };
        }
        else
        {
            listOfComments = Session["feedback"] as List<FeedbackComments>;
            listOfComments.Add(fb);
        }
        Session["feedback"] = listOfComments;
        this.FeedbackGridView.DataSource = listOfComments;
        this.FeedbackGridView.DataBind();

        if (Session["feedback"] != null && (Session["feedback"] as List<FeedbackComments>).Count > 0) {
            this.NoFeedbackLabel.Visible = false;
        }
        this.NameTextbox.Text = string.Empty;
        this.FeedbackTextbox.Text = string.Empty;
    }
}