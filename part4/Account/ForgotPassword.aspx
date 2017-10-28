<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="ForgotPassword.aspx.cs" Inherits="Account_ForgotPassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Password Recovery
    </h1>
    <p>
        <asp:ScriptManager ID="ScriptManager" runat="server">
        </asp:ScriptManager>
    </p>
    <p>
        Enter your Username below</p>
    <table class="auto-style2">
        <tr>
            <td class="auto-style3">
                <asp:Label ID="UsernameLabel" runat="server" CssClass="labelsRight" Text="Username:"></asp:Label>
            </td>
            <td class="auto-style9 validation">
                <asp:TextBox ID="UsernameTextbox" runat="server" Height="16px" Width="280px"></asp:TextBox>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                &nbsp;</td>
            <td class="auto-style9">
                <asp:Button ID="LoginButton" runat="server" CssClass="whiteButton" Height="30px" Text="Submit" Width="280px" OnClick="LoginButton_Click" />
                <br />
                <asp:Label ID="LoginErrorLabel" runat="server" CssClass="validation" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
