<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="Contents.aspx.cs" Inherits="ITM.Website.Manage.Contents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li>College Contents</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <asp:HyperLink ID="linkNewContent" CssClass="buttonLink blue" runat="server"
        NavigateUrl="~/Manage/ContentInsert.aspx">New Content</asp:HyperLink>
        <br />
        <br />
        <asp:GridView ID="listContent" runat="server" CssClass="table table-bordered" 
        AutoGenerateColumns="False" DataKeyNames="contentID" AllowPaging="True" 
            onpageindexchanging="listContent_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="contentID" HeaderText="ID" />
                <asp:BoundField DataField="contentTitle" HeaderText="Title" />
                <asp:BoundField DataField="contentCategory" HeaderText="Category" />
                <asp:HyperLinkField DataNavigateUrlFields="contentID" Text="Update" 
                    DataNavigateUrlFormatString="ContentUpdate.aspx?contentID={0}" />
                <asp:HyperLinkField DataNavigateUrlFields="contentID" 
                    DataNavigateUrlFormatString="ContentDelete.aspx?contentID={0}" Text="Delete" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
