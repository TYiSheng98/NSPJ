<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="q.aspx.cs" Inherits="NSPJ.q" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" onload="javascript:addAnother();">
    <style>
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
    <script type="text/javascript">
        function addAnother() {
            //get bookmarked string
            var ch = '<%=  Session["BookmarkList"] %>';
            var gg = ch.split('~');
            //alert(gg);
            
            var s = "";
            //get search result string
            var listString = document.getElementById('<%= HiddenField1.ClientID%>').value;
            alert(listString);            
            var listArray = listString.split('~');
            var total = parseInt(<%= Session["count"] %>);
            //alert(total);
            // Now you have an array in javascript of each value

            for (var counter = 0; counter < total ; counter++) {
                s = listArray[counter];
                
                var ul = document.getElementById("list");
                //var children = ul.children.length + 1;
                var li = document.createElement("li");
                li.setAttribute("id", "element" + counter);
                var div = document.createElement("div");
                div.setAttribute("class", "a");
                var btn = document.createElement("INPUT");
                btn.setAttribute("id", s);
                btn.setAttribute("type", "button");
                btn.setAttribute("class", "btn btn-info Button2");
                for (var counter1 = 0; counter1 < ch.length; counter1++) {
                    var In = gg[counter1];
                    
                    if (In === s) {
                        btn.setAttribute("value", "Added");
                        btn.disabled = true;
                        break;
                    }
                    else {
                        btn.setAttribute("value", "Add to bookmark");
                        btn.onclick = function () { save(this.id) };
                    }
                }
                
                //var t = document.createTextNode("Add to bookmark");
                //btn.appendChild(t);
                div.appendChild(btn);
                var linebreak= document.createElement("br");
                div.appendChild(linebreak);
                var c = document.createElement("a");
                c.setAttribute('href', "UserProfile.aspx");

                var h1 = document.createElement("h1"); // Create a <h1> element
                //h.setAttribute("class", "lol h5");
                var t = document.createTextNode(s);     // Create a text node
                h1.appendChild(t);                  // Append the text to <h1>
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
        function save(id) {
            var buttonclicked = document.getElementById(id);
            buttonclicked.setAttribute("value", "Added");
            buttonclicked.disabled = true;
            bookmarklist.push(id);
            <%--var str = bookmarklist.toString();
            document.getElementById('<%= HiddenField1.ClientID%>').value = str;
            alert(document.getElementById('<%= HiddenField1.ClientID%>').value);--%>
        };
    </script>

    <ul id="list" class="list-group">
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </ul>
    <%-- <section>
        <div class="lol" id="box1">
            <img src="Resources/windows.png" style="float:left;" />
            <img src="Resources/windows.png" style="float:right;" />
            <h5 style="font-size: 20px; font-weight: bold">FullName</h5>
            
            <h6 style="text-align:center;">position</h6>
        </div>--%>
</asp:Content>
