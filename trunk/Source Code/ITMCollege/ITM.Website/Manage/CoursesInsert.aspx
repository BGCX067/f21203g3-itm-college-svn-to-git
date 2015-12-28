<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="CoursesInsert.aspx.cs" Inherits="ITM.Website.Manage.CoursesInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li><asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/Manage/Courses.aspx">Course Manage</asp:HyperLink></li>
    <li>New Course</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <h3>New Course</h3>
    </div>
    <table class="table table-noborder">
        <tr>
            <td>Course Name</td>
            <td>
                <asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                Department</td>
            <td>
                <asp:DropDownList ID="departmentList" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="departmentList_SelectedIndexChanged"></asp:DropDownList><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                Faculty</td>
            <td>
                <asp:DropDownList ID="facultyList" runat="server" Visible="False"></asp:DropDownList><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                Start Date</td>
            <td>
                <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                End Date</td>
            <td>
                <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                Exam Date</td>
            <td>
                <asp:TextBox ID="txtExamDate" runat="server"></asp:TextBox><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                Description</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
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
