<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="test1.aspx.cs" Inherits="NSPJ.test1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>      
    <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem Text="All" Value="1"></asp:ListItem>
                <asp:ListItem Text="Industry" Value="2"></asp:ListItem>
                <asp:ListItem Text="Skill" Value="3"></asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
