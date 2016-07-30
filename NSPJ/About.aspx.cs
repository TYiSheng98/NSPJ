using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSPJ
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //MultiView1.ActiveViewIndex = 0;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //MultiView1.ActiveViewIndex = 1;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String query = "";
            using (SqlConnection connection = new
SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
"nspjConnectionString"].ConnectionString))
            {
                connection.Open();
                if (DropDownList1.SelectedIndex == 1)
                {
                    query = " SELECT * FROM[nspj].[dbo].[User] where Skill like '%' + @c + '%' ";
                    
                }
                else if (DropDownList1.SelectedIndex == 2)
                {
                    query = " SELECT * FROM[nspj].[dbo].[User] where Industry like '%' + @c + '%'";
                }
                else
                {
                    query = " SELECT * FROM[nspj].[dbo].[User] where Name like '%' + @c + '%' or Industry like '%' + @c + '%' or Skill like '%' + @c + '%' ";
                }
                    SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@c", SearchTextBox.Text);
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
