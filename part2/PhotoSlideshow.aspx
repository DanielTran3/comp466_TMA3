<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhotoSlideshow.aspx.cs" Inherits="PhotoSlideshow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Photo Slideshow</p>
        <p>
            <asp:Button ID="StartStopButton" runat="server" Text="Start" />
            <asp:Button ID="Button2" runat="server" Text="Sequential" />
            <asp:Button ID="Button3" runat="server" Text="Forward" />
        </p>
        <p>
            <asp:Image ID="Image1" runat="server" />
        </p>
        <asp:Label ID="CaptionLabel" runat="server"></asp:Label>
    </form>
</body>
</html>
