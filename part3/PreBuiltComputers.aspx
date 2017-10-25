<%@ Page Title="Pre-built Computers" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PreBuiltComputers.aspx.cs" Inherits="PreBuiltComputers" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Pre-Built Computer</h1>
    <asp:GridView ID="PreBuiltComputersGridView" runat="server" AutoGenerateSelectButton="True" CssClass="gridView" OnSelectedIndexChanged="PreBuiltComputersGridView_SelectedIndexChanged">
        <HeaderStyle ForeColor="Black" />
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
    </asp:GridView>
    </asp:Content>
