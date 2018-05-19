Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data

Public Class DxUserEntry
	Private id_Renamed As Integer
	Private description_Renamed As String
	Private bytes_Renamed As Byte()

	Public Property ID() As Integer
		Get
			Return id_Renamed
		End Get
		Set(ByVal value As Integer)
			id_Renamed = value
		End Set
	End Property
	Public Property Description() As String
		Get
			Return description_Renamed
		End Get
		Set(ByVal value As String)
			description_Renamed = value
		End Set
	End Property
	Public Property Bytes() As Byte()
		Get
			Return bytes_Renamed
		End Get
		Set(ByVal value As Byte())
			bytes_Renamed = value
		End Set
	End Property

	Public Sub Assign(ByVal source As DxUserEntry)
		Description = source.Description
		Bytes = source.Bytes
	End Sub
End Class

Public Class DxUserSessionProvider
	Private Const Key As String = "DxUserSessionProvider"

	Private Sub New()
	End Sub
	Private Shared ReadOnly Property Session() As HttpSessionState
		Get
			Return HttpContext.Current.Session
		End Get
	End Property
	Private Shared ReadOnly Property Data() As List(Of DxUserEntry)
		Get
			If Session(Key) Is Nothing Then
				Restore()
			End If
			Return TryCast(Session(Key), List(Of DxUserEntry))
		End Get
	End Property

	Public Shared Function [Select]() As IEnumerable(Of DxUserEntry)
		Return Data
	End Function
	Public Shared Sub Insert(ByVal item As DxUserEntry)
		Data.Add(item)
		item.ID = Data.Count
	End Sub
	Public Shared Sub Update(ByVal item As DxUserEntry)
		Dim storedItem As DxUserEntry = FindItem(item.ID)
		storedItem.Assign(item)
	End Sub
	Public Shared Sub Delete(ByVal item As DxUserEntry)
		Dim storedItem As DxUserEntry = FindItem(item.ID)
		Data.Remove(storedItem)
	End Sub
	Public Shared Sub Restore()
		Session(Key) = New List(Of DxUserEntry)()
	End Sub

	Public Shared Function GetImageBytes(ByVal key As Integer) As Byte()
		Dim storedItem As DxUserEntry = FindItem(key)
		If Not storedItem Is Nothing Then
			Return storedItem.Bytes
		Else
			Return Nothing
		End If
	End Function
	Private Shared Function FindItem(ByVal id As Integer) As DxUserEntry
		For Each item As DxUserEntry In Data
			If item.ID = id Then
				Return item
			End If
		Next item
		Return Nothing
	End Function
End Class
