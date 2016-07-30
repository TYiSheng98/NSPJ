using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSPJ
{
    public partial class test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                filldropdown();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MsgBox("jhello");

        }
        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }

        public void filldropdown()
        {
            using (SqlConnection connection = new
SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
"nspjConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select CompanyName from [nspj].[dbo].[Company]", connection);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DropDownList1.Items.Clear();
                if (dr.HasRows)
                {
                    //TextBox3.DataSource = dr["EmpID"].ToString();
                    //TextBox3.DataBind();

                    while (dr.Read())
                    {
                        DropDownList1.Items.Add(dr["CompanyName"].ToString());
                    }
                }
                connection.Close();
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Label1.Text = DropDownList2.SelectedIndex.ToString();
        }
    }
}