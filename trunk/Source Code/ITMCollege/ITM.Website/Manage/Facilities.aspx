<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="Facilities.aspx.cs" Inherits="ITM.Website.Manage.Facilities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
<div class="pageHeader">
    <asp:HyperLink ID="linkNewFacilities" CssClass="buttonLink blue" runat="server" 
            NavigateUrl="~/Manage/FacilitiesInsert.aspx">New Facilities</asp:HyperLink>
</div>
    <asp:GridView ID="listFacilities" runat="server" CssClass="table table-bordered" 
        AutoGenerateColumns="False" AllowPaging="True" 
        onpageindexchanging="listFacilities_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="facilitieID" HeaderText="ID" />
            <asp:BoundField DataField="facilitieName" HeaderText="Facilitie Name" />
            <asp:HyperLinkField DataNavigateUrlFields="facilitieID" 
                DataNavigateUrlFormatString="FacilitiesUpdate.aspx?ID={0}" Text="Update" />
            <asp:HyperLinkField Text="Delete" DataNavigateUrlFields="facilitieID" 
                DataNavigateUrlFormatString="FacilitiesDelete.aspx?ID={0}" />
        </Columns>
    </asp:GridView>
</asp:Content>
