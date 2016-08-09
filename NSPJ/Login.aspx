<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NSPJ.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Welcome to DatsMe Employer Login!" Font-Size="XX-Large"></asp:Label>
    <br />
    <asp:Label ID="UID" runat="server" Text="Username" Font-Size="Large"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ></asp:TextBox>
    <br />
    <asp:Label ID="password" runat="server" Text="Password" Font-Size="Large"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="form-control" ></asp:TextBox>
    <br />
    <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click"  CssClass="btn btn-info"/>
</asp:Content>
