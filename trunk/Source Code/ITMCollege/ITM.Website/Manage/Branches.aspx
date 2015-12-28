<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="Branches.aspx.cs" Inherits="ITM.Website.Manage.Branches" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li>Branches</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <asp:HyperLink ID="linkNewBranch" CssClass="buttonLink blue" runat="server"
        NavigateUrl="~/Manage/BranchInsert.aspx">New Branch</asp:HyperLink>
    </div>
    <asp:GridView ID="listBranch" runat="server" CssClass="table table-bordered" 
        AutoGenerateColumns="False" DataKeyNames="brancheID" AllowPaging="True" 
        onpageindexchanging="listBranch_PageIndexChanging" PageSize="5">
            <Columns>
                <asp:BoundField DataField="brancheID" HeaderText="ID" />
                <asp:BoundField DataField="brancheName" HeaderText="Branch" />
                <asp:BoundField DataField="brancheAddress" HeaderText="Address" />
                <asp:HyperLinkField DataNavigateUrlFields="brancheID" Text="Update" 
                    DataNavigateUrlFormatString="BranchUpdate.aspx?branchID={0}" />
                <asp:HyperLinkField DataNavigateUrlFields="brancheID" 
                    DataNavigateUrlFormatString="BranchDelete.aspx?branchID={0}" 
                    Text="Delete" />
            </Columns>
        </asp:GridView>
</asp:Content>
