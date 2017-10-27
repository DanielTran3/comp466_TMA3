<%@ Page Title="Contacts" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Contacts.aspx.cs" Inherits="Contacts" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Contacts
    </h1>
    <hr />
    <h3>
        <asp:Image ID="ContactImage" runat="server" ImageUrl="~/Resources/Contact_Image.jpg" AlternateText="Image of Daniel Tran" />
    </h3>
<h3>
        Name
    </h3>
    <p>
        Daniel Tran
    </p>
    <h3>
        Email
    </h3>
    <p>
        DTran3@ualberta.ca
    </p>
    <h3>
        Description
    </h3>
    <p>
        Daniel is a 5th year computer engineering student at the University of Alberta and is the Founder of Digital Electronics. He has a passion for software engineering and has developed many Android, .NET, and Web Applications. If you have any questions or concerns, please email him at the specified e-mail address above.</p>
</asp:Content>
