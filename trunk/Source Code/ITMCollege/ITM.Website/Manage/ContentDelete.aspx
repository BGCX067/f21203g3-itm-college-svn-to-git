<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="ContentDelete.aspx.cs" Inherits="ITM.Website.Manage.ContentDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            font-size: medium;
            color: #0066FF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <p>
        College Contents</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <p class="style2">Delete Content</p>
        <p>Are you sure to delete this content?</p>
        <table class="table table-noborder">
            <tr>
                <td>Content ID</td>
                <td><asp:Label ID="lblContentID" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Content Title</td>
                <td><asp:Label ID="lblContentTitle" runat="server"></asp:Label></td>
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
    <p>
    </p>
</asp:Content>
