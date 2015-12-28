<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="AdmissionStatus.aspx.cs" Inherits="ITM.Website.AdmissionStatus" %>
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
        <p>Enter your Unique ID to check your registration status</p>
        <p></p>
        <table class="table  table-noborder">
            <tr>
                <td>Unique ID</td>
                <td><asp:TextBox ID="txtAdmissionId" runat="server"></asp:TextBox></td>
            </tr>
        <asp:Panel ID="PanelStatus" Visible="False" runat="server">
            <tr>
                <td>Admission Status</td>
                <td>
                    <asp:Label ID="LabelStatus" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="PanelButton" Visible="True" runat="server">
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" onclick="ButtonSubmit_Click" />
                    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" onclick="ButtonCancel_Click" />
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="PanelSubmission" Visible="False" runat="server">
            <tr>
                <td></td>
                <td>
                    <p>Congratulation!</p>
                    <p>Your Admission had been Accepted.</p>
                    <p>Click "Proceed Online Submission" button below to complete your submission</p>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="ButtonProceed" runat="server" Text="Proceed Online Submission" onClick="ButtonProceed_Click" />
                </td>
            </tr>
        </asp:Panel>
        </table>
    </div>
</asp:Content>
