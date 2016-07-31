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
            if (IsPostBack)
            {
                
                string q= Request["__EVENTTARGET"];
                if (q == "lol")
                {
                    string parameter = Request["__EVENTARGUMENT"]; // parameter
                    Label1.Text = parameter;
                }
            }
        }

    }

        

       
    
}
