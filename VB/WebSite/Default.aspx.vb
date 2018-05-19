Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxUploadControl
Imports System.Collections.Specialized
Imports DevExpress.Web.ASPxTabControl
Imports DevExpress.Web.ASPxEditors

Partial Public Class Grid_Editing_ImageUpload_ImageUpload
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
	End Sub
	Protected Sub ASPxGridView1_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
		Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
		Dim textBox As ASPxTextBox = TryCast(FindPageControl(grid).FindControl("txbDesc"), ASPxTextBox)
		e.NewValues("Description") = textBox.Text
		e.Cancel = Not SaveFileBytesToRow(grid, e.NewValues)
	End Sub
	Protected Sub ASPxUploadControl1_FileUploadComplete(ByVal sender As Object, ByVal e As FileUploadCompleteEventArgs)
		If (TryCast(sender, ASPxUploadControl)).IsValid Then
			Session("data") = (TryCast(sender, ASPxUploadControl)).FileBytes
		End If
	End Sub

	Protected Function SaveFileBytesToRow(ByVal grid As ASPxGridView, ByVal newValues As OrderedDictionary) As Boolean
		Dim ret As Boolean = True
		If Not Session("data") Is Nothing Then
			newValues("Bytes") = Session("data") 'uploader.FileBytes;
			Session.Remove("data")
		Else
			ret = False
		End If
		Return ret
	End Function

	Private Function FindPageControl(ByVal grid As ASPxGridView) As ASPxPageControl
		Return TryCast(grid.FindEditFormTemplateControl("pageControl"), ASPxPageControl)
	End Function
End Class
