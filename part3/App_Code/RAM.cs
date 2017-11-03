using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// A class representing RAM that extends components
/// </summary>
public class RAM : Components
{
    #region Data
    private string _speed;
    private string _memoryType;
    #endregion

    #region Constructors
    public RAM(string brand, string model, string speed, string memoryType, string price) : base(brand, model, price)
    {
        _speed = speed;
        _memoryType = memoryType;
    }
    #endregion

    #region Getters and Setters
    public string Speed
    {
        get
        {
            return _speed;
        }

        set
        {
            _speed = value;
        }
    }

    public string MemoryType
    {
        get
        {
            return _memoryType;
        }

        set
        {
            _memoryType = value;
        }
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Check the equality of a RAM component with another RAM component
    /// </summary>
    /// <param name="r">The RAM component to compare to</param>
    /// <returns></returns>
    public bool EqualComponent(RAM r)
    {
        if (base.EqualComponent(r) && this._speed == r.Speed && this._memoryType == r.MemoryType)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Override the ToString method that is used to display a concatenated string containing
    /// all properties of the RAM class
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "<b>RAM: </b>" + this._brand + " " + this._model + " " + this._speed + " " + this._memoryType + " " + "(" + this._price + ")";
    }
    #endregion

    #region Abstract Implementations
    /// <summary>
    /// RAM class refers to the RAMGridView
    /// </summary>
    /// <returns></returns>
    public override string GetGridView()
    {
        return "RAMGridView";
    }

    /// <summary>
    /// RAM class refers to the ram session
    /// </summary>
    /// <returns></returns>
    public override string GetSessionName()
    {
        return "ram";
    }
    #endregion
}