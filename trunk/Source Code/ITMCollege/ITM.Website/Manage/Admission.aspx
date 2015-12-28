<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="Admission.aspx.cs" Inherits="ITM.Website.Manage.Admission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBreadCrumb" runat="server">
    <li>Admission Manage</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFunctionPlaceHolder" runat="server">
    <div class="pageHeader">
        <h3>New Admissions</h3>
    </div>
    <asp:GridView ID="OnlineAdmission" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CssClass="table table-bordered" 
        onpageindexchanging="OnlineAdmission_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="admissionID" HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Birthday" HeaderText="Birthday" />
            <asp:BoundField DataField="ResidentialAddress" HeaderText="Address" />
            <asp:TemplateField HeaderText="Status">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# (Boolean.Parse(Eval("status").ToString())) ? "Yes" : "WAITING" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="admissionID" 
                DataNavigateUrlFormatString="AdmissionUpdate.aspx?AID={0}" Text="Update" />
            <asp:HyperLinkField DataNavigateUrlFields="admissionID" 
                DataNavigateUrlFormatString="AdmissionDelete.aspx?AID={0}" Text="Delete" />
        </Columns>
    </asp:GridView>
</asp:Content>
