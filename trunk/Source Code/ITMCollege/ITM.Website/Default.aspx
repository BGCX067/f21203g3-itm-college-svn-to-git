<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ITM.Website.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ImagePlaceHolder" runat="server">
    <img src="Templates/FrontEnd/images/mainImage.png" alt="">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="grid_8 about-short">
        <div class="pageHeader">
            <h3>Welcome to ITM College</h3>
        </div>
        <div class="entry-content">
            <p>ITM College commenced its education and training business in 1986 and has globally trained over 6.4 million students. ITM College is an ISO 9001:2000 organization and the first IT Training and Education company to get this certification for Education Support Services in 1993.</p>
            <p>ITM College has presence in more than 40+ emerging countries through its two main streams of businesses – Individual training and Enterprise Business. As a leader in career education, it has over 1305 centres of learning across the world... <a class="readmore" href="AboutUs.aspx" title="">read more</a></p>
        </div>
    </div>
    <div class="grid_4 float-right">
        <div class="pageHeader">
            <h3>
                <asp:HyperLink ID="HyperLink1" NavigateUrl="Contents.aspx?view=news" runat="server">College News</asp:HyperLink>
            </h3>
        </div>
        <asp:ListView ID="NewsList" runat="server" ItemPlaceholderID="NewsList" >
            <LayoutTemplate>
                <div class="news-list">
                    <asp:PlaceHolder ID="NewsList" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="entry-part">
                    <div class="entry-title"><a href="ContentsDetail.aspx?cid=<%# Eval("contentID")%>" title="<%# Eval("contentTitle")%>"><%# Truncate(Eval("contentTitle"), 48)%></a></div>
                    <div class="entry-content">
                        <%# Truncate(HttpUtility.HtmlDecode((string)Eval("contentText")), 80)%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <asp:Panel ID="StudentLoginForm" Visible="True" runat="server">
            <div class="grid_3 alpha" id="student-login">
                <h3>Student Login</h3>
                <asp:TextBox ID="txtEnrollNumber" runat="server" placeholder="Enrollnumber"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                <asp:Button ID="ButtonLogin" runat="server" Text="Login" CssClass="float-right" 
                    onclick="ButtonLogin_Click"  />
            </div>
        </asp:Panel>
    </div>
    <div class="grid_4">
        <div class="pageHeader"><h3>Latest Coures</h3></div>
        <asp:ListView ID="LatestCourse" runat="server" ItemPlaceholderID="LatestCourse" >
            <LayoutTemplate>
                <asp:PlaceHolder ID="LatestCourse" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="entry-part">
                    <div class="entry-title course-name"><%# Eval("courseName")%></div>
                    <div class="entry-content">
                        <p>Instructor: <%# Eval("facultyName")%></p>
                        <p>Time: <%# Eval("startDate")%> - <%# Eval("endDate")%></p>
                        <p><%# Eval("courseDescription")%></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div class="grid_4">
        <div class="pageHeader"><h3><asp:HyperLink ID="HyperLink3" NavigateUrl="Contents.aspx?view=events" runat="server">Campus Events</asp:HyperLink></h3></div>
        <asp:ListView ID="EventList" runat="server" ItemPlaceholderID="EventList" >
            <LayoutTemplate>
                <ul class="event-list">
                    <asp:PlaceHolder ID="EventList" runat="server"></asp:PlaceHolder>
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li><a href="ContentsDetail.aspx?cid=<%# Eval("contentID")%>" title="<%# Eval("contentTitle")%>"><%# Eval("contentTitle")%></a></li>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>