<%@ Control Language="C#" AutoEventWireup="true" Codebehind="DevelopersLinksEditor.ascx.cs"
    Inherits="Apple.Web.Admin.Controls.Editors.DevelopersLinksEditor" %>
<%@ Register TagPrefix="uc" TagName="DatePicker" Src="~/Controls/DatePicker.ascx" %>
<%@ Register TagPrefix="uc" TagName="editor" Src="~/Controls/Editors/DevelopersLinkEditor.ascx" %>
<%@ Register TagPrefix="uc" Assembly="Apple.Web.Admin" Namespace="Apple.Web.Admin.Controls" %>
<asp:MultiView ID="MvEditor" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewList" runat="server">
        <asp:GridView ID="GridViewItemsList" runat="server" Width="600px" AutoGenerateColumns="False"
            DataKeyNames="GroupID" DataSourceID="ObjectDataSourceItemsList" AllowPaging="True"
            PageSize="15" OnSelectedIndexChanged="GridViewItemsList_SelectedIndexChanged"
            OnRowDeleted="GridViewItemsList_RowDeleted" OnDataBound="GridViewItemsList_DataBound"
            OnRowCommand="GridViewItemsList_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Редактирование">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="Select" ImageUrl="~/img/edit.png"
                            AlternateText="Edit" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:TemplateField>
                <%--<asp:BoundField DataField="Date" DataFormatString="{0:d}" HeaderText="Дата" SortExpression="Date" />--%>
                <asp:BoundField DataField="LinkText" HeaderText="Название" SortExpression="LinkText" />
                <asp:TemplateField HeaderText="Удаление">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonDelete" runat="server" CommandName="Delete" ImageUrl="~/img/delete.png"
                            AlternateText="Delete" OnClientClick="return confirm('Delete item?');" />&nbsp;
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceItemsList" runat="server" SelectMethod="GetAll"
            TypeName="Erc.Apple.Data.DevelopersLinks" DataObjectTypeName="Erc.Apple.Data.DevelopersLink" DeleteMethod="DeleteGroup">
            <SelectParameters>
                <asp:Parameter DefaultValue="ru" Name="langCode" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
    </asp:View>
    <asp:View ID="ViewEdit" runat="server">
        <div style="width: 100%; text-align: left;">
            <asp:Repeater ID="RepeaterLang" runat="server" DataSourceID="ObjectDataSourceEditItem"
                OnItemDataBound="RepeaterLang_ItemDataBound">
                <ItemTemplate>
                    <h2 style="text-align: left;">
                        <asp:Label ID="Label1" runat="server" Text='<% #Eval("Description","Язык: {0}") %>'></asp:Label></h2>
                    <uc:editor ID="editor" LangCode='<% #Eval("Code") %>' OnLoad="editor_Load" runat="server" />
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAll" TypeName="Erc.Apple.Data.Cache.LanguagesCache" OnSelecting="ObjectDataSourceEditItem_Selecting">
        </asp:ObjectDataSource>
        <div style="text-align: right;">
            <asp:Button ID="btnSave" runat="server" Text="Сохранить" OnClick="btnSave_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Закрыть" OnClick="btnClose_Click" />
            <asp:Button ID="btnSaveAndClose" runat="server" Text="Сохранить и закрыть" Width="120px"
                OnClick="btnSaveAndClose_Click" />
        </div>
    </asp:View>
</asp:MultiView>
