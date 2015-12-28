<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="ITM.Website.Departments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ImagePlaceHolder" runat="server">
    <img src="Templates/FrontEnd/images/departments.png" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="grid_8">
        <asp:ListView ID="DepartmentList" runat="server" ItemPlaceholderID="DepartmentList" >
            <LayoutTemplate>
                <div class="entryListView">
                     <asp:PlaceHolder ID="DepartmentList" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="entry-part">
                    <div class="entry-title"><h3><a href="DepartmentDetail.aspx?depid=<%# Eval("departmentID")%>" title="<%# Eval("departmentName")%>"><%# Eval("departmentName")%></a></h3></div>
                    <div class="entry-content">
                        <%# Truncate(HttpUtility.HtmlDecode((string)Eval("departmentDescription")))%>
                        <a class="readmore" href="DepartmentDetail.aspx?depid=<%# Eval("departmentID")%>" title="Read more <%# Eval("departmentName")%>">read more</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <asp:DataPager ID="DataPager" runat="server" PagedControlID="DepartmentList"
            PageSize="5" onprerender="DataPagerDepartment_PreRender" 
            ClientIDMode="Static">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" />
            </Fields>
        </asp:DataPager>
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
