using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RAM
/// </summary>
public class RAM
{
    #region Data
    private string _brand;
    private string _model;
    private string _speed;
    private string _memoryType;
    private string _price;
    #endregion

    #region Constructors
    public RAM(string brand, string model, string speed, string memoryType, string price)
    {
    _brand = brand;
    _model = model;
    _speed = speed;
    _memoryType = memoryType;
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
    public static List<RAM> GetAllRAMs()
    {
        List<RAM> ramDetails = new List<RAM>();
        ramDetails.Add(new RAM("Corsair", "Vengeance LPX", "2400MHz", "DDR4 2 x 8GB PC4-19200", "$234.99"));
        ramDetails.Add(new RAM("G.Skill", "Ripjaws 4", "2400MHz", "DDR4 2 x 8GB PC4-19200", "$184.99"));
        ramDetails.Add(new RAM("Corsair", "Vengeance LPX", "2133MHz", "DDR4 2 x 4GB", "$107.99"));
        ramDetails.Add(new RAM("G.Skill", "Trident Z RGB", "2400MHz", "DDR4 2 x 8GB PC4-19200", "$214.99"));
        ramDetails.Add(new RAM("Corsair", "Vengeance LPX", "2400MHz", "DDR4 2 x 8GB PC4-25600", "$234.99"));
        ramDetails.Add(new RAM("G.Skill", "Ripjaws V", "2800MHz", "DDR4 2 x 4GB PC4-22400", "$95.99"));
        ramDetails.Add(new RAM("Kingston", "HyperX Fury", "2133MHz", "DDR4 1 x 16GB PC4-17000", "$182.99"));
        ramDetails.Add(new RAM("Kingston", "HyperX Fury", "2133MHz", "DDR4 1 x 8GB PC4-17000", "$92.99"));
        ramDetails.Add(new RAM("G.Skill", "Ripjaws V", "2800MHz", "DDR4 4 x 4GB PC4-22400", "$189.99"));
        return ramDetails;
    }

    public static int GetIndexOfRAM(RAM ram, List<RAM> listOfRAMs = null)
    {
        List<RAM> ramList;
        if (listOfRAMs == null)
        {
            ramList = new List<RAM>();
        }
        else
        {
            ramList = listOfRAMs;
        }

        for (int i = 0; i < ramList.Count; i++)
        {
            if (ramList[i].EqualRAMs(ram))
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

    public bool EqualRAMs(RAM r)
    {
        if (this._brand == r.Brand && this._model == r.Model && this._speed == r.Speed &&
            this._memoryType == r.MemoryType && this._price == r.Price)
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return "RAM: " + this._brand + " " + this._model + " " + this._speed + " " + this._memoryType + " " + this._price;
    }
    #endregion
}