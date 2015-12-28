<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="ITM.Website.Manage.Logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li>Logout</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <h3>Logout</h3>
    </div>
        <p>Do you want to logout?</p>
        <asp:Button ID="ButtonLogout" runat="server" Text="Logout" 
            onclick="ButtonLogout_Click" />
        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
            onclick="ButtonCancel_Click" />
</asp:Content>
