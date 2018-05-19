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
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Partial Public Class Grid_Editing_ImageUpload_FileHandler
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not String.IsNullOrEmpty(Request.Params("PictureID"))) Then
			PostImage(Request.Params("PictureID"), HttpContext.Current)
		End If
	End Sub
	Private Sub PostImage(ByVal id As String, ByVal context As HttpContext)
		Dim val As Integer = -1
		Integer.TryParse(id, val)
		Dim image As Byte() = FindImage(val)
		WriteBinaryImage(image, context)
	End Sub
	Private Sub WriteBinaryImage(ByVal image As Byte(), ByVal context As HttpContext)
		If Not image Is Nothing Then
			context.Response.ContentType = "image/jpeg"
			Using ms As MemoryStream = New MemoryStream(image)
				Using bmp As Bitmap = CType(Bitmap.FromStream(ms), Bitmap)
					bmp.Save(context.Response.OutputStream, ImageFormat.Jpeg)
				End Using
			End Using
		Else
			context.Response.ContentType = "image/gif"
		End If
		context.Response.End()
	End Sub
	Private Function FindImage(ByVal id As Integer) As Byte()
		Return DxUserSessionProvider.GetImageBytes(id)
	End Function
End Class
