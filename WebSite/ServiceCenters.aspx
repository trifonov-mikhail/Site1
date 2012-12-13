<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" Codebehind="ServiceCenters.aspx.cs"
    Inherits="Apple.Web.ServiceCenters" Title="Авторизованные сервисные центры Apple" %>

<%@ Register TagPrefix="uc" TagName="ServiceCenters" Src="~/Controls/ServiceCenters.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="SecondMenu" runat="server">
    <asp:Localize ID="localize1" runat="server" Text='<%$ Resources: AppleRes,  ServiceCenters.SecondMenu %>'></asp:Localize>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:ServiceCenters ID="sc" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
        <table align="right" style="margin-right:7px;">
  <tbody><tr>
    <td class="txtrightmenu" style="padding-right: 10px;"><a href="http://www.erc.ua/Service/#&&p=5">Узнать <br />о ходе ремонта</a></td>
    <td><a href="http://www.erc.ua/Service/#&&p=5"><img align="middle" alt="" src='<%=this.GetUrl("~/images/icon_remont.png") %>'/></a> </td>
  </tr>
  <tr>
    <td class="txtrightmenu" style="padding-right: 10px;"><a href="http://www.apple.com/ru/support/exchange_repair/">Программы Apple <br/>по замене и ремонту</a></td>
    <td><a href="http://www.apple.com/ru/support/exchange_repair/"><img align="middle" alt="" src='<%=this.GetUrl("~/images/icon_programms.png") %>'/></a></td>
  </tr>
  <tr>
    <td class="txtrightmenu" style="padding-right: 10px;"><a href='<%=this.GetUrl("~/{lang}/content/important.aspx") %>'>Что важно знать о гарантии</a></td>
    <td><a href='<%=this.GetUrl("~/{lang}/content/important.aspx") %>'><img align="middle" alt="" src='<%=this.GetUrl("~/images/iconimportant.png") %>'/></a></td>
  </tr>
<tr>
	<td class="txtrightmenu"><a href="<%=this.GetUrl("~/{lang}/Request_SN.aspx") %>">Проверка серийного номера</a></td>
	<td><a href="<%=this.GetUrl("~/{lang}/Request_SN.aspx") %>"><img src="<%=this.GetUrl("~/images/sn.jpg") %>" alt="sn.jpg" align="middle" /></a></td>
</tr>    
<tr>
	<td class="txtrightmenu"><a href="<%=this.GetUrl("~/files/shipping.pdf") %>">Отправка изделий в сервисный центр</a></td>
	<td><a href="<%=this.GetUrl("~/files/shipping.pdf") %>"><img src="<%=this.GetUrl("~/images/shipping.jpg") %>" alt="Shipping" style="padding-top:3px;" align="middle" width="57px" /></a></td>
</tr>    
</tbody></table>

</asp:Content>