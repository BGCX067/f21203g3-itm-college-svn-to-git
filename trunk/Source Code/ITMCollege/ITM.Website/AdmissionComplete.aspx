<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="AdmissionComplete.aspx.cs" Inherits="ITM.Website.AdmissionComplete" %>
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
        <p>Your Admission had been completed.</p>
        <p>Please wait while we are processing your registration</p>
        <p>You can check your admission by click button "Check Admission Status" above and use this Unique ID below.</p>
        <p>This is your registration key</p>
        <table class="table table-noborder">
            <tr>
                <td>Unique ID</td>
                <td><asp:Label ID="UniqueID" runat="server" Text="" /></td>
            </tr>
        </table>
    </div>

</asp:Content>
