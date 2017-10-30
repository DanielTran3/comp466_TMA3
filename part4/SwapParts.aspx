<%@ Page Title="Swap Parts" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SwapParts.aspx.cs" Inherits="SwapParts" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Swap Parts
    </h1>
    <hr />
    <h2>
        <asp:Label ID="SelectPreBuiltComputerFirstLabel" runat="server" Text="Please Select A Pre-Built Computer First" Visible="False"></asp:Label>
    </h2>
    <h3>
        <asp:Label ID="ProcessorLabel" runat="server" Text="Processor"></asp:Label>
    </h3>
    <asp:GridView ID="ProcessorGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="GridView_SelectedIndexChanged" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="brand" HeaderText="Brand" />
            <asp:BoundField DataField="model" HeaderText="Model" />
            <asp:BoundField DataField="clock" HeaderText="Clock" />
            <asp:BoundField DataField="Cache" HeaderText="Cache" />
            <asp:BoundField DataField="socket" HeaderText="Socket" />
            <asp:BoundField DataField="price" HeaderText="Price" />
        </Columns>
        <HeaderStyle ForeColor="Black" />
        <PagerStyle CssClass="pagingToLeft" />
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
    </asp:GridView>
    <h3>
        <asp:Label ID="RAMLabel" runat="server" Text="RAM"></asp:Label>
    </h3>
    <asp:GridView ID="RAMGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="GridView_SelectedIndexChanged" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Brand" HeaderText="Brand" />
            <asp:BoundField DataField="Model" HeaderText="Model" />
            <asp:BoundField DataField="Speed" HeaderText="Speed" />
            <asp:BoundField DataField="MemoryType" HeaderText="Memory Type" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
        </Columns>
        <HeaderStyle ForeColor="Black" />
        <PagerStyle CssClass="pagingToLeft" />
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
    </asp:GridView>
    <h3>
        <asp:Label ID="HardDriveLabel" runat="server" Text="Hard Drive"></asp:Label>
    </h3>
    <asp:GridView ID="HardDriveGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="GridView_SelectedIndexChanged" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Brand" HeaderText="Brand" />
            <asp:BoundField DataField="Model" HeaderText="Model" />
            <asp:BoundField DataField="Type" HeaderText="Type" />
            <asp:BoundField DataField="Size" HeaderText="Size" />
            <asp:BoundField DataField="ReadSpeed" HeaderText="Read Speed" />
            <asp:BoundField DataField="WriteSpeed" HeaderText="Write Speed" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
        </Columns>
        <HeaderStyle ForeColor="Black" />
        <PagerStyle CssClass="pagingToLeft" />
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
    </asp:GridView>
    <h3>
        <asp:Label ID="OSLabel" runat="server" Text="Operating System"></asp:Label>
    </h3>
    <asp:GridView ID="OperatingSystemGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="GridView_SelectedIndexChanged" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Brand" HeaderText="Brand" />
            <asp:BoundField DataField="Version" HeaderText="Version" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
        </Columns>
        <HeaderStyle ForeColor="Black" />
        <PagerStyle CssClass="pagingToLeft" />
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
    </asp:GridView>
    <h3>
        <asp:Label ID="DisplayLabel" runat="server" Text="Display"></asp:Label>
    </h3>
    <asp:GridView ID="DisplayGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="GridView_SelectedIndexChanged" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Brand" HeaderText="Brand" />
            <asp:BoundField DataField="Model" HeaderText="Model" />
            <asp:BoundField DataField="Size" HeaderText="Size" />
            <asp:BoundField DataField="Resolution" HeaderText="Resolution" />
            <asp:BoundField DataField="ResponseTime" HeaderText="Response Time" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
        </Columns>
        <HeaderStyle ForeColor="Black" />
        <PagerStyle CssClass="pagingToLeft" />
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
    </asp:GridView>
    <h3>
        <asp:Label ID="SoundCardLabel" runat="server" Text="Sound Card"></asp:Label>
    </h3>
    <asp:GridView ID="SoundCardGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CssClass="gridView" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="GridView_SelectedIndexChanged" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Brand" HeaderText="Brand" />
            <asp:BoundField DataField="Model" HeaderText="Model" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
        </Columns>
        <HeaderStyle ForeColor="Black" />
        <PagerStyle CssClass="pagingToLeft" />
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
    </asp:GridView>
<br />
        <asp:Button ID="AddToCartButton" runat="server" CssClass="whiteButton " Text="Add to Cart" OnClick="AddToCartButton_Click" />
    </asp:Content>
