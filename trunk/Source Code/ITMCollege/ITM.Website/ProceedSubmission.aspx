<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="ProceedSubmission.aspx.cs" Inherits="ITM.Website.ProceedSubmission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ImagePlaceHolder" runat="server">
    <img src="Templates/FrontEnd/images/subImage.png" alt="" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="grid_12">
        <div class="pageHeader">
            <h3>Proceed Online Submission</h3>
        </div>
    </div>
    <div class="grid_4">
        <table class="table table-noborder">
            <tr>
                <td>Unique ID</td>
                <td><asp:Label ID="LabelUniqueID" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Admission Status</td>
                <td><asp:Label ID="LabelStatus" runat="server" Text="ACCEPTED"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">Select Course for Registration</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DropDownList ID="departmentList" runat="server" 
                        onselectedindexchanged="departmentList_SelectedIndexChanged" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <div class="grid_8">
        <h3>Available Courses</h3>
        <asp:GridView ID="CourseList" runat="server" CssClass="table table-bordered" 
            AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="courseID" 
                    DataFormatString="CRS{0:D4}" HeaderText="Course ID" />
                <asp:BoundField DataField="courseName" HeaderText="Course Name" />
                <asp:BoundField DataField="facultyName" HeaderText="Teacher" />
                <asp:BoundField DataField="startDate" HeaderText="Start Date" />
                <asp:BoundField DataField="endDate" HeaderText="End Date" />
                <asp:HyperLinkField Text="Register" DataNavigateUrlFields="courseID" 
                    DataNavigateUrlFormatString="RegisterCourse.aspx?courseID={0}" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
