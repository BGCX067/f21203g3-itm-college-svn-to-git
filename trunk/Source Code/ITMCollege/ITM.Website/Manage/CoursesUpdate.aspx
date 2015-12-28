<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="CoursesUpdate.aspx.cs" Inherits="ITM.Website.Manage.CoursesUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <h3>
            Update Course</h3>
    </div>
    <table class="table table-noborder">
        <tr>
            <td>
                CourseID</td>
            <td class="style1">
                <asp:TextBox ID="txtCourseID" runat="server" ReadOnly="True"></asp:TextBox><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                Course Name</td>
            <td class="style1">
                <asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                Department</td>
            <td class="style1">
                <asp:DropDownList ID="departmentList" runat="server">
                </asp:DropDownList><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                Faculty</td>
            <td class="style1">
                <asp:DropDownList ID="txtFaculty" runat="server">
                </asp:DropDownList><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                Start Date</td>
            <td class="style1">
                <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                End Date</td>
            <td class="style1">
                <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                Exam Date</td>
            <td class="style1">
                <asp:TextBox ID="txtExamDate" runat="server"></asp:TextBox><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                Description</td>
            <td class="style1">
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style1">
                <asp:Button ID="ButtonSubmit" runat="server" Text="Button" 
                    onclick="ButtonSubmit_Click" />
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                    onclick="ButtonCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
