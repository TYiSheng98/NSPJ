<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="NSPJ.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /*.lol img {
            float: left;
        }
         .lol h1 {
            text-align: center;
            font-weight: bold;
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
        }*/
        #list {
            list-style: none;
        }

            #list li {
                margin: 2% 0;
            }

        .Button2 {
            position: absolute;
            float: right;
            top: 5%;
            right: 2%;
        }

        .a {
            margin: 0 auto;
            width: 35%;
            border: 1px dashed red;
            position: relative;
        }

            .a h1 {
                clear: both;
                text-align: center;
                font-weight: bold;
            }

            .a h5 {
                clear: both;
                text-align: center;
            }
    </style>
    <script type="text/javascript">

        function test() {
            var s = "";
            //var listString = document.getElementById('HiddenField1').value;
            var listString = "Amy~Cliff~Hike~James~John~Kenny~Leslie~Mary";
            var listArray = listString.split('~');
            var total = parseInt(listArray.length);
            // Now you have an array in javascript of each value

            for (var counter = 0; counter < total; counter++) {
                s = listArray[counter];

                var ul = document.getElementById("list");
                var li = document.createElement("li");
                //var children = ul.children.length + 1;
                li.setAttribute("id", "element" + counter);
                var div = document.createElement("div");
                div.setAttribute("class", "a");
                var btn = document.createElement("BUTTON");
                btn.setAttribute("id", s);
                btn.setAttribute("type", "button");
                btn.setAttribute("value", "Add to bookmark");
                btn.setAttribute("class", "btn btn-info Button2");
                btn.onclick = function () { save(this.id) };
                //var t = document.createTextNode("Add to bookmark");
                //btn.appendChild(t);
                div.appendChild(btn);
                var c = document.createElement("a");
                c.setAttribute('href', "UserProfile.aspx");

                var h1 = document.createElement("h1"); // Create a <h1> element
                //h.setAttribute("class", "lol h5");
                var t = document.createTextNode(s);     // Create a text node
                h1.appendChild(t);                      // Append the text to <h1>
                c.appendChild(h1);
                div.appendChild(c);
                var h5 = document.createElement("h5"); // Create a <h5> element
                //h5.setAttribute("class", "badge");
                var t = document.createTextNode("Industry and skill");     // Create a text node
                h5.appendChild(t);                                   // Append the text to <h1>
                div.appendChild(h5);
                li.appendChild(div);

                ul.appendChild(li);
            }
        }
        var bookmarklist = new Array();
        function save(id) {
            //alert(id);
            var buttonclicked = document.getElementById(id);
            buttonclicked.setAttribute("value", "Added");
            buttonclicked.disabled = true;
            bookmarklist.push(id);
            var str = bookmarklist.toString();
            document.getElementById('<%= HiddenField1.ClientID%>').value = str;
            alert(document.getElementById('<%= HiddenField1.ClientID%>').value);
            __doPostBack('lol',id);
            //alert(typeof document.getElementById('<%= HiddenField1.ClientID%>').value);

        };

    </script>

    <ul id="list" class="list-group">
    </ul>

    <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="test() ;return false;" />
    <%--<input id="EButton" type="button" value="button" class="btn btn-info Button2" onclick="hello()" /> --%>


    <%-- <div>
    <div class="panel panel-default " style="margin:0 auto;width:40%; ">
        <img src="Resources/windows.png"  />
            <asp:Button ID="Button2" runat="server" Text="Button" CssClass="btn btn-info Button2"/>
&nbsp;<h5 style="font-size: 20px; font-weight: bold">FullName</h5>
            
            <h6 style="text-align:center;">position</h6>
        </div></div>--%>

    <asp:HiddenField ID="HiddenField1" runat="server" />

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    <section>
        <div id="box1" class="a">
            <img src="Resources/windows.png" />
            <asp:Button ID="Button2" runat="server" Text="Button" CssClass="btn btn-info Button2" />
            &nbsp;<h5 style="font-size: 20px; font-weight: bold">FullName</h5>

            <h6 style="text-align: center;">position</h6>
        </div>
        <%--<div class="lol" id="box2">
            <img src="Resources/windows.png" style="float:left;" />
            <img src="Resources/windows.png" style="float:right;" />
            <h5 style="font-size: 20px; font-weight: bold">FullName</h5>
            
            <h6 style="text-align:center;">position</h6>
        </div>--%>
    </section>

    </button>
     
</asp:Content>
