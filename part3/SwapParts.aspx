<%@ Page Title="Swap Parts" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SwapParts.aspx.cs" Inherits="SwapParts" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Swap Parts
    </h1>
    <h3>
        Processor</h3>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px">
        </asp:DetailsView>
    </p>
    <h3>
        RAM</h3>
    <p>
        &nbsp;</p>
    <h3>
        OS</h3>
    <p>
        &nbsp;</p>
    <h3>
        Display</h3>
    <p>
        &nbsp;</p>
    <h3>
        Sound Card</h3>
    <p>
        &nbsp;</p>
</asp:Content>
