<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="ITM.Website.Manage.Departments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li>Department Manage</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <asp:HyperLink ID="linkNewDepartement" CssClass="buttonLink blue" runat="server" 
            NavigateUrl="~/Manage/DepartementsInsert.aspx">New Departments</asp:HyperLink>
    </div>
    <asp:GridView ID="departmentList" runat="server" CssClass="table table-bordered" 
        AutoGenerateColumns="False" DataKeyNames="departmentID" AllowPaging="True" 
        onpageindexchanging="departmentList_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="departmentID" HeaderText="ID" />
            <asp:BoundField DataField="departmentName" HeaderText="Department Name" />
            <asp:BoundField DataField="departmentOrder" HeaderText="Order" />
            <asp:HyperLinkField DataNavigateUrlFields="departmentID" Text="Update" 
                DataNavigateUrlFormatString="DepartmentUpdate.aspx?ID={0}" />
            <asp:HyperLinkField Text="Delete" DataNavigateUrlFields="departmentID" 
                DataNavigateUrlFormatString="DepartmentDelete.aspx?ID={0}" />
        </Columns>
    </asp:GridView>
</asp:Content>
