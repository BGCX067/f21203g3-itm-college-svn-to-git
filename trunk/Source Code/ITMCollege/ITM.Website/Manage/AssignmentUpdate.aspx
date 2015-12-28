<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="AssignmentUpdate.aspx.cs" Inherits="ITM.Website.Manage.AssignmentUpdate" %>
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
        Assignments</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <p class="style1">
        &nbsp;Update Assignment</p>
    <table class="table table-noborder">
        <tr>
            <td>Assignment ID</td>
            <td><asp:TextBox ID="txtID" runat="server" Width="174px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Assignment Name</td>
            <td><asp:TextBox ID="txtName" runat="server" Width="174px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Course ID</td>
            <td><asp:DropDownList ID="listCourseID" runat="server"></asp:DropDownList>&nbsp;</td>
        </tr>
        <tr>
            <td>Assignment Description</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Height="52px" TextMode="MultiLine" 
                    Width="189px"></asp:TextBox>
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
