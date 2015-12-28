<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="Assignments.aspx.cs" Inherits="ITM.Website.Manage.Assignments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li>Assignments</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <asp:HyperLink ID="linkNewAssignment" CssClass="buttonLink blue" runat="server"
        NavigateUrl="~/Manage/AssignmentInsert.aspx">New Assignment</asp:HyperLink>
    </div>
        <asp:GridView ID="listAssignment" runat="server" CssClass="table table-bordered" 
        AutoGenerateColumns="False" DataKeyNames="assignmentID" AllowPaging="True" 
        onpageindexchanging="listAssignment_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="assignmentID" HeaderText="ID" />
                <asp:BoundField DataField="assignmentName" HeaderText="Name" />
                <asp:BoundField DataField="courseID" HeaderText="Course" />
                <asp:HyperLinkField DataNavigateUrlFields="assignmentID" Text="Update" 
                    DataNavigateUrlFormatString="AssignmentUpdate.aspx?assignmentID={0}" />
                <asp:HyperLinkField DataNavigateUrlFields="assignmentID" 
                    DataNavigateUrlFormatString="AssignmentDelete.aspx?assignmentID={0}" 
                    Text="Delete" />
            </Columns>
        </asp:GridView>
</asp:Content>
