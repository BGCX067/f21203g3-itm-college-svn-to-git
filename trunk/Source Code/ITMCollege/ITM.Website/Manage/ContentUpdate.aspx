<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="ContentUpdate.aspx.cs" Inherits="ITM.Website.Manage.ContentUpdate" ValidateRequest="false" %>
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
        <asp:HyperLink ID="HyperLink1" NavigateUrl="Contents.aspx" runat="server">Contents Manage</asp:HyperLink></li>
    <li>Update Content</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <p class="style1">
        Content&nbsp;Update</p>
    <table class="table table-noborder">
        <tr>
            <td>Content ID</td>
            <td><asp:TextBox ID="txtID" runat="server" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Content Title</td>
            <td><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><span class="required"></span></td>
        </tr>
        <tr>
            <td>Content Image</td>
            <td>
                <asp:Image ID="contentImage" Width="200px" runat="server" /><br/>
                <asp:FileUpload ID="FileUploadImage" runat="server" /><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>Content Category</td>
            <td>
                <asp:DropDownList ID="listCategory" runat="server">
                    <asp:ListItem Enabled="False">Select Category</asp:ListItem>
                    <asp:ListItem Value="news">News</asp:ListItem>
                    <asp:ListItem Value="events">Events</asp:ListItem>
                    <asp:ListItem Value="achievements">Achievements</asp:ListItem>
                    <asp:ListItem Value="merit">Merit List</asp:ListItem>
                </asp:DropDownList><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>Content Description</td>
            <td><asp:TextBox ID="txtText" runat="server" Height="52px" TextMode="MultiLine" 
                    Width="189px"></asp:TextBox><span class="required"></span>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" 
                    onclick="ButtonSubmit_Click" />
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                    onclick="ButtonCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
