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
        private Boolean InsertUpdateData(SqlCommand cmd)
        {
            String strConnString = System.Configuration.ConfigurationManager
            .ConnectionStrings["nspjConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Read the file and convert it to Byte Array
            string filePath = FileUpload1.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;

            //Set the contenttype based on File Extension
            switch (ext)
            {
               
                case ".jpg":
                    contenttype = "Resources/jpg";
                    break;
                case ".png":
                    contenttype = "Resources/png";
                    break;
                case ".gif":
                    contenttype = "Resources/gif";
                    break;
                
            }
            if (contenttype != String.Empty)
            {

                Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                //insert the file into database
                string strQuery = "insert into [imagetest](Image)" +
                   " values (@data)";
                SqlCommand cmd = new SqlCommand(strQuery);
                
                cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
                InsertUpdateData(cmd);
                Label1.ForeColor = System.Drawing.Color.Green;
                Label1.Text = "File Uploaded Successfully";
            }
            else
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "File format not recognised." +
                  " Upload Image/Word/PDF/Excel formats";
            }
        }
    }
}