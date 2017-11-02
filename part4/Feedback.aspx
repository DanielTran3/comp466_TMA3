<%@ Page Title="Feedback" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Feedback" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 440px;
        }
        .auto-style2 {
            width: 67%;
        }
        .auto-style3 {
            width: 440px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
        .auto-style5 {
            height: 25px;
        }
        .auto-style6 {
            background-color: #FFFFFF;
            border: 1.5px solid #000000;
            color: #000000;
            padding: 2%;
            font-size: 1.2em;
            margin-top: 5%;
            -o-transition: background-color 0.5s linear; /* opera */;
            -ms-transition: background-color 0.5s linear; /* IE 10 */;
            -moz-transition: background-color 0.5s linear; /* Firefox */;
            -webkit-transition: background-color 0.5s linear; /*safari and chrome */;
            transition: background-color 0.5s linear; /* vendorless fallback */
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Feedback
    </h1>
    <hr />
    <div>
        <div>
            <div>
                <div>
                </div>
            </div>
        </div>
    </div>
    <p>
        <table class="auto-style2">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="UsernameLabel" runat="server" Text="Username:" CssClass="labelsRight"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="UsernameTextbox" runat="server" Height="16px" Width="300px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="FeedbackLabel" runat="server" CssClass="labelsRight" Text="Your Feedback:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="FeedbackTextbox" runat="server" Rows="10" TextMode="MultiLine" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style5">
                    <asp:Button ID="FeedbackSubmitButton" runat="server" CssClass="whiteButton" Height="30px" Text="Submit" Width="301px" OnClick="FeedbackSubmitButton_Click" />
                </td>
            </tr>
        </table>
    </p>
    <h2>
        <asp:Label ID="NoFeedbackLabel" runat="server" Text="There is Currently No Feedback Available"></asp:Label>
    </h2>
    <p>
        <asp:GridView ID="FeedbackGridView" runat="server" CssClass="gridView" AutoGenerateColumns="False" Width="50px">
            <Columns>
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="feedbackText" HeaderText="Comment" HtmlEncode="false"/>
            </Columns>
        </asp:GridView>
    </p>
    </asp:Content>
