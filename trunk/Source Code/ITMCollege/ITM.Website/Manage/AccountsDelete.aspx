<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="AccountsDelete.aspx.cs" Inherits="ITM.Website.Manage.AccountsDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <h3>Delete Account</h3>
        <p>Are you sure to delete this account?</p>
        <table class="table table-noborder">
            <tr>
                <td>Account ID</td>
                <td><asp:Label ID="lblAccountId" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Username</td>
                <td><asp:Label ID="lblUsername" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Role</td>
                <td><asp:Label ID="lblRole" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="ButtonDelete" runat="server" Text="Delete" 
                        onclick="ButtonDelete_Click" />
                    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                        onclick="ButtonCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
