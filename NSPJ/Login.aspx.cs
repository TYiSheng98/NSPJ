using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSPJ
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            String ID="";
            String password="";

            using (SqlConnection connection = new
SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
"nspjConnectionString"].ConnectionString))
            {
                
                connection.Open();
                String query;
                query = " SELECT EmployerID,Password FROM[nspj].[dbo].[EMP] where EmployerID =@1 and Password =@2";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@1", TextBox1.Text);
                cmd.Parameters.AddWithValue("@2", TextBox2.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                ID = dt.Rows[0][0].ToString();
                password = dt.Rows[0][1].ToString();

                //using (SqlDataReader reader = cmd.ExecuteReader())
                //{

                //        while (reader.Read())
                //        {

                //            ID = reader.GetString(1);
                //            password = reader.GetString(2);
                //             }

                //}
                if (TextBox1.Text.Equals(ID) && TextBox2.Text.Equals(password))
                {
                    Session["ID"] = ID;

                    ArrayList BList = new ArrayList();
                    using (SqlConnection con = new
        SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
        "nspjConnectionString"].ConnectionString))
                    {
                        
                        String bquery = "SELECT MarkedPeople FROM[nspj].[dbo].[Bookmark] where EmployerID = @a ";
                        SqlCommand cmd1 = new SqlCommand(bquery, connection);
                        cmd1.Parameters.AddWithValue("@a", (String)Session["ID"]);
                        using (SqlDataReader dr = cmd1.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {

                                    BList.Add(dr["MarkedPeople"].ToString());
                                }
                            }

                        }

                        
                        Session["BookmarkList"] = ArrayListToString(ref BList);

                    }

                    Response.Redirect("Default.aspx");
                }
                else
                    MsgBox("Login failed.Please try again!");
            }
            



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
    }
}