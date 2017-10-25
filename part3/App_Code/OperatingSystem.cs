using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OS
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
    public bool EqualOperatingSystems(OperatingSystem os)
    {
        if (this._brand == os.Brand && this._brand == os.Brand && this._price == os.Price)
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return "Operating System: " + this._brand + " " + this._model + " " + this._price;
    }
    #endregion

    #region Abstract Implementations
    public override string GetGridView()
    {
        return "OperatingSystemGridView";
    }

    public override string GetSessionName()
    {
        return "OperatingSystem";
    }
    #endregion
}