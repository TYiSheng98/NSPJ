using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
        public void filldropdown()
        {
            using (SqlConnection connection = new
SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
"nspjConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select CompanyName from [nspj].[dbo].[CompanyTable]", connection);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                CompanyList.Items.Clear();
                if (dr.HasRows)
                {
                    //TextBox3.DataSource = dr["EmpID"].ToString();
                    //TextBox3.DataBind();

                    while (dr.Read())
                    {
                        CompanyList.Items.Add(dr["CompanyName"].ToString());
                    }
                }
                connection.Close();
            }
        }


        protected void CreateCompanyButton_Click1(object sender, EventArgs e)
        {
            Boolean valid = false;
            String a = Cname.Text;
            String b = address.Text;
            String c = PhoneNo.Text;
            String d = RadioButtonList1.SelectedValue;
            String f = RadioButtonList2.SelectedValue;
            String[] ha = new string[] { a,b,c,d,f};
            
            if (Cname.Text.Length > 200)
            {
                valid = false;
                MsgBox("Maximum of 200 characters!");
            }
            else
                valid = true;
        
            if (address.Text.Length > 1000)
            {
                valid = false;
                MsgBox("Maximum of 1000 characters!");
            }
            else
                valid = true;

            char[] myChar = c.ToCharArray();
            for (int count = 0; count < myChar.Length; count++)
            {
                char ch = myChar[count];

                if (Char.IsDigit(ch) == false)
                {
                    MsgBox("Invalid phone number!Only numbers are allowed!");
                    valid = false;
                    break;
                }
                else if (count == 0 && ch != '6')
                {
                    MsgBox("Invalid phone number entered!");
                    valid = false;
                    break;
                }
                else if (myChar.Length != 8)
                {
                    MsgBox("Invalid phone number entered!");
                    valid = false;
                    break;
                }
                else
                    valid = true;
               
            }
            for (int i = 0; i < ha.Length; i++)
            {
                String s = ha[i];
                if (s.Equals(""))
                {
                    valid = false;
                    MsgBox("Please fill in all fields!");

                    break;
                }

                else
                    valid = true;
            }





            if (valid == true)
            {
                using (SqlConnection connection = new
    SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
    "nspjConnectionString"].ConnectionString))
                {
                    try
                    {
                        int counter = 0;
                        SqlCommand cmd = new SqlCommand();
                        //cmd.CommandText = "INSERT INTO [nspj].[dbo].[Company] (CompanyName,CompanyAddress,CompanySize,CompanyLocation,CompanyNo)  VALUES ('" + Cname.Text + "','" + address.Text + "','" + RadioButtonList1.SelectedValue + "','" + RadioButtonList2.SelectedValue + "','" + PhoneNo.Text + "');";
                        cmd.CommandText = "INSERT INTO [nspj].[dbo].[CompanyTable] (CompanyName,CompanyAddress,CompanyRegion,CompanySize,CompanyContact)  VALUES (@0,@1,@2,@3,@4);";
                        cmd.Parameters.Add(new SqlParameter("@0", a));
                        cmd.Parameters.Add(new SqlParameter("@1", b));
                        cmd.Parameters.Add(new SqlParameter("@2", RadioButtonList2.SelectedValue));
                        cmd.Parameters.Add(new SqlParameter("@3", RadioButtonList1.SelectedValue));
                        cmd.Parameters.Add(new SqlParameter("@4", c));
                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        counter++;
                        connection.Close();
                        if (counter == 1)
                        {
                            filldropdown();
                            MsgBox("Created");
                            RadioButtonList1.ClearSelection();
                            RadioButtonList2.ClearSelection();
                            Cname.Text = "";
                            address.Text = "";
                            PhoneNo.Text = "";
                        }
                        else
                        {
                            MsgBox("Profile not created! Please kindly contact database admin if the details entered are 100% accurate.");
                        }
                    }
                    
                    catch (SqlException exception)
                    { 
                    
                        if(exception.Number == 2627)
                    {
                            MsgBox("Company name used before!");
                    }
                        

                             
                }
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

        protected void Prev_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            filldropdown();
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

        protected void ECreate_Click(object sender, EventArgs e)
        {
            Boolean validtor = false;
            String id = UID.Text;
            String Password = password.Text;
            String name = Ename.Text;
            String gender = RadioButtonList3.SelectedValue;
            String contactno = EPhoneNo.Text;
            String email = Eemail.Text;
            String scomapany = CompanyList.SelectedItem.Text;
            String position = Designation.Text;
            

            // Read the file and convert it to Byte Array
            string filePath = FileUpload1.PostedFile.FileName;
            

            String[] list = new String[] {id,Password,name,gender,contactno,email,scomapany,position,filePath };
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
                    if (ch !='9' && ch != '8')
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
                        //cmd.CommandText = "INSERT INTO [nspj].[dbo].[Company] (CompanyName,CompanyAddress,CompanySize,CompanyLocation,CompanyNo)  VALUES ('" + Cname.Text + "','" + address.Text + "','" + RadioButtonList1.SelectedValue + "','" + RadioButtonList2.SelectedValue + "','" + PhoneNo.Text + "');";
                        cmd.CommandText = "INSERT INTO [nspj].[dbo].[EMP] (EmployerID,Password,EName,Gender,EPhoneNo,Email,Ecompany,Designation,image)  VALUES (@0,@1,@2,@3,@4,@5,@6,@7,@8);";
                        cmd.Parameters.Add(new SqlParameter("@0", UID.Text));
                        cmd.Parameters.Add(new SqlParameter("@1", password.Text));
                        cmd.Parameters.Add(new SqlParameter("@2", Ename.Text));
                        cmd.Parameters.Add(new SqlParameter("@3", RadioButtonList3.SelectedValue));
                        cmd.Parameters.Add(new SqlParameter("@4", EPhoneNo.Text));
                        cmd.Parameters.Add(new SqlParameter("@5", Eemail.Text));
                        cmd.Parameters.Add(new SqlParameter("@6", CompanyList.SelectedItem.Text));
                        cmd.Parameters.Add(new SqlParameter("@7", Designation.Text));
                        string filename = Path.GetFileName(filePath);
                        Stream fs = FileUpload1.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        cmd.Parameters.Add("@8", SqlDbType.Binary).Value = bytes;

                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        counter++;
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
        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }


    }
}