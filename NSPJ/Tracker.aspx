<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tracker.aspx.cs" Inherits="NSPJ.Tracker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #Label {
            font-size: 25em;
        }

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
        .a a{clear:both;}

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
   


    <h2 style="text-align: center; font-size: 50px; padding: 50px;">Welcome to Tracker Page! </h2>
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

    <asp:Button ID="Status1" runat="server" Text="Status" class="btn btn-info" OnClick="Status1_Click1"  />
    <asp:Button ID="Bookmarks2" runat="server" Text="Bookmarks" class="btn btn-warning" OnClick="Bookmarks2_Click" />
    <asp:Button ID="History3" runat="server" Text="History" class="btn btn-danger" OnClick="History3_Click" />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <h1>Status</h1>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <h1>Bookmarks</h1>
             <script type="text/javascript">
        //get bookmarked string
        var ch = '<%=  Session["BookmarkList"] %>';
        var gg = ch.split('~');
            
        function addAnother() {
            alert("1");
            
            
            
            //get search result string
            //var listString = document.getElementById('HiddenField1.ClientID%>').value;
            //alert(listString);    
            var listString = '<%=  Session["BookmarkList"] %>';
            var listArray = listString.split('~');
            var total = listArray.length;
            var listString1 = '<%=  Session["IList"] %>';
            var listArray1 = listString1.split('~');

            var listString2 = '<%=  Session["SList"] %>';
            var listArray2 = listString2.split('~');

            alert("2");
            
            
            
            // Now you have an array in javascript of each value

            for (var counter = 0; counter < total ; counter++) {
                var name = listArray[counter];
                var industry = listArray1[counter];
                var skill = listArray2[counter];

                var ul = document.getElementById("list");
                //var children = ul.children.length + 1;
                var li = document.createElement("li");
                li.setAttribute("id", "element" + counter);
                var div = document.createElement("div");
                div.setAttribute("class", "a");
                var btn = document.createElement("INPUT");
                btn.setAttribute("id", name);
                btn.setAttribute("type", "button");
                btn.setAttribute("class", "btn btn-info Button2");
                btn.setAttribute("value", "Add to bookmark");
                for (var counter1 = 0; counter1 < ch.length; counter1++) {
                    var In = gg[counter1];
                    
                    if (In === name) {
                        btn.setAttribute("value", "Added");
                        btn.disabled = true;
                        break;
                    }
                    
                }
                
                //var t = document.createTextNode("Add to bookmark");
                //btn.appendChild(t);
                btn.onclick = function () { save(this.id) };
                div.appendChild(btn);
                var linebreak= document.createElement("br");
                div.appendChild(linebreak);
                var c = document.createElement("a");
                c.setAttribute('href', "UserProfile.aspx");

                var h1 = document.createElement("h1"); // Create a <h1> element
                //h.setAttribute("class", "lol h5");
                var t = document.createTextNode(name);     // Create a text node
                h1.appendChild(t);                  // Append the text to <h1>
                c.appendChild(h1);
                div.appendChild(c);
                var h5 = document.createElement("h5"); // Create a <h5> element
                //h5.setAttribute("class", "badge");
                var t = document.createTextNode(skill+"("+ industry+")");     // Create a text node
                h5.appendChild(t);                                   // Append the text to <h1>
                div.appendChild(h5);
                li.appendChild(div);

                ul.appendChild(li);
            }
        }
        <%--function save(id) {
            var buttonclicked = document.getElementById(id);
            buttonclicked.setAttribute("value", "Added");
            buttonclicked.disabled = true;
            ch +="~" + id;
            __doPostBack('lol', id);
            //bookmarklist.push(id);
            var str = bookmarklist.toString();
            document.getElementById('<%= HiddenField1.ClientID%>').value = str;
            alert(document.getElementById('<%= HiddenField1.ClientID%>').value);
        };--%>
    </script>
            <ul id="list" class="list-group">
            </ul>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <h1>History</h1>
        </asp:View>
    </asp:MultiView>
    <br />
    <br />
</asp:Content>
