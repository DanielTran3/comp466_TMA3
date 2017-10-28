<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="ForgotPassword.aspx.cs" Inherits="Account_ForgotPassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 312px;
        }
        .auto-style3 {
            height: 29px;
        }
    </style>
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
        <asp:Label ID="PasswordRecoveryLabel" runat="server"></asp:Label>
    </p>
    <table class="auto-style2">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="UsernameLabel" runat="server" CssClass="labelsRight" Text="Username:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="UsernameTextbox" runat="server" Height="16px" Width="280px"></asp:TextBox>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="PasswordLabel" runat="server" CssClass="labelsRight" Text="Password:"></asp:Label>
            </td>
            <td class="auto-style9 validation">
                <asp:TextBox ID="PasswordTextBox" runat="server" Height="16px" Width="280px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
                    <td class="auto-style1">
                        <asp:Label ID="SecurityQuestionLabel" runat="server" CssClass="labelsRight" Text="Security Question:"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="SecurityQuestionTextbox" runat="server" Height="16px" Width="280px"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="SecurityAnswerLabel" runat="server" CssClass="labelsRight" Text="Answer:"></asp:Label>
                    </td>
                    <td class="auto-style9 validation">
                        <asp:TextBox ID="SecurityAnswerTextBox" runat="server" Height="16px" Width="280px"></asp:TextBox>
                    </td>
                </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style9">
                <asp:Button ID="RecoveryButton" runat="server" CssClass="whiteButton" Height="30px" Text="Submit" Width="280px" OnClick="LoginButton_Click" />
                <br />
                <asp:Label ID="PasswordRecoveryErrorLabel" runat="server" CssClass="validation" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
