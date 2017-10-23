using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SoundCard
/// </summary>
public class SoundCard
{
    #region Data
    private string _brand;
    private string _model;
    private string _price;
    #endregion

    #region Constructor
    public SoundCard(string brand, string model, string price)
    {
        _brand = brand;
        _model = model;
        _price = price;
    }


    #endregion

    #region Getters and Setters
    public string Brand
    {
        get
        {
            return _brand;
        }

        set
        {
            _brand = value;
        }
    }

    public string Model
    {
        get
        {
            return _model;
        }

        set
        {
            _model = value;
        }
    }

    public string Price
    {
        get
        {
            return _price;
        }

        set
        {
            _price = value;
        }
    }
    #endregion

    #region Public Methods
    public static List<SoundCard> GetAllSoundCards()
    {
        List<SoundCard> soundDetails = new List<SoundCard>();
        soundDetails.Add(new SoundCard("Creative Labs", "Sound Blaster Audigy PCI-E 5.1", "$49.99"));
        soundDetails.Add(new SoundCard("ASUS", "Xonar DDGX PCI-E 5.1", "$64.99"));
        soundDetails.Add(new SoundCard("Creative Labs", "Sound Blaster Z PCI-E 5.1", "$149.99"));
        soundDetails.Add(new SoundCard("ASUS", "Xonar DG PCI-E 5.1", "$49.99"));
        soundDetails.Add(new SoundCard("ASUS", "Xonar DSX PCI-E 7.1", "$49.99"));
        return soundDetails;
    }

    public override string ToString()
    {
        return "Sound Card: " + this._brand + " " + this._model + " " + this._price;
    }
    #endregion
}