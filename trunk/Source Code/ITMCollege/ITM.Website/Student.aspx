<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="ITM.Website.Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ImagePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="grid_3" id="student-nav">
        <h3>Student Control Panel</h3>
        <ul>
            <li><asp:HyperLink ID="studentExam" NavigateUrl="Student.aspx?view=Exam" runat="server">Exam Time Table</asp:HyperLink></li>
            <li><asp:HyperLink ID="studentAssignment" NavigateUrl="Student.aspx?view=Assignments" runat="server">Assignments</asp:HyperLink></li>
            <li><asp:HyperLink ID="studentProfile" NavigateUrl="Student.aspx?view=Profile" runat="server">Profile</asp:HyperLink></li>
            <li><asp:HyperLink ID="studentChangePassword" NavigateUrl="Student.aspx?view=ChangePassword" runat="server">Change Password</asp:HyperLink></li>
            <li><asp:HyperLink ID="studentFeedBack" NavigateUrl="Student.aspx?view=FeedBack" runat="server">FeedBack</asp:HyperLink></li>
        </ul>
    </div>
    <div class="grid_9">
    <asp:Panel ID="PanelProfile" runat="server">
        <div class="pageHeader">
            <h3>Student Profile</h3>
        </div>
        <asp:ListView ID="ProfileView" runat="server" ItemPlaceholderID="ProfileView" >
            <LayoutTemplate>
                <table class="table table-bordered">
                    <asp:PlaceHolder ID="ProfileView" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <th>Student name</th><td><%# Eval("Name") %></td>
                    <th colspan="2">Previous Examination</th>
                </tr>
                <tr>
                    <th>Father Name</th><td><%# Eval("FatherName")%></td>
                    <th>University</th><td><%# Eval("prevUniversity")%></td>
                </tr>
                <tr>
                    <th>Mother Name</th><td><%# Eval("MortherName")%></td>
                    <th>Enroll Number</th><td><%# Eval("prevEnrolNumber")%></td>
                </tr>
                <tr>
                    <th>Birthday</th><td><%# Eval("Birthday")%></td>
                    <th>Center</th><td><%# Eval("prevCenter")%></td>
                </tr>
                <tr>
                    <th>Gender</th><td><%# (bool)Eval("Gender") ? "Female" : "Male"%></td>
                    <th>Stream</th><td><%# Eval("prevStream")%></td>
                </tr>
                <tr>
                    <th>Residental Address</th><td><%# Eval("ResidentialAddress")%></td>
                    <th>Field</th><td><%# Eval("prevField")%></td>
                </tr>
                <tr>
                    <th>Pernament Address</th><td><%# Eval("PermanentAddress")%></td>
                    <th>Mark secured</th><td><%# Eval("prevMarks")%></td>
                </tr>
                <tr>
                    <th>Sport detail</th><td><%# Eval("prevSportsDetails")%></td>
                    <th>Out of</th><td><%# Eval("prevOutOf")%></td>
                </tr>
                <tr>
                    <th>Admission for</th><td><%# Eval("admissionFor")%></td>
                    <th>Class Obtained</th><td><%# Eval("prevClass")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </asp:Panel>
    <asp:Panel ID="PanelExam" runat="server" Visible="False">
        <asp:ListView ID="MainCourseView" runat="server" ItemPlaceholderID="MainCourseView" >
            <LayoutTemplate>
                <asp:PlaceHolder ID="MainCourseView" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <h3>Specialized Subject: <%# Eval("courseName")%></h3>
                <table class="table table-bordered">
                    <tr>
                        <th>Course ID</th>
                        <th>Department</th>
                        <th>Faculty</th>
                        <th>Start Date</th>
                        <th>End Date</th>
                        <th>Exam Date</th>
                    </tr>
                    <tr>
                        <td><%# "CRS" + Eval("courseID", "{0:D4}")%></td>
                        <td><%# Eval("departmentName")%></td>
                        <td><%# Eval("facultyName")%></td>
                        <td><%# Eval("startDate")%></td>
                        <td><%# Eval("endDate")%></td>
                        <td><%# Eval("examDate")%></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:ListView>
        <asp:ListView ID="OptioncalCourseView" runat="server" ItemPlaceholderID="OptioncalCourseView" >
            <LayoutTemplate>
                <asp:PlaceHolder ID="OptioncalCourseView" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <h3>Optional Subject: <%# Eval("courseName")%></h3>
                <table class="table table-bordered">
                    <tr>
                        <th>Course ID</th>
                        <th>Department</th>
                        <th>Faculty</th>
                        <th>Start Date</th>
                        <th>End Date</th>
                        <th>Exam Date</th>
                    </tr>
                    <tr>
                        <td><%# "CRS" + Eval("courseID", "{0:D4}")%></td>
                        <td><%# Eval("departmentName")%></td>
                        <td><%# Eval("facultyName")%></td>
                        <td><%# Eval("startDate")%></td>
                        <td><%# Eval("endDate")%></td>
                        <td><%# Eval("examDate")%></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:ListView>
    </asp:Panel>
    <asp:Panel ID="PanelAssignment" runat="server" Visible="False">
        <asp:ListView ID="MainAssignment" runat="server" ItemPlaceholderID="MainAssignment" >
            <LayoutTemplate>
                <h3>Specialized Subject</h3>
                <table class="table table-bordered">
                    <tr>
                        <th>Course ID</th>
                        <th>Assignment ID</th>
                        <th>Assignment Name</th>
                        <th>Detail</th>
                    </tr>
                    <asp:PlaceHolder ID="MainAssignment" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                    <tr>
                        <td><%# "CRS" + Eval("courseID", "{0:D4}")%></td>
                        <td><%# "AS" + Eval("assignmentID", "{0:D4}")%></td>
                        <td><%# Eval("assignmentName")%></td>
                        <td><%# Eval("assignmentDescription")%></td>
                    </tr>
            </ItemTemplate>
        </asp:ListView>
        <asp:ListView ID="OptionalAssignment" runat="server" ItemPlaceholderID="OptionalAssignment" >
            <LayoutTemplate>
                <h3>Optional Subject</h3>
                <table class="table table-bordered">
                    <tr>
                        <th>Course ID</th>
                        <th>Assignment ID</th>
                        <th>Assignment Name</th>
                        <th>Detail</th>
                    </tr>
                    <asp:PlaceHolder ID="OptionalAssignment" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                    <tr>
                        <td><%# "CRS" + Eval("courseID", "{0:D4}")%></td>
                        <td><%# "AS" + Eval("assignmentID", "{0:D4}")%></td>
                        <td><%# Eval("assignmentName")%></td>
                        <td><%# Eval("assignmentDescription")%></td>
                    </tr>
            </ItemTemplate>
        </asp:ListView>
    </asp:Panel>
    <asp:Panel ID="PanelChangePassword" runat="server" Visible="False">
        <h3>Change Password</h3>
        <p><strong>Note</strong>: If you change your password you will have to log back in</p>
        <table class="table table-noborder">
            <tr>
                <td>EnrillNumber</td>
                <td><asp:Label ID="LabelEnrollNumber" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">You must submit the current password to update this page</td>
            </tr>
            <tr>
                <td>Current Password</td>
                <td><asp:TextBox ID="txtCurrPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td>New Password</td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Re-type New Password</td>
                <td><asp:TextBox ID="txtPassword2" runat="server" TextMode="Password"></asp:TextBox></td>
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
    </asp:Panel>
    <asp:Panel ID="PanelFeedBack" runat="server" Visible="False">
        <h3>FeedBack</h3>
        <table class="table">
            <tr>
                <td>Select Course</td>
                <td>
                    <asp:DropDownList ID="FeedbackCourseList" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Feedback</td>
                <td>
                    <asp:TextBox ID="txtFeedback" runat="server" Width="300" Height="100" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="ButtonFeedBackSubmit" runat="server" Text="Button" 
                        onclick="ButtonFeedBackSubmit_Click" /></td>
            </tr>
        </table>
    </asp:Panel>
    </div>
</asp:Content>