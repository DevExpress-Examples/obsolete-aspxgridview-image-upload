Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class GridData
    Public Sub New()

    End Sub
    Public Sub New(ByVal employeeID As Integer, ByVal firstName As String, ByVal lastName As String, ByVal photo() As Byte)
        Me.EmployeeID = employeeID
        Me.FirstName = firstName
        Me.LastName = lastName
        Me.Photo = photo
    End Sub
    Public Property EmployeeID() As Integer
    Public Property FirstName() As String
    Public Property LastName() As String
    Public Property Photo() As Byte()
End Class