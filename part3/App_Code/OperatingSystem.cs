using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OS
/// </summary>
public class OperatingSystem
{
    #region Data
    private string _brand;
    private string _version;
    private string _price;
    #endregion

    #region Constructor
    public OperatingSystem(string brand, string version, string price)
    {
        _brand = brand;
        _version = version;
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

    public string Version
    {
        get
        {
            return _version;
        }

        set
        {
            _version = value;
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
    public static List<OperatingSystem> GetAllOperatingSystems()
    {
        List<OperatingSystem> operatingSystems = new List<OperatingSystem>();
        operatingSystems.Add(new OperatingSystem("Microsoft", "Windows 10 Home (64-Bit)", "$139.99"));
        operatingSystems.Add(new OperatingSystem("Microsoft", "Windows 10 Pro (64-Bit)", "$219.99"));
        operatingSystems.Add(new OperatingSystem("Microsoft", "Windows 7 Pro (64-Bit)", "$199.99"));
        return operatingSystems;
    }

    public static int GetIndexOfOperatingSystem(OperatingSystem os, List<OperatingSystem> listOfOperatingSystems = null)
    {
        List<OperatingSystem> osList;
        if (listOfOperatingSystems == null)
        {
            osList = new List<OperatingSystem>();
        }
        else
        {
            osList = listOfOperatingSystems;
        }

        for (int i = 0; i < osList.Count; i++)
        {
            if (osList[i].EqualOperatingSystems(os))
            {
                return i;
            }
        }
        return -1;
    }

    public double GetPrice()
    {
        return Convert.ToDouble(this._price.Replace("$", ""));
    }

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
        return "Operating System: " + this._brand + " " + this._version + " " + this._price;
    }
    #endregion
}