<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="BranchUpdate.aspx.cs" Inherits="ITM.Website.Manage.BranchUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            font-size: large;
            color: #0066FF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <p>
        Branches</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <p class="style1">
        Branch Update</p>
    <table class="table table-noborder">
        <tr>
            <td>Branch ID</td>
            <td><asp:TextBox ID="txtID" runat="server" Width="174px" ReadOnly="True"></asp:TextBox><span class="required"></span></td>
        </tr>
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
            <td><asp:TextBox ID="txtPhone" runat="server" Width="174px"></asp:TextBox><span class="required"></span></td>
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
            <td><asp:TextBox ID="txtDescription" runat="server" Height="52px" TextMode="MultiLine" 
                    Width="189px"></asp:TextBox><span class="required"></span>
            </td>
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
