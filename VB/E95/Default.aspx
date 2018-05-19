<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" KeyFieldName="EmployeeID">
                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="EmployeeID" VisibleIndex="1" ReadOnly="true">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="FirstName" VisibleIndex="2"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="LastName" VisibleIndex="3"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataBinaryImageColumn FieldName="Photo" VisibleIndex="4">
                        <PropertiesBinaryImage ImageHeight="170px" ImageWidth="160px">
                            <EditingSettings Enabled="true" UploadSettings-UploadValidationSettings-MaxFileSize="4194304"
                                UploadSettings-UploadValidationSettings-AllowedFileExtensions=".jpg,.png" />
                        </PropertiesBinaryImage>
                    </dx:GridViewDataBinaryImageColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="GridData"
                DeleteMethod="DeleteFromGridDataSet"
                InsertMethod="InsertToGridDataSet" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetGridDataSet" TypeName="GridDataHelper"
                UpdateMethod="UpdateGridDataSet"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>