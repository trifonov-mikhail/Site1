<%@ Control Language="C#" AutoEventWireup="true" Codebehind="CitiesEditor.ascx.cs"
    Inherits="Apple.Web.Admin.Controls.Editors.CitiesEditor" %>
<%@ Register TagPrefix="uc" TagName="editor" Src="~/Controls/Editors/CityEditor.ascx" %>
<asp:MultiView ID="MvEditor" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewList" runat="server">
        <div style="text-align: left;">
            <table border="0">
                <tr>
                    <td>
                        <h3>
                            По имени:
                        </h3>
                    </td>
                    <td style="width: 350px;" valign="middle">
                        <asp:TextBox ID="txtNameFilter" Width="200" runat="server"></asp:TextBox>
                        <asp:Button ID="btnApplyFilter" runat="server" Text="Показать" OnClick="btnApplyFilter_Click" />
                    </td>
                    <td valign="middle">
                        <h3>
                            Области:
                        </h3>
                    </td>
                    <td valign="middle">
                        <asp:DropDownList ID="ddlRegionFilter" runat="server" DataSourceID="ODSRegions" DataTextField="Name"
                            DataValueField="GroupID" AppendDataBoundItems="true" AutoPostBack="true">
                            <asp:ListItem Selected="True" Value="0" Text="Все"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <asp:GridView ID="GridViewItemsList" runat="server" Width="600px" AutoGenerateColumns="False"
            DataKeyNames="GroupID" DataSourceID="ObjectDataSourceItemsList" AllowPaging="True"
            PageSize="15" OnSelectedIndexChanged="GridViewItemsList_SelectedIndexChanged"
            OnRowDeleted="GridViewItemsList_RowDeleted">
            <Columns>
                <asp:TemplateField HeaderText="Редактирование">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="Select" ImageUrl="~/img/edit.png"
                            AlternateText="Edit" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Партнёры">
                    <ItemTemplate>
                        <a href='<%# this.ResolveUrl(string.Format("~/Partners.aspx?City={0}&region={1}",DataBinder.Eval(Container.DataItem, "GroupID"), ddlRegionFilter.SelectedValue)) %>'>*</a>
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
        <asp:ObjectDataSource ID="ObjectDataSourceItemsList" runat="server" SelectMethod="GetAllByLanguageAndRegionAndName"
            TypeName="Erc.Apple.Data.Cities" DataObjectTypeName="Erc.Apple.Data.City" DeleteMethod="DeleteGroup"
            OnSelecting="ObjectDataSourceItemsList_Selecting">
            <SelectParameters>
                <asp:Parameter DefaultValue="ru" Name="language" Type="String" />
                <asp:ControlParameter ControlID="ddlRegionFilter" DefaultValue="0" Name="regionId"
                    Type="Int32" />
                <asp:Parameter Name="name" Type="String" />
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
                        Область:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRegions" runat="server" DataSourceID="ODSRegions" DataTextField="Name"
                            DataValueField="GroupID" OnDataBound="ddlRegions_DataBound">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:Repeater ID="RepeaterLang" runat="server" DataSourceID="ObjectDataSourceEditItem"
                OnItemDataBound="RepeaterLang_ItemDataBound">
                <ItemTemplate>
                    <h2 style="text-align: left;">
                        <asp:Label ID="Label1" runat="server" Text='<% #Eval("Code","Язык: {0}") %>'></asp:Label></h2>
                    <uc:editor ID="editor" LangCode='<% #Eval("Code") %>' OnLoad="editor_Load" runat="server" />
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!-- ObjectDataSource -->
        <asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAll" TypeName="Erc.Apple.Data.Cache.LanguagesCache" OnSelecting="ObjectDataSourceEditItem_Selecting">
        </asp:ObjectDataSource>
        <div style="text-align: right;">
            <asp:Button ID="btnSave" runat="server" Text="Сохранить"  OnClick="btnSave_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Закрыть"  OnClick="btnClose_Click" />
            <asp:Button ID="btnSaveAndClose" runat="server" Text="Сохранить и закрыть" Width="120px"  OnClick="btnSaveAndClose_Click" />
        </div>
        <asp:ObjectDataSource ID="ODSRegions" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAllByLanguage" TypeName="Erc.Apple.Data.Regions" OnSelecting="ODSRegions_Selecting">
            <SelectParameters>
                <asp:Parameter DbType="string" DefaultValue="ru" Name="language" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
</asp:MultiView>
