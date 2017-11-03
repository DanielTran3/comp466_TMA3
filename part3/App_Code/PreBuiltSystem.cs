using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PreBuiltSystem
/// </summary>
public class PreBuiltSystem
{
    private string _system;
    private string _price;
    private Components _processorPart;
    private Components _ramPart;
    private Components _hardDrivePart;
    private Components _displayPart;
    private Components _operatingSystemPart;
    private Components _soundCardPart;
    private int _preBuiltIndex;
    public PreBuiltSystem(Components processor, Components ram, Components hardDrive, Components display, Components os, Components soundCard)
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
    }

    #region Getters And Setters
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
    /// Static method to initialize all of the components (using the ComponentsFactory) and add all of the components to the system
    /// </summary>
    /// <returns></returns>
    public static List<PreBuiltSystem> GetAllPreBuiltSystems()
    {
        List<Components> processors = ComponentsFactory.GetAllProcessors();
        List<Components> ram = ComponentsFactory.GetAllRAMs();
        List<Components> hardDrives = ComponentsFactory.GetAllHardDrives();
        List<Components> displays = ComponentsFactory.GetAllDisplays();
        List<Components> operatingSystems = ComponentsFactory.GetAllOperatingSystems();
        List<Components> soundCards = ComponentsFactory.GetAllSoundCards();
        List<PreBuiltSystem> preBuiltSystem = new List<PreBuiltSystem>();
        preBuiltSystem.Add(new PreBuiltSystem(processors[0], ram[0], hardDrives[0], displays[0], operatingSystems[0], soundCards[0]));
        preBuiltSystem.Add(new PreBuiltSystem(processors[1], ram[3], hardDrives[4], displays[1], operatingSystems[1], soundCards[2]));
        preBuiltSystem.Add(new PreBuiltSystem(processors[0], ram[5], hardDrives[8], displays[6], operatingSystems[1], soundCards[2]));
        preBuiltSystem.Add(new PreBuiltSystem(processors[5], ram[7], hardDrives[1], displays[2], operatingSystems[0], soundCards[3]));
        preBuiltSystem.Add(new PreBuiltSystem(processors[4], ram[2], hardDrives[6], displays[3], operatingSystems[2], soundCards[4]));
        return preBuiltSystem;
    }

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