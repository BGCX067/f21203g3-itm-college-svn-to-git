<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="FeedBacks.aspx.cs" Inherits="ITM.Website.Manage.FeedBacks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li>Feedback</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">FeedBack</div>
    <asp:GridView ID="FeedbackList" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CssClass="table table-bordered" 
        onpageindexchanging="FeedbackList_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="feedbackID" HeaderText="ID" />
            <asp:BoundField DataField="feedbackContent" HeaderText="Feedback" />
            <asp:BoundField DataField="courseName" HeaderText="Course Name" />
            <asp:HyperLinkField Text="Delete" DataNavigateUrlFields="feedbackID" 
                DataNavigateUrlFormatString="FeedbackDelete.aspx?fid={0}" />
        </Columns>
    </asp:GridView>
</asp:Content>
