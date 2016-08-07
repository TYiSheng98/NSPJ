using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NSPJ
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            test();
            if (IsPostBack)
            {
                test();
            }
            
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            Button selected = (Button)sender;

            selected.Enabled = false;
            String id = selected.ID;
            selected.Text = "Added!";

        }
        protected void test()
        {
            string[] itemList = new string[] { "1", "2", "3" };
            foreach (string item in itemList)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");

                li.Attributes.Add("id", item);

                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("id", item);
                div.Attributes.Add("class", "a");

                Button btnSave = new Button();
                btnSave.ID = item;
                btnSave.Text = "Add to bookmarks";
                //btnSave.Attributes.Add("onclick", "return false;");
                //btnSave.Attributes.Add("OnClick", "btnSave_Click");
                btnSave.OnClientClick = "addAnother(" + btnSave.ID + ");return false;";
                btnSave.Attributes.Add("class", "btn btn-info Button2");
                div.Controls.Add(btnSave);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "myFunction", "addAnother()", true);

                //HtmlGenericControl btn = new HtmlGenericControl("INPUT");
                //btn.Attributes.Add("id", item);
                //btn.Attributes.Add("type", "button");
                //btn.Attributes.Add("class", "btn btn-info Button2");
                //btn.Attributes.Add("value", "Add to bookmark");
                ////btn.Attributes.Add("oncl")

                HtmlGenericControl linebreak = new HtmlGenericControl("br");

                HtmlGenericControl a = new HtmlGenericControl("a");
                div.Attributes.Add("id", item);
                div.Attributes.Add("href", "UserProfile.aspx");
                div.Controls.Add(a);

                HtmlGenericControl h1 = new HtmlGenericControl("h1");
                h1.InnerText = item;
                h1.Controls.Add(a);
                div.Controls.Add(h1);

                HtmlGenericControl h5 = new HtmlGenericControl("h5");
                h5.InnerText = item;
                div.Controls.Add(h5);



                li.Controls.Add(div);
                list.Controls.Add(li);
            }
        }
    }
}