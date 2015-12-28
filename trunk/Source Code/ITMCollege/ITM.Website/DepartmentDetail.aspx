<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="DepartmentDetail.aspx.cs" Inherits="ITM.Website.DepartmentDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ImagePlaceHolder" runat="server">
    <img src="Templates/FrontEnd/images/departments.png" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="grid_8">
        <asp:ListView ID="DepartmentView" runat="server" ItemPlaceholderID="DepartmentView" >
            <LayoutTemplate>
                <div class="entry-part">
                     <asp:PlaceHolder ID="DepartmentView" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="entry-title">
                    <h3><%# Eval("departmentName")%></h3>
                </div>
                <div class="entry-image department"><img src="Images/Departments/<%# Eval("departmentImage")%>" alt=""/></div>
                <div class="entry-content">
                    <%# HttpUtility.HtmlDecode((string) Eval("departmentDescription"))%>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div class="grid_4">
        <div class="entry-title">
            <h3>Departments</h3>
        </div>
        <asp:ListView ID="DepartmentLink" runat="server" ItemPlaceholderID="DepartmentLink" >
            <LayoutTemplate>
                <ul class="listItems">
                     <asp:PlaceHolder ID="DepartmentLink" runat="server"></asp:PlaceHolder>
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li><a href="DepartmentDetail.aspx?depid=<%# Eval("departmentID")%>" title="<%# Eval("departmentName")%>"><%# Eval("departmentName")%></a></li>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>