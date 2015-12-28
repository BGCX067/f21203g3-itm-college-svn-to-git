<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Admission.aspx.cs" Inherits="ITM.Website.Admission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ImagePlaceHolder" runat="server">
    <img src="Templates/FrontEnd/images/subImage.png" alt="" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="grid_12">
        <div class="pageHeader">Online Admission</div>
    </div>
    <div class="grid_6" id="personalDetail">
        <table class="table table-noborder">
            <tr>
                <td>Your Name</td>
                <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox><span class="required"></span></td>
            </tr>
            <tr>
                <td>Father Name</td>
                <td><asp:TextBox ID="txtFatherName" runat="server"></asp:TextBox><span class="required"></span></td>
            </tr>
            <tr>
                <td>Mother Name</td>
                <td><asp:TextBox ID="txtMothername" runat="server"></asp:TextBox><span class="required"></span>
            </tr>
            <tr>
                <td>Date of Birth</td>
                <td>
                    <asp:TextBox ID="txtBirthday" runat="server"></asp:TextBox><br/>
                    <asp:RegularExpressionValidator ID="DoBValidate" runat="server" 
                        ControlToValidate="txtBirthday" 
                        ErrorMessage="Date of Birth should be in MM-DD-YYYY format" 
                        
                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d" 
                        CssClass="error"></asp:RegularExpressionValidator>
            </tr>
            <tr>
                <td>Residential Address</td>
                <td><asp:TextBox ID="txtResidentialAddress" runat="server"></asp:TextBox><span class="required"></span>
            </tr>
            <tr>
                <td>Permanent Address</td>
                <td><asp:TextBox ID="txtPermanentAddress" runat="server"></asp:TextBox><span class="required"></span>
            </tr>
            <tr>
                <td>Gender</td>
                <td>
                    <asp:RadioButtonList ID="radGender" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="0">Male</asp:ListItem>
                        <asp:ListItem Value="1">Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>Sport detail</td>
                <td><asp:TextBox ID="txtSportDetail" runat="server"></asp:TextBox><span class="required"></span>
            </tr>
            <tr>
                <td>Admission for</td>
                <td><asp:TextBox ID="txtAdmissionFor" runat="server"></asp:TextBox><span class="required"></span>
            </tr>
            <asp:HiddenField ID="regKey" runat="server" />
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
    </div>
    <div class="grid_6" id="prevExam">
        <h4>Previous Exam</h4>
        <table class="table table-noborder">
            <tr>
                <td width="140">University</td>
                <td><asp:TextBox ID="txtUniversity" runat="server"></asp:TextBox>
            </tr>
            <tr>
                <td>Enrollment number</td>
                <td><asp:TextBox ID="txtEnrolNumber" runat="server"></asp:TextBox>
            </tr>
            <tr>
                <td>Center</td>
                <td><asp:TextBox ID="txtCenter" runat="server"></asp:TextBox>
            </tr>
            <tr>
                <td>Stream</td>
                <td><asp:TextBox ID="txtStream" runat="server"></asp:TextBox>
            </tr>
            <tr>
                <td>Field</td>
                <td><asp:TextBox ID="txtField" runat="server"></asp:TextBox>
            </tr>
            <tr>
                <td>Marks secured</td>
                <td><asp:TextBox ID="txtMarkSecured" runat="server"></asp:TextBox>
            </tr>
            <tr>
                <td>Out of </td>
                <td><asp:TextBox ID="txtOutOf" runat="server"></asp:TextBox>
            </tr>
            <tr>
                <td>Class Obtained</td>
                <td><asp:TextBox ID="txtClassObtained" runat="server"></asp:TextBox>
            </tr>
        </table>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
</asp:Content>
