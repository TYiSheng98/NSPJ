<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="NSPJ.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div style="margin:10% auto;">
        <style>
            .haha{float:right;}
        </style>
         <script type="text/javascript">
             function a() {
                 
                 var s = document.getElementById(<%= TextBox1.ClientID %>);
                 
                 s.setAttribute("disabled", "disabled");
                 alert("test");
             }
         </script>
        
            <asp:Button ID="Button1" runat="server" Text="Edit" CssClass="haha" />
        <br />
    <section>
    <h2>Profile Picture</h2>
        <br />
        <asp:Image ID="Image1" Visible = "false" runat="server" />
        </section>
    <section>
    <h2>Account Security</h2>
        <h3> ID: </h3>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <h3> Password: </h3>
        <asp:TextBox ID="TextBox1" runat="server"  ></asp:TextBox>
    </section>
    <section>
        <h2>Account Information</h2>
        <h3>Name:</h3><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <h3>Gender: </h3><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <h3>Email: </h3><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    </section>
    <section>
    <h2>Company Details</h2>
        <h3>Company:</h3><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        <h3>Designation:</h3><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
        
    </section>
   
        </div>
</asp:Content>
