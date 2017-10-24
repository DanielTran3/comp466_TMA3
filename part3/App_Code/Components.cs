using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Components
/// </summary>
public abstract class Components
{
    #region Data
    protected string _brand;
    protected string _model;
    protected string _price;
    #endregion

    #region Constructors
    public Components(string brand, string model, string price)
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

    #region Abstract Methods
    public abstract bool EqualComponent(Components component);
    #endregion

    #region Public Methods
    public double GetPrice()
    {
        return Convert.ToDouble(this._price.Replace("$", ""));
    }

    public int GetIndexOfComponent(Components component, List<Components> listOfComponents = null)
    {
        List<Components> displayList;
        if (listOfComponents == null)
        {
            displayList = new List<Components>();
        }
        else
        {
            displayList = listOfComponents;
        }

        for (int i = 0; i < displayList.Count; i++)
        {
            if (displayList[i].EqualComponent(component))
            {
                return i;
            }
        }
        return -1;
    }
    #endregion
}