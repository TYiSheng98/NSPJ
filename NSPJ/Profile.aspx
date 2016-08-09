<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="NSPJ.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 2% auto;">
        <style>
            .haha {
                float: right;
            }

            section h2 {
                font-size: 35px;
            }

            section h3 {
                font-size: 30px;
            }
        </style>
       <!-- Trigger the modal with a button -->
<%--<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>--%>

<!-- Modal -->
<div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Modal Header</h4>
      </div>
      <div class="modal-body">
          <asp:Label ID="Label7" runat="server" Text="Please enter your current password below!"></asp:Label>
          <br />
          <asp:Label ID="Label8" runat="server" Text="Current Password: "></asp:Label>
          <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
      </div>
      <div class="modal-footer">
           <asp:Button ID="confirmp" runat="server"  Text="Continue" CssClass="btn btn-info" OnClick="confirm_Click" />
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
         
      </div>
    </div>

  </div>
    <%--data-toggle="modal" data-target="#myModal"--%> 
</div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:Button ID="EditB" runat="server" Text="Update Your Profile" Font-Size="Large" CssClass="btn btn-primary haha" OnClick="EditB_Click" />
                <br />
                <section>
                    <h2>Profile Picture</h2>
                    <br />
                    <asp:Image ID="Image1" Visible="false" runat="server" />
                </section>
                <section>
                    <h2>Account Security</h2>
                    <h3>ID: </h3>
                    <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="X-Large"></asp:Label>
                    <h3>Password: </h3>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Font-Size="X-Large" ></asp:TextBox>
                </section>
                <section>
                    <h2>Account Information</h2>
                    <h3>Name:</h3>
                    <asp:Label ID="Label2" runat="server" Text="Label" Font-Size="X-Large"></asp:Label>
                    <h3>Gender: </h3>
                    <asp:Label ID="Label3" runat="server" Text="Label" Font-Size="X-Large"></asp:Label>
                    <h3>Email: </h3>
                    <asp:Label ID="Label4" runat="server" Text="Label" Font-Size="X-Large"></asp:Label>
                </section>
                <section>
                    <h2>Company Details</h2>
                    <h3>Company:</h3>
                    <asp:Label ID="Label5" runat="server" Text="Label" Font-Size="X-Large"></asp:Label>
                    <h3>Designation:</h3>
                    <asp:Label ID="Label6" runat="server" Text="Label" Font-Size="X-Large"></asp:Label>

                </section>

            </asp:View>
            <asp:View ID="View2" runat="server">
<section class="form-horizontal">
                <fieldset>
                    <legend>Update Employer Profile</legend>
                    
                    
                    <div class="form-group">
                        <label for="EPhoneNo" class="col-lg-2 control-label">Employer Phone Number</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="EPhoneNo" runat="server" TextMode="Phone" CssClass="form-control" ></asp:TextBox>
                          <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                runat="server" ErrorMessage="Enter valid Phone number"
                                ControlToValidate="EPhoneNo"
                                ValidationExpression="[0-9]{8}"></asp:RegularExpressionValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="Eemail" class="col-lg-2 control-label">Employer Email</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="Eemail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                   
                    <div class="form-group">
                        <label for="password" class="col-lg-2 control-label">Employer Password</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                     <%--<div class="form-group">
                        <label for="CompanyList" class="col-lg-2 control-label">Employer's Company</label>
                        <div class="col-lg-10">
                            <asp:DropDownList ID="CompanyList" runat="server" CssClass="form-control" Width="20%"></asp:DropDownList>
                           
                            
                           
                        </div>
                    </div>--%>
                     <div class="form-group">
                        <label for="Designation" class="col-lg-2 control-label">Designation</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="Designation" runat="server"  CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                   <div class="form-group">
                        <label for="Designation" class="col-lg-2 control-label">Upload Photo</label>
                        <div class="col-lg-10">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
                    </div>

                    
                    
                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <asp:Button ID="EClear" runat="server" Text="Clear All" CssClass="btn btn-default" OnClick="EClear_Click"   />
                            <asp:Button ID="ECreate" runat="server" Text="Update details" CssClass="btn btn-primary" OnClick="ECreate_Click" />
                            
                        </div>
                    </div>
                </fieldset>
            </section>



            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
