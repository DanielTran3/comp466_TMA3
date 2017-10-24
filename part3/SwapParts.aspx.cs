using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SwapParts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["processor"] != null && Session["ram"] != null && Session["hardDrive"] != null &&
            Session["display"] != null && Session["operatingSystem"] != null && Session["soundCard"] != null && 
            Session["totalPrice"] != null)
        {
            List<Processor> listOfProcessors = Processor.GetAllProcessors();
            this.ProcessorsGridView.DataSource = listOfProcessors;
            this.ProcessorsGridView.DataBind();

            List<RAM> listOfRAMs = RAM.GetAllRAMs();
            this.RAMGridView.DataSource = listOfRAMs;
            this.RAMGridView.DataBind();

            List<HardDrive> listOfHardDrives = HardDrive.GetAllHardDrives();
            this.HardDriveGridView.DataSource = listOfHardDrives;
            this.HardDriveGridView.DataBind();

            List<OperatingSystem> listOfOSs = OperatingSystem.GetAllOperatingSystems();
            this.OSGridView.DataSource = listOfOSs;
            this.OSGridView.DataBind();

            List<Display> listOfDisplays = Display.GetAllDisplays();
            this.DisplayGridView.DataSource = listOfDisplays;
            this.DisplayGridView.DataBind();

            List<SoundCard> listOfSoundCards = SoundCard.GetAllSoundCards();
            this.SoundCardGridView.DataSource = listOfSoundCards;
            this.SoundCardGridView.DataBind();

            UpdateTotalCostLabel();

            this.ProcessorsGridView.SelectRow(Processor.GetIndexOfProcessor(Session["processor"] as Processor, listOfProcessors));
            this.RAMGridView.SelectRow(RAM.GetIndexOfRAM(Session["ram"] as RAM, listOfRAMs));
            this.HardDriveGridView.SelectRow(HardDrive.GetIndexOfHardDrive(Session["hardDrive"] as HardDrive, listOfHardDrives));
            this.OSGridView.SelectRow(OperatingSystem.GetIndexOfOperatingSystem(Session["operatingSystem"] as OperatingSystem, listOfOSs));
            this.DisplayGridView.SelectRow(Display.GetIndexOfDisplay(Session["display"] as Display, listOfDisplays));
            this.SoundCardGridView.SelectRow(SoundCard.GetIndexOfSoundCard(Session["soundCard"] as SoundCard, listOfSoundCards));

            this.SelectPreBuiltComputerFirstLabel.Visible = false;
            this.ProcessorLabel.Visible = true;
            this.RAMLabel.Visible = true;
            this.HardDriveLabel.Visible = true;
            this.OSLabel.Visible = true;
            this.DisplayLabel.Visible = true;
            this.SoundCardLabel.Visible = true;
        }
        else
        {
            this.SelectPreBuiltComputerFirstLabel.Visible = true;
            this.ProcessorLabel.Visible = false;
            this.RAMLabel.Visible = false;
            this.HardDriveLabel.Visible = false;
            this.OSLabel.Visible = false;
            this.DisplayLabel.Visible = false;
            this.SoundCardLabel.Visible = false;
        }
    }

    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView gridView = sender as GridView;
        gridView.PageIndex = e.NewPageIndex;
        gridView.DataBind();

        if (gridView.DataSource as List<Processor> != null)
        {
            List<Processor> tempList = gridView.DataSource as List<Processor>;
            int index = Processor.GetIndexOfProcessor(Session["processor"] as Processor, tempList);

            if (index - (gridView.PageSize * gridView.PageIndex) >= 0)
            {
                this.ProcessorsGridView.SelectRow(index - (gridView.PageSize * gridView.PageIndex));
                Session.Add("processor", tempList[index]);
            }
            else
            {
                this.ProcessorsGridView.SelectRow(-1);
            }
        }
        else if (gridView.DataSource as List<RAM> != null)
        {
            List<RAM> tempList = gridView.DataSource as List<RAM>;
            int index = RAM.GetIndexOfRAM(Session["ram"] as RAM, tempList);

            if (index - (gridView.PageSize * gridView.PageIndex) >= 0)
            {
                this.RAMGridView.SelectRow(index - (gridView.PageSize * gridView.PageIndex));
                Session.Add("ram", tempList[index]);
            }
            else
            {
                this.RAMGridView.SelectRow(-1);
            }
        }
        else if (gridView.DataSource as List<HardDrive> != null)
        {
            List<HardDrive> tempList = gridView.DataSource as List<HardDrive>;
            int index = HardDrive.GetIndexOfHardDrive(Session["hardDrive"] as HardDrive, tempList);

            if (index - (gridView.PageSize * gridView.PageIndex) >= 0)
            {
                this.HardDriveGridView.SelectRow(index - (gridView.PageSize * gridView.PageIndex));
                Session.Add("hardDrive", tempList[index]);
            }
            else
            {
                this.HardDriveGridView.SelectRow(-1);
            }
        }
        else  if (gridView.DataSource as List<OperatingSystem> != null)
        {
            List<OperatingSystem> tempList = gridView.DataSource as List<OperatingSystem>;
            int index = OperatingSystem.GetIndexOfOperatingSystem(Session["operatingSystem"] as OperatingSystem, tempList);

            if (index - (gridView.PageSize * gridView.PageIndex) >= 0)
            {
                this.OSGridView.SelectRow(index - (gridView.PageSize * gridView.PageIndex));
                Session.Add("operatingSystem", tempList[index]);
            }
            else
            {
                this.OSGridView.SelectRow(-1);
            }
        }
        else if (gridView.DataSource as List<Display> != null)
        {
            List<Display> tempList = gridView.DataSource as List<Display>;
            int index = Display.GetIndexOfDisplay(Session["display"] as Display, tempList);

            if (index - (gridView.PageSize * gridView.PageIndex) >= 0)
            {
                this.DisplayGridView.SelectRow(index - (gridView.PageSize * gridView.PageIndex));
                Session.Add("display", tempList[index]);
            }
            else
            {
                this.DisplayGridView.SelectRow(-1);
            }
        }
        else if (gridView.DataSource as List<SoundCard> != null)
        {
            List<SoundCard> tempList = gridView.DataSource as List<SoundCard>;
            int index = SoundCard.GetIndexOfSoundCard(Session["soundCard"] as SoundCard, tempList);

            if (index - (gridView.PageSize * gridView.PageIndex) >= 0)
            {
                this.SoundCardGridView.SelectRow(index - (gridView.PageSize * gridView.PageIndex));
                Session.Add("soundCard", tempList[index]);
            }
            else
            {
                this.SoundCardGridView.SelectRow(-1);
            }
        }
    }

    protected void ProcessorsGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridView gv = sender as GridView;
            if (gv.SelectedIndex >= 0)
            {
                List<Processor> processorList = gv.DataSource as List<Processor>;
                Processor processor = processorList[(gv.SelectedIndex % gv.PageSize) + (gv.PageSize * gv.PageIndex)];
                Processor oldProcessor = Session["processor"] as Processor;

                double totalPrice = (double) Session["totalPrice"];
                totalPrice -= oldProcessor.GetPrice();
                totalPrice += processor.GetPrice();

                Session.Add("processor", processor);
                Session.Add("totalPrice", totalPrice);
                UpdateTotalCostLabel();
                //Need to have something like the page index change
            }
        }
        catch { }
    }

    protected void RAMGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        if (gv.SelectedIndex >= 0)
        {
            List<RAM> ramList = gv.DataSource as List<RAM>;
            RAM ram = ramList[(gv.SelectedIndex % gv.PageSize) + (gv.PageSize * gv.PageIndex)];
            RAM oldRAM = Session["ram"] as RAM;

            double totalPrice = (double)Session["totalPrice"];
            totalPrice -= oldRAM.GetPrice();
            totalPrice += ram.GetPrice();

            Session.Add("ram", ram);
            Session.Add("totalPrice", totalPrice);
            UpdateTotalCostLabel();
        }
    }

    protected void HardDriveGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        if (gv.SelectedIndex >= 0)
        {
            List<HardDrive> hardDriveList = gv.DataSource as List<HardDrive>;
            HardDrive hardDrive = hardDriveList[(gv.SelectedIndex % gv.PageSize) + (gv.PageSize * gv.PageIndex)];
            HardDrive oldHardDrive = Session["hardDrive"] as HardDrive;

            double totalPrice = (double)Session["totalPrice"];
            totalPrice -= oldHardDrive.GetPrice();
            totalPrice += hardDrive.GetPrice();

            Session.Add("hardDrive", hardDrive);
            Session.Add("totalPrice", totalPrice);
            UpdateTotalCostLabel();
        }
    }

    protected void OSGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        if (gv.SelectedIndex >= 0)
        {
            List<OperatingSystem> operatingSystemList = gv.DataSource as List<OperatingSystem>;
            OperatingSystem operatingSystem = operatingSystemList[(gv.SelectedIndex % gv.PageSize) + (gv.PageSize * gv.PageIndex)];
            OperatingSystem oldOperatingSystem = Session["operatingSystem"] as OperatingSystem;

            double totalPrice = (double)Session["totalPrice"];
            totalPrice -= oldOperatingSystem.GetPrice();
            totalPrice += operatingSystem.GetPrice();

            Session.Add("operatingSystem", operatingSystem);
            Session.Add("totalPrice", totalPrice);
            UpdateTotalCostLabel();
        }
    }
    protected void DisplayGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        if (gv.SelectedIndex >= 0)
        {
            List<Display> displayList = gv.DataSource as List<Display>;
            Display display = displayList[(gv.SelectedIndex % gv.PageSize) + (gv.PageSize * gv.PageIndex)];
            Display oldDisplay = Session["display"] as Display;

            double totalPrice = (double)Session["totalPrice"];
            totalPrice -= oldDisplay.GetPrice();
            totalPrice += display.GetPrice();

            Session.Add("display", display);
            Session.Add("totalPrice", totalPrice);
            UpdateTotalCostLabel();
        }
    }

    protected void SoundCardGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        if (gv.SelectedIndex >= 0)
        {
            List<SoundCard> soundCardList = gv.DataSource as List<SoundCard>;
            SoundCard soundCard = soundCardList[(gv.SelectedIndex % gv.PageSize) + (gv.PageSize * gv.PageIndex)];
            SoundCard oldSoundCard = Session["soundCard"] as SoundCard;

            double totalPrice = (double)Session["totalPrice"];
            totalPrice -= oldSoundCard.GetPrice();
            totalPrice += soundCard.GetPrice();

            Session.Add("soundCard", soundCard);
            Session.Add("totalPrice", totalPrice);
            UpdateTotalCostLabel();
        }
    }

    public void UpdateTotalCostLabel()
    {
        Label totalCostLabel = (Label)Master.FindControl("TotalCostLabel");
        if (totalCostLabel != null)
        {
            totalCostLabel.Text = "$" + Session["totalPrice"];
        }
    }
}