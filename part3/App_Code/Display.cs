using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// A class representing Displays that extends components
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
    /// <summary>
    /// Check the equality of a display with another display
    /// </summary>
    /// <param name="d">The display to compare to</param>
    /// <returns></returns>
    public bool EqualComponent(Display d)
    {
        if (base.EqualComponent(d) && this._size == d.Size &&
            this._resolution == d.Resolution && this._responseTime == d.ResponseTime)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Override the ToString method that is used to display a concatenated string containing
    /// all properties of the Display class
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "<b>Monitor: </b>" + this._brand + " " + this._model + " " + this._size + 
               " " + this._resolution + " " + this._responseTime + " " + "(" + this._price + ")";
    }
    #endregion

    #region Abstract Implementations
    /// <summary>
    /// Display class refers to the DisplayGridView
    /// </summary>
    /// <returns></returns>
    public override string GetGridView()
    {
        return "DisplayGridView";
    }

    /// <summary>
    /// Display class refers to the display session
    /// </summary>
    /// <returns></returns>
    public override string GetSessionName()
    {
        return "display";
    }
    #endregion
}