<%@ Page Title="Registration Success" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="RegistrationSuccess.aspx.cs" Inherits="Account_RegistrationSuccess" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Registration Successful!
    </h1>
    <h2>
        Press the button below to continue</h2>
    <h2>
        &nbsp;<asp:Button ID="RegistrationSuccessfulButton" runat="server" CssClass="whiteButton" Text="Continue" OnClick="RegistrationSuccessContinueButton_Click" />
    </h2>
</asp:Content>
