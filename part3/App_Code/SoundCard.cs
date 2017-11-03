using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// A class representing SoundCard that extends components
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
    /// <summary>
    /// Check the equality of a SoundCard with another SoundCard
    /// </summary>
    /// <param name="soundCard">The SoundCard to compare to</param>
    /// <returns></returns>
    public bool EqualComponent(SoundCard soundCard)
    {
        return base.EqualComponent(soundCard);
    }

    /// <summary>
    /// Override the ToString method that is used to display a concatenated string containing
    /// all properties of the SoundCard class
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "<b>Sound Card: </b>" + this._brand + " " + this._model + " " + "(" + this._price + ")";
    }
    #endregion

    #region Abstract Implementations
    /// <summary>
    /// SoundCard class refers to the SoundCardGridView
    /// </summary>
    /// <returns></returns>
    public override string GetGridView()
    {
        return "SoundCardGridView";
    }

    /// <summary>
    /// SoundCard class refers to the soundCard session
    /// </summary>
    /// <returns></returns>
    public override string GetSessionName()
    {
        return "soundCard";
    }
    #endregion
}