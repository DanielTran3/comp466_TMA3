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
            <asp:Button ID="StartStopButton" runat="server" Text="Start" OnClick="StartStopButton_Click" />
            <asp:Button ID="SequentialRandomButton" runat="server" Text="Sequential" OnClick="SequentialRandomButton_Click" />
            <asp:Button ID="ForwardBackwardButton" runat="server" Text="Forward" OnClick="ForwardBackwardButton_Click" />
        </p>
        <p>
            <asp:Image ID="PhotoDisplay" runat="server" />
        </p>
        <asp:Label ID="CaptionLabel" runat="server"></asp:Label>
    </form>
</body>
</html>
