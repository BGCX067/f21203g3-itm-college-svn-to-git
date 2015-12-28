<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="FacultyInsert.aspx.cs" Inherits="ITM.Website.Manage.FacultyInsert" %>
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
    <li>
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/Manage/Faculty.aspx">Faculty Manage</asp:HyperLink></li>
    <li>New Faculty</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <h3>New Faculty</h3>
    </div>
    <table class="table table-noborder">
        <tr>
            <td>
                Faculty Name</td>
            <td>
                <asp:TextBox ID="txtFacultyName" runat="server" Width="173px"></asp:TextBox><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                FacultyImage</td>
            <td>
                <asp:FileUpload ID="FileUploadImage" runat="server" /><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                FacultyOrder</td>
            <td>
                <asp:TextBox ID="txtOrder" runat="server" Width="174px"></asp:TextBox><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                Department ID</td>
            <td>
                <asp:DropDownList ID="departmentList" runat="server" Width="174px">
                </asp:DropDownList><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                Description</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="500px" Height="180px"></asp:TextBox><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" 
                    onclick="ButtonSubmit_Click" />
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                    onclick="ButtonCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
