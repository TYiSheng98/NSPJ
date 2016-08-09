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
        String s;
        //TextBox txt = new TextBox();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                String ID, password, name, gender, email, company, Designation;
                byte[] image;
                //MemoryStream stream = new MemoryStream();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myFunction", "a()", true);
                using (SqlConnection connection = new
       SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
       "nspjConnectionString"].ConnectionString))
                {

                    connection.Open();
                    String query;
                    query = " SELECT [EmployerID],[Password],[EName],[Gender],[Email],[Ecompany],[Designation],[image] FROM[nspj].[dbo].[EMP] where EmployerID =@0 ";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@0", (String)Session["ID"]);

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
                    //stream.Write(image, 0, image.Length);
                    //connection.Close();
                    //Bitmap bitmap = new Bitmap(stream);
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

        
        protected void EditButton1_Click(object sender, EventArgs e)
        {
            //Panel p = new Panel();
            //Label header = new Label();
            //header.Text = "Please enter Your current password below !";
            //p.Controls.Add(header);
            //System.Web.UI.HtmlControls.HtmlGenericControl linebreak = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            //linebreak.ID = "createDiv";
            //p.Controls.Add(linebreak);
            //Label l = new Label();
            //l.Text = "Password:";
            //p.Controls.Add(l);
            
            //txt.ID = "textBox1";
            //p.Controls.Add(txt);
            
            //PlaceHolder1.Controls.Add(p);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            
        }
       
        protected void va(object sender, EventArgs e)
        {// compare valid password
            s = TextBox2.Text;
            String password = "";
            try {
                using (SqlConnection connection = new
    SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
    "nspjConnectionString"].ConnectionString))
                {

                    connection.Open();
                    String query;
                    query = " select Password FROM[nspj].[dbo].[EMP] where EmployerID =@1 ";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@1", (String)Session["ID"]);
                    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dt.Clear();
                    da.Fill(dt);
                    password = dt.Rows[0][0].ToString();

                }

                if (password.Equals(s))
                {
                    MultiView1.ActiveViewIndex = 1 ;
                }
            } catch (SqlException ex)
            {
                MsgBox("Error!Password entered is invalid !");
            }

           
            
                }


        protected void EClear_Click(object sender, EventArgs e)
        {
            Ename.Text = "";
            
            EPhoneNo.Text = "";
            Eemail.Text = "";
            
            password.Text = "";
            Designation.Text = "";
        }

        protected void ECreate_Click(object sender, EventArgs e)
        {
            Boolean validtor = false;
            
            String Password = password.Text;
            String name = Ename.Text;
           
            String contactno = EPhoneNo.Text;
            String email = Eemail.Text;
            
            String position = Designation.Text;


            // Read the file and convert it to Byte Array
            string filePath = FileUpload1.PostedFile.FileName;


            String[] list = new String[] { Password,  contactno, email, position, filePath };
            foreach (String o in list)
            {
                if (o.Equals(""))
                {
                    validtor = false;
                    MsgBox("Please fill in all the fields!");
                    break;
                }
                else
                    validtor = true;
            }

            if (Ename.Text.Length > 1000)
            {
                MsgBox("Maximium of 1000 characters");
                validtor = false;
            }

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
                //else if (count == 0 && ch != '9' )
                //{
                //    MsgBox("Invalid phone number entered!");
                //    validtor = false;
                //    break;
                //}
                //else if (count == 0 && ch != '8')
                //{
                //    MsgBox("Invalid phone number entered!");
                //    validtor = false;
                //    break;
                //}

                else
                    validtor = true;
            }


            //if (id.Equals("") || Password.Equals("") || name.Equals("") || gender.Equals("") || contactno.Equals("") || email.Equals("") || scomapany.Equals("") || position.Equals("") || filePath.Equals(""))
            //{
            //    validtor = false;

            //}





            if (validtor == true)
            {
                try
                {
                    int counter = 0;
                    using (SqlConnection connection = new
        SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
        "nspjConnectionString"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand();
                        
                        cmd.CommandText = "UPDATE [nspj].[dbo].[EMP] set Password = @1, EName =@2 ,EPhoneNo=@3,Email=@4,Designation=@5,image=@6 where EmployerID =@7";
                        
                        cmd.Parameters.Add(new SqlParameter("@1", password.Text));
                        cmd.Parameters.Add(new SqlParameter("@2", Ename.Text));
                        
                        cmd.Parameters.Add(new SqlParameter("@3", EPhoneNo.Text));
                        cmd.Parameters.Add(new SqlParameter("@4", Eemail.Text));
                        
                        cmd.Parameters.Add(new SqlParameter("@5", Designation.Text));
                        string filename = Path.GetFileName(filePath);
                        Stream fs = FileUpload1.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        cmd.Parameters.Add("@6", SqlDbType.Binary).Value = bytes;
                        cmd.Parameters.AddWithValue("@7", (String)Session["ID"]);
                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        counter++;
                        connection.Close();
                        if (counter == 1)
                        {
                            MsgBox("Created");
                            Ename.Text = "";
                            
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
                    MsgBox("Update not successful!");


                }
            }


        }

        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }
    }
}