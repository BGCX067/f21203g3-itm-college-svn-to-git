<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="AccountsUpdate.aspx.cs" Inherits="ITM.Website.Manage.AccountsUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li><asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/Manage/Accounts.aspx">Account manage</asp:HyperLink></li>
    <li>Update Account</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <h3>Update Account</h3>
    </div>
    <table class="table table-noborder">
        <tr>
            <td>Account ID</td>
            <td><asp:TextBox ID="txtAccountID" runat="server" Enabled="False"></asp:TextBox></td>    
        </tr>
        <tr>
            <td>Username</td>
            <td><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>New Password</td>
            <td><asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Re-type new Password</td>
            <td><asp:TextBox ID="txtNewPassword2" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Role</td>
            <td>
                <asp:RadioButtonList ID="roleRadio" runat="server" EnableTheming="False" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="admin">Admin</asp:ListItem>
                    <asp:ListItem Value="staff">Staff</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" 
                    onclick="ButtonSubmit_Click" />
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                    onclick="ButtonCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>