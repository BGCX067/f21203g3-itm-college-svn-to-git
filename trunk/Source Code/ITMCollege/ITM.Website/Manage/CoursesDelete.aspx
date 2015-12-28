<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="CoursesDelete.aspx.cs" Inherits="ITM.Website.Manage.CoursesDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <h3>
            Delete Courses</h3>
        <p>
            Are you sure to delete this course?</p>
        <table class="table table-noborder">
            <tr>
                <td>
                    CourseID</td>
                <td>
                    <asp:Label ID="lblCourseID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Course Name</td>
                <td>
                    <asp:Label ID="lblCourseName" runat="server"></asp:Label>
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
</asp:Content>
