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
            this.ForwardButton.Enabled = false;
            this.BackwardButton.Enabled = false;

            photos.RandomCurrentPhotoIndex();
            this.PhotoDisplay.ImageUrl = photos.GetPhoto();
            this.CaptionLabel.Text = photos.GetCaption();
        }
        else
        {
            button.Text = "Sequential";
            this.ForwardButton.Enabled = true;
            this.BackwardButton.Enabled = true;
        }
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
        Label2.Text = "Photo Index: " + photos.CurrentPhotoIndex;
    }
}