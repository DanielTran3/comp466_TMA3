using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// A PreBuiltSystem contains instances of the children classes of the Components class, which
/// includes Processor, RAM, HardDRive, Display, OperatingSystem, and SoundCard
/// </summary>
public class PreBuiltSystem
{
    private string _id;
    private string _system;
    private string _price;
    private Components _processorPart;
    private Components _ramPart;
    private Components _hardDrivePart;
    private Components _displayPart;
    private Components _operatingSystemPart;
    private Components _soundCardPart;
    private int _preBuiltIndex;

    // Constructor that creates the _system string that contains the details for a system.
    // Constructor also calculates the total price of the system
    public PreBuiltSystem(string id, Components processor, Components ram, Components hardDrive, Components display, Components os, Components soundCard)
    {
        _system = processor.ToString() + "<br />" + ram.ToString() + "<br />" + hardDrive.ToString() + 
                  "<br />" + display.ToString() + "<br />" + os.ToString() + "<br />" + soundCard.ToString();
        _processorPart = processor;
        _ramPart = ram;
        _hardDrivePart = hardDrive;
        _displayPart = display;
        _operatingSystemPart = os;
        _soundCardPart = soundCard;

        TotalPrice();

        _id = id;
    }

    #region Getters And Setters
    public string Id
    {
        get
        {
            return _id;
        }

        set
        {
            _id = value;
        }
    }
    public string System
    {
        get
        {
            return _system;
        }

        set
        {
            _system = value;
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

    public Components ProcessorPart
    {
        get
        {
            return _processorPart;
        }

        set
        {
            _processorPart = value;
        }
    }

    public Components RamPart
    {
        get
        {
            return _ramPart;
        }

        set
        {
            _ramPart = value;
        }
    }

    public Components HardDrivePart
    {
        get
        {
            return _hardDrivePart;
        }

        set
        {
            _hardDrivePart = value;
        }
    }

    public Components DisplayPart
    {
        get
        {
            return _displayPart;
        }

        set
        {
            _displayPart = value;
        }
    }

    public Components OperatingSystemPart
    {
        get
        {
            return _operatingSystemPart;
        }

        set
        {
            _operatingSystemPart = value;
        }
    }

    public Components SoundCardPart
    {
        get
        {
            return _soundCardPart;
        }

        set
        {
            _soundCardPart = value;
        }
    }

    public int PreBuiltIndex
    {
        get
        {
            return _preBuiltIndex;
        }

        set
        {
            _preBuiltIndex = value;
        }
    }
    #endregion

    /// <summary>
    /// Parses the $ sign out of the string and returns the equivalent double value
    /// </summary>
    /// <param name="price">The price string to parse and get the value for</param>
    /// <returns></returns>
    public static double GetPrice(string price)
    {
        string tempString = price.Replace("$", "");
        return Convert.ToDouble(tempString);
    }

    /// <summary>
    /// Gets the total price of each component and concatenates a $ sign in the front
    /// </summary>
    public void TotalPrice()
    {
        _price = "$" + (GetPrice(_processorPart.Price) + GetPrice(_ramPart.Price) + GetPrice(_hardDrivePart.Price) + GetPrice(_displayPart.Price) + 
                        GetPrice(_operatingSystemPart.Price) + GetPrice(_soundCardPart.Price)).ToString();
    }
}