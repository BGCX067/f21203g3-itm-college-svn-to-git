<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ITM.Website.Manage.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li>Change Password</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <h3>Change Password</h3>
        <p><strong>Note</strong>: If you change your password you will have to log back in</p>
        <table class="table table-noborder">
            <tr>
                <td>Username</td>
                <td><asp:Label ID="LabelUsername" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">You must submit the current password to update this page</td>
            </tr>
            <tr>
                <td>Current Password</td>
                <td><asp:TextBox ID="txtCurrPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td>New Password</td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Re-type New Password</td>
                <td><asp:TextBox ID="txtPassword2" runat="server" TextMode="Password"></asp:TextBox></td>
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
    </div>
</asp:Content>
