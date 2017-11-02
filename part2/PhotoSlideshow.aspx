<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhotoSlideshow.aspx.cs" Inherits="PhotoSlideshow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Photo Slideshow</title>
    <%--<link rel = "stylesheet" type="text/css" runat="server" href="~/shared/tma3_stylesheet.css" />--%>
    <style type="text/css">
        .alignCenter {
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="alignCenter">Photo Slideshow</h1>
        <p class="alignCenter">
            <asp:Button ID="StartStopButton" runat="server" Text="Start" OnClick="StartStopButton_Click" />
            <asp:Button ID="SequentialRandomButton" runat="server" Text="Sequential" OnClick="SequentialRandomButton_Click" />
            <asp:Button ID="ForwardButton" runat="server" Text="Forward" OnClick="ForwardBackwardButton_Click" />
            <asp:Button ID="BackwardButton" runat="server" Text="Backward" OnClick="ForwardBackwardButton_Click" />
        </p>
        <p>
            <asp:Image ID="PhotoDisplay" runat="server" />
        </p>
        <asp:Label ID="CaptionLabel" CssClass="alignCenter" runat="server"></asp:Label>
    </form>
</body>
</html>
