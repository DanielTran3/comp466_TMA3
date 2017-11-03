using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// A class representing Operating Systems that extends components
/// </summary>
public class OperatingSystem : Components
{
    #region Data
    #endregion

    #region Constructor
    public OperatingSystem(string brand, string version, string price) : base(brand, version, price)
    {
    }
    #endregion

    #region Getters and Setters
    public string Version
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
    #endregion

    #region Public Methods
    /// <summary>
    /// Check the equality of a hard drive with another hard drive
    /// </summary>
    /// <param name="os">The operating system to compare to</param>
    /// <returns></returns>
    public bool EqualOperatingSystems(OperatingSystem os)
    {
        if (this._brand == os.Brand && this._brand == os.Brand && this._price == os.Price)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Override the ToString method that is used to display a concatenated string containing
    /// all properties of the OperatingSystem class
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "<b>Operating System: </b>" + this._brand + " " + this._model + " " + "(" + this._price + ")";
    }
    #endregion

    #region Abstract Implementations
    /// <summary>
    /// OperatingSystem class refers to the OperatingSystemGridView
    /// </summary>
    /// <returns></returns>
    public override string GetGridView()
    {
        return "OperatingSystemGridView";
    }

    /// <summary>
    /// OperatingSystem class refers to the OperatingSystem session
    /// </summary>
    /// <returns></returns>
    public override string GetSessionName()
    {
        return "OperatingSystem";
    }
    #endregion
}