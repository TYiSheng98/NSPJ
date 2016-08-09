using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSPJ
{
    public partial class Tracker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                string q = Request["__EVENTTARGET"];//contrl
                if (q == "lala")
                {
                    string parameter = Request["__EVENTARGUMENT"]; // parameter
                    
                    Response.Redirect("UserProfile.aspx?name=" + parameter);

                }

                else if (q == "lol")
                {
                    string parameter = Request["__EVENTARGUMENT"]; // parameter
                    MsgBox(parameter + " has been added to Bookmarks!");


                    using (SqlConnection connection123 = new
SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
"nspjConnectionString"].ConnectionString))
                    {
                        connection123.Open();
                        SqlCommand command = new SqlCommand();
                        //cmd.CommandText = "INSERT INTO [nspj].[dbo].[Company] (CompanyName,CompanyAddress,CompanySize,CompanyLocation,CompanyNo)  VALUES ('" + Cname.Text + "','" + address.Text + "','" + RadioButtonList1.SelectedValue + "','" + RadioButtonList2.SelectedValue + "','" + PhoneNo.Text + "');";
                        command.CommandText = "INSERT INTO [nspj].[dbo].[Bookmark] (EmployerID,MarkedPeople)  VALUES (@0,@1);";
                        command.Parameters.Add(new SqlParameter("@0", Session["ID"].ToString()));
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

        }

        protected void Status1_Click1(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }


        protected void Bookmarks2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            String q = (String)(Session["BookmarkList"]);
            String[] blist = q.Split('~');
           
            int abc = blist.Length;
            ArrayList List1 = new ArrayList();
            ArrayList List2 = new ArrayList();


            String query = "";
            using (SqlConnection connection = new
SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
"nspjConnectionString"].ConnectionString))
            {
                connection.Open();
                for (int a = 0; a < abc; a++)
                {
                    query = " SELECT [Industry],[Skill] FROM[nspj].[dbo].[User] where Name = @a ";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@a", blist[a]);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                                List1.Add(dr["Industry"].ToString());
                                List2.Add(dr["Skill"].ToString());
                            }
                        }

                    }
                }
                connection.Close();
            }
            Session["IList"] = ArrayListToString(ref List1);
            Session["SList"] = ArrayListToString(ref List2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myFunction", "addAnother()", true);
        }

        protected void History3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            String q = (String)(Session["historyList"]);
            String[] blist = q.Split('~');
           
            int abc = blist.Length;
            ArrayList List1 = new ArrayList();
            ArrayList List2 = new ArrayList();


            String query = "";
            using (SqlConnection connection = new
SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
"nspjConnectionString"].ConnectionString))
            {
                connection.Open();
                for (int a = 0; a < abc; a++)
                {
                    query = " SELECT [Industry],[Skill] FROM[nspj].[dbo].[User] where Name = @a ";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@a", blist[a]);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                                List1.Add(dr["Industry"].ToString());
                                List2.Add(dr["Skill"].ToString());
                            }
                        }

                    }
                }
                connection.Close();
            }
            Session["iList"] = ArrayListToString(ref List1);
            Session["sList"] = ArrayListToString(ref List2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myFunction", "add()", true);
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
        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
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
                cmd1.Parameters.AddWithValue("@a", (String)Session["ID"]);
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

    }       
}