<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployerRegistration.aspx.cs" Inherits="NSPJ.EmployerRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">--%>
            <section class="form-horizontal">
                <fieldset>
                    <legend>Company Profile</legend>
                    <div class="form-group">
                        <label for="Cname" class="col-lg-2 control-label">Company Name</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="Cname" runat="server" CssClass="form-control"></asp:TextBox>
                           <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="CName" ErrorMessage="Please enter your name!" />
                            
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="address" class="col-lg-2 control-label">Company Address</label>
                        <div class="col-lg-10">
                           
                            <asp:TextBox ID="address" runat="server" CssClass="form-control" Rows="1" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="RadioButtonList1" class="col-lg-2 control-label">Company Size</label>
                        <div class="col-lg-10 ">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">

                                <asp:ListItem Text="Small" Value="Small" />
                                <asp:ListItem Text="Medium" Value="Medium" />
                                <asp:ListItem Text="Large" Value="Large" />

                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="RadioButtonList2" class="col-lg-2 control-label">Company Location</label>
                        <div class="col-lg-10">

                           
                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="North" Value="North" />
                                <asp:ListItem Text="South" Value="South" />
                                <asp:ListItem Text="West" Value="West" />
                                <asp:ListItem Text="East" Value="East" />
                                <asp:ListItem Text="Central" Value="Central" />
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="PhoneNo" class="col-lg-2 control-label">Company Phone Number</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="PhoneNo" runat="server" TextMode="Phone" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                runat="server" ErrorMessage="Enter valid Phone number"
                                ControlToValidate="PhoneNo"
                                ValidationExpression="[0-9]{8}"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                           
                            <asp:Button ID="ClearButton" runat="server" Text="Clear" CssClass="btn btn-default" OnClick="ClearButton_Click" />
                            <asp:Button ID="CreateCompanyButton" runat="server" Text="Create Company Profile" CssClass="btn btn-primary" OnClick="CreateCompanyButton_Click1" />
                        </div>
                    </div>
                </fieldset>
            </section>
       <%-- </asp:View>
        <asp:View ID="View2" runat="server">--%>
            <section class="form-horizontal">
                <fieldset>
                    <legend>Employer Profile</legend>
                    <div class="form-group">
                        <label for="Ename" class="col-lg-2 control-label">Employer Name</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="Ename" runat="server" CssClass="form-control"></asp:TextBox>
                            

                        </div>
                    </div>
                    <div class="form-group">
                        <label for="RadioButtonList3" class="col-lg-2 control-label">Gender</label>
                        <div class="col-lg-10 ">

                            <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal">

                                <asp:ListItem Text="Male" Value="Male" />
                                <asp:ListItem Text="Female" Value="Female" />

                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="EPhoneNo" class="col-lg-2 control-label">Employer Phone Number</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="EPhoneNo" runat="server" TextMode="Phone" CssClass="form-control" ></asp:TextBox>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                runat="server" ErrorMessage="Enter valid Phone number"
                                ControlToValidate="EPhoneNo"
                                ValidationExpression="[0-9]{8}"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="Eemail" class="col-lg-2 control-label">Employer Email</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="Eemail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-group">
                        <label for="UID" class="col-lg-2 control-label">Employer UserID</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="UID" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="password" class="col-lg-2 control-label">Employer Password</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-group">
                        <label for="CompanyList" class="col-lg-2 control-label">Employer's Company</label>
                        <div class="col-lg-10">
                            <asp:DropDownList ID="CompanyList" runat="server" DataSourceID="SqlDataSource1" DataTextField="CompanyName" DataValueField="CompanyName" ></asp:DropDownList>
                           
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:nspjConnectionString %>" SelectCommand="SELECT [CompanyName] FROM [Company]"></asp:SqlDataSource>
                           
                        </div>
                    </div>
                     <div class="form-group">
                        <label for="Designation" class="col-lg-2 control-label">Designation</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="Designation" runat="server"  CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <%--<div class="form-group">
                        <label for="Designation" class="col-lg-2 control-label">picture</label>
                        <div class="col-lg-10">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
                    </div>--%>
                    
                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <asp:Button ID="EClear" runat="server" Text="Clear" CssClass="btn btn-default" OnClick="EClear_Click" />
                            <asp:Button ID="ECreate" runat="server" Text="Create Employer" CssClass="btn btn-primary" OnClick="ECreate_Click" />
                            
                        </div>
                    </div>
                </fieldset>
            </section>
        <%--</asp:View>
    </asp:MultiView>--%>
    <%--<asp:Button ID="Prev" runat="server" Text="Prev" OnClick="Prev_Click" />

    <asp:Button ID="Next" runat="server" Text="Next" OnClick="Next_Click" />--%>

    
    
</asp:Content>
