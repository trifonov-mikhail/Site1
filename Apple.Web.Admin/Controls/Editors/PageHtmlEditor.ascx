<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PageHtmlEditor.ascx.cs"
    Inherits="Apple.Web.Admin.Controls.Editors.PageHtmlEditor" %>
<%@ Register TagPrefix="uc" TagName="HtmlEditor" Src="~/Controls/HtmlEditor.ascx" %>
<asp:DetailsView ID="DetailsViewEditItem" Width="100%" runat="server" DataSourceID="ObjectDataSourceEditItem"
    AutoGenerateRows="False" DefaultMode="Edit" OnDataBound="DetailsViewEditItem_DataBound"
    DataKeyNames="Name" OnItemInserting="DetailsViewEditItem_ItemInserting" OnItemInserted="DetailsViewEditItem_ItemInserted"
    OnItemUpdated="DetailsViewEditItem_ItemUpdated">
    <Fields>
        <asp:TemplateField HeaderText="Текст" SortExpression="Text" ShowHeader="False">
            <EditItemTemplate>
                <uc:HtmlEditor ID="editor" Height="400" Width="100%" runat="server" Text='<%# Bind("Html") %>' />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="False">
            <ItemStyle HorizontalAlign="Right" />
            <EditItemTemplate>
                <asp:Button ID="Button1" runat="server" CssClass="btn" CausesValidation="True" CommandName="Update"
                    Text="Save" />
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:Button ID="Button1" runat="server" CssClass="btn" CausesValidation="True" CommandName="Insert"
                    Text="Save" />
            </InsertItemTemplate>
        </asp:TemplateField>
    </Fields>
</asp:DetailsView>
<asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" SelectMethod="GetByName"
    TypeName="Erc.Apple.Data.PagesHTML" DataObjectTypeName="Erc.Apple.Data.PageHTML"
    InsertMethod="Add" UpdateMethod="Update" OnSelecting="ObjectDataSourceEditItem_Selecting"
    OnSelected="ObjectDataSourceEditItem_Selected">
    <SelectParameters>
        <asp:Parameter Name="name" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
