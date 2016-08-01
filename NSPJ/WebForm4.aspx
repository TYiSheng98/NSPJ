<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="NSPJ.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function test(){
            var ch = '<%= Session["t"]%>';
            alert(ch);
            var s = document.getElementById('<%=Label1.ClientID%>');
            s.innerHTML = ch;
        }
    </script>
    <div>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="test();return false;"/>--%>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="encrypt" OnClick="Button2_Click" />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
   <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" />
         <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
