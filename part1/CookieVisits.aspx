<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CookieVisits.aspx.cs" Inherits="CookieVisits" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cookie Visits</title>
    <link rel = "stylesheet" type="text/css" runat="server" href="~/shared/tma3_stylesheet.css" />
    <script type="text/javascript">
        function getTimeZone() {
            var offset = new Date().getTimezoneOffset() / 60;
            //document.getElementById("ClientTimeZoneLabel").innerHTML = offset + " hours";
            document.getElementById("ClientTimeZoneLabel").innerHTML = new Date().toUTCString() + ", " + offset + " Hours";
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 50%;
            margin: 0 auto;
            text-align: center;
            width: 500px;
            height: 100px;
            border: 1px dashed black;
        }
        .title3 {
            font-size: 1.2em !important;
        }
    </style>
</head>
<body onload="getTimeZone()">
    <form id="form1" runat="server">
        <div>
            <h1 class="title1" style="text-align:center;">Cookie Visits</h1>
        </div>
        <div class="containerDiv">
            <div class="auto-style1">
                <asp:Label ID="NumberOfVisitsLabel" CssClass="title3" runat="server" Text="Number of Visits: "></asp:Label>
                <asp:Label ID="NumberOfVisitsCountLabel" CssClass="title3" runat="server"></asp:Label>
                <br />
                <asp:Label ID="ClientIPAddressTextLabel" CssClass="title3" runat="server" Text="IP Address: "></asp:Label>
                <asp:Label ID="ClientIPAddressLabel" CssClass="title3" runat="server"></asp:Label>
                <br />
                <asp:Label ID="ClientTimeZoneTextLabel" CssClass="title3" runat="server" Text="Time Zone: "></asp:Label>
                <asp:Label ID="ClientTimeZoneLabel" CssClass="title3" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
