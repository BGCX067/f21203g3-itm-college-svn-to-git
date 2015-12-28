<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="BranchDelete.aspx.cs" Inherits="ITM.Website.Manage.BranchDelete" %>
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
        Branches</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <p class="style2">Delete Branch</p>
        <p>Are you sure to delete this branch?</p>
        <table class="table table-noborder">
            <tr>
                <td>Branch ID</td>
                <td><asp:Label ID="lblBranchID" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Branch Name</td>
                <td><asp:Label ID="lblBranchName" runat="server"></asp:Label></td>
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
