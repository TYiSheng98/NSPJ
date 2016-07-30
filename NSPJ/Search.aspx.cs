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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var eventTarget = Request.Form["__EVENTTARGET"].ToString();
            
            if (eventTarget == "lol")
            {
                string parameter = Request["__EVENTARGUMENT"];
                Label1.Text = parameter;
               
            }
        }

    }

        

       
    
}
