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
    public partial class WebForm3 : System.Web.UI.Page
    {
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
                if (k == 1)
                {
                    query = " SELECT * FROM[nspj].[dbo].[User] where Skill like '%' + @c + '%' ";

                }
                else if (k == 2)
                {
                    query = " SELECT * FROM[nspj].[dbo].[User] where Industry like '%' + @c + '%'";
                }
                else
                {
                    query = " SELECT * FROM[nspj].[dbo].[User] where Name like '%' + @c + '%' or Industry like '%' + @c + '%' or Skill like '%' + @c + '%' ";
                }
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@c", a);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            NList.Add(rdr["Name"].ToString());
                            IList.Add(rdr["Industry"].ToString());
                            SList.Add(rdr["Skill"].ToString());
                        }
                    }

                }

                connection.Close();
            }
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Industry", typeof(string)));
            dt.Columns.Add(new DataColumn("Skill", typeof(string)));
           
            for (int i = 0; i < NList.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = NList[i];
                dr["Industry"] = IList[i];
                dr["Skill"] = SList[i];
                dt.Rows.Add(dr);
            }
            this.GridView1.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}