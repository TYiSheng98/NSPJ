using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSPJ
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                String ID, password, name, gender, email, company, Designation;
                byte[] image;
                
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "myFunction", "a()", true);
                using (SqlConnection connection = new
       SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
       "nspjConnectionString"].ConnectionString))
                {

                    connection.Open();
                    String query;
                    query = " SELECT [EmployerID],[Password],[EName],[Gender],[Email],[Ecompany],[Designation],[image] FROM[nspj].[dbo].[EMP] where EmployerID =@1 ";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@1", (String)(Session["ID"]));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dt.Clear();
                    da.Fill(dt);
                    ID = dt.Rows[0][0].ToString();
                    password = dt.Rows[0][1].ToString();
                    name = dt.Rows[0][2].ToString();
                    gender = dt.Rows[0][3].ToString();
                    email = dt.Rows[0][4].ToString();
                    company = dt.Rows[0][5].ToString();
                    Designation = dt.Rows[0][6].ToString();
                    image = (byte[])dt.Rows[0][7];
                    connection.Close();
                }
                string base64String = Convert.ToBase64String(image, 0, image.Length);
                Image1.ImageUrl = "data:image/png;base64," + base64String;
                Image1.Visible = true;

                Label1.Text = ID;
                TextBox1.Attributes["type"] = "password";
                TextBox1.Text = password;
                //TextBox1.ReadOnly = true;

                Label2.Text = name;
                Label3.Text = gender;
                Label4.Text = email;
                Label5.Text = company;
                Label6.Text = Designation;
            }
            
        }
        protected void confirm_Click(object sender, EventArgs e)
        {//validate pass
            String password;
            try
            {
                using (SqlConnection connection123 = new
        SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
        "nspjConnectionString"].ConnectionString))
                {

                    connection123.Open();
                    String query;
                    query = " SELECT Password FROM[nspj].[dbo].[EMP] where EmployerID = @0";
                    SqlCommand cmd = new SqlCommand(query, connection123);
                    cmd.Parameters.AddWithValue("@0", (String)(Session["ID"]));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dt.Clear();
                    da.Fill(dt);
                    password = dt.Rows[0][0].ToString();
                    connection123.Close();
                    if (Label8.Text.Equals(password))
                    {
                        MultiView1.ActiveViewIndex = 1;
                    }
                }
            }catch(SqlException s)
            {
                MsgBox("Something is wrong!");   
            }
        
        }
        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }

        protected void EditB_Click(object sender, EventArgs e)
        {
            //MsgBox("ttt");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mymodal", "$('#myModal').modal();", true);
        }
    }
}