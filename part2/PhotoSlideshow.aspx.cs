using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PhotoSlideshow : System.Web.UI.Page
{
    private Photos photos = new Photos();

    protected void Page_Load(object sender, EventArgs e)
    {
        string[] photoDataLines = File.ReadAllLines(Server.MapPath("~/App_Data/photoslideshow.txt"));
        photos.StorePhotoDetails(photoDataLines);
        if (ViewState["photoIndex"] != null)
        {
            photos.CurrentPhotoIndex = Convert.ToInt32(ViewState["photoIndex"].ToString());
        }
        if (ViewState["forward"] != null)
        {
            photos.Forward = (bool) ViewState["forward"];
        }
        if (ViewState["random"] != null)
        {
            photos.Random = (bool) ViewState["random"];
        }
        if (ViewState["interval"] != null)
        {
            this.PhotoTimer.Interval = Convert.ToInt32(ViewState["interval"].ToString());
        }
    }

    protected void StartStopButton_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (button.Text == "Start")
        {
            button.Text = "Stop";
            this.PhotoTimer.Enabled = true;
            // Add a timed sequential callback function
            //this.PhotoDisplay.ImageUrl = photos.GetPhoto();
            //this.CaptionLabel.Text = photos.GetCaption();
            //photos.UpdateCurrentPhotoIndex();
        }
        else
        {
            button.Text = "Start";
            this.PhotoTimer.Enabled = false;
        }
    }

    protected void SequentialRandomButton_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (button.Text == "Sequential")
        {
            button.Text = "Random";
            photos.Random = true;
            this.ForwardButton.Enabled = false;
            this.BackwardButton.Enabled = false;
        }
        else
        {
            button.Text = "Sequential";
            photos.Random = false;
            this.ForwardButton.Enabled = true;
            this.BackwardButton.Enabled = true;
        }
        ViewState["random"] = photos.Random;
    }

    protected void ForwardBackwardButton_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (button.Text == "Forward")
        {
            photos.Forward = true;
        }
        else
        {
            photos.Forward = false;
        }
        ViewState["forward"] = photos.Forward;
    }

    protected void PhotoTimer_Tick(object sender, EventArgs e)
    {
        Label1.Text = "Panel refreshed at: " +
DateTime.Now.ToLongTimeString();
        //Timer timer = sender as Timer;
        photos.UpdateCurrentPhotoIndex();
        this.PhotoDisplay.ImageUrl = photos.GetPhoto();
        this.CaptionLabel.Text = photos.GetCaption();
        ViewState["photoIndex"] = photos.CurrentPhotoIndex;
        ViewState["forward"] = photos.Forward;
        ViewState["random"] = photos.Random;
        Label2.Text = "Photo Index: " + photos.CurrentPhotoIndex;
    }

    protected void IntervalButton_Click(object sender, EventArgs e)
    {
        int photoSwitchInterval;
        if (int.TryParse(this.IntervalTextBox.Text, out photoSwitchInterval))
        {
            this.PhotoTimer.Interval = photoSwitchInterval * 1000;
            ViewState["interval"] = this.PhotoTimer.Interval;
        }
    }
}