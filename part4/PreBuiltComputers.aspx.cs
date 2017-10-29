﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PreBuiltComputers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginController.IsUserLoggedIn(this);
        // CHECK IF "selectedPreBuiltComputerRowIndex" and "prebuiltSystems" exist in the session, if they do load
        // up the correct index and the data
        if (Session["prebuiltSystems"] != null)
        {
            this.PreBuiltComputersGridView.DataSource = Session["prebuiltSystems"];
        }
        else
        {
            this.PreBuiltComputersGridView.DataSource = PreBuiltSystem.GetAllPreBuiltSystems();
            Session.Add("prebuiltSystems", this.PreBuiltComputersGridView.DataSource);
        }
        if (Session["selectedPreBuiltComputerRowIndex"] != null)
        {
            this.PreBuiltComputersGridView.SelectRow((int)Session["selectedPreBuiltComputerRowIndex"]);
        }

        this.PreBuiltComputersGridView.DataBind();
    }

    protected void PreBuiltComputersGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        List<PreBuiltSystem> pbsList = gv.DataSource as List<PreBuiltSystem>;
        PreBuiltSystem pbs = pbsList[gv.SelectedIndex];
        pbs.PreBuiltIndex = gv.SelectedIndex;
        Session.Add(pbs.ProcessorPart.GetSessionName(), pbs.ProcessorPart);
        Session.Add(pbs.RamPart.GetSessionName(), pbs.RamPart);
        Session.Add(pbs.HardDrivePart.GetSessionName(), pbs.HardDrivePart);
        Session.Add(pbs.DisplayPart.GetSessionName(), pbs.DisplayPart);
        Session.Add(pbs.OperatingSystemPart.GetSessionName(), pbs.OperatingSystemPart);
        Session.Add(pbs.SoundCardPart.GetSessionName(), pbs.SoundCardPart);
        // Keep the totalPrice stored as a double
        Session.Add("totalPrice", Convert.ToDouble(pbs.Price.Replace("$","")));

        Label totalCostLabel = (Label)Master.FindControl("TotalCostLabel");
        if (totalCostLabel != null)
        {
            totalCostLabel.Text = pbs.Price;
        }

        Session.Add("selectedPreBuiltComputerRowIndex", pbs.PreBuiltIndex);
    }
}