<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            height: 38px;
        }
        .auto-style2 {
            width: 858px;
        }
        .auto-style3 {
            width: 345px;
        }
        .auto-style4 {
            height: 38px;
            width: 345px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Login</h1>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
    <table class="auto-style2">
        <tr>
            <td class="auto-style3">
                <asp:Label ID="UsernameLabel" runat="server" CssClass="labelsRight" Text="Username:"></asp:Label>
            </td>
            <td class="auto-style9 validation">
                <asp:TextBox ID="UsernameTextbox" runat="server" Height="16px" Width="280px"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username Required" ControlToValidate="UsernameTextbox" CssClass="validation"></asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator1_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator1">
                </ajaxToolkit:ValidatorCalloutExtender>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="PasswordLabel" runat="server" CssClass="labelsRight" Text="Password:"></asp:Label>
            </td>
            <td class="auto-style1 validation">
                <asp:TextBox ID="PasswordTextBox" runat="server" Height="16px" Width="280px" TextMode="Password"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password Required" ControlToValidate="PasswordTextBox" CssClass="validation"></asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator1_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator2">
                </ajaxToolkit:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                &nbsp;</td>
            <td class="auto-style9">
                <asp:Button ID="LoginButton" runat="server" CssClass="whiteButton" Height="30px" Text="Login" Width="280px" OnClick="LoginButton_Click" />
                <br />
                <asp:Label ID="LoginErrorLabel" runat="server" CssClass="validation" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>