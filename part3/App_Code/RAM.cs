using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RAM
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
    public bool EqualComponent(RAM r)
    {
        if (base.EqualComponent(r) && this._speed == r.Speed && this._memoryType == r.MemoryType)
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