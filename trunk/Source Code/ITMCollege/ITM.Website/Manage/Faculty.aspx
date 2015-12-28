<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="Faculty.aspx.cs" Inherits="ITM.Website.Manage.Faculty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li>Faculty Manage</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <asp:HyperLink ID="linkNewFaculty" CssClass="buttonLink blue" runat="server" 
            NavigateUrl="~/Manage/FacultyInsert.aspx">New Faculty</asp:HyperLink>
    </div>
    <asp:GridView ID="listFaculty" runat="server" CssClass="table table-bordered" 
        AutoGenerateColumns="False" DataKeyNames="facultyID" AllowPaging="True" 
        onpageindexchanging="listFaculty_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="facultyID" HeaderText="ID" />
            <asp:BoundField DataField="facultyName" HeaderText="Faculty Name" />
            <asp:BoundField DataField="departmentName" HeaderText="Department" />
            <asp:HyperLinkField DataNavigateUrlFields="facultyID" Text="Update" 
                DataNavigateUrlFormatString="FacultyUpdate.aspx?ID={0}" />
            <asp:HyperLinkField Text="Delete" DataNavigateUrlFields="facultyID" 
                DataNavigateUrlFormatString="FacultyDelete.aspx?ID={0}" />
        </Columns>
    </asp:GridView>
</asp:Content>
