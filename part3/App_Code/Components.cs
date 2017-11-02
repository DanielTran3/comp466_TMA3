using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Components class is an abstract base class that contains three properties
/// that all components (display, hard drive, operating system, processor, ram, 
/// and sound card) must contain, which is a brand, model, and price
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
    /// <summary>
    /// Returns the gridview related to a component
    /// </summary>
    /// <returns></returns>
    public abstract string GetGridView();
    /// <summary>
    /// Returns the session related to a component
    /// </summary>
    /// <returns></returns>
    public abstract string GetSessionName();
    #endregion

    #region Public Methods
    /// <summary>
    /// Returns the price property as a double
    /// </summary>
    /// <returns></returns>
    public double GetPrice()
    {
        return Convert.ToDouble(this._price.Replace("$", ""));
    }

    /// <summary>
    /// Compares a component with another component's properties to check for equality
    /// </summary>
    /// <param name="component">The second component to compare against</param>
    /// <returns></returns>
    protected bool EqualComponent(Components component)
    {
        if (this._brand == component.Brand && this._model == component.Model && this._price == component.Price)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns the index of a component that exists in the list of components
    /// </summary>
    /// <param name="component">Component that the index will be retrieved for</param>
    /// <param name="listOfComponents">List of components to iterate through and compare the component parameter with</param>
    /// <returns></returns>
    public static int GetIndexOfComponent(Components component, List<Components> listOfComponents = null)
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