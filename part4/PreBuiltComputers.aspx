<%@ Page Title="Pre-built Computers" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PreBuiltComputers.aspx.cs" Inherits="PreBuiltComputers" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Pre-Built Computer
    </h1>
    <hr />
    <asp:GridView ID="PreBuiltComputersGridView" runat="server" AutoGenerateSelectButton="True" CssClass="gridView" OnSelectedIndexChanged="PreBuiltComputersGridView_SelectedIndexChanged" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="System" HeaderText="System" HtmlEncode="false"/>
            <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
        </Columns>
        <HeaderStyle ForeColor="Black" />
        <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
    </asp:GridView>
    </asp:Content>
