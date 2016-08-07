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
        .qwer > *{
            display:inline;
        }
        .testing {
                margin: 10px 0;
    border-radius:20px 30px;
    float: left;
    width: 50%;
    padding: 1%;
        font-style: italic;
    font-size: 15px;
    text-align:center;
        }
        /*.testing h2{text-align:center;    font-weight: bold;}
        .testing p {text-align:center; }*/
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
        #header{
            font-weight:bold;
            font-style:italic;
            font-size:35px;
        }
        .mb1{
            background-color:#fcd04b;
        }
        .bb2{
            background-color:#2ac56c;
        }
        .ib3{
            background-color:#9e54bd;
        }
        .dmb4{
            background-color:#f06060;
        }
    </style>
    <div class="alert alert-dismissible alert-info">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    <div class="jumbotron">
        <div id="logoM">
            <img alt="" class="troll" src="Resources/windows.png" />
            <br />
            <h1 id ="header">Find the talents you need here!</h1>
        </div>
        <p class="qwer">
            <asp:DropDownList ID="SearchList" runat="server"  CssClass="form-control" Width="20%">
                <asp:ListItem Text="All" Value="1"></asp:ListItem>
                <asp:ListItem Text="Industry" Value="2"></asp:ListItem>
                <asp:ListItem Text="Skill" Value="3"></asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="querystring" runat="server" placeholder="Search la!" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-info" OnClick="SearchButton_Click1" />
        </p>
    </div>
    <section id="123">
        <div id="b1" class="testing">
            <h2>Medical Healthcare Prospects</h2>
            <p>Find passionate candidates who want to make an positive impact on others lives!</p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <img src="Resources/m.png" width="200px" height="160px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <img src="Resources/m1.png"  width="200px" height="160px"/><br />
            <asp:Button ID="mButton1" runat="server" Text="Click here!"  CssClass="btn btn-warning " OnClick="mButton1_Click" Height="55px" Width="150px" />
        </div>
        <div id="b2" class="testing">
            <h2>Business Management Prospects</h2>
            <p>Find your potential business guru here!</p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <img src="Resources/c.png" width="200px" height="160px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <img src="Resources/money.png" width="200px" height="160px" /><br />
            <asp:Button ID="bButton2" runat="server" Text="Click here!"  CssClass="btn btn-warning " OnClick="bButton2_Click" Height="55px" Width="150px" />
        </div>
        <div id="b3" class="testing">
            <h2>Information Technology Prospects</h2>
            <p>Get your high tech people here! </p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <img src="Resources/js.png" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <img src="Resources/a.png" width="200px" height="160px" /><br />
            <asp:Button ID="itButton3" runat="server" Text="Click here!"  CssClass="btn btn-warning " OnClick="itButton3_Click" Height="55px" Width="150px" />
        </div>
        <div id="b4" class="testing">
            <h2>Digital Media Prospects</h2>
            <p>Spend no time finding creative prospects in the digital media field! </p>&nbsp;&nbsp;&nbsp;&nbsp;
            <img src="Resources/ps.png" width="200px" height="160px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <img src="Resources/pr.png" width="200px" height="160px"  /><br />
            <asp:Button ID="dmButton4" runat="server" Text="Click here!"  CssClass="btn btn-warning" OnClick="dmButton4_Click" Height="55px" Width="150px" />
        </div>
    </section>

    <%--<div >
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
    <div >
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

    </div>--%>

</asp:Content>
