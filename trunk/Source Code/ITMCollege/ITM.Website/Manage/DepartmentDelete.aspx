<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="DepartmentDelete.aspx.cs" Inherits="ITM.Website.Manage.DepartmentDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
<li><asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/Manage/Departments.aspx">Department Manage</asp:HyperLink>
</li>
<li>Delete Departments</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <h3>Delete Departments</h3>
    </div>
        <p>Are you sure to delete this department?</p>
        <table class="table table-noborder">
            <tr>
                <td>DepartmentID</td>
                <td><asp:Label ID="lblDepartmentID" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Department Name</td>
                <td><asp:Label ID="lblDepartmentName" runat="server"></asp:Label></td>
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
</asp:Content>
