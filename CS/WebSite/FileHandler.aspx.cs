using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public partial class Grid_Editing_ImageUpload_FileHandler : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!string.IsNullOrEmpty(Request.Params["PictureID"])) {
            PostImage(Request.Params["PictureID"], HttpContext.Current);
        }
    }
    void PostImage(string id, HttpContext context) {
        int val = -1;
        int.TryParse(id, out val);
        byte[] image = FindImage(val);
        WriteBinaryImage(image, context);
    }
    void WriteBinaryImage(byte[] image, HttpContext context) {
        if (image != null) {
            context.Response.ContentType = "image/jpeg";
            using (MemoryStream ms = new MemoryStream(image)) {
                using (Bitmap bmp = (Bitmap)Bitmap.FromStream(ms)) {
                    bmp.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                }
            }
        } else {
            context.Response.ContentType = "image/gif";
        }
        context.Response.End();
    }
    byte[] FindImage(int id) {
        return DxUserSessionProvider.GetImageBytes(id);
    }
}
