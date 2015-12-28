<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="FacilitiesDetail.aspx.cs" Inherits="ITM.Website.Templates.FacilitiesDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ImagePlaceHolder" runat="server">
<img src="Templates/FrontEnd/images/subImage.png" alt="" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<div class="grid_8" id="FacilitiView">
        <asp:ListView ID="FacilitiView" runat="server" ItemPlaceholderID="FacilitiView" >
            <LayoutTemplate>
                <div class="entry-part">
                     <asp:PlaceHolder ID="FacilitiView" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="pageHeader">
                    <h3><%# Eval("facilitieName")%></h3>
                </div>
                <div class="entry-image facilities"><img src="Images/Facilities/<%# Eval("facilitieImage")%>" alt=""/></div>
                <div class="entry-content">
                    <%# HttpUtility.HtmlDecode((string) Eval("facilitieDescription"))%>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div class="grid_4">
        <div class="entry-title">
            <h3>Faculities</h3>
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
