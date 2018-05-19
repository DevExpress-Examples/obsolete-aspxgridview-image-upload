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
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxUploadControl;
using System.Collections.Specialized;
using DevExpress.Web.ASPxTabControl;
using DevExpress.Web.ASPxEditors;

public partial class Grid_Editing_ImageUpload_ImageUpload : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
    }
    protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e) {
        ASPxGridView grid = sender as ASPxGridView;
        ASPxTextBox textBox = FindPageControl(grid).FindControl("txbDesc") as ASPxTextBox;
        e.NewValues["Description"] = textBox.Text;
        e.Cancel = !SaveFileBytesToRow(grid, e.NewValues);
    }
    protected void ASPxUploadControl1_FileUploadComplete(object sender, FileUploadCompleteEventArgs e) {
        if ((sender as ASPxUploadControl).IsValid)
            Session["data"] = (sender as ASPxUploadControl).FileBytes;
    }

    protected bool SaveFileBytesToRow(ASPxGridView grid, OrderedDictionary newValues) {
        bool ret = true;
        if (Session["data"] != null) {
            newValues["Bytes"] = Session["data"];//uploader.FileBytes;
            Session.Remove("data");
        } else
            ret = false;
        return ret;
    }

    ASPxPageControl FindPageControl(ASPxGridView grid) {
        return grid.FindEditFormTemplateControl("pageControl") as ASPxPageControl;
    }
}
