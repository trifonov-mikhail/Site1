<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpecializationEditor.ascx.cs" 
Inherits="Apple.Web.Admin.Controls.SpecializationEditor" %>

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
        <asp:TemplateField HeaderText="Описание" SortExpression="Description">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" SkinID="TextArea" runat="server" Text='<%# Bind("Description") %>' TextMode="MultiLine"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
    </Fields>
</asp:DetailsView>
<asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" SelectMethod="GetByLangGroup" TypeName="Erc.Apple.Data.Specializations" 
OnSelecting="ObjectDataSourceEditItem_Selecting" OldValuesParameterFormatString="original_{0}" 
DataObjectTypeName="Erc.Apple.Data.Specialization" InsertMethod="AddUpdate" 
UpdateMethod="AddUpdate" OnSelected="ObjectDataSourceEditItem_Selected">
    <SelectParameters>
        <asp:Parameter Name="language" Type="String" />
        <asp:Parameter Name="groupId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
