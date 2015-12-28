<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Facilities.aspx.cs" Inherits="ITM.Website.Facilities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ImagePlaceHolder" runat="server">
    <img src="Templates/FrontEnd/images/subImage.png" alt="" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="grid_8">
        <asp:ListView ID="FacilitiesList" runat="server" ItemPlaceholderID="FacilitiesList" >
            <LayoutTemplate>
                <div class="entryListView">
                     <asp:PlaceHolder ID="FacilitiesList" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="entry-part">
                    <div class="entry-title"><h3><a href="FacilitiesDetail.aspx?facid=<%# Eval("facilitieID")%>" title="<%# Eval("facilitieName")%>"><%# Eval("facilitieName")%></a></h3></div>
                    <div class="entry-content">
                        <%# Truncate(HttpUtility.HtmlDecode((string) Eval("facilitieDescription")))%>
                        <a class="readmore" href="FacilitiesDetail.aspx?facid=<%# Eval("facilitieID")%>" title="Read more <%# Eval("facilitieName")%>">read more</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <asp:DataPager ID="DataPager" runat="server" PagedControlID="FacilitiesList"
            PageSize="5" onprerender="DataPagerFacilities_PreRender" 
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
            <h3>Facilities</h3>
        </div>
        <asp:ListView ID="FacilitiesLink" runat="server" ItemPlaceholderID="FacilitiesLink" >
            <LayoutTemplate>
                <ul class="listItems">
                     <asp:PlaceHolder ID="FacilitiesLink" runat="server"></asp:PlaceHolder>
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li><a href="FacilitiesDetail.aspx?facid=<%# Eval("facilitieID")%>" title="<%# Eval("facilitieName")%>"><%# Eval("facilitieName")%></a></li>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
