using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// A class representing Processors that extends components
/// </summary>
public class Processor : Components
{
    #region Data
    private string _clock;
    private string _cache;
    private string _socket;
    #endregion

    #region Constructors
    public Processor(string brand, string model, string clock, string cache, string socket, string price) : base(brand, model, price)
    {
        this._clock = clock;
        this._cache = cache;
        this._socket = socket;
    }
    #endregion

    #region Getters and Setters
    public string Clock
    {
        get
        {
            return _clock;
        }

        set
        {
            _clock = value;
        }
    }

    public string Cache
    {
        get
        {
            return _cache;
        }

        set
        {
            _cache = value;
        }
    }

    public string Socket
    {
        get
        {
            return _socket;
        }

        set
        {
            _socket = value;
        }
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Check the equality of a processor with another processor
    /// </summary>
    /// <param name="p">The processor to compare to</param>
    /// <returns></returns>
    public bool EqualProcessors(Processor p)
    {
        if (base.EqualComponent(p) && this._clock == p.Clock &&
            this._cache == p.Cache && this._socket == p.Socket)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Override the ToString method that is used to display a concatenated string containing
    /// all properties of the Processor class
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "<b>Processor: </b>" + this._brand + " " + this._model + " " + this._clock + " " + 
               this._cache + " " + this._socket + " " + "(" + this._price + ")";
    }
    #endregion

    #region Abstract Implementations
    /// <summary>
    /// Processor class refers to the ProcessorGridView
    /// </summary>
    /// <returns></returns>
    public override string GetGridView()
    {
        return "ProcessorGridView";
    }

    /// <summary>
    /// Processor class refers to the processor session
    /// </summary>
    /// <returns></returns>
    public override string GetSessionName()
    {
        return "processor";
    }
    #endregion
} 