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
            HiddenField1.Value = ArrayListToString(ref NList);
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


        } //endpage load
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
//}