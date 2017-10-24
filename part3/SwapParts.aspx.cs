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

            Label totalCostLabel = (Label)Master.FindControl("TotalCostLabel");
            if (totalCostLabel != null)
            {
                totalCostLabel.Text = Session["totalPrice"] as string;
            }

            this.ProcessorsGridView.SelectRow(Processor.GetIndexOfProcessor(Session["processor"] as Processor, listOfProcessors));
            this.RAMGridView.SelectRow(RAM.GetIndexOfRAM(Session["ram"] as RAM, listOfRAMs));
            this.HardDriveGridView.SelectRow(HardDrive.GetIndexOfHardDrive(Session["hardDrive"] as HardDrive, listOfHardDrives));
            this.OSGridView.SelectRow(OperatingSystem.GetIndexOfOperatingSystem(Session["operatingSystem"] as OperatingSystem, listOfOSs));
            this.DisplayGridView.SelectRow(Display.GetIndexOfDisplay(Session["display"] as Display, listOfDisplays));
            this.SoundCardGridView.SelectRow(SoundCard.GetIndexOfSoundCard(Session["soundCard"] as SoundCard, listOfSoundCards));

            this.SelectPreBuiltComputerFirstLabel.Visible = true;
            this.ProcessorLabel.Visible = true;
            this.RAMLabel.Visible = true;
            this.HardDriveLabel.Visible = true;
            this.OSLabel.Visible = true;
            this.DisplayLabel.Visible = true;
            this.SoundCardLabel.Visible = true;
        }
        else
        {
            this.SelectPreBuiltComputerFirstLabel.Visible = false;
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
    }

    protected void ProcessorsGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        List<Processor> processorList = gv.DataSource as List<Processor>;
        Processor processor = processorList[gv.SelectedIndex];
        Session.Add("processor", processor);
    }

    protected void RAMGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        List<RAM> ramList = gv.DataSource as List<RAM>;
        RAM ram = ramList[gv.SelectedIndex];
        Session.Add("ram", ram);
    }

    protected void HardDriveGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        List<HardDrive> hardDriveList = gv.DataSource as List<HardDrive>;
        HardDrive hardDrive = hardDriveList[gv.SelectedIndex];
        Session.Add("hardDrive", hardDrive);
    }

    protected void OSGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        List<OperatingSystem> operatingSystemList = gv.DataSource as List<OperatingSystem>;
        OperatingSystem operatingSystem = operatingSystemList[gv.SelectedIndex];
        Session.Add("operatingSystem", operatingSystem);
    }

    protected void DisplayGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        List<Display> displayList = gv.DataSource as List<Display>;
        Display display = displayList[gv.SelectedIndex];
        Session.Add("display", display);
    }

    protected void SoundCardGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        List<SoundCard> soundCardList = gv.DataSource as List<SoundCard>;
        SoundCard soundCard = soundCardList[gv.SelectedIndex];
        Session.Add("soundCard", soundCard);
    }
}