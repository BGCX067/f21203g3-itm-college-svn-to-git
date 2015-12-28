<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="FeedbackDelete.aspx.cs" Inherits="ITM.Website.Manage.FeedbackDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li><asp:HyperLink ID="HyperLink1" NavigateUrl="FeedBacks.aspx" runat="server">Feedback</asp:HyperLink></li>
    <li>Delete Feedback</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader"><h3>Delete Feedback</h3></div>
    <p>Please check this information below. Click Delete button to delete Feedback</p>
    <table class="table table-noborder">
        <tr>
            <td>Feedback ID</td>
            <td><asp:TextBox ID="txtFeedbackID" runat="server" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Course</td>
            <td>
                <asp:TextBox ID="txtCourse" runat="server" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Feedback</td>
            <td>
                <asp:TextBox ID="txtFeedback" runat="server" ReadOnly="True" TextMode="MultiLine" Width="200px" Height="60px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="ButtonDelete" runat="server" Text="Delete" 
                    onclick="ButtonDelete_Click" />
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                    onclick="ButtonCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
