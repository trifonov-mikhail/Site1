<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuccessStoryEditor.ascx.cs" 
Inherits="Apple.Web.Admin.Controls.SuccessStoryEditor" %>

<%@ Register TagPrefix="uc" TagName="HtmlEditor" Src="~/Controls/HtmlEditor.ascx" %>

<asp:DetailsView ID="DetailsViewEditItem" runat="server" 
    DataKeyNames="LangCode,GroupID" DataSourceID="ObjectDataSourceEditItem" DefaultMode="Edit"
    Height="50px" Width="800px" OnDataBound="DetailsViewEditItem_DataBound" OnItemInserting="DetailsViewEditItem_ItemInserting"
    OnItemUpdating="DetailsViewEditItem_ItemUpdating" AutoGenerateRows="False">
    <CommandRowStyle HorizontalAlign="Right" />
    <Fields>
        <asp:TemplateField HeaderText="Название" SortExpression="Title">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Текст" SortExpression="Text">
            <EditItemTemplate>
                <uc:HtmlEditor ID="editor" runat="server" Text='<%# Bind("Text") %>' />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Pdf файл">
            <EditItemTemplate>
                <asp:FileUpload ID="fuImage" runat="server" />
                <table border="0" cellspacing="0">
                     <tr>
                        <td>
                            <asp:Button Visible=false ID="PdfName" runat="server" />
                            <%--<img height="55" alt='Image' src='<%=this.ResolveUrl("~/GetImage.ashx?type=8&id="+this.GroupID) %>' />--%>                                    
                        </td>
                        <td>
                            <asp:ImageButton ImageUrl="~/img/Delete.png" ID="btnDeletePdfFile" runat="server" OnClick="btnDeletePdfFile_Click"
                                Visible="false" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:TemplateField>
        
    </Fields>
    <FieldHeaderStyle VerticalAlign="Top" Width="120px" />
</asp:DetailsView>
<asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" SelectMethod="GetByLangGroup" 
TypeName="Erc.Apple.Data.SuccessStories" 
OnSelecting="ObjectDataSourceEditItem_Selecting" 
OldValuesParameterFormatString="original_{0}" 
DataObjectTypeName="Erc.Apple.Data.SuccessStory" 
InsertMethod="Add" 
UpdateMethod="Update" 
OnSelected="ObjectDataSourceEditItem_Selected">
    <SelectParameters>
        <asp:Parameter Name="language" Type="String" />
        <asp:Parameter Name="groupId" Type="Int32" />
    </SelectParameters>    
</asp:ObjectDataSource>
