using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSPJ
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            var a = Request.QueryString["query"];
            //var q = Cipher.Decrypt(a, "test");
            var c = Request.QueryString["cat"];
            int k= Convert.ToInt32(c);
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
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }

                connection.Close();
            }

        }

       
       
    }
}