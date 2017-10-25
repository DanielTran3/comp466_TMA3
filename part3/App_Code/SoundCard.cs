using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SoundCard
/// </summary>
public class SoundCard : Components
{
    #region Data
    #endregion

    #region Constructor
    public SoundCard(string brand, string model, string price) : base(brand, model, price)
    {

    }


    #endregion

    #region Getters and Setters
    #endregion

    #region Public Methods
    public bool EqualComponent(SoundCard soundCard)
    {
        return base.EqualComponent(soundCard);
    }

    public override string ToString()
    {
        return "Sound Card: " + this._brand + " " + this._model + " " + this._price;
    }
    #endregion
}