using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class GridData {
    public GridData() {

    }
    public GridData(int employeeID, string firstName, string lastName, Byte[] photo) {
        EmployeeID = employeeID;
        FirstName = firstName;
        LastName = lastName;
        Photo = photo;
    }
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Byte[] Photo { get; set; }
}