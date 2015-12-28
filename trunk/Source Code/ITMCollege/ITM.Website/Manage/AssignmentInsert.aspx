<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="AssignmentInsert.aspx.cs" Inherits="ITM.Website.Manage.AssignmentInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            color: #0066FF;
            font-size: medium;
        }
        .style2
        {
            width: 100%;
        }
        .style4
        {
            width: 190px;
        }
        .style6
        {
            width: 190px;
            height: 30px;
        }
        .style7
        {
            height: 30px;
        }
        .style8
        {
            width: 190px;
            height: 34px;
        }
        .style9
        {
            height: 34px;
        }
        .style10
        {
            height: 26px;
            width: 190px;
        }
        .style11
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li><asp:HyperLink ID="HyperLink1" NavigateUrl="Assignments.aspx" runat="server">Assignment manage</asp:HyperLink></li>
    <li>Create Assignment</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <h3>New Assignment</h3>
    </div>
    <table class="table table-noborder">
        <tr>
            <td>Assignment Name</td>
            <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Course ID</td>
            <td><asp:DropDownList ID="listCourseID" runat="server"></asp:DropDownList>&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td>Assignment Description</td>
            <td><asp:TextBox ID="txtDescription" runat="server" Height="195px" TextMode="MultiLine" 
                    Width="367px"></asp:TextBox>
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
