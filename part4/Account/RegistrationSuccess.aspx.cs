﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_RegistrationSuccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = false;
    }

    protected void RegistrationSuccessContinueButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/Login.aspx");
    }
}