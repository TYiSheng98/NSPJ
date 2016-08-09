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
        String A;
        protected void Page_Load(object sender, EventArgs e)
        {
            String ppp = (String)(Session)["ID"];
            A = ppp;
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
                    cmd.Parameters.AddWithValue("@1", ppp);

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
                TextBox1.ReadOnly = true;

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
                    cmd.Parameters.AddWithValue("@0", A);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dt.Clear();
                    da.Fill(dt);
                    password = dt.Rows[0][0].ToString();
                    connection123.Close();
                    if (password.Equals(TextBox2.Text))
                    {
                        MultiView1.ActiveViewIndex = 1;
                    }
                    else
                        MsgBox("Password incorrect!");
                }
            }
            catch (SqlException s)
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

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mymodal", "$('#myModal').modal();", true);
        }
        protected void EClear_Click(object sender, EventArgs e)
        {

            EPhoneNo.Text = "";
            Eemail.Text = "";

            password.Text = "";
            Designation.Text = "";
        }

        protected void ECreate_Click(object sender, EventArgs e)
        {
            Boolean validtor = false;

            String Password = password.Text;
            String contactno = EPhoneNo.Text;
            String email = Eemail.Text;

            String position = Designation.Text;


            // Read the file and convert it to Byte Array
            string filePath = FileUpload1.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            Stream fs = FileUpload1.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);

            String[] list = new String[] { Password, contactno, email, position, filePath };
            //foreach (String o in list)
            //{
            //    if (o.Equals(""))
            //    {
            //        validtor = false;
            //        MsgBox("Please fill in all the fields!");
            //        break;
            //    }
            //    else
            //        validtor = true;
            //}


            if (!(contactno.Equals("")))
            {
                char[] myChar = contactno.ToCharArray();
                for (int count = 0; count < myChar.Length; count++)
                {
                    char ch = myChar[count];
                    if (myChar.Length != 8)
                    {
                        MsgBox("Invalid phone number entered!Only 8 numbers allowed!");
                        validtor = false;
                        break;
                    }

                    else if (Char.IsDigit(ch) == false)
                    {
                        MsgBox("Invalid phone number!Only numbers are allowed!");
                        validtor = false;
                        break;
                    }
                    else if (count == 0)
                    {
                        if (ch != '9' && ch != '8')
                        {
                            MsgBox("Invalid phone number entered!");
                            validtor = false;
                            break;
                        }
                    }



                    else
                        validtor = true;
                }
            }
            else
                validtor = true;
            if (validtor == true)
            {
                String[] list1 = new String[] { "Password", "EPhoneNo", "Email", "Designation", "image" };
                try
                {
                    int counter = 0;
                    using (SqlConnection connection = new
        SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
        "nspjConnectionString"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand();
                        for (int a = counter; a < list.Length; a++)
                        {
                            String op = list[a];
                            if (!(op.Equals("")))
                            {
                                cmd.CommandText = "UPDATE [nspj].[dbo].[EMP] set " + list1[a] + "= @" + a + " where EmployerID=@100 ;";
                                if (a != 4)
                                {
                                    cmd.Parameters.Add(new SqlParameter("@" + a, list[a]));
                                    

                                }
                                else
                                {
                                    cmd.Parameters.Add("@4", SqlDbType.Binary).Value = bytes;

                                }
                                cmd.Parameters.Add(new SqlParameter("@100", (String)(Session["ID"])));
                                cmd.Connection = connection;
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                            }
                        }
                        counter++;
                        connection.Close();
                        if (counter == 1)
                        {

                            MsgBox("Updated!");
                            EPhoneNo.Text = "";
                            Eemail.Text = "";

                            password.Text = "";
                            Designation.Text = "";
                            FileUpload1.Attributes.Clear();

                        }
                        else
                        {
                            MsgBox("try again!");
                        }

                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MsgBox("USER ID already been used!Please try again!");
                    }


                }
            }


        }
    }
}