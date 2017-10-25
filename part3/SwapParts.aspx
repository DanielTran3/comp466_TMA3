<%@ Page Title="Swap Parts" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SwapParts.aspx.cs" Inherits="SwapParts" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Swap Parts
    </h1>
    <h1>
        <asp:Label ID="SelectPreBuiltComputerFirstLabel" runat="server" Text="Please Select A Pre-Built Computer First" Visible="False"></asp:Label>
    </h1>
    <h3>
        <asp:Label ID="ProcessorLabel" runat="server" Text="Processor"></asp:Label>
    </h3>
    <asp:GridView ID="ProcessorGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
        <HeaderStyle ForeColor="Black" />
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
    </asp:GridView>
    <h3>
        <asp:Label ID="RAMLabel" runat="server" Text="RAM"></asp:Label>
    </h3>
    <asp:GridView ID="RAMGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
        <HeaderStyle ForeColor="Black" />
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
    </asp:GridView>
    <h3>
        <asp:Label ID="HardDriveLabel" runat="server" Text="Hard Drive"></asp:Label>
    </h3>
    <asp:GridView ID="HardDriveGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
        <HeaderStyle ForeColor="Black" />
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
    </asp:GridView>
    <h3>
        <asp:Label ID="OSLabel" runat="server" Text="Operating System"></asp:Label>
    </h3>
    <asp:GridView ID="OperatingSystemGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
        <HeaderStyle ForeColor="Black" />
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
    </asp:GridView>
    <h3>
        <asp:Label ID="DisplayLabel" runat="server" Text="Display"></asp:Label>
    </h3>
    <asp:GridView ID="DisplayGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
        <HeaderStyle ForeColor="Black" />
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
    </asp:GridView>
    <h3>
        <asp:Label ID="SoundCardLabel" runat="server" Text="Sound Card"></asp:Label>
    </h3>
    <asp:GridView ID="SoundCardGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
        <HeaderStyle ForeColor="Black" />
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
    </asp:GridView>
<br />
        <asp:Button ID="AddToCartButton" runat="server" CssClass="whiteButton " Text="Add to Cart" OnClick="AddToCartButton_Click" />
    </asp:Content>
