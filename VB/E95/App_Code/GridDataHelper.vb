Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Web

<DataObject(True)> _
Public Class GridDataHelper

    Private gridDataSet_Renamed As List(Of GridData)
    Public ReadOnly Property GridDataSet() As List(Of GridData)
        Get
            If (HttpContext.Current.Session("DataSet") Is Nothing) Then
                HttpContext.Current.Session("DataSet") = CreateDataset()
                Return gridDataSet_Renamed
            Else
                Return CType(HttpContext.Current.Session("DataSet"), List(Of GridData))
            End If
        End Get
    End Property
    Private img1() As Byte = System.IO.File.ReadAllBytes(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/Nancy.jpg"))
    Private img2() As Byte = System.IO.File.ReadAllBytes(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/Andrew.jpg"))
    Private img3() As Byte = System.IO.File.ReadAllBytes(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/Janet.jpg"))
    Public Function CreateDataset() As List(Of GridData)
        gridDataSet_Renamed = New List(Of GridData)()
        gridDataSet_Renamed.Add(New GridData(1, "Nancy", "Davolio", img1))
        gridDataSet_Renamed.Add(New GridData(2, "Andrew", "Fuller", img2))
        gridDataSet_Renamed.Add(New GridData(3, "Janet", "Leverling", img3))
        Return gridDataSet_Renamed
    End Function
    <DataObjectMethod(DataObjectMethodType.Select, True)> _
    Public Function GetGridDataSet() As List(Of GridData)
        Return GridDataSet
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Sub UpdateGridDataSet(ByVal gridData As GridData)
        Dim ID As Integer = gridData.EmployeeID
        Dim firstName As String = gridData.FirstName
        Dim lastName As String = gridData.LastName
        Dim photo() As Byte = gridData.Photo
        For Each item In GridDataSet
            If item.EmployeeID = ID Then
                item.FirstName = firstName
                item.LastName = lastName
                item.Photo = photo
                Exit For
            End If
        Next item
    End Sub
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Sub DeleteFromGridDataSet(ByVal gridData As GridData)
        Dim employeeID As Integer = gridData.EmployeeID
        Dim tmp As New List(Of GridData)(GridDataSet)
        For Each item In tmp
            If item.EmployeeID = employeeID Then
                GridDataSet.Remove(item)
            End If
        Next item
    End Sub
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Sub InsertToGridDataSet(ByVal gridData As GridData)
        Dim last As GridData = GridDataSet.ElementAt(GridDataSet.Count - 1)
        Dim employeeID As Integer = last.EmployeeID + 1
        Dim firstName As String = gridData.FirstName
        Dim lastName As String = gridData.LastName
        Dim photo() As Byte = gridData.Photo
        Dim newEmployee As New GridData(employeeID, firstName, lastName, photo)
        GridDataSet.Add(newEmployee)
    End Sub
End Class