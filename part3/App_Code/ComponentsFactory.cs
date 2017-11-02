using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// A static class that contains methods used to create components. The methods contain the hard-coded data for each
/// component type.
/// </summary>
public static class ComponentsFactory
{
    /// <summary>
    /// Creates a list of Sound Cards
    /// </summary>
    /// <returns></returns>
    public static List<Components> GetAllSoundCards()
    {
        List<Components> soundDetails = new List<Components>();
        soundDetails.Add(new SoundCard("Creative Labs", "Sound Blaster Audigy PCI-E 5.1", "$49.99"));
        soundDetails.Add(new SoundCard("ASUS", "Xonar DDGX PCI-E 5.1", "$64.99"));
        soundDetails.Add(new SoundCard("Creative Labs", "Sound Blaster Z PCI-E 5.1", "$149.99"));
        soundDetails.Add(new SoundCard("ASUS", "Xonar DG PCI-E 5.1", "$49.99"));
        soundDetails.Add(new SoundCard("ASUS", "Xonar DSX PCI-E 7.1", "$49.99"));
        return soundDetails;
    }

    /// <summary>
    /// Creates a list of Displays
    /// </summary>
    /// <returns></returns>
    public static List<Components> GetAllDisplays()
    {
        List<Components> displayDetails = new List<Components>();
        displayDetails.Add(new Display("BenQ", "GW2765HT", "27in", "2560 x 1440", "4ms (GTG)", "$379.99"));
        displayDetails.Add(new Display("BenQ", "GL2760H", "27in", "1920 x 1080", "2ms (GTG)", "$179.99"));
        displayDetails.Add(new Display("BenQ", "GW2270", "21.5in", "1920 x 1080", "5ms (GTG)", "$119.99"));
        displayDetails.Add(new Display("LG", "24M38D-B", "23.6in", "1920 x 1080", "5ms", "$159.99"));
        displayDetails.Add(new Display("LG", "22MP48HQ-P", "21.5in", "1920 x 1080", "5ms", "$169.99"));
        displayDetails.Add(new Display("ASUS", "VP239H-P", "23in", "1920 x 1080", "5ms (GTG)", "$184.99"));
        displayDetails.Add(new Display("ASUS", "ROG SWIFT PG279Q", "27in", "2560 x 1440", "4ms (GTG)", "$1059.99"));
        displayDetails.Add(new Display("ACER", "Predator XB241H", "24in", "1920x1080", "1ms", "$549.99"));
        return displayDetails;
    }

    /// <summary>
    /// Creates a list of Hard Drives
    /// </summary>
    /// <returns></returns>
    public static List<Components> GetAllHardDrives()
    {
        List<Components> hardDriveDetails = new List<Components>();
        hardDriveDetails.Add(new HardDrive("Seagate", "BarraCuda", "Hard Drive (HDD)", "1TB", "156MB/sec", "156MB/sec", "$79.99"));
        hardDriveDetails.Add(new HardDrive("Western Digital", "Blue", "Hard Drive (HDD)", "1TB", "150MB/sec", "150MB/sec", "$79.99"));
        hardDriveDetails.Add(new HardDrive("Seagate", "BarraCuda", "Hard Drive (HDD)", "2TB", "156MB/sec", "156MB/sec", "$109.99"));
        hardDriveDetails.Add(new HardDrive("Western Digital", "Blue", "Hard Drive (HDD)", "2TB", "150MB/sec", "150MB/sec", "$109.99"));
        hardDriveDetails.Add(new HardDrive("Seagate", "BarraCuda", "Hard Drive (HDD)", "3TB", "156MB/sec", "156MB/sec", "$139.99"));
        hardDriveDetails.Add(new HardDrive("Samsung", "850 EVO", "Solid State Drive (SSD)", "250GB", "540MB/sec", "520MB/sec", "$149.99"));
        hardDriveDetails.Add(new HardDrive("Kingston", "SSDNow UV400", "Solid State Drive (SSD)", "240GB", "550MB/sec", "490MB/sec", "$129.99"));
        hardDriveDetails.Add(new HardDrive("ADATA", "Ultimate SU800", "Solid State Drive (SSD)", "256GB", "560MB/sec", "520MB/sec", "$139.99"));
        hardDriveDetails.Add(new HardDrive("Samsung", "850 EVO", "Solid State Drive (SSD)", "500GB", "540MB/sec", "520MB/sec", "$249.99"));
        hardDriveDetails.Add(new HardDrive("ADATA", "Premier SP580", "Solid State Drive (SSD)", "120GB", "560MB/sec", "410MB/sec", "$79.99"));
        return hardDriveDetails;
    }

    /// <summary>
    /// Creates a list of Operating Systems
    /// </summary>
    /// <returns></returns>
    public static List<Components> GetAllOperatingSystems()
    {
        List<Components> operatingSystems = new List<Components>();
        operatingSystems.Add(new OperatingSystem("Microsoft", "Windows 10 Home (64-Bit)", "$139.99"));
        operatingSystems.Add(new OperatingSystem("Microsoft", "Windows 10 Pro (64-Bit)", "$219.99"));
        operatingSystems.Add(new OperatingSystem("Microsoft", "Windows 7 Pro (64-Bit)", "$199.99"));
        return operatingSystems;
    }

    /// <summary>
    /// Creates a list of Processors
    /// </summary>
    /// <returns></returns>
    public static List<Components> GetAllProcessors()
    {
        List<Components> processorDetails = new List<Components>();
        processorDetails.Add(new Processor("Intel", "Core i7-7700k", "4.20 GHz", "8MB Cache", "LGA1151", "$499.99"));
        processorDetails.Add(new Processor("Intel", "Core i5-7400", "3.00 GHz", "6MB Cache", "LGA1151", "$269.99"));
        processorDetails.Add(new Processor("Intel", "Core i3-7100", "3.90 GHz", "3MB Cache", "LGA1151", "$169.99"));
        processorDetails.Add(new Processor("AMD", "Ryzen 7 1700", "3.00 GHz", "16MB Cache", "PGA 1331 ", "$469.99"));
        processorDetails.Add(new Processor("AMD", "Ryzen 5 1600", "3.20 GHz", "16MB Cache", "PGA 1331", "$299.99"));
        processorDetails.Add(new Processor("AMD", "Ryzen 3 1300X", "3.50 GHz", "8MB Cache", "PGA 1331 ", "$169.99"));
        return processorDetails;
    }

    /// <summary>
    /// Creates a list of RAM
    /// </summary>
    /// <returns></returns>
    public static List<Components> GetAllRAMs()
    {
        List<Components> ramDetails = new List<Components>();
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
}