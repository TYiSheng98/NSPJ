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
            String q = (String)Session["BookmarkList"];
            String [] blist = q.Split('~');

            ArrayList List1 = new ArrayList();
            ArrayList List2 = new ArrayList();
           
            
            String query = "";
            using (SqlConnection connection = new
SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
"nspjConnectionString"].ConnectionString))
            {
                connection.Open();
                
        query = " SELECT [Industry],[Skill] FROM[nspj].[dbo].[User] where Name = @c ";
                
                SqlCommand cmd = new SqlCommand(query, connection);
                foreach (String people in blist) {
                    cmd.Parameters.AddWithValue("@c", people);
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

        }

        protected void Status1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Bookmarks2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void History3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
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