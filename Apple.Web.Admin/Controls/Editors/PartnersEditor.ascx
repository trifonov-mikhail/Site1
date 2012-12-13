<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PartnersEditor.ascx.cs"
    Inherits="Apple.Web.Admin.Controls.Editors.PartnersEditor" %>
<%@ Register TagPrefix="uc" TagName="editor" Src="~/Controls/Editors/PartnerEditor.ascx" %>
<asp:MultiView ID="MvEditor" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewList" runat="server">
    
    <div style="text-align:left;">
		<table cellpadding="5" cellspacing="0">
			<tr>
			<td colspan="2"><asp:Literal ID="BackLink" runat="server" Visible="false" ></asp:Literal></td>
			</tr>
			<tr >
				<td><b>Область:</b>
				</td>
				<td><asp:DropDownList ID="DdlRegionFilter" runat="server" 
							DataSourceID="ODSRegionFilter" DataTextField="Name" DataValueField="GroupID"
							 AppendDataBoundItems="true" AutoPostBack="true" >
							<asp:ListItem Selected="True" Value="0" Text="Все"></asp:ListItem>
						</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td><b>Город:</b></td>
				<td><asp:DropDownList ID="ddlCityFilter" runat="server" 
							DataSourceID="ODSCityFilter" DataTextField="Name" DataValueField="GroupID"
							AutoPostBack="true" >						
						</asp:DropDownList></td>
			</tr>
			<tr>
				<td><b>Специализация:</b></td>
				<td><asp:DropDownList ID="ddlSpecialization" runat="server" 
							DataSourceID="ODSSpecializationFilter" DataTextField="Name" DataValueField="GroupID"
							AutoPostBack="true" >
						</asp:DropDownList></td>
			</tr>
			<tr>
				<td><b>Компания:</b></td>
				<td><asp:TextBox runat="server" ID="txtCompanyFilter"></asp:TextBox> <asp:Button runat="server" ID="btnSearch" Text="Искать" OnClick="btnSearch_Click"/></td>
			</tr>			
		</table>
		<br />
    </div>
     
        <asp:GridView ID="GridViewItemsList" runat="server" Width="100%" AutoGenerateColumns="False"
            DataKeyNames="GroupID" DataSourceID="ObjectDataSourceItemsList" AllowPaging="True"
            PageSize="15" OnSelectedIndexChanged="GridViewItemsList_SelectedIndexChanged"
            OnRowDeleted="GridViewItemsList_RowDeleted" OnRowCommand="GridViewItemsList_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Редактирование">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="Select" ImageUrl="~/img/edit.png"
                            AlternateText="Edit" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="На сайте">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgOn" runat="server" Visible='<%#(bool)Eval("Publish") %>' CommandName="Off" CommandArgument='<%# Eval("GroupID") %>' ImageUrl="~/img/on.gif" />
                        <asp:ImageButton ID="imgOff" runat="server" Visible='<%#!(bool)Eval("Publish") %>' CommandName="On" CommandArgument='<%# Eval("GroupID") %>' ImageUrl="~/img/off.gif" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                
                <asp:BoundField DataField="Name" HeaderText="Название" SortExpression="Name">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="CityName" HeaderText="Город" SortExpression="CityName">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="Address" HeaderText="Адрес" SortExpression="Address">
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
        <asp:ObjectDataSource ID="ObjectDataSourceItemsList" runat="server" 
        SelectMethod="Partners_GetAllByLanguageRegionCitySpecializationAdmin"
            TypeName="Erc.Apple.Data.Partners" DataObjectTypeName="Erc.Apple.Data.Partner"
            DeleteMethod="DeleteGroup" >
            <SelectParameters>
                <asp:Parameter DefaultValue="ru" Name="language" Type="String" />
                <asp:ControlParameter ControlID="ddlCityFilter" DefaultValue="0" Name="cityID" Type="Int32" />
                <asp:ControlParameter ControlID="ddlSpecialization" DefaultValue="0" Name="specializationID" Type="Int32" />
                <asp:ControlParameter ControlID="ddlRegionFilter" DefaultValue="0" Name="regionID" Type="Int32" />
				<asp:ControlParameter ControlID="txtCompanyFilter" DefaultValue="" Name="company" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
    </asp:View>
    <asp:View ID="ViewEdit" runat="server">
		<div style="width:100%; text-align:left;">
		<table width="200" cellpadding="5">
			<tr style="background-color: rgb(239, 243, 251);">
				<td style="background-color: rgb(222, 232, 245);width:40px; font-weight: bold;">Область:
				</td>
				<td>
				<asp:DropDownList ID="ddlRegion" runat="server" AutoPostBack="true" DataSourceID="ODSRegion" DataTextField="Name" DataValueField="GroupID"></asp:DropDownList>
				</td>
			</tr>
			<tr style="background-color: rgb(239, 243, 251);">
				<td style="background-color: rgb(222, 232, 245);width:40px; font-weight: bold;">Город:
				</td>
				<td>
				<asp:DropDownList ID="ddlCity" runat="server" DataSourceID="ODSCity" DataTextField="Name" DataValueField="GroupID"></asp:DropDownList>
				</td>
			</tr>
			<tr style="background-color: rgb(239, 243, 251);">
				<td style="background-color: rgb(222, 232, 245);width:40px; font-weight: bold;">Телефон:
				</td>
				<td>
				<asp:TextBox ID="txtTelephone" runat="server" ></asp:TextBox>
				</td>
			</tr>
			<tr style="background-color: rgb(239, 243, 251);">
				<td style="background-color: rgb(222, 232, 245);width:40px; font-weight: bold;">Веб адрес:
				</td>
				<td>
				<asp:TextBox ID="txtUrl" runat="server" ></asp:TextBox>
				</td>
			</tr>
			<tr style="background-color: rgb(239, 243, 251);">
				<td style="background-color: rgb(222, 232, 245);width:40px; font-weight: bold;">Статус:
				</td>
				<td>
				<asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="ODSPartnerStatus" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
				</td>
			</tr>
			<tr style="background-color: rgb(239, 243, 251);">
				<td style="background-color: rgb(222, 232, 245);width:40px; font-weight: bold;">Специализация:
				</td>
				<td>
				<asp:CheckBoxList ID="chbSpecialization" runat="server" 
				DataSourceID="ODSSpecialization" DataTextField="Name" DataValueField="GroupID"
				>					
				</asp:CheckBoxList>
				</td>
			</tr>
		</table>
		
		
		
        <asp:Repeater ID="RepeaterLang" runat="server" DataSourceID="ObjectDataSourceEditItem" OnItemDataBound="RepeaterLang_ItemDataBound">
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
            <asp:Button ID="btnSave" runat="server" Text="Сохранить"  OnClick="btnSave_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Закрыть"  OnClick="btnClose_Click" />
            <asp:Button ID="btnSaveAndClose" runat="server" Text="Сохранить и закрыть" Width="120px"  OnClick="btnSaveAndClose_Click" />
        </div>
        <asp:ObjectDataSource ID="ODSRegion" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAllByLanguage" TypeName="Erc.Apple.Data.Regions" 
            OnSelecting="ODSCategory_Selecting">
            <SelectParameters>
				<asp:Parameter DbType="string" DefaultValue="ru" Name="language" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODSRegionFilter" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAllByLanguage" TypeName="Erc.Apple.Data.Regions" 
            OnSelecting="ODSCategory_Selecting">
            <SelectParameters>
				<asp:Parameter DbType="string" DefaultValue="ru" Name="language" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODSCityFilter" runat="server" SelectMethod="GetAllByLanguageAndRegionFilter"
            TypeName="Erc.Apple.Data.Cities" DataObjectTypeName="Erc.Apple.Data.City"
            DeleteMethod="DeleteGroup" >
            <SelectParameters>
                <asp:Parameter DefaultValue="ru" Name="language" Type="String" />
                <asp:ControlParameter ControlID="DdlRegionFilter" DefaultValue="0" Name="regionId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODSCity" runat="server" SelectMethod="GetAllByLanguageAndRegion"
            TypeName="Erc.Apple.Data.Cities" DataObjectTypeName="Erc.Apple.Data.City">
            <SelectParameters>
                <asp:Parameter DefaultValue="ru" Name="language" Type="String" />
                <asp:ControlParameter ControlID="ddlRegion" DefaultValue="0" Name="regionId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODSSpecializationFilter" runat="server" SelectMethod="GetAllByLanguageFilter"
            TypeName="Erc.Apple.Data.Specializations" DataObjectTypeName="Erc.Apple.Data.Specialization">            
            <SelectParameters>
				<asp:Parameter DefaultValue="ru" Name="language" Type="String" />
            </SelectParameters>            
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODSSpecialization" runat="server" SelectMethod="GetAllByLanguage"
            TypeName="Erc.Apple.Data.Specializations" DataObjectTypeName="Erc.Apple.Data.Specialization">            
            <SelectParameters>
				<asp:Parameter DefaultValue="ru" Name="language" Type="String" />
            </SelectParameters>            
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODSPartnerStatus" runat="server" SelectMethod="GetAll"
            TypeName="Erc.Apple.Data.PartnerStatuses" DataObjectTypeName="Erc.Apple.Data.PartnerStatus">            
        </asp:ObjectDataSource>
        
        
    </asp:View>
</asp:MultiView>
