<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="NSPJ.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div style="margin:10% auto;">
        <style>
            .haha{float:right;}
        </style>
        
            <asp:Button ID="Button1" runat="server" Text="Edit" CssClass="haha" />
        <br />
    <section>
    <h2>Profile Picture</h2>
        <br />
        <img src="Resources/windows.png" />
        </section>
    <section>
    <h2>Account Security</h2>
        <h3> ID: </h3>
        <h3> Password: *********</h3>
    </section>
    <section>
        <h2>Account Information</h2>
        <h3>Name:</h3>
        <h3>Gender: </h3>
    </section>
    <section>
    <h2>Company Details</h2>
        <h3>Company:</h3>
        <h3>Designation:</h3>
        <h3>Email: </h3>
    </section>
    <%--<h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>--%>
        </div>
</asp:Content>
