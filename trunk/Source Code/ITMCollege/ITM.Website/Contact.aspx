<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ITM.Website.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ImagePlaceHolder" runat="server">
 <img src="Templates/FrontEnd/images/subImage.png" alt="" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<asp:ListView ID="ContactList" runat="server" ItemPlaceholderID="ContactList" >
            <LayoutTemplate>
                <div id="contact">
                     <asp:PlaceHolder ID="ContactList" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="grid_4 entry-part">
                    <div class="entry-title">
                        <h3><%# Eval("brancheName")%></h3>
                        <p>Address: <span><%# Eval("brancheAddress")%></span></p>
                        <div class="clear"></div>
                        <p>Phone: <span><%# Eval("branchePhone")%></span></p>
                        <div class="clear"></div>
                        <p>Fax: <span><%# Eval("brancheFax")%></span></p>
                        <div class="clear"></div>
                        <p>Email: <span><%# Eval("brancheEmail")%></span></p>
                        <div class="clear"></div>
                        <p><%# Eval("Description")%></p> 
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <div class="grid_12">
            <asp:DataPager ID="DataPager" runat="server" PagedControlID="ContactList"
                PageSize="3" ClientIDMode="Static" onprerender="DataPager_PreRender">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" />
                </Fields>
            </asp:DataPager>
        </div>
</asp:Content>
