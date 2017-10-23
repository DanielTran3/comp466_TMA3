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
        this.ProcessorsGridView.DataSource = Processor.GetAllProcessors();
        this.ProcessorsGridView.DataBind();
        this.RAMGridView.DataSource = RAM.GetAllRAMs();
        this.RAMGridView.DataBind();
        this.OSGridView.DataSource = OperatingSystem.GetAllOperatingSystems();
        this.OSGridView.DataBind();
        this.DisplayGridView.DataSource = Display.GetAllDisplays();
        this.DisplayGridView.DataBind();
        this.SoundCardGridView.DataSource = SoundCard.GetAllSoundCards();
        this.SoundCardGridView.DataBind();

    }

    protected void ProcessorsGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ProcessorsGridView.DataBind();
    }

    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView gridView = sender as GridView;
        gridView.PageIndex = e.NewPageIndex;
        gridView.DataBind();
    }
}