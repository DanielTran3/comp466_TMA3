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
    private Processor _processor;
    private RAM _ram;
    private HardDrive _hardDrive;
    private Display _display;
    private OperatingSystem _operatingSystem;
    private SoundCard _soundCard;

    public PreBuiltSystem(Processor processor, RAM ram, HardDrive hardDrive, Display display, OperatingSystem os, SoundCard soundCard)
    {
        _system = processor.ToString() + "\r\n" + ram.ToString() + "\r\n" + hardDrive.ToString() + "\r\n" + display.ToString() + "\r\n" + os.ToString() + "\r\n" + soundCard.ToString();
        _processor = processor;
        _ram = ram;
        _hardDrive = hardDrive;
        _display = display;
        _operatingSystem = os;
        _soundCard = soundCard;

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

    public Processor Processor
    {
        get
        {
            return _processor;
        }

        set
        {
            _processor = value;
        }
    }

    public RAM Ram
    {
        get
        {
            return _ram;
        }

        set
        {
            _ram = value;
        }
    }

    public HardDrive HardDrive
    {
        get
        {
            return _hardDrive;
        }

        set
        {
            _hardDrive = value;
        }
    }

    public Display Display
    {
        get
        {
            return _display;
        }

        set
        {
            _display = value;
        }
    }

    public OperatingSystem OperatingSystem
    {
        get
        {
            return _operatingSystem;
        }

        set
        {
            _operatingSystem = value;
        }
    }

    public SoundCard SoundCard
    {
        get
        {
            return _soundCard;
        }

        set
        {
            _soundCard = value;
        }
    }
    #endregion

    public static List<PreBuiltSystem> GetAllPreBuiltSystems()
    {
        List<Processor> processors = Processor.GetAllProcessors();
        List<RAM> ram = RAM.GetAllRAMs();
        List<HardDrive> hardDrives = HardDrive.GetAllHardDrives();
        List<Display> displays = Display.GetAllDisplays();
        List<OperatingSystem> operatingSystems = OperatingSystem.GetAllOperatingSystems();
        List<SoundCard> soundCards = SoundCard.GetAllSoundCards();
        List<PreBuiltSystem> preBuiltSystem = new List<PreBuiltSystem>();
        preBuiltSystem.Add(new PreBuiltSystem(processors[0], ram[0], hardDrives[0], displays[0], operatingSystems[0], soundCards[0]));
        preBuiltSystem.Add(new PreBuiltSystem(processors[1], ram[3], hardDrives[4], displays[1], operatingSystems[1], soundCards[2]));
        preBuiltSystem.Add(new PreBuiltSystem(processors[0], ram[5], hardDrives[8], displays[6], operatingSystems[1], soundCards[2]));
        preBuiltSystem.Add(new PreBuiltSystem(processors[5], ram[7], hardDrives[1], displays[2], operatingSystems[0], soundCards[3]));
        preBuiltSystem.Add(new PreBuiltSystem(processors[4], ram[2], hardDrives[6], displays[3], operatingSystems[2], soundCards[4]));
        return preBuiltSystem;
    }

    public static double GetPrice(string price)
    {
        string tempString = price.Replace("$", "");
        return Convert.ToDouble(tempString);
    }

    public void TotalPrice()
    {
        _price = "$" + (GetPrice(_processor.Price) + GetPrice(_ram.Price) + GetPrice(_hardDrive.Price) + GetPrice(_display.Price) + 
                        GetPrice(_operatingSystem.Price) + GetPrice(_soundCard.Price)).ToString();
    }
}