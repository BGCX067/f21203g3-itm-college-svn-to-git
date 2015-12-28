<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ITM.Website.Manage.Login" %>
<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <title>ITM College Manage</title>
    <!--[if lt IE 9]>
    <script src="~/Templates/global/scripts/html5.js"></script>
    <![endif]-->
    <link href="~/Templates/global/css/bootstraps.css" rel="stylesheet" type="text/css"/>
    <link href="~/Templates/BackEnd/css/Login.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div id="loginForm">
            <header><img src="../Templates/global/images/ITM-logo.png" /></header>
            <div class="loginForm">
                <asp:Label ID="LabelUsername" runat="server" Text="Username" CssClass="formLabel"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <asp:Label ID="LabelPassword" runat="server" Text="Password" CssClass="formLabel"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <div class="clear"></div>
                <asp:Label ID="LabelButton" runat="server" Text="" CssClass="formLabel"></asp:Label>
                <asp:Button ID="ButtonLogin" runat="server" Text="Login" 
                    onclick="ButtonLogin_Click" />
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                    onclick="ButtonCancel_Click" />
                <div class="clear"></div>
            </div>
        </div>
    </form>
</body>
</html>
