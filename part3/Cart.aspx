﻿<%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Your Items</h1>
    <h1>
        <asp:Label ID="EmptyCartLabel" runat="server" Text="Your Cart is Empty!" Visible="False"></asp:Label>
    </h1>
    <h2>
        <asp:Label ID="EmptyCartSubtitleLabel" runat="server" Text="Go to the &quot;Pre-Built Computers&quot; tab to get Started"></asp:Label>
    </h2>
    <asp:GridView ID="CartGridView" runat="server" CssClass="gridView" AutoGenerateDeleteButton="True" OnRowDeleting="CartGridView_RowDeleting">
        <HeaderStyle ForeColor="Black" />
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
    </asp:GridView>
    </asp:Content>