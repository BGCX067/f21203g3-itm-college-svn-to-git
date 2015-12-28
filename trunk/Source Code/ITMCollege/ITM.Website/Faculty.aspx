<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Faculty.aspx.cs" Inherits="ITM.Website.Faculty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ImagePlaceHolder" runat="server">
    <img src="Templates/FrontEnd/images/subImage.png" alt="" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <asp:ListView ID="FacultyList" runat="server" ItemPlaceholderID="FacultyList" >
            <LayoutTemplate>
                <div id="faculty">
                     <asp:PlaceHolder ID="FacultyList" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="grid_3 entry-part">
                    <div class="entry-title">
                        <h3><a href="FacultyDetail.aspx?fid=<%# Eval("facultyID")%>" title="<%# Eval("facultyName")%>"><%# Eval("facultyName")%></a></h3>
                    </div>
                    <div class="entry-thumb">
                        <img src="Images/Faculty/<%# Eval("facultyImage")%>" width="220" alt=""/>
                    </div>
                    <div class="entry-content">
                        <p><a href="DepartmentDetail.aspx?depid=<%# Eval("departmentID")%>"><%# Eval("departmentName")%> Instructor</a></p>
                        <%# Truncate(HttpUtility.HtmlDecode((string) Eval("facultyDescription")))%>
                        <a class="readmore" href="FacultyDetail.aspx?fid=<%# Eval("facultyID")%>" title="Read more <%# Eval("facultyName")%>">read more</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <div class="grid_12">
            <asp:DataPager ID="DataPager" runat="server" PagedControlID="FacultyList"
                PageSize="4" ClientIDMode="Static" onprerender="DataPager_PreRender">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" />
                </Fields>
            </asp:DataPager>
        </div>
</asp:Content>
