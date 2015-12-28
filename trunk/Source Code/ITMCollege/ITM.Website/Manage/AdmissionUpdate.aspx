<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="AdmissionUpdate.aspx.cs" Inherits="ITM.Website.Manage.AdmissionUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li>
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/Manage/Admission.aspx">Admission Manage</asp:HyperLink></li>
    <li>Update Admission</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <h3>Update Admission</h3>
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
                <td>Admission for</td>
                <td><asp:Label ID="LabelAdmissionFor" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td colspan="2"><strong>Previous Examination</strong>
                    <hr/>
                </td>
            </tr>
            <tr>
                <td>University</td>
                <td><asp:Label ID="LabelUniversity" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td>Enroll Number</td>
                <td><asp:Label ID="LabelEnrol" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Center</td>
                <td><asp:Label ID="LabelCenter" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Stream</td>
                <td><asp:Label ID="LabelStream" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Field</td>
                <td><asp:Label ID="LabelField" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Mark secured</td>
                <td><asp:Label ID="LabelMark" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Out of</td>
                <td><asp:Label ID="LabelOutOf" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Class Obtained</td>
                <td><asp:Label ID="LabelClass" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Registration Status</td>
                <td><asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">Click “Accept Admission” button below to accept this Admission or Click Cancel button to return previous page</td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="ButtonAccept" runat="server" Text="Accept Admission" 
                        onclick="ButtonAccept_Click" />
                    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                        onclick="ButtonCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
