﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// A class representing Hard Drives that extends components
/// </summary>
public class HardDrive : Components
{
    #region Data
    private string _type;
    private string _size;
    private string _readSpeed;
    private string _writeSpeed;
    #endregion

    #region Constructors
    public HardDrive(string brand, string model, string type, string size, string readSpeed, string writeSpeed, string price) : base(brand, model, price)
    {
        _type = type;
        _size = size;
        _readSpeed = readSpeed;
        _writeSpeed = writeSpeed;
    }
    #endregion

    #region Getters and Setters
    public string Type
    {
        get
        {
            return _type;
        }

        set
        {
            _type = value;
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

    public string ReadSpeed
    {
        get
        {
            return _readSpeed;
        }

        set
        {
            _readSpeed = value;
        }
    }

    public string WriteSpeed
    {
        get
        {
            return _writeSpeed;
        }

        set
        {
            _writeSpeed = value;
        }
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Check the equality of a hard drive with another hard drive
    /// </summary>
    /// <param name="hdd">The hard drive to compare to</param>
    /// <returns></returns>
    public bool EqualComponent(HardDrive hdd)
    {
        if (base.EqualComponent(hdd) && this._type == hdd.Type &&
            this._size == hdd.Size && this._readSpeed == hdd.ReadSpeed && 
            this._writeSpeed == hdd.WriteSpeed)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Override the ToString method that is used to display a concatenated string containing
    /// all properties of the HardDrive class
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "<b>Hard Drive: </b>" + this._brand + " " + this._model + " " + this._size + " " + this._type + 
               " Read Speed:" + this._readSpeed + " Write Speed:" + this._writeSpeed + " " + "(" + this._price + ")";
    }
    #endregion

    #region Abstract Implementations
    /// <summary>
    /// HardDrive class refers to the HardDriveGridView
    /// </summary>
    /// <returns></returns>
    public override string GetGridView()
    {
        return "HardDriveGridView";
    }

    /// <summary>
    /// HardDrive class refers to the hardDrive session
    /// </summary>
    /// <returns></returns>
    public override string GetSessionName()
    {
        return "hardDrive";
    }
    #endregion
}