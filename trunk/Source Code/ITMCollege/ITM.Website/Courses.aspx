<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="ITM.Website.Courses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ImagePlaceHolder" runat="server">
    <img src="Templates/FrontEnd/images/subImage.png" alt="" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<div class="grid_12">
    <asp:DropDownList ID="listDepartment" runat="server" Width="156px">
        <asp:ListItem>Department</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="txtName" runat="server" Width="150px"></asp:TextBox>
    <asp:Button ID="ButtonSearch" runat="server" Text="Shearch" onclick="ButtonSearch_Click" /><br/>
    <asp:GridView ID="CoursesList" runat="server" CssClass="table table-bordered" 
        AutoGenerateColumns="False" 
        onpageindexchanging="CoursesList_PageIndexChanging" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="courseID" HeaderText="ID" />
                <asp:BoundField DataField="courseName" HeaderText="Course Name" />
                <asp:BoundField DataField="facultyName" HeaderText="Teacher" />
                <asp:BoundField HeaderText="Start Date" DataField="startDate" />
                <asp:BoundField HeaderText="End Date" DataField="endDate" />
            </Columns>
        </asp:GridView>
</div>
</asp:Content>
