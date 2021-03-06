﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LatestProductEditor.ascx.cs" 
Inherits="Apple.Web.Admin.Controls.LatestProductEditor" %>

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
        <asp:TemplateField HeaderText="Адрес ссылки" SortExpression="LinkUrl">
            <EditItemTemplate>
                <asp:TextBox ID="LinkUrl" runat="server" Text='<%# Bind("LinkUrl") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <%--<asp:TemplateField HeaderText="Текст ссылки" SortExpression="LinkText">
            <EditItemTemplate>
                <asp:TextBox ID="LinkText" runat="server" Text='<%# Bind("LinkText") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>--%>
        <%--<asp:TemplateField HeaderText="Адрес загрузки" SortExpression="Link2Url">
            <EditItemTemplate>
                <asp:TextBox ID="Link2Url" runat="server" Text='<%# Bind("Link2Url") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Текст загрузки" SortExpression="Link2Text">
            <EditItemTemplate>
                <asp:TextBox ID="Link2Text" runat="server" Text='<%# Bind("Link2Text") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Анонс" SortExpression="Notice">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" TextMode="MultiLine" SkinID="TextArea" runat="server" Text='<%# Bind("Notice") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Текст" SortExpression="Text">
            <EditItemTemplate>
                <uc:HtmlEditor ID="editor" runat="server" Text='<%# Bind("Text") %>' />
            </EditItemTemplate>
        </asp:TemplateField>
    </Fields>
    <FieldHeaderStyle VerticalAlign="Top" Width="120px" />
</asp:DetailsView>
<asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" SelectMethod="GetByLangGroup" 
TypeName="Erc.Apple.Data.LatestProducts" 
OnSelecting="ObjectDataSourceEditItem_Selecting" 
OldValuesParameterFormatString="original_{0}" 
DataObjectTypeName="Erc.Apple.Data.LatestProduct" 
InsertMethod="Add" 
UpdateMethod="Update" 
OnSelected="ObjectDataSourceEditItem_Selected">
    <SelectParameters>
        <asp:Parameter Name="language" Type="String" />
        <asp:Parameter Name="groupId" Type="Int32" />
    </SelectParameters>    
</asp:ObjectDataSource>
