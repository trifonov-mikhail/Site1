<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AdminsEditor.ascx.cs"
    Inherits="Apple.Web.Admin.Controls.Editors.AdminsEditor" %>
<asp:GridView ID="GridViewItemsList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
    DataSourceID="ObjectDataSourceItemsList" AllowPaging="True" PageSize="5" EmptyDataText="There are no data records to display." Width="600" CssClass="mylist">
    <Columns>
        <asp:TemplateField HeaderText="Редактирование">
            <ItemTemplate>
                <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="Select" ImageUrl="~/img/edit.png"
                    AlternateText="Редактирование" />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
        </asp:TemplateField>
        <asp:BoundField DataField="Name" HeaderText="Имя" SortExpression="Name" >
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" Width="100px" />
        </asp:BoundField>
        <asp:BoundField DataField="Email" HeaderText="Эл. почта" SortExpression="Email" >
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" Width="100px" />
        </asp:BoundField>
        <asp:BoundField DataField="DateCreated" HeaderText="Дата создания" SortExpression="DateCreated" >
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
<asp:ObjectDataSource ID="ObjectDataSourceItemsList" runat="server" DataObjectTypeName="Erc.Apple.Data.Admin"
    DeleteMethod="Delete" SelectMethod="GetAll" TypeName="Erc.Apple.Data.Admins"></asp:ObjectDataSource>
<br />
<br />
<asp:DetailsView ID="DetailsViewEditItem" runat="server" AutoGenerateRows="False"
    DataKeyNames="ID" DataSourceID="ObjectDataSourceEditItem" DefaultMode="Insert"
    Height="50px" Width="300px" CaptionAlign="Top">
    <CommandRowStyle HorizontalAlign="Right" />
    <Fields>
        <asp:TemplateField HeaderText="Имя" SortExpression="Name">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Эл. почта" SortExpression="Email" >
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" AUTOCOMPLETE="off" Text='<%# Bind("Email") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Пароль" SortExpression="Password">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" AUTOCOMPLETE="off" TextMode="Password" Text='<%# Bind("Password") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
    </Fields>
    <FieldHeaderStyle HorizontalAlign="Left" />
</asp:DetailsView>
<asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" DataObjectTypeName="Erc.Apple.Data.Admin"
    InsertMethod="Add" SelectMethod="GetByID" TypeName="Erc.Apple.Data.Admins" UpdateMethod="Update">
    <SelectParameters>
        <asp:ControlParameter ControlID="GridViewItemsList" Name="id" PropertyName="SelectedValue"
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
