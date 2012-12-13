<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SpecializationsEditor.ascx.cs"
    Inherits="Apple.Web.Admin.Controls.Editors.SpecializationsEditor" %>
<%@ Import Namespace="System.ComponentModel"%>
<%@ Register TagPrefix="uc" TagName="editor" Src="~/Controls/Editors/SpecializationEditor.ascx" %>
<asp:MultiView ID="MvEditor" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewList" runat="server">
        <asp:GridView ID="GridViewItemsList" runat="server" Width="600px" AutoGenerateColumns="False"
            DataKeyNames="GroupID" DataSourceID="ObjectDataSourceItemsList" AllowPaging="True"
            PageSize="15" OnSelectedIndexChanged="GridViewItemsList_SelectedIndexChanged"
            OnRowDeleted="GridViewItemsList_RowDeleted"
            >
            <Columns>
                <asp:TemplateField HeaderText="Редактирование">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="Select" ImageUrl="~/img/edit.png"
                            AlternateText="Edit" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Название" SortExpression="Name">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Удаление">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonDelete" runat="server" CommandName="Delete" ImageUrl="~/img/delete.png"
                            AlternateText="Delete" OnClientClick="return confirm('Delete item?');" />&nbsp;
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceItemsList" runat="server" SelectMethod="GetAllByLanguage"
            TypeName="Erc.Apple.Data.Specializations" DataObjectTypeName="Erc.Apple.Data.Specialization"
            DeleteMethod="DeleteGroup">
            <SelectParameters>
                <asp:Parameter DefaultValue="ru" Name="language" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
    </asp:View>
    <asp:View ID="ViewEdit" runat="server">
        <asp:Repeater ID="RepeaterLang" runat="server" DataSourceID="ObjectDataSourceEditItem" OnItemDataBound="RepeaterLang_ItemDataBound">
            <ItemTemplate>
                <h2 style="text-align: left;">
                    <asp:Label ID="Label1" runat="server" Text='<% #Eval("Description","Язык: {0}") %>'></asp:Label></h2>
                <uc:editor ID="editor" LangCode='<% #Eval("Code") %>' OnLoad="editor_Load" runat="server" />
            </ItemTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAll" TypeName="Erc.Apple.Data.Cache.LanguagesCache" OnSelecting="ObjectDataSourceEditItem_Selecting">
        </asp:ObjectDataSource>
        <div style="text-align: right;">
            <asp:Button ID="btnSave" runat="server" Text="Сохранить"  OnClick="btnSave_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Закрыть"  OnClick="btnClose_Click" />
            <asp:Button ID="btnSaveAndClose" runat="server" Text="Сохранить и закрыть" Width="120px"  OnClick="btnSaveAndClose_Click" />
        </div>
    </asp:View>
</asp:MultiView>
