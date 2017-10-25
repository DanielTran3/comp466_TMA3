using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Display
/// </summary>
public class Display : Components
{
    #region Data
    private string _size;
    private string _resolution;
    private string _responseTime;
    #endregion

    #region Constructors
    public Display(string brand, string model, string size, string resolution, string responseTime, string price) : base(brand, model, price)
    {
        _size = size;
        _resolution = resolution;
        _responseTime = responseTime;
    }
    #endregion

    #region Getters and Setters
    public string Size
    {
        get
        {
            return _size;
        }

        set
        {
            _size = value;
        }
    }

    public string Resolution
    {
        get
        {
            return _resolution;
        }

        set
        {
            _resolution = value;
        }
    }

    public string ResponseTime
    {
        get
        {
            return _responseTime;
        }

        set
        {
            _responseTime = value;
        }
    }
    #endregion

    #region Public Methods
    public bool EqualComponent(Display d)
    {
        if (base.EqualComponent(d) && this._size == d.Size &&
            this._resolution == d.Resolution && this._responseTime == d.ResponseTime)
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return "Monitor: " + this._brand + " " + this._model + " " + this._size + " " + this._resolution + " " + this._responseTime + " " + this._price;
    }
    #endregion
}