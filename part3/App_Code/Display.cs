using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Display
/// </summary>
public class Display
{
    #region Data
    private string _brand;
    private string _model;
    private string _size;
    private string _resolution;
    private string _responseTime;
    private string _price;
    #endregion

    #region Constructors
    public Display(string brand, string model, string size, string resolution, string responseTime, string price)
    {
        _brand = brand;
        _model = model;
        _size = size;
        _resolution = resolution;
        _responseTime = responseTime;
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
    public static List<Display> GetAllDisplays()
    {
        List<Display> displayDetails = new List<Display>();
        displayDetails.Add(new Display("BenQ", "GW2765HT", "27in", "2560 x 1440", "4ms (GTG)", "$379.99"));
        displayDetails.Add(new Display("BenQ", "GL2760H", "27in", "1920 x 1080", "2ms (GTG)", "$179.99"));
        displayDetails.Add(new Display("BenQ", "GW2270", "21.5in", "1920 x 1080", "5ms (GTG)", "$119.99"));
        displayDetails.Add(new Display("LG", "24M38D-B", "23.6in", "1920 x 1080", "5ms", "$159.99"));
        displayDetails.Add(new Display("LG", "22MP48HQ-P", "21.5in", "1920 x 1080", "5ms", "$169.99"));
        displayDetails.Add(new Display("ASUS", "VP239H-P", "23in", "1920 x 1080", "5ms (GTG)", "$184.99"));
        displayDetails.Add(new Display("ASUS", "ROG SWIFT PG279Q", "27in", "2560 x 1440", "4ms (GTG)", "$1059.99"));
        displayDetails.Add(new Display("ACER", "Predator XB241H", "24in", "1920x1080", "1ms", "$549.99"));
        return displayDetails;
    }

    public override string ToString()
    {
        return "Monitor: " + this._brand + " " + this._model + " " + this._size + " " + this._resolution + " " + this._responseTime + " " + this._price;
    }
    #endregion
}