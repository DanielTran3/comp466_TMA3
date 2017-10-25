using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Processors
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
    //public static List<Processor> GetAllProcessorsBasedOnSocket(string socket)
    //{
    //    List<Processor> processorDetails = new List<Processor>();
    //    foreach (Processor p in GetAllProcessors())
    //    {
    //        if (p.Socket == socket)
    //        {
    //            processorDetails.Add(p);
    //        }
    //    }
    //    return processorDetails;
    //}

    public bool EqualProcessors(Processor p)
    {
        if (base.EqualComponent(p) && this._clock == p.Clock &&
            this._cache == p.Cache && this._socket == p.Socket)
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return "Processor: " + this._brand + " " + this._model + " " + this._clock + " " + this._cache+ " " + this._socket + " " + this._price;
    }
    #endregion
}