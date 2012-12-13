<%@ Control Language="C#" AutoEventWireup="true" Codebehind="StatusRequestsEditor.ascx.cs"
    Inherits="Apple.Web.Admin.Controls.Editors.StatusRequestsEditor" %>
    
<%@ Register Namespace="Apple.Web.Admin.Controls" TagPrefix="UC" Assembly="Apple.Web.Admin" %>    
    
<asp:MultiView ID="MvEditor" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewList" runat="server">
        <div style="text-align: left;">
            <h3>
                Статус:
                <asp:DropDownList ID="ddlRequestTypes" runat="server" AutoPostBack="true">
                    <asp:ListItem Selected="True" Value="" Text="Все"></asp:ListItem>
                    <asp:ListItem Value="LAR" Text="LAR"></asp:ListItem>
                    <asp:ListItem Value="AASP" Text="AASP"></asp:ListItem>
                    <asp:ListItem Value="ACP" Text="ACP"></asp:ListItem>
                </asp:DropDownList>
            </h3>
            <br />
        </div>
        <asp:GridView ID="GridViewItemsList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            DataSourceID="ObjectDataSourceItemsList" AllowPaging="True" PageSize="5" EmptyDataText="There are no data records to display."
            Width="100%" CssClass="mylist" OnSelectedIndexChanging="GridViewItemsList_SelectedIndexChanging" OnDataBound="GridViewItemsList_DataBound">
            <Columns>
                <asp:TemplateField HeaderText="Редактирование">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="Select" ImageUrl="~/img/edit.png"
                            AlternateText="Редактирование" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
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
        <br />
        <UC:GetCsvControl id="csv" DataSourceID="ObjectDataSourceItemsList" runat="server" />
        <br />
        <asp:ObjectDataSource ID="ObjectDataSourceItemsList" runat="server" DataObjectTypeName="Erc.Apple.Data.StatusRequest"
            DeleteMethod="Delete" SelectMethod="GetByStatus" TypeName="Erc.Apple.Data.StatusRequests">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlRequestTypes" Name="status" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:View>
    <asp:View ID="ViewEdit" runat="server">
        <asp:DetailsView ID="DetailsViewEditItem" runat="server" AutoGenerateRows="False"
            DataKeyNames="ID" DataSourceID="ObjectDataSourceEditItem" DefaultMode="Insert"
            Height="50px" Width="300px" CaptionAlign="Top">
            <CommandRowStyle HorizontalAlign="Right" />
            <Fields>
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:CheckBoxField DataField="IsPartner" HeaderText="IsPartner" SortExpression="IsPartner" />
                <asp:CheckBoxField DataField="IsServicePartner" HeaderText="IsServicePartner" SortExpression="IsServicePartner" />
                <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" ReadOnly="True"
                    SortExpression="DateCreated" />
            </Fields>
            <FieldHeaderStyle HorizontalAlign="Left" />
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" DataObjectTypeName="Erc.Apple.Data.StatusRequest"
            InsertMethod="Add" SelectMethod="GetByID" TypeName="Erc.Apple.Data.StatusRequests"
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

