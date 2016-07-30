    <%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NSPJ.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

    <%--<asp:Button ID="Button1" runat="server" Text="Button1" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="Button2" OnClick="Button2_Click" />

    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            hello
        </asp:View>
        <asp:View ID="View2" runat="server"> world</asp:View>
    </asp:MultiView>--%>

    <asp:DropDownList ID="DropDownList1" runat="server">
         <asp:ListItem Text="All" Value="1"></asp:ListItem>
        <asp:ListItem Text="Skill" Value="2"></asp:ListItem>
                <asp:ListItem Text="Industry" Value="3"></asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="Button3" runat="server" Text="Search" OnClick="Button3_Click" />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
