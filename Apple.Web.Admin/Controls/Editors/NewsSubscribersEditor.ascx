<%@ Control Language="C#" AutoEventWireup="true" Codebehind="NewsSubscribersEditor.ascx.cs"
    Inherits="Apple.Web.Admin.Controls.Editors.NewsSubscribersEditor" %>
    
<%@ Register Namespace="Apple.Web.Admin.Controls" TagPrefix="UC" Assembly="Apple.Web.Admin" %>    
    
<asp:MultiView ID="MvEditor" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewList" runat="server">
        <asp:GridView ID="GridViewItemsList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            DataSourceID="ObjectDataSourceItemsList" AllowPaging="True" PageSize="5" EmptyDataText="There are no data records to display."
            Width="800" CssClass="mylist" OnSelectedIndexChanging="GridViewItemsList_SelectedIndexChanging" OnDataBound="GridViewItemsList_DataBound">
            <Columns>
                <asp:TemplateField HeaderText="Редактирование">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="Select" ImageUrl="~/img/edit.png"
                            AlternateText="Редактирование" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" DataFormatString="{0:D}" SortExpression="DateCreated">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="150" />
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
        <br />
        <UC:GetCsvControl id="csv" DataSourceID="ObjectDataSourceItemsList" runat="server" />
        <br />
        <asp:ObjectDataSource ID="ObjectDataSourceItemsList" runat="server" DataObjectTypeName="Erc.Apple.Data.NewsSubscriber"
            DeleteMethod="Delete" SelectMethod="GetAll" TypeName="Erc.Apple.Data.NewsSubscribers">
        </asp:ObjectDataSource>
    </asp:View>
    <asp:View ID="ViewEdit" runat="server">
        <asp:DetailsView ID="DetailsViewEditItem" runat="server" AutoGenerateRows="False"
            DataKeyNames="ID" DataSourceID="ObjectDataSourceEditItem" DefaultMode="Insert"
            Height="50px" Width="400px" CaptionAlign="Top">
            <CommandRowStyle HorizontalAlign="Right" />
            <Fields>
                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvf1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" SortExpression="Email">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvf2" runat="server" ControlToValidate="TextBox2"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev1" runat="server" ControlToValidate="TextBox2"
                            ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Fields>
            <FieldHeaderStyle HorizontalAlign="Left" />
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" DataObjectTypeName="Erc.Apple.Data.NewsSubscriber"
            InsertMethod="Add" SelectMethod="GetByID" TypeName="Erc.Apple.Data.NewsSubscribers"
            UpdateMethod="Update">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridViewItemsList" Name="id" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <div style="text-align: right;">
            <asp:Button ID="btnSave" runat="server" Text="Сохранить" OnClick="btnSave_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Закрыть" OnClick="btnClose_Click" />
            <asp:Button ID="btnSaveAndClose" runat="server" Text="Сохранить и закрыть" Width="120px"
                OnClick="btnSaveAndClose_Click" />
        </div>
    </asp:View>
</asp:MultiView>

