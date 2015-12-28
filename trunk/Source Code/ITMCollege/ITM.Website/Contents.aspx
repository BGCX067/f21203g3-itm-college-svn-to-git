<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Contents.aspx.cs" Inherits="ITM.Website.Contents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ImagePlaceHolder" runat="server">
     <img src="Templates/FrontEnd/images/subImage.png" alt="" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<div class="grid_8">
        <asp:ListView ID="ContentList" runat="server" ItemPlaceholderID="ContentList" >
            <LayoutTemplate>
                <div class="entryListView">
                     <asp:PlaceHolder ID="ContentList" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="entry-part">
                    <div class="entry-title"><h3><a href="ContentsDetail.aspx?cid=<%# Eval("contentID")%>" title="<%# Eval("contentTitle")%>"><%# Eval("contentTitle")%></a></h3></div>
                    <div class="entry-content">
                        <%# Truncate(HttpUtility.HtmlDecode((string) Eval("contentText")))%>
                        <a class="readmore" href="ContentsDetail.aspx?cid=<%# Eval("contentID")%>" title="Read more <%# Eval("contentTitle")%>">read more</a>
                    </div>
                </div>
            </ItemTemplate>
            <EmptyDataTemplate>
                No Data
            </EmptyDataTemplate>
        </asp:ListView>
        <asp:DataPager ID="DataPager" runat="server" PagedControlID="ContentList"
            PageSize="5" onprerender="DataPagerContentNews_PreRender" 
            ClientIDMode="Static">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" />
            </Fields>
        </asp:DataPager>
    </div>
</asp:Content>
