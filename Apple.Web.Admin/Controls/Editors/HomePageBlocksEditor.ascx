<%@ Control Language="C#" AutoEventWireup="true" Codebehind="HomePageBlocksEditor.ascx.cs"
    Inherits="Apple.Web.Admin.Controls.Editors.HomePageBlocksEditor" %>
<%@ Register TagPrefix="uc" TagName="editor" Src="~/Controls/Editors/HomePageBlockEditor.ascx" %>
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
                <asp:TemplateField HeaderText="Порядок" InsertVisible="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgUp" runat="server" CommandArgument='<%# Eval("GroupID") %>'
                                    CommandName="MoveUp" ImageUrl="~/img/up.png" ImageAlign="Left" />
                                <asp:ImageButton ID="imgDown" runat="server" CommandArgument='<%# Eval("GroupID") %>'
                                    CommandName="MoveDown" ImageUrl="~/img/down.png" ImageAlign="Right" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:TemplateField>
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
            TypeName="Erc.Apple.Data.HomePageBlocks" DataObjectTypeName="Erc.Apple.Data.HomePageBlock" DeleteMethod="DeleteGroup">
            <SelectParameters>
                <asp:Parameter DefaultValue="ru" Name="langCode" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
    </asp:View>
    <asp:View ID="ViewEdit" runat="server">
        <div style="width: 100%; text-align: left;">
            <table width="550" border="0" cellspacing="1" cellpadding="5">
                <tr style="background-color: rgb(239, 243, 251);">
                    <%--<td style="background-color: rgb(222, 232, 245); width: 150px; font-weight: bold;">
                        Дата:
                    </td>
                    <td>
                        <uc:DatePicker ID="dpHomePageBlockDate" runat="server" />
                    </td>--%>
                </tr>
                <tr>
                    <td style="background-color: rgb(222, 232, 245);font-weight: bold;">
                        Фото:
                    </td>
                    <td style="background-color: rgb(239, 243, 251);">
                        <asp:FileUpload ID="fuImage" runat="server" />
                    </td>
                    <td style="background-color: rgb(239, 243, 251);">
                        <table border="0" cellspacing="0">
                            <tr>
                                <td>
                                    <img height="55" alt='Image' src='<%=this.ResolveUrl("~/GetImage.ashx?type=7&id="+this.GroupID) %>' /></td>
                                <td>
                                    <asp:ImageButton ImageUrl="~/img/Delete.png" ID="btnDeleteImage" runat="server" OnClick="btnDeleteImage_Click"
                                        Visible="false" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
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
