<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="FacultyDetail.aspx.cs" Inherits="ITM.Website.FacultyDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ImagePlaceHolder" runat="server">
    <img src="Templates/FrontEnd/images/subImage.png" alt="" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<div class="grid_8">
        <asp:ListView ID="FacultyView" runat="server" ItemPlaceholderID="FacultyView" >
            <LayoutTemplate>
                <div class="entry-part">
                     <asp:PlaceHolder ID="FacultyView" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="entry-title">
                    <h3><%# Eval("facultyName")%></h3>
                </div>
                <div class="entry-image faculty"><img src="Images/Faculty/<%# Eval("facultyImage")%>" alt=""/></div>
                <div class="entry-content">
                    <%# HttpUtility.HtmlDecode((string) Eval("facultyDescription"))%>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div class="grid_4">
        <div class="entry-title">
            <h3>Faculty</h3>
        </div>
        <asp:ListView ID="FacultyLink" runat="server" ItemPlaceholderID="FacultyLink" >
            <LayoutTemplate>
                <ul class="listItems">
                     <asp:PlaceHolder ID="FacultyLink" runat="server"></asp:PlaceHolder>
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li><a href="FacultyDetail.aspx?fid=<%# Eval("facultyID")%>" title="<%# Eval("facultyName")%>"><%# Eval("facultyName")%></a></li>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
