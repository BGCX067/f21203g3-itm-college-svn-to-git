<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="FacilitiesDelete.aspx.cs" Inherits="ITM.Website.Manage.FacilitiesDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <h3>
            Delete Facilities</h3>
        <p>
            Are you sure to delete this facilities?</p>
        <table class="table table-noborder">
            <tr>
                <td>
                    FacilitiesID</td>
                <td>
                    <asp:Label ID="lblFacilityID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Faculities Name</td>
                <td>
                    <asp:Label ID="lblFacilityName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="ButtonDelete" runat="server" Text="Delete" 
                        onclick="ButtonDelete_Click" />
                    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                        onclick="ButtonCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
