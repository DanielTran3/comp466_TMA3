<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CookieVisits.aspx.cs" Inherits="CookieVisits" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cookie Visits</title>
    <script type="text/javascript">
        // Does the time zone need to be done in ASP.NET and C#? Or can it be done using js?
        //window.onload = function () {
        //    alert("load");
        //    var offset = new Date().getTimezoneOffset();
        //    document.getElementById("ClientTimeZoneLabel").innerHTML = offset;
        //};
        function test() {
            //var offset = new Date().getTimezoneOffset() / 60;
            //document.getElementById("ClientTimeZoneLabel").innerHTML = offset + " hours";
            document.getElementById("ClientTimeZoneLabel").innerHTML = new Date().toUTCString();
        }
    </script>
</head>
<body onload="test()">
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="NumberOfVisitsLabel" runat="server" Text="Number of Visits: "></asp:Label>
        <asp:Label ID="NumberOfVisitsCountLabel" runat="server"></asp:Label>
        <br />
        <asp:Label ID="ClientIPAddressTextLabel" runat="server" Text="IP Address: "></asp:Label>
        <asp:Label ID="ClientIPAddressLabel" runat="server"></asp:Label>
        <br />
        <asp:Label ID="ClientTimeZoneTextLabel" runat="server" Text="Time Zone: "></asp:Label>
        <asp:Label ID="ClientTimeZoneLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
