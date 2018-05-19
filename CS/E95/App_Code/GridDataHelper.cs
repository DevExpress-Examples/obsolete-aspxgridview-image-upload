using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

[DataObject(true)]
public class GridDataHelper {
    List<GridData> gridDataSet;
    public List<GridData> GridDataSet {
        get {
            if((HttpContext.Current.Session["DataSet"] == null)) {
                HttpContext.Current.Session["DataSet"] = CreateDataset();
                return gridDataSet;
            } else {
                return (List<GridData>)HttpContext.Current.Session["DataSet"];
            }
        }
    }
    byte[] img1 = System.IO.File.ReadAllBytes(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/Nancy.jpg"));
    byte[] img2 = System.IO.File.ReadAllBytes(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/Andrew.jpg"));
    byte[] img3 = System.IO.File.ReadAllBytes(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/Janet.jpg"));
    public List<GridData> CreateDataset() {
        gridDataSet = new List<GridData>();
        gridDataSet.Add(new GridData(1, "Nancy", "Davolio", img1));
        gridDataSet.Add(new GridData(2, "Andrew", "Fuller", img2));
        gridDataSet.Add(new GridData(3, "Janet", "Leverling", img3));
        return gridDataSet;
    }
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public List<GridData> GetGridDataSet() {
        return GridDataSet;
    }
    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public void UpdateGridDataSet(GridData gridData) {
        int ID = gridData.EmployeeID;
        string firstName = gridData.FirstName;
        string lastName = gridData.LastName;
        Byte[] photo = gridData.Photo;
        foreach(var item in GridDataSet) {
            if(item.EmployeeID == ID) {
                item.FirstName = firstName;
                item.LastName = lastName;
                item.Photo = photo;
                break;
            }
        }
    }
    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public void DeleteFromGridDataSet(GridData gridData) {
        int employeeID = gridData.EmployeeID;
        List<GridData> tmp = new List<GridData>(GridDataSet);
        foreach(var item in tmp) {
            if(item.EmployeeID == employeeID)
                GridDataSet.Remove(item);
        }
    }
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public void InsertToGridDataSet(GridData gridData) {
        GridData last = GridDataSet.ElementAt(GridDataSet.Count - 1);
        int employeeID = last.EmployeeID + 1;
        string firstName = gridData.FirstName;
        string lastName = gridData.LastName;
        Byte[] photo = gridData.Photo;
        GridData newEmployee = new GridData(employeeID, firstName, lastName, photo);
        GridDataSet.Add(newEmployee);
    }
}