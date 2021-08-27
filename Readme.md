<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/134059882/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E95)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [SessionDataSource.cs](./CS/WebSite/App_Code/Grid/Editing/SessionDataSource.cs) (VB: [SessionDataSource.vb](./VB/WebSite/App_Code/Grid/Editing/SessionDataSource.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
* [FileHandler.aspx](./CS/WebSite/FileHandler.aspx) (VB: [FileHandler.aspx](./VB/WebSite/FileHandler.aspx))
* [FileHandler.aspx.cs](./CS/WebSite/FileHandler.aspx.cs) (VB: [FileHandler.aspx.vb](./VB/WebSite/FileHandler.aspx.vb))
<!-- default file list end -->
# OBSOLETE - Image Upload in ASPxGridView
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e95)**
<!-- run online end -->


<p><strong>UPDATED:</strong><br /><br />Starting with version v2015 vol 1 (v15.1), this functionality is available out of the box. Simply set the <strong>GridViewDataBinaryImageColumn.PropertiesBinaryImage.EditingSettings.Enabled</strong> property to True to activate it. Please refer to the <a href="https://community.devexpress.com/blogs/aspnet/archive/2015/05/28/asp-net-data-grid-binary-image-editor-coming-soon-in-v15-1.aspx">ASP.NET Data Grid - Binary Image Editor (Coming soon in v15.1)</a> blog post and the <a href="http://demos.devexpress.com/ASPxGridViewDemos/GridEditing/BinaryImageColumnEditing.aspx">Binary Image Column Editing</a> demo for more information.<br /><br />If you have version v15.1+ available, consider using the built-in functionality instead of the approach detailed below.<br /><br />The ASPxUploadControl can be used within the ASPxGridView's Edit Form to upload image files to the grid's bound database. In the online sample, the grid's data is stored within the Session object and is obtained/modified by using the ObjectDataSource component.</p>
<p>The project version that employs a SqlDataSource component is also provided in a separate zip file within the example folder.</p>
<p><strong>See also:</strong><br /> <a href="https://www.devexpress.com/Support/Center/p/E1414">How to bind the ASPxBinaryImage to a field which contains image data stored as OLE object</a><br /> <a href="https://www.devexpress.com/Support/Center/p/E2933">OBSOLETE - Inserting a new row in ASPxGridView with the image preview enabled</a></p>

<br/>


