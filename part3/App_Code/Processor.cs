using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Processors
/// </summary>
public class Processor
{
    #region Data
    private string _brand;
    private string _model;
    private string _clock;
    private string _cache;
    private string _socket;
    private string _price;
    #endregion

    #region Constructors
    public Processor(string brand, string model, string clock, string cache, string socket, string price)
    {
        this._brand = brand;
        this._model = model;
        this._clock = clock;
        this._cache = cache;
        this._socket = socket;
        this._price = price;
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
    public static List<Processor> GetAllProcessors()
    {
        List<Processor> processorDetails = new List<Processor>();
        processorDetails.Add(new Processor("Intel", "Core i7-7700k", "4.20 GHz", "8MB Cache", "LGA1151", "$499.99"));
        processorDetails.Add(new Processor("Intel", "Core i5-7400", "3.00 GHz", "6MB Cache", "LGA1151", "$269.99"));
        processorDetails.Add(new Processor("Intel", "Core i3-7100", "3.90 GHz", "3MB Cache", "LGA1151", "$169.99"));
        processorDetails.Add(new Processor("AMD", "Ryzen 7 1700", "3.00 GHz", "16MB Cache", "PGA 1331 ", "$469.99"));
        processorDetails.Add(new Processor("AMD", "Ryzen 5 1600", "3.20 GHz", "16MB Cache", "PGA 1331", "$299.99"));
        processorDetails.Add(new Processor("AMD", "Ryzen 3 1300X", "3.50 GHz", "8MB Cache", "PGA 1331 ", "$169.99"));
        return processorDetails;
    }


    public static List<Processor> GetAllProcessorsBasedOnSocket(string socket)
    {
        List<Processor> processorDetails = new List<Processor>();
        foreach (Processor p in GetAllProcessors())
        {
            if (p.Socket == socket)
            {
                processorDetails.Add(p);
            }
        }
        return processorDetails;
    }

    public static int GetIndexOfProcessor(Processor processor, List<Processor> listOfProcessors = null)
    {
        List<Processor> processorList;
        if (listOfProcessors == null)
        {
            processorList = new List<Processor>();
        }
        else
        {
            processorList = listOfProcessors;
        }

        for (int i = 0; i < processorList.Count; i++)
        {
            if (processorList[i].EqualProcessors(processor))
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

    public bool EqualProcessors(Processor p)
    {
        if (this._brand == p.Brand && this._model == p.Model && this._clock == p.Clock &&
            this._cache == p.Cache && this._socket == p.Socket && this._price == p.Price)
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