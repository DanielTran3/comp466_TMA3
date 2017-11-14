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
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </p>
        <div class="alignCenter">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="PhotoTimer" runat="server" Enabled="False" Interval="5000" OnTick="PhotoTimer_Tick">
                    </asp:Timer>
                    <asp:Label ID="Label1" runat="server" Text="Panel not refreshed yet"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Image ID="PhotoDisplay" runat="server" Width="480px" />
                    <br />
                    <asp:Label ID="CaptionLabel" runat="server"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
