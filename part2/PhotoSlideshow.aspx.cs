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
        
    }

    protected void StartStopButton_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (button.Text == "Start")
        {
            button.Text = "Stop";

            // Add a timed sequential callback function
            this.PhotoDisplay.ImageUrl = photos.GetPhoto();
            this.CaptionLabel.Text = photos.GetCaption();
            photos.IncrementCurrentPhotoIndex();
        }
        else
        {
            button.Text = "Start";
        }
    }

    protected void SequentialRandomButton_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (button.Text == "Sequential")
        {
            button.Text = "Random";
            this.ForwardBackwardButton.Enabled = false;

            photos.RandomCurrentPhotoIndex();
            this.PhotoDisplay.ImageUrl = photos.GetPhoto();
            this.CaptionLabel.Text = photos.GetCaption();
        }
        else
        {
            button.Text = "Sequential";
            this.ForwardBackwardButton.Enabled = true;
        }
    }

    protected void ForwardBackwardButton_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (button.Text == "Forward")
        {
            button.Text = "Backward";

            photos.Forward = true;
        }
        else
        {
            button.Text = "Forward";

            photos.Forward = false;
        }
    }
}