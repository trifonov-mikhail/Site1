<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DownloadFileDetails.ascx.cs" Inherits="Apple.Web.Admin.Controls.Editors.DownloadFileDetails" %>
<asp:MultiView ID="MvEditor" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewList" runat="server">
    <asp:DropDownList runat="server" ID="ddlCategory" AutoPostBack="true">
        <asp:ListItem Value="0" Text="Выберите"></asp:ListItem>
        <asp:ListItem Value="1" Text="Mac OS X"></asp:ListItem>
        <asp:ListItem Value="2" Text="iLife"></asp:ListItem>
        <asp:ListItem Value="3" Text="iWork"></asp:ListItem>
    </asp:DropDownList>
    <!--OnDataBound="GridViewItemsList_DataBound" -->
	
	<asp:GridView ID="GridViewItemsList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            DataSourceID="ObjectDataSourceItemsList" AllowPaging="True" PageSize="10" EmptyDataText="There are no data records to display."
            Width="400px" CssClass="mylist" OnSelectedIndexChanging="GridViewItemsList_SelectedIndexChanging" OnRowCommand="GridViewItemsList_RowCommand"
            >
            <Columns>
                <asp:TemplateField HeaderText="Редактирование">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="Select" ImageUrl="~/img/edit.png"
                            AlternateText="Редактирование" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Название продукта" SortExpression="Name">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="Краткое описание" SortExpression="Description">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="FileName" HeaderText="Имя файла" SortExpression="FileName">
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
				<asp:TemplateField HeaderText="Удаление">
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnDownloadList" Text="Скачать список пользователей" Width="180px" CommandArgument='<%#Eval("ID") %>' CommandName="Download" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceItemsList" runat="server" DataObjectTypeName="Erc.Apple.Data.DownloadFile"
            SelectMethod="GetByTypeId" TypeName="Erc.Apple.Data.DownloadFiles" DeleteMethod="Delete" OnDeleting="ObjectDataSourceItemsList_OnDeleting">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCategory" Name="typeid" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>			
        </asp:ObjectDataSource>
    </asp:View>
    
    
    <asp:View ID="ViewEdit" runat="server">
    <asp:DetailsView ID="DetailsViewEditItem" runat="server" AutoGenerateRows="False"
            DataKeyNames="ID" DataSourceID="ObjectDataSourceEditItem" DefaultMode="Insert"
            Height="50px" Width="400px" CaptionAlign="Top" OnItemUpdating="DetailsViewEditItem_ItemUpdating"
            OnItemInserting="DetailsViewEditItem_ItemInserting">
            <CommandRowStyle HorizontalAlign="Right" />
            <Fields>
                <asp:TemplateField HeaderText="Название продукта" SortExpression="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Категория" SortExpression="TypeID">
                    <EditItemTemplate>
                        <asp:DropDownList runat="server" ID="ddlCategory"  SelectedValue = '<%# Bind("TypeId") %>'>
                            <asp:ListItem Value="0" Text="Выберите"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Mac OS X"></asp:ListItem>
                            <asp:ListItem Value="2" Text="iLife"></asp:ListItem>
                            <asp:ListItem Value="3" Text="iWork"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:DropDownList runat="server" ID="ddlCategory" SelectedValue = '<%# Bind("TypeId") %>' >
                            <asp:ListItem Value="0" Text="Выберите"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Mac OS X"></asp:ListItem>
                            <asp:ListItem Value="2" Text="iLife"></asp:ListItem>
                            <asp:ListItem Value="3" Text="iWork"></asp:ListItem>
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:DropDownList runat="server" ID="ddlCategory"  SelectedValue = '<%# Bind("TypeId") %>'>
                            <asp:ListItem Value="0" Text="Выберите"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Mac OS X"></asp:ListItem>
                            <asp:ListItem Value="2" Text="iLife"></asp:ListItem>
                            <asp:ListItem Value="3" Text="iWork"></asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:FileUpload ID="fuFile" runat="server" />
                        <%--<asp:PlaceHolder runat="server" Visible='<%#(Eval("FileName") != null && !string.IsNullOrEmpty(Eval("FileName").ToString())) %>'>
                        
                                    <a href='<%=this.ResolveUrl("~/GetDownloadFile.ashx?id=" + Eval("ID").ToString())%>>скачать</a>
                                    </asp:PlaceHolder>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Описание" SortExpression="Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
            <FieldHeaderStyle HorizontalAlign="Left" />
        </asp:DetailsView>
	<asp:PlaceHolder ID="dwnImagePanel" runat="server">	
	<table cellspacing="0" cellpadding="6" border="0" style="color: rgb(51, 51, 51); height: 50px; width: 400px; border-collapse: collapse;">
			<tbody>
			<tr style="background-color: rgb(239, 243, 251);">
			<td align="left" style="background-color: rgb(222, 232, 245); font-weight: bold;width:70px;">Картинка</td>
			<td>
			<asp:FileUpload ID="fuImage" runat="server" /> <asp:Button runat="server" Visible="false" ID="btnDwnImage" OnClick="btnDwnImage_Click" Text="Загрузить картинку" /><asp:Button runat="server" ID="btnDeleteImage" OnClick="btnDeleteImage_Click" Visible="true" Text="Удалить картинку" />
			<br />
			<img src='<%=GetImagePath() %>' />
			</td>

			</tr>
			</tbody>
	</table>
	
    </asp:PlaceHolder>

        <asp:ObjectDataSource ID="ObjectDataSourceEditItem" runat="server" DataObjectTypeName="Erc.Apple.Data.DownloadFile"
            InsertMethod="Add" SelectMethod="GetByID" TypeName="Erc.Apple.Data.DownloadFiles"
            UpdateMethod="Update" OldValuesParameterFormatString="original_{0}" OnUpdating="ObjectDataSourceEditItem_Updating">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridViewItemsList" Name="id" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="item" Type="Object" />                
            </UpdateParameters>
            <InsertParameters>
                <asp:ControlParameter ControlID="ddlCategory"/>
            </InsertParameters>
        </asp:ObjectDataSource>
        <div style="text-align: right;">
            <asp:Button ID="btnSave" runat="server" Text="Сохранить" OnClick="btnSave_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Закрыть" OnClick="btnClose_Click" />
            <asp:Button ID="btnSaveAndClose" runat="server" Text="Сохранить и закрыть" Width="120px"
                OnClick="btnSaveAndClose_Click" />
    </asp:View>
</asp:MultiView>