using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HardDrive
/// </summary>
public class HardDrive
{
    #region Data
    private string _brand;
    private string _model;
    private string _type;
    private string _size;
    private string _readSpeed;
    private string _writeSpeed;
    private string _price;
    #endregion

    #region Constructors
    public HardDrive(string brand, string model, string type, string size, string readSpeed, string writeSpeed, string price)
    {
        _brand = brand;
        _model = model;
        _type = type;
        _size = size;
        _readSpeed = readSpeed;
        _writeSpeed = writeSpeed;
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
    public static List<HardDrive> GetAllHardDrives()
    {
        List<HardDrive> hardDriveDetails = new List<HardDrive>();
        hardDriveDetails.Add(new HardDrive("Seagate", "BarraCuda", "Hard Drive (HDD)", "1TB", "156MB/sec", "156MB/sec", "$79.99"));
        hardDriveDetails.Add(new HardDrive("Western Digital", "Blue", "Hard Drive (HDD)", "1TB", "150MB/sec", "150MB/sec", "$79.99"));
        hardDriveDetails.Add(new HardDrive("Seagate", "BarraCuda", "Hard Drive (HDD)", "2TB", "156MB/sec", "156MB/sec", "$109.99"));
        hardDriveDetails.Add(new HardDrive("Western Digital", "Blue", "Hard Drive (HDD)", "2TB", "150MB/sec", "150MB/sec", "$109.99"));
        hardDriveDetails.Add(new HardDrive("Seagate", "BarraCuda", "Hard Drive (HDD)", "3TB", "156MB/sec", "156MB/sec", "$139.99"));
        hardDriveDetails.Add(new HardDrive("Samsung", "850 EVO", "Solid State Drive(SSD)", "250GB", "540MB/sec", "520MB/sec", "$149.99"));
        hardDriveDetails.Add(new HardDrive("Kingston", "SSDNow UV400", "Solid State Drive(SSD)", "240GB", "550MB/sec", "490MB/sec", "$129.99"));
        hardDriveDetails.Add(new HardDrive("ADATA", "Ultimate SU800", "Solid State Drive(SSD)", "256GB", "560MB/sec", "520MB/sec", "$139.99"));
        hardDriveDetails.Add(new HardDrive("Samsung", "850 EVO", "Solid State Drive(SSD)", "500GB", "540MB/sec", "520MB/sec", "$249.99"));
        hardDriveDetails.Add(new HardDrive("ADATA", "Premier SP580", "Solid State Drive(SSD)", "120GB", "560MB/sec", "410MB/sec", "$79.99"));
        return hardDriveDetails;
    }

    public static int GetIndexOfHardDrive(HardDrive hardDrive, List<HardDrive> listOfHardDrives = null)
    {
        List<HardDrive> hardDriveList;
        if (listOfHardDrives == null)
        {
            hardDriveList = new List<HardDrive>();
        }
        else
        {
            hardDriveList = listOfHardDrives;
        }

        for (int i = 0; i < hardDriveList.Count; i++)
        {
            if (hardDriveList[i].EqualHardDrives(hardDrive))
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

    public bool EqualHardDrives(HardDrive hdd)
    {
        if (this._brand == hdd.Brand && this._model == hdd.Model && this._type == hdd.Type &&
            this._size == hdd.Size && this._readSpeed == hdd.ReadSpeed && 
            this._writeSpeed == hdd.WriteSpeed && this._price == hdd.Price)
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return "Hard Drive: " + "Brand: " + this._brand + "Model: " + this._model + "Type: " + this._type + "Size: " + this._size + "Read/Write Speed: " + this._readSpeed + " " + this._writeSpeed + "Price: " + this._price;
    }
    #endregion
}