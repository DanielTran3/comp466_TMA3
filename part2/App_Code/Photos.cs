using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Photos
/// </summary>
public class Photos
{
    private List<List<string>> photoDetails;
    private int currentPhotoIndex;
    private bool forward;

    #region Constructors
    public Photos()
    {
        photoDetails = new List<List<string>>();
        currentPhotoIndex = 0;
        forward = true;
    }
    #endregion

    #region Getters and Setters
    public List<List<string>> PhotoDetails
    {
        get
        {
            return photoDetails;
        }

        set
        {
            this.photoDetails = value;
        }
    }

    public int CurrentPhotoIndex
    {
        get
        {
            return currentPhotoIndex;
        }

        set
        {
            this.currentPhotoIndex = value;
        }
    }

    public bool Forward
    {
        get
        {
            return forward;
        }

        set
        {
            this.forward = value;
        }
    }
    #endregion

    #region Public Methods
    public void StorePhotoDetails(string[] photoDataLines)
    {
        foreach (string line in photoDataLines)
        {
            string[] separatedLine = line.Split(',');
            List<string> tempList = new List<string>();
            foreach (string s in separatedLine)
            {
                tempList.Add(s);
            }
            photoDetails.Add(tempList);
        }
    }

    public string GetPhoto()
    {
        return photoDetails[currentPhotoIndex][0];
    }

    public string GetCaption()
    {
        return photoDetails[currentPhotoIndex][1];
    }

    public void IncrementCurrentPhotoIndex()
    {
        this.currentPhotoIndex++;
    }

    public void RandomCurrentPhotoIndex()
    {
        Random random = new Random();
        currentPhotoIndex = random.Next(0, photoDetails.Count);
    }

    public List<string> NextPhotoAndCaption()
    {
        return forward ? photoDetails[currentPhotoIndex++] : photoDetails[currentPhotoIndex--];
    }

    public List<string> RandomPhotoAndCaption()
    {
        Random random = new Random();
        currentPhotoIndex = random.Next(0, photoDetails.Count);
        return photoDetails[currentPhotoIndex];
    }
    #endregion

}