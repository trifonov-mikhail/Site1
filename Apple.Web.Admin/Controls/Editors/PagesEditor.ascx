<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PagesEditor.ascx.cs"
    Inherits="Apple.Web.Admin.Controls.Editors.PagesEditor" %>
<asp:GridView ID="GridViewItemsList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
    DataSourceID="ObjectDataSourceItemsList" AllowPaging="True" PageSize="9">
    <Columns>
        <asp:TemplateField HeaderText="Редактирование">
            <ItemTemplate>
                <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="Select" ImageUrl="~/img/edit.png"
                    AlternateText="Edit" />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
        </asp:TemplateField>
        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="Url" HeaderText="Url" SortExpression="Url">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="Control" HeaderText="Control" SortExpression="Control">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="OrderID" HeaderText="OrderID" SortExpression="OrderID">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active" />
        <asp:TemplateField HeaderText="Delete">
            <ItemTemplate>
                <asp:ImageButton ID="ImageButtonDelete" runat="server" CommandName="Delete" ImageUrl="~/img/delete.png"
                    AlternateText="Delete" OnClientClick="return confirm('Delete item?');" />&nbsp;
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ObjectDataSourceItemsList" runat="server" DataObjectTypeName="Erc.Apple.Data.AdminPage"
    DeleteMethod="Delete" SelectMethod="GetAll" TypeName="Erc.Apple.Data.AdminPages">
</asp:ObjectDataSource>
<br />
<br />
<asp:DetailsView ID="DetailsViewEditItem" runat="server" AutoGenerateRows="False"
    DataKeyNames="ID" DataSourceID="ObjectDataSourceEditItem" DefaultMode="Insert"
    Height="50px" Width="300px">
    <CommandRowStyle HorizontalAlign="Right" />
    <Fields>
        <asp:TemplateField HeaderText="Parent">
            <EditItemTemplate>
                <asp:DropDownList ID="ddlPages" runat="server" DataSourceID="odsPagesDDL" DataTextField="Title"
                    DataValueField="ID" SelectedValue='<%# Bind("ParentID") %>' AppendDataBoundItems="True">
                    <asp:ListItem Text="None" Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsPagesDDL" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetAll" TypeName="Erc.Apple.Data.AdminPages"></asp:ObjectDataSource>
            </EditItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title" SortExpression="Title">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Url" SortExpression="Url">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Url") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Control" SortExpression="Control">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Control") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OrderID" SortExpression="OrderID">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("OrderID") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active">
            <ItemStyle HorizontalAlign="Left" />
        </asp:CheckBoxField>
        <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
    </Fields>
</asp:DetailsView>
<asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" DataObjectTypeName="Erc.Apple.Data.AdminPage"
    InsertMethod="Add" SelectMethod="GetByID" TypeName="Erc.Apple.Data.AdminPages"
    UpdateMethod="Update" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:ControlParameter ControlID="GridViewItemsList" Name="id" PropertyName="SelectedValue"
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
