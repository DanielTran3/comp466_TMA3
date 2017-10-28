<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">

        .auto-style2 {
            width: 99%;
        }
        .auto-style9 {
            height: 20px;
            width: 320px;
        }
        .auto-style13 {
        width: 184px;
        height: 20px;
    }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Register
    </h1>
    <p>
        <asp:ScriptManager ID="RegisterScriptManager" runat="server">
        </asp:ScriptManager>
    </p>

    <asp:UpdatePanel ID="RegisterUpdatePanel" runat="server">
        <ContentTemplate>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="UsernameLabel" runat="server" CssClass="labelsRight" Text="Username:"></asp:Label>
                    </td>
                    <td class="auto-style9 validation">
                        <asp:TextBox ID="UsernameTextbox" runat="server" Height="16px" Width="280px"></asp:TextBox>
                        *
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username Required" ControlToValidate="UsernameTextbox" CssClass="validation"></asp:RequiredFieldValidator>
                        <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator1_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator1">
                        </ajaxToolkit:ValidatorCalloutExtender>
                        &nbsp;<asp:Label ID="UsernameAlreadyExistsLabel" runat="server" Text="Username Already Exists" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="PasswordLabel" runat="server" CssClass="labelsRight" Text="Password:"></asp:Label>
                    </td>
                    <td class="auto-style9 validation">
                        <asp:TextBox ID="PasswordTextBox" runat="server" Height="16px" Width="280px" TextMode="Password"></asp:TextBox>
                        *
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password Required" ControlToValidate="PasswordTextBox" CssClass="validation"></asp:RequiredFieldValidator>
                        <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator1_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator2">
                        </ajaxToolkit:ValidatorCalloutExtender>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="ConfirmPasswordTextBox" ControlToValidate="PasswordTextBox" ErrorMessage="Passwords do not match" CssClass="validation"></asp:CompareValidator>
                        <ajaxToolkit:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" runat="server" BehaviorID="CompareValidator1_ValidatorCalloutExtender" TargetControlID="CompareValidator1">
                        </ajaxToolkit:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="ConfirmPasswordLabel" runat="server" CssClass="labelsRight" Text="Confirm Password:"></asp:Label>
                    </td>
                    <td class="auto-style9 validation">
                        <asp:TextBox ID="ConfirmPasswordTextBox" runat="server" Height="16px" Width="280px" TextMode="Password"></asp:TextBox>
                        *
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Confirmation Password Required" ControlToValidate="ConfirmPasswordTextBox" CssClass="validation"></asp:RequiredFieldValidator>
                        <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator1_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator3">
                        </ajaxToolkit:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="SecurityQuestionLabel" runat="server" CssClass="labelsRight" Text="Security Question:"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="SecurityQuestionDropDownList" runat="server" Width="285px">
                            <asp:ListItem>What is the name of the city you were born?</asp:ListItem>
                            <asp:ListItem>What is the name of your best friend?</asp:ListItem>
                            <asp:ListItem>What is your favorite movie?</asp:ListItem>
                            <asp:ListItem>What was your favorite food as a child?</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<br /> </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="SecurityAnswerLabel" runat="server" CssClass="labelsRight" Text="Answer:"></asp:Label>
                    </td>
                    <td class="auto-style9 validation">
                        <asp:TextBox ID="SecurityAnswerTextBox" runat="server" Height="16px" Width="280px"></asp:TextBox>
                        *
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Security Answer Required" ControlToValidate="SecurityAnswerTextBox" CssClass="validation"></asp:RequiredFieldValidator>
                        <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator1_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator4">
                        </ajaxToolkit:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        &nbsp;</td>
                    <td class="auto-style9">
                        <asp:Button ID="RegisterSubmitButton" runat="server" CssClass="whiteButton" Height="30px" Text="Submit" Width="301px" OnClick="RegisterSubmitButton_Click" />
                        <asp:HyperLink ID="ForgotPasswordLink0" runat="server">Forgot Password?</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="RegisterSubmitButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    </asp:Content>