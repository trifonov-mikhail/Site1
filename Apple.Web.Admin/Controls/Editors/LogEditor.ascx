<%@ Control Language="C#" AutoEventWireup="true" Codebehind="LogEditor.ascx.cs" Inherits="Apple.Web.Admin.Controls.Editors.LogEditor" %>
<asp:GridView ID="GridViewItemsList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
    DataSourceID="ObjectDataSourceItemsList" AllowPaging="True" PageSize="5" EmptyDataText="There are no data records to display."
    Width="600" CssClass="mylist" OnDataBound="GridViewItemsList_DataBound">
    <Columns>
        <asp:TemplateField HeaderText="Редактирование">
            <ItemTemplate>
                <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="Select" ImageUrl="~/img/edit.png"
                    AlternateText="Редактирование" />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
        </asp:TemplateField>
        <asp:BoundField DataField="Source" HeaderText="Source" SortExpression="Source" />
        <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
        <asp:TemplateField HeaderText="Удаление">
            <ItemTemplate>
                <asp:ImageButton ID="ImageButtonDelete" runat="server" CommandName="Delete" ImageUrl="~/img/delete.png"
                    AlternateText="Delete" OnClientClick="return confirm('Delete item?');" />&nbsp;
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ObjectDataSourceItemsList" runat="server" DataObjectTypeName="Erc.Apple.Data.LogMessage"
    DeleteMethod="Delete" SelectMethod="GetAll" TypeName="Erc.Apple.Data.Log"></asp:ObjectDataSource>
<br />
<asp:Button ID="btnClearLog" runat="server" Text="Clear Log" OnClick="btnClearLog_Click" />
<br />
<asp:DetailsView ID="DetailsViewEditItem" runat="server"  EmptyDataText="" AutoGenerateRows="False"
    DataKeyNames="ID" DataSourceID="ObjectDataSourceEditItem"
    Height="50px" Width="750px" CaptionAlign="Top">
    <CommandRowStyle HorizontalAlign="Right" />
    <Fields>
        <asp:BoundField DataField="Source" HeaderText="Source" ReadOnly="True" SortExpression="Source" />
        <asp:BoundField DataField="Message" HeaderText="Message" ReadOnly="True" SortExpression="Message" />
        <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" InsertVisible="False"
            ReadOnly="True" SortExpression="DateCreated" />
    </Fields>
    <FieldHeaderStyle HorizontalAlign="Left" />
</asp:DetailsView>
<asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" DataObjectTypeName="Erc.Apple.Data.LogMessage"
    InsertMethod="Add" SelectMethod="GetByID" TypeName="Erc.Apple.Data.Log" UpdateMethod="Update"
    OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:ControlParameter ControlID="GridViewItemsList" Name="id" PropertyName="SelectedValue"
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
