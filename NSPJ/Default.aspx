<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NSPJ._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .troll {
            clear: both;
            width: 160px;
            height: 129px;
        }

        #logoM {
            clear: both;
            text-align: center;
        }

        .col-md-6 {
        }

        #b1 {
            background-color: #40ff00;
        }

        #b2 {
            background-color: #ffff66;
        }

        #b3 {
            background-color: #66a3ff;
        }

        #b4 {
            background-color: #99ff99;
        }
    </style>
    <div class="alert alert-dismissible alert-info">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    <div class="jumbotron">
        <div id="logoM">
            <img alt="" class="troll" src="Resources/windows.png" />
            <br />
            Find all sorts of talents here!
        </div>
        <p>
            <asp:DropDownList ID="SearchList" runat="server">
                <asp:ListItem Text="All" Value="1"></asp:ListItem>
                <asp:ListItem Text="Industry" Value="2"></asp:ListItem>
                <asp:ListItem Text="Skill" Value="3"></asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="querystring" runat="server" placeholder="Search la!" ></asp:TextBox>
            <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-info" OnClick="SearchButton_Click1" />
        </p>


        


    </div>

    <div class="row">
        <div class="col-md-6" id="b1">
            <h2>Medical Healthcare Prospects</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-6" id="b2">
            <h2>Business Management Prospects</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>

    </div>
    <div class="row">
        <div class="col-md-6" id="b3">
            <h2>Information Technology Prospects</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-6" id="b4">
            <h2>Digital Media Prospects</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>

    </div>

</asp:Content>
