<%@ Page Title="Swap Parts" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SwapParts.aspx.cs" Inherits="SwapParts" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Swap Parts
    </h1>
    <h3>
        Processor</h3>
    <asp:GridView ID="ProcessorsGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" AllowSorting="True">
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="#CCCCCC" />
    </asp:GridView>
    <h3>
        RAM</h3>
    <asp:GridView ID="RAMGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" AllowSorting="True">
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="#CCCCCC" />
    </asp:GridView>
    <h3>
        OS</h3>
    <asp:GridView ID="OSGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" AllowSorting="True">
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="#CCCCCC" />
    </asp:GridView>
    <h3>
        Display</h3>
    <asp:GridView ID="DisplayGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" AllowSorting="True">
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="#CCCCCC" />
    </asp:GridView>
    <h3>
        Sound Card</h3>
    <asp:GridView ID="SoundCardGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" AllowSorting="True">
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="#CCCCCC" />
    </asp:GridView>
    </asp:Content>
