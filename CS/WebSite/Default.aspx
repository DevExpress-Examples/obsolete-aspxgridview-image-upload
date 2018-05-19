<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Grid_Editing_ImageUpload_ImageUpload" %>
<%@ Register Assembly="DevExpress.Web.v8.1" Namespace="DevExpress.Web.ASPxClasses"
    TagPrefix="dxw" %>
<%@ Register Assembly="DevExpress.Web.v8.1" Namespace="DevExpress.Web.ASPxUploadControl"
    TagPrefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v8.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v8.1" Namespace="DevExpress.Web.ASPxTabControl"
    TagPrefix="dxtc" %>  
    

    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Image Upload in ASPxGridView</title>
    <script type="text/javascript">
        function OnUpdateClick() {
            uploader.UploadFile();            
        }
    </script>
    <style type="text/css">
        .note {
            color: black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        
		<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="DxUserEntry"
					DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Select" TypeName="DxUserSessionProvider"
					UpdateMethod="Update">
        </asp:ObjectDataSource>
        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
            DataSourceID="ObjectDataSource1" KeyFieldName="ID" Width="369px" OnRowInserting="ASPxGridView1_RowInserting" ClientInstanceName="grid">
            <Columns>
                <dxwgv:GridViewCommandColumn VisibleIndex="0">
                    <ClearFilterButton Visible="True">
                    </ClearFilterButton>
                    <NewButton Visible="True">
                    </NewButton>
                </dxwgv:GridViewCommandColumn>
                <dxwgv:GridViewDataTextColumn FieldName="Description" VisibleIndex="1">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn Caption="Image" Name="Image" VisibleIndex="2">
                    <DataItemTemplate>
                        <dxe:ASPxImage ID="ASPxImage1" runat="server" ImageUrl='<%# "FileHandler.aspx?PictureID=" + Eval("ID") %>'>
                        </dxe:ASPxImage>
                    </DataItemTemplate>
                </dxwgv:GridViewDataTextColumn>
            </Columns>
            <Templates>
                <EditForm>
                    <div style="padding: 4px 4px 3px 4px">
                        <dxtc:ASPxPageControl runat="server" ID="pageControl" Width="100%" Height="140px"
                            ActiveTabIndex="1">
                            <TabPages>
                                <dxtc:TabPage Text="General">
                                    <ContentCollection>
                                        <dxw:contentcontrol runat="server">
                                            <dxe:ASPxLabel ID="lblDesc" runat="server" Width="170px" Text="Description:">
                                            </dxe:ASPxLabel>
                                            <dxe:ASPxTextBox ID="txbDesc" runat="server" Width="170px" Text='<%# Eval("Description") %>'>
                                            </dxe:ASPxTextBox>
                                        </dxw:contentcontrol>
                                    </ContentCollection>
                                </dxtc:TabPage>
                                <dxtc:TabPage Text="Foto">
                                    <ContentCollection>
                                        <dxw:contentcontrol runat="server">
                                            <table border="0" cellpadding="0" cellspacing="0" id="Table1">
                                                <tr>
                                                    <td valign="top" align="center" class="content">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="center" style="padding-right: 20px; vertical-align: top;">
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td style="white-space:nowrap; padding-right: 5px;">
                                                                                <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Select Image:" AssociatedControlID="uplImage">
                                                                                </dxe:ASPxLabel>
                                                                            </td>
                                                                            <td>
                                                                              <dxuc:ASPxUploadControl runat="server" ClientInstanceName="uploader" Size="35" ID="ASPxUploadControl1" OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete">
                                                                                    <ValidationSettings AllowedFileExtensions=".jpg,.jpeg,.jpe" MaxFileSize="4000000">
                                                                                    </ValidationSettings>
                                                                                    <ClientSideEvents FileUploadComplete="function(s, e) { if (e.isValid) { grid.UpdateEdit(); }}" />
                                                                                </dxuc:ASPxUploadControl>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td class="note">
                                                                                <dxe:ASPxLabel ID="ASPxLabel2" runat="server" Text="Allowed ContentTypes: image/jpeg"
                                                                                    Font-Size="8pt">
                                                                                </dxe:ASPxLabel>
                                                                                <br />
                                                                                <dxe:ASPxLabel ID="ASPxLabel3" runat="server" Text="Maximum file size: 4Mb" Font-Size="8pt">
                                                                                </dxe:ASPxLabel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </dxw:contentcontrol>
                                    </ContentCollection>
                                </dxtc:TabPage>
                            </TabPages>
                        </dxtc:ASPxPageControl>
                    </div>
                    <div style="text-align: right; padding: 2px 2px 2px 2px">
                        <a href="#" onclick="OnUpdateClick()">Update</a>
                        <dxwgv:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton"
                            runat="server">
                        </dxwgv:ASPxGridViewTemplateReplacement>
                    </div>
                </EditForm>
            </Templates>
        </dxwgv:ASPxGridView>
        <br/>
         <span class="note">Note: Uploading image file maximum size is 4096Kb</span>
    </form>
</body>
</html>
