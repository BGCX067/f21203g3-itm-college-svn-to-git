<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="AdmissionDelete.aspx.cs" Inherits="ITM.Website.Manage.AdmissionDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li>
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/Manage/Admission.aspx">Admission Manage</asp:HyperLink></li>
    <li>Delete Admission</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <h3>Delete Admission</h3>
        <table class="table table-noborder">
            <tr>
                <td>Admission ID</td>
                <td><asp:Label ID="LabelAdmissionID" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Name</td>
                <td><asp:Label ID="LabelName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Father Name</td>
                <td><asp:Label ID="LabelFatherName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Mother Name</td>
                <td><asp:Label ID="LabelMotherName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Birthday</td>
                <td><asp:Label ID="LabelBirthday" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Gender</td>
                <td><asp:Label ID="LabelGender" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Residental Address</td>
                <td><asp:Label ID="LabelResAddress" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Pernament Address</td>
                <td><asp:Label ID="LabelPerAddress" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Sport detail</td>
                <td><asp:Label ID="LabelSport" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2"><hr/></td>
            </tr>
            <tr>
                <td colspan="2">Click “Delete Admission” button below to Delete this Admission or Click Cancel button to return previous page</td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="ButtonDelete" runat="server" Text="Delete Admission" 
                        onclick="ButtonDelete_Click" />
                    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                        onclick="ButtonCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
