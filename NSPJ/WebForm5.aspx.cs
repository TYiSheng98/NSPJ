using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSPJ
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void confirm_Click(object sender, EventArgs e)
        {
            Panel p = new Panel();
            Label header = new Label();
            header.Text = "Please enter Your current password below !";
            p.Controls.Add(header);
            System.Web.UI.HtmlControls.HtmlGenericControl linebreak = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            linebreak.ID = "createDiv";
            p.Controls.Add(linebreak);
            Label l = new Label();
            l.Text = "Password:";
            p.Controls.Add(l);
            TextBox txt = new TextBox();
            txt.ID = "textBox1";
            p.Controls.Add(txt);
            
            PlaceHolder1.Controls.Add(p);
            ScriptManager.RegisterStartupScript(Page,Page.GetType(), "myModal", "$('#myModal').modal();",true);
        }
        protected void va(object sender, EventArgs e)
        {
            MsgBox("tttt");
        }
        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }

    }
}