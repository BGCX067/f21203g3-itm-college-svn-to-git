<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="FacultyDelete.aspx.cs" Inherits="ITM.Website.Manage.FacultyDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
 <li>
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/Manage/Faculty.aspx">Faculty Manage</asp:HyperLink></li>
    <li>Delete Faculty</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
         <div class="pageHeader">
        <h3>Delete Faculty</h3>
    </div>
        <p>
            Are you sure to delete this Faculty?</p>
        <table class="table table-noborder">
            <tr>
                <td>
                    FacultyID</td>
                <td>
                    <asp:Label ID="lblFacultyID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    FacultyName</td>
                <td>
                    <asp:Label ID="lblFacultyName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="ButtonDelete" runat="server" Text="Delete" 
                        onclick="ButtonDelete_Click" />
                    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                        onclick="ButtonCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    <p>
    </p>
</asp:Content>
