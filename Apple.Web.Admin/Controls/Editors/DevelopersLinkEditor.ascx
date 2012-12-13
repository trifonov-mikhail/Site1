<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DevelopersLinkEditor.ascx.cs" 
Inherits="Apple.Web.Admin.Controls.DevelopersLinkEditor" %>

<%@ Register TagPrefix="uc" TagName="HtmlEditor" Src="~/Controls/HtmlEditor.ascx" %>

<asp:DetailsView ID="DetailsViewEditItem" runat="server" 
    DataKeyNames="LangCode,GroupID" DataSourceID="ObjectDataSourceEditItem" DefaultMode="Edit"
    Height="50px" Width="800px" OnDataBound="DetailsViewEditItem_DataBound" OnItemInserting="DetailsViewEditItem_ItemInserting"
    OnItemUpdating="DetailsViewEditItem_ItemUpdating" AutoGenerateRows="False">
    <CommandRowStyle HorizontalAlign="Right" />
    <Fields>
        <asp:TemplateField HeaderText="Адрес ссылки" SortExpression="LinkUrl">
            <EditItemTemplate>
                <asp:TextBox ID="LinkUrl" runat="server" Text='<%# Bind("LinkUrl") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Текст ссылки" SortExpression="LinkText">
            <EditItemTemplate>
                <asp:TextBox ID="LinkText" runat="server" Text='<%# Bind("LinkText") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Текст" SortExpression="Text">
            <EditItemTemplate>
                <%--<uc:HtmlEditor ID="editor" runat="server" Text='<%# Bind("Text") %>' />--%>
                <asp:TextBox ID="TextBox1" TextMode="MultiLine" SkinID="TextArea" Text='<%# Bind("Text") %>' runat="server"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
    </Fields>
    <FieldHeaderStyle VerticalAlign="Top" Width="120px" />
</asp:DetailsView>
<asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" SelectMethod="GetByLangGroup" 
TypeName="Erc.Apple.Data.DevelopersLinks" 
OnSelecting="ObjectDataSourceEditItem_Selecting" 
OldValuesParameterFormatString="original_{0}" 
DataObjectTypeName="Erc.Apple.Data.DevelopersLink" 
InsertMethod="Add" 
UpdateMethod="Update" 
OnSelected="ObjectDataSourceEditItem_Selected">
    <SelectParameters>
        <asp:Parameter Name="language" Type="String" />
        <asp:Parameter Name="groupId" Type="Int32" />
    </SelectParameters>    
</asp:ObjectDataSource>
