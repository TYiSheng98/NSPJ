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
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Welcome back, " + (String)Session["ID"];
            
        }      

        protected void SearchButton_Click1(object sender, EventArgs e)
        {


            Response.Redirect("q.aspx?query=" + querystring.Text + "&cat=" + SearchList.SelectedIndex);
        }
        

    }
}