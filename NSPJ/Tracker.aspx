<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tracker.aspx.cs" Inherits="NSPJ.Tracker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #Label {
            font-size: 25em;
        }

        .lol img {
            float: left;
        }

        .lol h5 {
            text-align: center;
        }

        .lol {
            clear: both;
            position: relative;
            left: 30%;
            border: 1px dashed red;
            width: 40%;
            padding: 20px;
            margin-top: 3%;
        }
    </style>
    

    <h2 style="text-align: center; font-size: 50px; padding: 50px;">
        Result Found </h2>
        <br />

    <%--<h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>--%>


    <%--<section>
        <div class="lol" id="box1">
            <img src="Resources/windows.png" style="float:left;" />
            <img src="Resources/windows.png" style="float:right;" />
            <h5 style="font-size: 20px; font-weight: bold">FullName</h5>
            
            <h6 style="text-align:center;">position</h6>
        </div>
        <div class="lol" id="box2">
            <img src="Resources/windows.png" style="float:left;" />
            <img src="Resources/windows.png" style="float:right;" />
            <h5 style="font-size: 20px; font-weight: bold">FullName</h5>
            
            <h6 style="text-align:center;">position</h6>
        </div>
    </section>--%>
    
    <asp:Button ID="Status1" runat="server" Text="Status" class="btn btn-info" OnClick="Status1_Click" />
    <asp:Button ID="Bookmarks2" runat="server" Text="Bookmarks" class="btn btn-warning" OnClick="Bookmarks2_Click"/> 
    <asp:Button ID="History3" runat="server" Text="History" class="btn btn-danger" OnClick="History3_Click"/>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server"><h1>Status</h1></asp:View>
        <asp:View ID="View2" runat="server"><h1>Bookmarks</h1></asp:View>
        <asp:View ID="View3" runat="server"><h1>History</h1></asp:View>
    </asp:MultiView>
    <br />
<br />
</asp:Content>
