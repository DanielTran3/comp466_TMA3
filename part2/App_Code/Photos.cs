﻿using System;
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
    private bool random;

    #region Constructors
    public Photos()
    {
        photoDetails = new List<List<string>>();
        currentPhotoIndex = 0;
        forward = true;
        random = false;
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

    public bool Random
    {
        get
        {
            return random;
        }

        set
        {
            this.random = value;
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

    public void UpdateCurrentPhotoIndex()
    {
        if (random)
        {
            RandomCurrentPhotoIndex();
        }
        else
        {
            if (forward)
            {
                if (currentPhotoIndex == photoDetails.Count - 1)
                {
                    this.currentPhotoIndex = 0;
                }
                else
                {
                    this.currentPhotoIndex++;
                }
            }
            else
            {
                if (currentPhotoIndex == 0)
                {
                    this.currentPhotoIndex = photoDetails.Count - 1;
                }
                else
                {
                    this.currentPhotoIndex--;
                }
            }
        }
    }

    public void RandomCurrentPhotoIndex()
    {
        Random random = new Random();
        currentPhotoIndex = random.Next(0, photoDetails.Count);
    }
    #endregion

}