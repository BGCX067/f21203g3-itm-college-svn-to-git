<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="RegistrationCompleted.aspx.cs" Inherits="ITM.Website.RegistrationCompleted" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ImagePlaceHolder" runat="server">
    <img src="Templates/FrontEnd/images/subImage.png" alt="">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="grid_12">
        <div class="pageHeader">
            <h3>Online Admission Completed</h3>
        </div>
    </div>
    <div class="grid_1">&nbsp;</div>
    <div class="grid_6">
        <p>Congratulation!</p>
        <p>Your Admission Registration had been completed.</p>
        <p>This is your registration information</p>
        <p>You can use Enrolnumber and Password below to login to Student Area!</p>
        <table class="table table-noborder">
            <tr>
                <td>Enroll Number</td>
                <td><asp:Label ID="EnrollNumber" runat="server" Text="" /></td>
            </tr>
            <tr>
                <td>Password</td>
                <td><asp:Label ID="LabelPassword" runat="server" Text="" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
