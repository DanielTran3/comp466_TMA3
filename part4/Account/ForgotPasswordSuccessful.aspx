<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="ForgotPasswordSuccessful.aspx.cs" Inherits="Account_ForgotPasswordSuccessful" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Password Recovery Successful!
    </h1>
    <h2>
        Press the Button Below to Continue</h2>
    <h2>
                        <asp:Button ID="RecoverySuccessfulContinueButton" runat="server" CssClass="whiteButton" Text="Submit" OnClick="RegisterSubmitButton_Click" />
    </h2>
</asp:Content>