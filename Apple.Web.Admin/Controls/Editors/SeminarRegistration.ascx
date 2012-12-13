<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SeminarRegistration.ascx.cs" Inherits="Apple.Web.Admin.Controls.Editors.SeminarRegistration" %>
<%@ Register Namespace="Apple.Web.Admin.Controls" TagPrefix="UC" Assembly="Apple.Web.Admin" %>    
<div style="text-align: left;">
            <h3>
                Семинар:
                <asp:DropDownList ID="dllSeminars" runat="server" AutoPostBack="true">
                    <asp:ListItem Selected="True" Value="1" Text="SMB семинар 09.12.2010"></asp:ListItem>                    
                </asp:DropDownList>
            </h3>
            <br />
            Email: <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox><asp:Button runat="server" ID="btn" Text="Фильтровать"/>
            <br />
            Отправленно поздравлений: <asp:Literal runat="server" ID="ltCount"></asp:Literal>
            <br />
        </div>
        <asp:GridView ID="GridViewItemsList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            DataSourceID="ObjectDataSourceItemsList" AllowPaging="True" PageSize="20" EmptyDataText="Нет данных для отображения."
            Width="100%" CssClass="mylist" OnRowDataBound="GridViewItemsList_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkSelected" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:TemplateField>
                <asp:BoundField DataField="FIO" HeaderText="ФИО" SortExpression="FIO">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="CompanyName" HeaderText="Название компании" SortExpression="CompanyName">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="JobTitle" HeaderText="Должность" SortExpression="JobTitle">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Site" HeaderText="Сайт" SortExpression="Site">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Тип сообщения">
                    <ItemTemplate>
                        <asp:Literal runat="server" Visible='<%#(int)Eval("SentEmailType") == 0 %>'>Не отправленно</asp:Literal>
                        <asp:Literal ID="Literal1" runat="server" Visible='<%#(int)Eval("SentEmailType") == 1 %>'>Поздравление</asp:Literal>
                        <asp:Literal ID="Literal2" runat="server" Visible='<%#(int)Eval("SentEmailType") == 2 %>'>Отказ</asp:Literal>
                        <asp:Literal ID="Literal3" runat="server" Visible='<%#(int)Eval("SentEmailType") == 3 %>'>Напоминание</asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:DropDownList runat="server" ID="ddlJobAction" Enabled="false" >
                                  <asp:ListItem Value="1" Text="Брендовая розница"              ></asp:ListItem>
                                  <asp:ListItem Value="2" Text="Медийное агентство"             ></asp:ListItem>
                                  <asp:ListItem Value="3" Text="Маркетинговое агентство"        ></asp:ListItem>
                                  <asp:ListItem Value="4" Text="Туристическое агентство"        ></asp:ListItem>
                                  <asp:ListItem Value="5" Text="Юридическая компания"           ></asp:ListItem>
                                  <asp:ListItem Value="6" Text="Другие профессиональные услуги" ></asp:ListItem>
                                  <asp:ListItem Value="7" Text="Торговая компания"></asp:ListItem>
                         </asp:DropDownList>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:TemplateField>
                <asp:BoundField DataField="DateCreated" HeaderText="Дата регистрации" SortExpression="DateCreated">
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
                <%--<asp:TemplateField HeaderText="Удаление">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonDelete" runat="server" CommandName="Delete" ImageUrl="~/img/delete.png"
                            AlternateText="Delete" OnClientClick="return confirm('Delete item?');" />&nbsp;
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
        <asp:DropDownList runat="server" ID="EmailType">
            <asp:ListItem Value="1" Text="Отправка поздравления"></asp:ListItem>
            <asp:ListItem Value="2" Text="Отправка об отсутсвия мест"></asp:ListItem>
            <asp:ListItem Value="3" Text="Отправка напоминания"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button runat="server" ID="btnSend"  Text="Отправить" OnClick="btnSend_Click"/>
        <asp:Button runat="server" ID="btnRemind" Text="Напоминание" />
        
        <asp:ObjectDataSource ID="ObjectDataSourceItemsList" runat="server" DataObjectTypeName="Erc.Apple.Data.SeminarRegistration"
            SelectMethod="GetByType" TypeName="Erc.Apple.Data.SeminarRegistrations" DeleteMethod="DeleteById">
            <SelectParameters>
                <asp:ControlParameter ControlID="dllSeminars" Name="typeID" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:SessionParameter Name="emailType" SessionField="emailType"/> 
                <asp:ControlParameter ControlID="txtEmail" Name="email" PropertyName="Text" Type="String" />
            </SelectParameters>            
        </asp:ObjectDataSource>
<% if(SentEmailType == 1)
   {%>
 <br />
<UC:GetCsvControl id="csv" runat="server" DataSourceID="ObjectDataSourceItemsList" />
<br />
<% }%>