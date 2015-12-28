<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="Accounts.aspx.cs" Inherits="ITM.Website.Manage.Accounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li>Account Manage</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <asp:HyperLink ID="linkNewAccount" CssClass="buttonLink blue" runat="server" 
            NavigateUrl="~/Manage/AccountsInsert.aspx">New Account</asp:HyperLink>
    </div>
    <asp:GridView ID="listAccounts" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="accountID" HeaderText="ID" />
            <asp:BoundField DataField="username" HeaderText="Username" />
            <asp:BoundField DataField="role" HeaderText="Role" />
            <asp:HyperLinkField DataNavigateUrlFields="accountID" 
                DataNavigateUrlFormatString="AccountsUpdate.aspx?ID={0}" Text="Update" />
            <asp:HyperLinkField Text="Delete" DataNavigateUrlFields="accountID" 
                DataNavigateUrlFormatString="AccountsDelete.aspx?ID={0}" />
        </Columns>
    </asp:GridView>
</asp:Content>
