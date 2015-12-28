<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="ContentsDetail.aspx.cs" Inherits="ITM.Website.ContentsDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ImagePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
 <div class="grid_8">
        <asp:ListView ID="ContentView" runat="server" ItemPlaceholderID="ContentView" >
            <LayoutTemplate>
                <div class="entry-part">
                     <asp:PlaceHolder ID="ContentView" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="entry-title">
                    <h3><%# Eval("contentTitle")%></h3>
                </div>
                <div class="entry-image content"><img src="Images/News/<%# Eval("contentImage")%>" alt=""/></div>
                <div class="entry-content">
                    <%# HttpUtility.HtmlDecode((string) Eval("contentText"))%>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
