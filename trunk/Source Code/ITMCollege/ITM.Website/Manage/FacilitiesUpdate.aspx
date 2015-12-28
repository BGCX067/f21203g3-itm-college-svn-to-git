<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="FacilitiesUpdate.aspx.cs" Inherits="ITM.Website.Manage.FacilitiesUpdate" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Templates/global/scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Templates/global/scripts/tinymce/tinymce.min.js"></script>
    <script type="text/javascript">
        tinymce.init({
            selector: "textarea",
            plugins: [
                "advlist autolink lists link image charmap print preview anchor",
                "searchreplace visualblocks code fullscreen",
                "insertdatetime media table contextmenu paste"
            ]
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader" >
    <h3>
        Update Facilities</h3>
</div>
<table class="table table-noborder">
    <tr>
        <td>
            FacilitiesID</td>
        <td>
            <asp:TextBox ID="txtFacilityID" runat="server" ReadOnly="True"></asp:TextBox><span class="required"></span>
        </td>
    </tr>
    <tr>
        <td>
            Facilities Name</td>
        <td>
            <asp:TextBox ID="txtFacilityName" runat="server"></asp:TextBox><span class="required"></span>
        </td>
    </tr>
    <tr>
        <td>
            Facilities Image</td>
        <td>
            <asp:Image ID="FacilityImage" Width="200px" runat="server" /><br/>
            <asp:FileUpload ID="FileUploadImage" runat="server" /><span class="required"></span>
        </td>
    </tr>
    <tr>
        <td>
            Facilities Description</td>
        <td>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox><span class="required"></span>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" 
                    onclick="ButtonSubmit_Click" />
            <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                    onclick="ButtonCancel_Click" />
        </td>
    </tr>
</table>
</asp:Content>
