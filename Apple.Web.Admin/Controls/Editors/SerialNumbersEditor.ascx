<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SerialNumbersEditor.ascx.cs" Inherits="Apple.Web.Admin.Controls.Editors.SerialNumbersEditor" %>
<%@ Register Namespace="Apple.Web.Admin.Controls" TagPrefix="UC" Assembly="Apple.Web.Admin" %>    
<asp:MultiView ID="MvEditor" runat="server" ActiveViewIndex="0">

    <asp:View ID="ViewList" runat="server">
    
    <div style="text-align:left;">
		<table cellpadding="5" cellspacing="0">
			<tr >
				<td><b>По номеру:</b>
				</td>
                <td style="width: 350px;" valign="middle">
                    <asp:TextBox ID="txtNameFilter" Width="200" runat="server"></asp:TextBox>
                    <asp:Button ID="btnApplyFilter" runat="server" Text="Показать" />
                </td>
				<td><b>Сервис:</b>
				</td>
				<td><asp:DropDownList ID="ddlServices" runat="server" 
							DataSourceID="ServicesDataSource" DataTextField="Name" DataValueField="ID"
							 AppendDataBoundItems="true" AutoPostBack="true" >
							<asp:ListItem Selected="True" Value="0" Text="Все"></asp:ListItem>
						</asp:DropDownList>
				</td>
			</tr>
		</table>
		<br />
    </div>


        <asp:GridView ID="GridViewItemsList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
			EnableViewState="true"
            DataSourceID="LinqDataSourceEditItem" AllowPaging="True" PageSize="20" EmptyDataText="There are no data records to display."
            Width="800" CssClass="mylist" OnSelectedIndexChanging="GridViewItemsList_SelectedIndexChanging" OnDataBound="GridViewItemsList_DataBound">
            <Columns>
                <asp:TemplateField HeaderText="Редактирование">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="Select" ImageUrl="~/img/edit.png"
                            AlternateText="Редактирование" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Number" HeaderText="Серийный номер" SortExpression="Number">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ServiceName" HeaderText="Сервис" SortExpression="ServiceName">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="CreatedDate" HeaderText="Дата создания" DataFormatString="{0:D}" SortExpression="CreatedDate">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="150" />
                </asp:BoundField>
                <asp:BoundField DataField="ModifiedDate" HeaderText="Дата модификации" DataFormatString="{0:D}" SortExpression="ModifiedDate">
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
        <UC:GetCsvControl id="csv" DataSourceID="LinqDataSourceEditItem" runat="server" />
        <br />
    </asp:View>
    <asp:View ID="ViewEdit" runat="server">
        <asp:DetailsView ID="DetailsViewEditItem" runat="server" AutoGenerateRows="False"
            DataKeyNames="ID" DataSourceID="LinqDataSourceEditItem" DefaultMode="Edit"
            Height="50px" Width="500px" CaptionAlign="Top" 
			OnItemUpdating="DetailsViewEditItem_ItemUpdating" 
			oniteminserting="DetailsViewEditItem_ItemInserting" 
			oniteminserted="DetailsViewEditItem_ItemInserted" >
            <CommandRowStyle HorizontalAlign="Right" />
            <FieldHeaderStyle Font-Size="Small" HorizontalAlign="Left" />
            <Fields>
                <asp:TemplateField HeaderText="Серийный номер" SortExpression="Number">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Number") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvf1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Сервисный центр" SortExpression="Number">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlServices" DataSourceID="ObjectDataSourceServicesList" runat="server" DataTextField="Name" DataValueField="ID" AppendDataBoundItems="True" SelectedValue='<%# Bind("ServiceID") %>'>
							<asp:ListItem Text="Select" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Fields>
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ObjectDataSourceServicesList" runat="server" SelectMethod="GetAllByLanguage" TypeName="Erc.Apple.Data.Services" DataObjectTypeName="Erc.Apple.Data.Service" >
            <SelectParameters>
                <asp:Parameter DefaultValue="ru" Name="language" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <div style="text-align: right;">
            <asp:Button ID="btnSave" runat="server" Text="Сохранить" OnClick="btnSave_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Закрыть" OnClick="btnClose_Click" CausesValidation="false" />
            <asp:Button ID="btnSaveAndClose" runat="server" Text="Сохранить и закрыть" Width="120px"
                OnClick="btnSaveAndClose_Click" />
        </div>
    </asp:View>
</asp:MultiView>
<asp:LinqDataSource 
	ID="LinqDataSourceEditItem" 
	runat="server"  
	ContextTypeName="Erc.Apple.Data.Models.AppleDataContext"
	Where="(ServiceID == @ServiceID || @ServiceID = 0) && Number.ToString().ToLower().StartsWith(@Filter.ToString().ToLower())"
	EnableDelete="true" 
	EnableUpdate="true"
	EnableInsert="true"
	TableName="SerialNumbers">
	<WhereParameters>
		<asp:ControlParameter ControlID="ddlServices" DefaultValue="0" Name="ServiceID" PropertyName="SelectedValue" Type="Int32" />
		<asp:ControlParameter ControlID="txtNameFilter" DefaultValue="" ConvertEmptyStringToNull="false" Name="Filter" PropertyName="Text" Type="String" />
	</WhereParameters>
</asp:LinqDataSource>

<asp:ObjectDataSource ID="ServicesDataSource" runat="server" 
    SelectMethod="GetAllByLanguage" TypeName="Erc.Apple.Data.Services">
    <SelectParameters>
		<asp:Parameter DbType="string" DefaultValue="ru" Name="language" />
    </SelectParameters>
</asp:ObjectDataSource>