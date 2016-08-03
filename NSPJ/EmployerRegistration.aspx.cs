using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSPJ
{
    public partial class EmployerRegistration : System.Web.UI.Page
    {
        int counter = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void CreateCompanyButton_Click1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new
SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
"nspjConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "INSERT INTO [nspj].[dbo].[Company] (CompanyName,CompanyAddress,CompanySize,CompanyLocation,CompanyNo)  VALUES ('" + Cname.Text + "','" + address.Text + "','" + RadioButtonList1.SelectedValue + "','" + RadioButtonList2.SelectedValue + "','" + PhoneNo.Text + "');";
                cmd.CommandText = "INSERT INTO [nspj].[dbo].[Company] (CompanyName,CompanyAddress,CompanySize,CompanyLocation,CompanyNo)  VALUES (@0,@1,@2,@3,@4);";
                cmd.Parameters.Add(new SqlParameter("@0", Cname.Text));
                cmd.Parameters.Add(new SqlParameter("@1", address.Text));
                cmd.Parameters.Add(new SqlParameter("@2", RadioButtonList1.SelectedValue));
                cmd.Parameters.Add(new SqlParameter("@3", RadioButtonList2.SelectedValue));
                cmd.Parameters.Add(new SqlParameter("@4", PhoneNo.Text));
                cmd.Connection = connection;
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                counter++;
                if (counter == 1)
                {
                    MsgBox("Created");
                    RadioButtonList1.ClearSelection();
                    RadioButtonList2.ClearSelection();
                    Cname.Text = "";
                    address.Text = "";
                    PhoneNo.Text = "";
                }
                else
                {
                    MsgBox("try again!");
                }
            }
            

        }


        protected void ClearButton_Click(object sender, EventArgs e)
        {
            RadioButtonList1.ClearSelection();
            RadioButtonList2.ClearSelection();
            Cname.Text = "";
            address.Text = "";
            PhoneNo.Text = "";



        }

        protected void ClearEmp_Click(object sender, EventArgs e)
        {
            

        }

        //protected void Prev_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 0;
        //}

        //protected void Next_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 1;
        //}

        //protected void EClear_Click(object sender, EventArgs e)
        //{
        //    Ename.Text = "";
        //    RadioButtonList3.ClearSelection();
        //    EPhoneNo.Text = "";
        //    Eemail.Text = "";
        //    UID.Text = "";
        //    password.Text = "";
        //    Designation.Text = "";
        //}

        protected void ECreate_Click(object sender, EventArgs e)
        {
            int counter = 0;
            using (SqlConnection connection = new
SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
"nspjConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "INSERT INTO [nspj].[dbo].[Company] (CompanyName,CompanyAddress,CompanySize,CompanyLocation,CompanyNo)  VALUES ('" + Cname.Text + "','" + address.Text + "','" + RadioButtonList1.SelectedValue + "','" + RadioButtonList2.SelectedValue + "','" + PhoneNo.Text + "');";
                cmd.CommandText = "INSERT INTO [nspj].[dbo].[EMP] (EmployerID,Password,EName,Gender,EPhoneNo,Email,Ecompany,Designation)  VALUES (@0,@1,@2,@3,@4,@5,@6,@7);";
                cmd.Parameters.Add(new SqlParameter("@0", UID.Text));
                cmd.Parameters.Add(new SqlParameter("@1", password.Text));
                cmd.Parameters.Add(new SqlParameter("@2", Ename.Text));
                cmd.Parameters.Add(new SqlParameter("@3", RadioButtonList3.SelectedValue));
                cmd.Parameters.Add(new SqlParameter("@4", EPhoneNo.Text));
                cmd.Parameters.Add(new SqlParameter("@5", Eemail.Text));
                cmd.Parameters.Add(new SqlParameter("@6", CompanyList.SelectedItem.Text));
                cmd.Parameters.Add(new SqlParameter("@7", Designation.Text));
                //int img = FileUpload1.PostedFile.ContentLength;

                //byte[] msdata = new byte[img];

                //FileUpload1.PostedFile.InputStream.Read(msdata, 0, img);

                //cmd.Parameters.AddWithValue("@image", msdata);
                cmd.Connection = connection;
                connection.Open();
                cmd.ExecuteNonQuery();
                counter ++;
                connection.Close();
                if (counter == 1)
                {
                    MsgBox("Created");
                    Ename.Text = "";
                    RadioButtonList3.ClearSelection();
                    EPhoneNo.Text = "";
                    Eemail.Text = "";
                    UID.Text = "";
                    password.Text = "";
                    Designation.Text = "";
                }
                else
                {
                    MsgBox("try again!");
                }
            }
            //remeber to catch for sql error(duplicate PK,field not created)
            
        }
        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }

        protected void EClear_Click(object sender, EventArgs e)
        {
            Ename.Text = "";
            RadioButtonList3.ClearSelection();
            EPhoneNo.Text = "";
            Eemail.Text = "";
            UID.Text = "";
            password.Text = "";
            Designation.Text = "";
        }
    }
}