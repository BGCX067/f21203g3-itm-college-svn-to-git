<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="FacultyInsert.aspx.cs" Inherits="ITM.Website.Manage.FacultyInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <p class="style1">
        New Faculty</p>
    <table class="style2">
        <tr>
            <td class="style6">
                Faculty Name</td>
            <td class="style7">
                <asp:TextBox ID="txtName" runat="server" Width="173px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                FacultyImage</td>
            <td class="style3">
                <asp:TextBox ID="txtImage" runat="server" Width="173px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style8">
                FacultyOrder</td>
            <td class="style9">
                <asp:TextBox ID="txtOrder" runat="server" Width="174px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style8">
                Department ID</td>
            <td class="style9">
                <asp:DropDownList ID="departmentList" runat="server" Width="174px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style10">
                Description</td>
            <td class="style11">
                <asp:TextBox ID="txtDescription" runat="server" Height="29px" TextMode="MultiLine" 
                    Width="177px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" 
                    onclick="ButtonSubmit_Click" />
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                    onclick="ButtonCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
