<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="DepartmentUpdate.aspx.cs" Inherits="ITM.Website.Manage.DepartmentUpdate" ValidateRequest="false" %>
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
 <li><asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/Manage/Departments.aspx">Department Manage</asp:HyperLink>
 </li>
 <li>Update Departments </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader" >
        <h3>Update Departments</h3>
    </div>
    <table class="table table-noborder">
        <tr>
            <td>DepartmentID</td>
            <td>
                <asp:TextBox ID="txtID" runat="server" Width="174px" ReadOnly="True"></asp:TextBox>
                <span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>Department Name</td>
            <td>
                <asp:TextBox ID="txtDepartmentName" runat="server" Width="173px"></asp:TextBox>
                <span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>Department Image</td>
            <td class="style3">
                <asp:Image ID="depImage" runat="server" Width="200px" /><br/>
                <asp:FileUpload ID="FileUploadImage" runat="server" />
                <span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>Department Order</td>
            <td>
                <asp:TextBox ID="txtOrder" runat="server" Width="174px"></asp:TextBox>
                <span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>Description</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Height="52px" TextMode="MultiLine" Width="189px"></asp:TextBox>
               <span class="required"></span>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" 
                    onclick="ButtonSubmit_Click" />
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                    onclick="ButtonCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
