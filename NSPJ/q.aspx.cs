using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSPJ
{
    public partial class q : System.Web.UI.Page
    {
        protected string test;
        protected void Page_Load(object sender, EventArgs e)
        {

            
            ArrayList NList = new ArrayList();
            ArrayList IList = new ArrayList();
            ArrayList SList = new ArrayList();

            var a = Request.QueryString["query"];
            var c = Request.QueryString["cat"];
            int k = Convert.ToInt32(c);
            String query = "";
            using (SqlConnection connection = new
SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
"nspjConnectionString"].ConnectionString))
            {
                connection.Open();
                if (k == 2)
                {
                    query = " SELECT * FROM[nspj].[dbo].[User] where Skill like '%' + @c + '%' ";

                }
                else if (k == 1)
                {
                    query = " SELECT * FROM[nspj].[dbo].[User] where Industry like '%' + @c + '%'";
                }
                else
                {
                    query = " SELECT * FROM[nspj].[dbo].[User] where Name like '%' + @c + '%' or Industry like '%' + @c + '%' or Skill like '%' + @c + '%' ";
                }
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@c", a);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            NList.Add(dr["Name"].ToString());
                            IList.Add(dr["Industry"].ToString());
                            SList.Add(dr["Skill"].ToString());
                        }
                    }

                }

                connection.Close();
            }
            //foreach (String n in NList)
            //    //Console.Write("   {0}", n);
            //    System.Diagnostics.Debug.WriteLine(n);
            //HiddenField1.Value = ArrayListToString(ref NList);
            Session["NameList"]= ArrayListToString(ref NList);
            Session["IndustryList"] = ArrayListToString(ref IList);
            Session["SkillList"] = ArrayListToString(ref SList);
            //   System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
            //new System.Web.Script.Serialization.JavaScriptSerializer();
            //   string sJSON = oSerializer.Serialize(NList);
            Session["count"] = NList.Count;
            
            //StringBuilder sb = new StringBuilder();
            //sb.Append("alert('Finished');");
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "", sb.ToString(), true);
            //sb.Append("<script>"  + "var listString=document.getElementById('HiddenField1').value;" + "alert(listString)");
            //sb.Append("</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myFunction", "addAnother()", true);

            if (IsPostBack)
            {
                
                string q = Request["__EVENTTARGET"];//contrl
                if (q == "lala")
                {
                    string parameter = Request["__EVENTARGUMENT"]; // parameter
                    //MsgBox(parameter + " has been added to Bookmarks!");


                    using (SqlConnection connection123 = new
SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
"nspjConnectionString"].ConnectionString))
                    {
                        connection123.Open();
                        SqlCommand command = new SqlCommand();
                        //cmd.CommandText = "INSERT INTO [nspj].[dbo].[Company] (CompanyName,CompanyAddress,CompanySize,CompanyLocation,CompanyNo)  VALUES ('" + Cname.Text + "','" + address.Text + "','" + RadioButtonList1.SelectedValue + "','" + RadioButtonList2.SelectedValue + "','" + PhoneNo.Text + "');";
                        command.CommandText = "INSERT INTO [nspj].[dbo].[History] (EmployerID,HistoryPeople)  VALUES (@0,@1);";
                        command.Parameters.Add(new SqlParameter("@0", Session["ID"].ToString()));
                        command.Parameters.Add(new SqlParameter("@1", parameter));

                        command.Connection = connection123;

                        command.ExecuteNonQuery();
                        connection123.Close();
                    }
                    ArrayList UpdateHList = new ArrayList();
                    UpdateHList = lol();
                    Session["historyList"] = ArrayListToString(ref UpdateHList);
                    Response.Redirect("UserProfile.aspx?name="+parameter);

                }

               else if (q == "lol" )
                {
                    string parameter = Request["__EVENTARGUMENT"]; // parameter
                    MsgBox( parameter + " has been added to Bookmarks!");


                    using (SqlConnection connection123 = new
SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
"nspjConnectionString"].ConnectionString))
                    {
                        connection123.Open();
                        SqlCommand command = new SqlCommand();
                        //cmd.CommandText = "INSERT INTO [nspj].[dbo].[Company] (CompanyName,CompanyAddress,CompanySize,CompanyLocation,CompanyNo)  VALUES ('" + Cname.Text + "','" + address.Text + "','" + RadioButtonList1.SelectedValue + "','" + RadioButtonList2.SelectedValue + "','" + PhoneNo.Text + "');";
                        command.CommandText = "INSERT INTO [nspj].[dbo].[Bookmark] (EmployerID,MarkedPeople)  VALUES (@0,@1);";
                        command.Parameters.Add(new SqlParameter("@0", session.SName));
                        command.Parameters.Add(new SqlParameter("@1", parameter));

                        command.Connection = connection123;

                        command.ExecuteNonQuery();
                        connection123.Close();
                    }
                    ArrayList UpdateList = new ArrayList();
                    UpdateList = qwerty();
                    Session["BookmarkList"] = ArrayListToString(ref UpdateList);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myFunction", "addAnother()", true);
                }
                 
            }
        } //endpage load
        private ArrayList lol()
        {
            ArrayList hlist = new ArrayList();
            using (SqlConnection con = new
       SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
       "nspjConnectionString"].ConnectionString))
            {
                con.Open();
                String bquery = "SELECT HistoryPeople FROM [nspj].[dbo].[History] where EmployerID = @a order by RowID desc";
                SqlCommand cmd1 = new SqlCommand(bquery, con);
                cmd1.Parameters.AddWithValue("@a", session.SName);
                using (SqlDataReader dr = cmd1.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            hlist.Add(dr["HistoryPeople"].ToString());
                        }
                    }

                }



                con.Close();
            }
            return hlist;
        }
        private ArrayList qwerty()
        {
            ArrayList Bookmarklist = new ArrayList();
            using (SqlConnection con = new
       SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
       "nspjConnectionString"].ConnectionString))
            {
                con.Open();
                String bquery = "SELECT MarkedPeople FROM[nspj].[dbo].[Bookmark] where EmployerID = @a order by [MarkedPeople]";
                SqlCommand cmd1 = new SqlCommand(bquery, con);
                cmd1.Parameters.AddWithValue("@a",session.SName);
                using (SqlDataReader dr = cmd1.ExecuteReader())
                {
                    
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            Bookmarklist.Add(dr["MarkedPeople"].ToString());
                        }
                    }

                }



                con.Close();
            }
            return Bookmarklist;
        }

        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }
        private string ArrayListToString(ref ArrayList _ArrayList)
        {
            int intCount;
            string strFinal = "";

            for (intCount = 0; intCount <= _ArrayList.Count - 1; intCount++)
            {
                if (intCount > 0)
                {
                    strFinal += "~";
                }

                strFinal += _ArrayList[intCount].ToString();
            }

            return strFinal;
        }
    }

}