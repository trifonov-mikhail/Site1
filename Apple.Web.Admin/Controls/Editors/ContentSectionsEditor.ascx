<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ContentSectionsEditor.ascx.cs"
    Inherits="Apple.Web.Admin.Controls.Editors.ContentSectionsEditor" %>
<asp:MultiView ID="MvEditor" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewList" runat="server">
        <asp:GridView ID="GridViewItemsList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            DataSourceID="ObjectDataSourceItemsList" AllowPaging="True" PageSize="10" EmptyDataText="There are no data records to display."
            Width="400px" CssClass="mylist" OnSelectedIndexChanging="GridViewItemsList_SelectedIndexChanging"
            OnDataBound="GridViewItemsList_DataBound">
            <Columns>
                <asp:TemplateField HeaderText="Редактирование">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="Select" ImageUrl="~/img/edit.png"
                            AlternateText="Редактирование" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Название" SortExpression="Name">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
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
        <asp:ObjectDataSource ID="ObjectDataSourceItemsList" runat="server" DataObjectTypeName="Erc.Apple.Data.ContentSection"
            DeleteMethod="Delete" SelectMethod="GetAll" TypeName="Erc.Apple.Data.ContentSections">
        </asp:ObjectDataSource>
    </asp:View>
    <asp:View ID="ViewEdit" runat="server">
        <asp:DetailsView ID="DetailsViewEditItem" runat="server" AutoGenerateRows="False"
            DataKeyNames="ID" DataSourceID="ObjectDataSourceEditItem" DefaultMode="Insert"
            Height="50px" Width="400px" CaptionAlign="Top" OnItemUpdating="DetailsViewEditItem_ItemUpdating">
            <CommandRowStyle HorizontalAlign="Right" />
            <Fields>
                <asp:TemplateField HeaderText="Название" SortExpression="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
            <FieldHeaderStyle HorizontalAlign="Left" />
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" DataObjectTypeName="Erc.Apple.Data.ContentSection"
            InsertMethod="Add" SelectMethod="GetByID" TypeName="Erc.Apple.Data.ContentSections"
            UpdateMethod="Update" OldValuesParameterFormatString="original_{0}" OnUpdating="ObjectDataSourceEditItem_Updating">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridViewItemsList" Name="id" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="item" Type="Object" />
                <asp:Parameter Name="setForAll" Type="Boolean" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <div style="text-align: right;">
            <asp:Button ID="btnSave" runat="server" Text="Сохранить" OnClick="btnSave_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Закрыть" OnClick="btnClose_Click" />
            <asp:Button ID="btnSaveAndClose" runat="server" Text="Сохранить и закрыть" Width="120px"
                OnClick="btnSaveAndClose_Click" />
        </div>
    </asp:View>
</asp:MultiView>
