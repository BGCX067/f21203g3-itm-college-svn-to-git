<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="ITM.Website.Manage.Courses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <asp:HyperLink ID="linkNewCourses" CssClass="buttonLink blue" runat="server" 
            NavigateUrl="~/Manage/CoursesInsert.aspx">New Course</asp:HyperLink>
    </div>
        <asp:GridView ID="listCourses" runat="server" CssClass="table table-bordered" 
        AutoGenerateColumns="False" 
        onpageindexchanging="listCourses_PageIndexChanging" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="courseID" HeaderText="ID" />
                <asp:BoundField DataField="courseName" HeaderText="Course Name" />
                <asp:BoundField DataField="courseDescription" HeaderText="Teacher" />
                <asp:BoundField HeaderText="Start Date" DataField="startDate" />
                <asp:BoundField HeaderText="End Date" DataField="endDate" />
                <asp:HyperLinkField DataNavigateUrlFields="courseID" 
                DataNavigateUrlFormatString="CoursesUpdate.aspx?ID={0}" Text="Update" />
                <asp:HyperLinkField Text="Delete" DataNavigateUrlFields="courseID" 
                DataNavigateUrlFormatString="CoursesDelete.aspx?ID={0}" />
            </Columns>
        </asp:GridView>
</asp:Content>
