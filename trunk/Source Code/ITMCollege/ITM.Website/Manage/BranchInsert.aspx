<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="BranchInsert.aspx.cs" Inherits="ITM.Website.Manage.BranchInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            color: #0066FF;
            font-size: medium;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <p>
        Branches</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <p class="style1">
        New Branch</p>
    <table class="table table-noborder">
        <tr>
            <td>Branch Name</td>
            <td><asp:TextBox ID="txtName" runat="server" Width="173px"></asp:TextBox><span class="required"></span></td>
        </tr>
        <tr>
            <td>Branch Address</td>
            <td><asp:TextBox ID="txtAddress" runat="server" Width="173px"></asp:TextBox><span class="required"></span></td>
        </tr>
        <tr>
            <td>Branch Phone</td>
            <td><asp:TextBox ID="txtPhone" runat="server" Width="173px"></asp:TextBox><span class="required"></span></td>
        </tr>
        <tr>
            <td>Branch Fax</td>
            <td><asp:TextBox ID="txtFax" runat="server" Width="173px"></asp:TextBox><span class="required"></span></td>
        </tr>
        <tr>
            <td>Branch Email</td>
            <td><asp:TextBox ID="txtEmail" runat="server" Width="173px"></asp:TextBox><span class="required"></span></td>
        </tr>
        <tr>
            <td>Branch Description</td>
            <td><asp:TextBox ID="txtDescription" runat="server" Height="195px" 
                    TextMode="MultiLine" Width="367px"></asp:TextBox><span class="required"></span></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" 
                    onclick="ButtonSubmit_Click" />
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                    onclick="ButtonCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
