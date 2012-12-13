<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ProductsEditor.ascx.cs"
    Inherits="Apple.Web.Admin.Controls.Editors.ProductsEditor" %>
<%@ Register TagPrefix="uc" TagName="editor" Src="~/Controls/Editors/ProductEditor.ascx" %>
<asp:MultiView ID="MvEditor" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewList" runat="server">
        <div style="text-align: left;">
            <h3>
                Категории:
                <asp:DropDownList ID="DdlCategoryFilter" runat="server" DataSourceID="ODSCategory"
                    DataTextField="Name" DataValueField="GroupID" AppendDataBoundItems="true" AutoPostBack="true">
                    <asp:ListItem Selected="True" Value="0" Text="Все"></asp:ListItem>
                </asp:DropDownList>
            </h3>
            <br />
        </div>
        <asp:GridView ID="GridViewItemsList" runat="server" Width="600px" AutoGenerateColumns="False"
            DataKeyNames="GroupID" DataSourceID="ObjectDataSourceItemsList" AllowPaging="True"
            PageSize="15" OnSelectedIndexChanged="GridViewItemsList_SelectedIndexChanged"
            OnRowDeleted="GridViewItemsList_RowDeleted" OnDataBound="GridViewItemsList_DataBound" OnRowCommand="GridViewItemsList_RowCommand">
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
        <asp:ObjectDataSource ID="ObjectDataSourceItemsList" runat="server" SelectMethod="GetAllByLanguageCategory"
            TypeName="Erc.Apple.Data.Products" DataObjectTypeName="Erc.Apple.Data.Product"
            DeleteMethod="DeleteGroup">
            <SelectParameters>
                <asp:Parameter DefaultValue="ru" Name="language" Type="String" />
                <asp:ControlParameter ControlID="DdlCategoryFilter" DefaultValue="0" Name="categoryId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
    </asp:View>
    <asp:View ID="ViewEdit" runat="server">
        <div style="width: 100%; text-align: left;">
            <table width="200" cellpadding="5">
                <tr style="background-color: rgb(239, 243, 251);">
                    <td style="background-color: rgb(222, 232, 245); width: 40px; font-weight: bold;">
                        Категория:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="ODSCategory" DataTextField="Name"
                            DataValueField="GroupID" OnDataBound="ddlCategory_DataBound">
                        </asp:DropDownList>
                    </td>
                    <td rowspan="2">
                        <table>
                            <tr>
                                <td>
                                    <img height="55" alt='Image' src='<%=this.ResolveUrl("~/GetImage.ashx?type=1&id="+this.GroupID) %>' /></td>
                                <td>
                                    <asp:ImageButton ImageUrl="~/img/Delete.png" ID="btnDeleteImage" runat="server" OnClick="btnDeleteImage_Click"
                                        Visible="false" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="background-color: rgb(239, 243, 251);">
                    <td style="background-color: rgb(222, 232, 245); width: 40px; font-weight: bold;">
                        Фото:
                    </td>
                    <td>
                        <asp:FileUpload ID="fuImage" runat="server" />
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
        <!-- ObjectDataSource -->
        <asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAll" TypeName="Erc.Apple.Data.Cache.LanguagesCache" OnSelecting="ObjectDataSourceEditItem_Selecting">
        </asp:ObjectDataSource>
        <div style="text-align: right;">
            <asp:Button ID="btnSave" runat="server" Text="Сохранить" OnClick="btnSave_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Закрыть" OnClick="btnClose_Click" />
            <asp:Button ID="btnSaveAndClose" runat="server" Text="Сохранить и закрыть" Width="120px"
                OnClick="btnSaveAndClose_Click" />
        </div>
        <asp:ObjectDataSource ID="ODSCategory" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAllByLanguage" TypeName="Erc.Apple.Data.Categories" OnSelecting="ODSCategory_Selecting">
            <SelectParameters>
                <asp:Parameter DbType="string" DefaultValue="ru" Name="language" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
</asp:MultiView>
