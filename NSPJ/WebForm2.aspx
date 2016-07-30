<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="NSPJ.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <script>
         function add(){
            var c =document.getElementById("Label1").value;
            var d = c.valueOf();
            document.getElementById("a").innerHTML = d;
         }
         window.onload = add();
    </script>
    <p id="a">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="Name" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                <asp:BoundField DataField="Industry" HeaderText="Industry" SortExpression="Industry" />
                <asp:BoundField DataField="Skill" HeaderText="Skill" SortExpression="Skill" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:nspjConnectionString %>" DeleteCommand="DELETE FROM [User] WHERE [Name] = @Name" InsertCommand="INSERT INTO [User] ([Name], [Industry], [Skill]) VALUES (@Name, @Industry, @Skill)" ProviderName="<%$ ConnectionStrings:nspjConnectionString.ProviderName %>" SelectCommand="SELECT [Name], [Industry], [Skill] FROM [User]" UpdateCommand="UPDATE [User] SET [Industry] = @Industry, [Skill] = @Skill WHERE [Name] = @Name">
            <DeleteParameters>
                <asp:Parameter Name="Name" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Industry" Type="String" />
                <asp:Parameter Name="Skill" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Industry" Type="String" />
                <asp:Parameter Name="Skill" Type="String" />
                <asp:Parameter Name="Name" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>
