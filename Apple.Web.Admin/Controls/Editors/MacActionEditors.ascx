<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MacActionEditors.ascx.cs" 
    Inherits="Apple.Web.Admin.Controls.Editors.MacActionEditors" %>
<%@ Register Namespace="Apple.Web.Admin.Controls" TagPrefix="UC" Assembly="Apple.Web.Admin" %>    
<asp:MultiView ID="MvEditor" runat="server" ActiveViewIndex="0">
	<asp:View ID="ViewList" runat="server">
	Статус
	<ul>
		<li>0 – в стадии проверки</li>
		<li>1 – Гарантия подтверждена</li>
		<li>2 – Гарантия отклонена</li>
		<li>3 – Ошибка ввода данных (или при ошибке просто отклонять гарантию)</li>
	</ul>
	Статус: <asp:DropDownList ID="DdlStatus" runat="server" 
							AutoPostBack="true" >
		<asp:ListItem Selected="True" Value="0" Text="в стадии проверки"></asp:ListItem>
		<asp:ListItem Value="1" Text="Гарантия подтверждена"></asp:ListItem>
		<asp:ListItem Value="2" Text="Гарантия отклонена"></asp:ListItem>
		<asp:ListItem Value="3" Text="Ошибка ввода данных"></asp:ListItem>
	</asp:DropDownList><br />
	Серийный номер:<asp:DropDownList ID="ddlSerials" runat="server" 
							AutoPostBack="true" AppendDataBoundItems="true" DataSourceID="dsSerials">
		<asp:ListItem Selected="True" Value="0" Text="Все"></asp:ListItem>		
	</asp:DropDownList><br />
	Место покупки:<asp:DropDownList ID="ddlSeller" runat="server" 
							AutoPostBack="true" AppendDataBoundItems="true" DataSourceID="dsSellers" DataTextField="Text"
							DataValueField="Value">
		<asp:ListItem Selected="True" Value="0" Text="Все"></asp:ListItem>		
	</asp:DropDownList><br />
	Email:<asp:DropDownList ID="ddlEmails" runat="server" 
							AutoPostBack="true" AppendDataBoundItems="true" DataSourceID="dsEmails">
		<asp:ListItem Selected="True" Value="0" Text="Все"></asp:ListItem>		
	</asp:DropDownList><br />
	<asp:ObjectDataSource runat="server" ID="dsSerials" TypeName="Erc.Apple.Data.MacActionSerials" SelectMethod="GetSerialNumbers">
	</asp:ObjectDataSource>
	<asp:ObjectDataSource runat="server" ID="dsSellers" TypeName="Erc.Apple.Data.MacActionSerials" SelectMethod="GetSellers">
	</asp:ObjectDataSource>
	<asp:ObjectDataSource runat="server" ID="dsEmails" TypeName="Erc.Apple.Data.MacActionSerials" SelectMethod="GetEmails">
	</asp:ObjectDataSource>
	<%--
            OnRowDeleted="GridViewItemsList_RowDeleted" OnRowCommand="GridViewItemsList_RowCommand" --%>
	<asp:GridView ID="GridViewItemsList" runat="server" Width="100%" AutoGenerateColumns="False"
            DataKeyNames="ID" DataSourceID="ObjectDataSourceItemsList" AllowPaging="True"
            PageSize="15" OnSelectedIndexChanged="GridViewItemsList_SelectedIndexChanged"
			OnRowEditing="gridview_RowEditing" AutoGenerateEditButton="true" OnRowUpdated="GridViewItemsList_RowUpdated"
			
			>
            <Columns>
                <asp:BoundField  DataField="Serial" HeaderText="Серийный номер" SortExpression="Serial" ReadOnly="false"/>
				<asp:TemplateField>
					<ItemTemplate>
						<asp:Label runat="server" ID="buyDate"><%#Eval("BuyDate") %></asp:Label>
					</ItemTemplate>
				</asp:TemplateField>
				
				<asp:BoundField  DataField="Email" HeaderText="Email" SortExpression="Email" ReadOnly="false"/>
				<asp:BoundField  DataField="SellerName" HeaderText="Место покупки" SortExpression="SellerName" ReadOnly="true"/>
				<asp:BoundField  DataField="Status" HeaderText="Status" SortExpression="Status"  ReadOnly="false"/>
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
        <asp:ObjectDataSource ID="ObjectDataSourceItemsList" runat="server" 
			SelectMethod="GetAll"
            TypeName="Erc.Apple.Data.MacActionSerials" DataObjectTypeName="Erc.Apple.Data.MacActionSerial"
            UpdateMethod="Update" DeleteMethod="Delete" >
			<SelectParameters>
			<asp:ControlParameter ControlID="DdlStatus" DefaultValue="0" Name="statusid" Type="Int32" />
			<asp:ControlParameter ControlID="ddlSerials" DefaultValue="0" Name="serial" Type="String" />
			<asp:ControlParameter ControlID="ddlEmails" DefaultValue="0" Name="email" Type="String" />
			<asp:ControlParameter ControlID="ddlSeller" DefaultValue="0" Name="seller" Type="Int32" />
			</SelectParameters>
			
        </asp:ObjectDataSource>
	</asp:View>
	<asp:View ID="View1" runat="server">
	</asp:View>
</asp:MultiView>