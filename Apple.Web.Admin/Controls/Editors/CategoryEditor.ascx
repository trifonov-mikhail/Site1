﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryEditor.ascx.cs" 
Inherits="Apple.Web.Admin.Controls.CategoryEditor" %>

<asp:DetailsView ID="DetailsViewEditItem" runat="server" 
    DataKeyNames="LangCode,GroupID" DataSourceID="ObjectDataSourceEditItem" DefaultMode="Edit"
    Height="50px" Width="300px" OnDataBound="DetailsViewEditItem_DataBound" OnItemInserting="DetailsViewEditItem_ItemInserting" AutoGenerateRows="False">
    <CommandRowStyle HorizontalAlign="Right" />
    <Fields>
        <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Название" SortExpression="Name">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
    </Fields>
</asp:DetailsView>
<asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" SelectMethod="GetByLangGroup" TypeName="Erc.Apple.Data.Categories" OnSelecting="ObjectDataSourceEditItem_Selecting" OldValuesParameterFormatString="original_{0}" DataObjectTypeName="Erc.Apple.Data.Category" InsertMethod="AddUpdate" UpdateMethod="AddUpdate" OnSelected="ObjectDataSourceEditItem_Selected">
    <SelectParameters>
        <asp:Parameter Name="language" Type="String" />
        <asp:Parameter Name="groupId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
