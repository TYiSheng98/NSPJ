<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="NSPJ.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #ResultCounter {
            margin: 0 auto;
        }

        .list {
            list-style: none;
        }

            .list li {
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

            .a a {
                clear: both;
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
        function addAnother(id) {
            
            var btnclicked = document.getElementById(id);
            btnclicked.setAttribute("value", "Added");
            
            
        }
    </script>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%><asp:Panel ID="Panel1" runat="server">
            <h1 id="ResultCounter" runat="server">0 Results Found!</h1>
            <ul id="list" class="list-group list" runat="server">
            </ul>
        </asp:Panel>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
