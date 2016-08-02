using System;
using System.Collections.Generic;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            //    // Read the file and convert it to Byte Array
            //    string filePath = FileUpload1.PostedFile.FileName;
            //    string filename = Path.GetFileName(filePath);
            //    string ext = Path.GetExtension(filename);
            //    string contenttype = String.Empty;

            //    //Set the contenttype based on File Extension
            //    switch (ext)
            //    {
            //        case ".doc":
            //            contenttype = "application/vnd.ms-word";
            //            break;
            //        case ".docx":
            //            contenttype = "application/vnd.ms-word";
            //            break;
            //        case ".xls":
            //            contenttype = "application/vnd.ms-excel";
            //            break;
            //        case ".xlsx":
            //            contenttype = "application/vnd.ms-excel";
            //            break;
            //        case ".jpg":
            //            contenttype = "image/jpg";
            //            break;
            //        case ".png":
            //            contenttype = "image/png";
            //            break;
            //        case ".gif":
            //            contenttype = "image/gif";
            //            break;
            //        case ".pdf":
            //            contenttype = "application/pdf";
            //            break;
            //    }
            //    if (contenttype != String.Empty)
            //    {

            //        Stream fs = FileUpload1.PostedFile.InputStream;
            //        BinaryReader br = new BinaryReader(fs);
            //        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

            //        //insert the file into database
            //        string strQuery = "insert into tblFiles(Name, ContentType, Data)" +
            //           " values (@Name, @ContentType, @Data)";
            //        SqlCommand cmd = new SqlCommand(strQuery);
            //        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename;
            //        cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value
            //          = contenttype;
            //        cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
            //        InsertUpdateData(cmd);
            //        Label1.ForeColor = System.Drawing.Color.Green;
            //        Label1.Text = "File Uploaded Successfully";
            //    }
            //    else
            //    {
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //        Label1.Text = "File format not recognised." +
            //          " Upload Image/Word/PDF/Excel formats";
            //    }
        }
    }
}