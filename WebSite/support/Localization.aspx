<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Localization.aspx.cs" Inherits="Apple.Web.Localization" %>
<asp:Content ContentPlaceHolderID="SecondMenu" ID="C1" runat="server">
<!-- include the Tools -->
	<script src="http://cdn.jquerytools.org/1.2.5/full/jquery.tools.min.js"></script>

	 

	<!-- standalone page styling (can be removed) -->
	<link rel="stylesheet" type="text/css" href='<%=this.ResolveUrl("~/css/standalone.css")%>'/>	


	<link rel="stylesheet" type="text/css" href='<%=this.ResolveUrl("~/css/overlay-apple.css")%>'/>
	
	<style>
	
	/* use a semi-transparent image for the overlay */
	#overlay {
		background-image:url(<%=this.ResolveUrl("~/images/transparent.png")%>);
		color:#efefef;
		height:250px;
	}
	
	/* container for external content. uses vertical scrollbar, if needed */
	div.contentWrap {
		height:315px;
		overflow-y:auto;
	}
	</style>

<div id="contentmenu">
	<table width="100%">
		<tr>
			<td>
				<img src="../../images/contentmenu_separator2.gif"" alt="" />
				<a href="../support/Warranty.aspx">Гарантийные<br /> обязательства Apple</a>
			</td>
			<td>
				<img src="../../images/contentmenu_separator2.gif" alt="" /><a href="../support/AASP.aspx">Получение
					статуса авторизованного<br /> сервисного центра по продукции Apple</a>
			</td>
			<td>
				<img src="../../images/contentmenu_separator2.gif" alt="" /><a href="../ServiceCenters.aspx">Авторизованные<br />
					сервисные центры Apple</a>
			</td>
		</tr>
	</table>
</div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<!-- #contentmenu-->
<div class="main">
			<table cellpadding="0" cellspacing="0">
				<tr>
					<td style="width: 170px;">
						<div class="greyroundblock">
							<img src="../../images/bg_block_top.gif" />
							<div class="greyroundblock_content">
								<h2>
									Служба поддержки Apple
								</h2>
								<br />
								<a href="/ru/support/localization.aspx" target="blank">Украинизация ПО</a><br />
								<br />
								<a href="http://support.apple.com/ru_RU/manuals/" target="blank">Руководства</a><br />
								<br />
								<a href="http://support.apple.com/ru_RU/specs/" target="blank">Характеристики</a>
								<br />
								<br />
								<a href="http://support.apple.com/ru_RU/downloads/" target="blank">Загрузка</a><br />
								<br />
								<a href="#">Устаревшее и снятое с эксплуатации оборудование</a>
								<br />
								<br />
								<a href="http://search.info.apple.com/" target="blank">Расширенный поиск информации по продукции Apple</a><br />
								<br />
								<a href="http://www.apple.com/ru/support/appleid/" target="blank">Получение Apple ID</a>
							</div>
						</div>
						<div class="clear">
						</div>
						<div class="greyroundblock">
							<img src="../../images/bg_block_top.gif" alt="" />
							<div class="greyroundblock_content">
								<h2>
									Часто задаваемые вопросы по поддержке
								</h2>
								<br />
								<a href="http://www.apple.com/ru/support/ipod/five_rs/" target="blank">Пять действий, которые решают большинство неполадок с iPod</a><br />
								<br />
								<a href="http://www.apple.com/ru/itunes/how-to/#video-sync" target="blank">Синхронизация музыки в iPod</a>
								<br />
								<br />
								<a href="http://discussions.apple.com/index.jspa" target="blank">Полезные советы при переходе c Windows на Mac </a>
								<br />
								<br />
								<a href="http://discussions.apple.com/index.jspa" target="blank">Полезные дискуссии по сервису (En)</a>
							</div>
						</div>
					</td>
					<td>
					</td>
					<td class="v-top">
<!-- make all links with the 'rel' attribute open overlays -->
<script>

    $(function() {

        // if the function argument is given to overlay,
        // it is assumed to be the onBeforeLoad event listener
        $("a[rel]").overlay({

            mask: 'gray',
            effect: 'apple',

            onBeforeLoad: function() {

                // grab wrapper element inside content
                var wrap = this.getOverlay().find(".contentWrap");

                // load the page specified in the trigger
                wrap.load(this.getTrigger().attr("href"));
            }

        });
    });
</script>

						<h1>Украинизация ПО</h1>
Пожалуйста, выберите категорию:  <asp:DropDownList runat="server" ID="ddlCategory" AutoPostBack="true" Width="200px">
        <asp:ListItem Value="0" Text="Все продукты"></asp:ListItem>
        <asp:ListItem Value="1" Text="Mac OS X"></asp:ListItem>
        <asp:ListItem Value="2" Text="iLife"></asp:ListItem>
        <asp:ListItem Value="3" Text="iWork"></asp:ListItem>
    </asp:DropDownList>	
    <!-- overlayed element -->

<div class="apple_overlay" id="overlay" style="width:370px;">

	<!-- the external content is loaded inside this tag -->
	<div class="contentWrap"></div>

</div>

 <asp:Repeater runat="server" ID="rptFile">
 <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 15px;">
 </HeaderTemplate>
 <ItemTemplate>
 <tr>
    <td style="width:95px"><img src='<%#GetImagePath(Eval("ID")) %>' alt="" style="padding: 10px 15px 0 0 " /></td>
    <td class="v-top" style="padding-bottom:10px;">
	<h2><%#Eval("Name") %></h2>
<%#Eval("Description") %>
<p><a href='<%#Eval("ID", "/ru/support/DownloadFileForm.aspx?id={0:d}") %>' rel="#overlay" target="blank">Скачать</a></p>
	</td>
  </tr>
  
 </ItemTemplate>
 <FooterTemplate>
</table>

<p style="margin-left: 95px;"><a href='<%=ResolveUrl("~/ru/support/Localization.aspx?items=archive") %>'>Архив</a></p>
    
 </FooterTemplate>
 </asp:Repeater>

					</td>
				</tr>
			</table>
		</div>
</asp:Content>
<asp:Content ID="c3" ContentPlaceHolderID="SideBarContent" runat="server">
<div class="clear"></div>
<!-- #container-->

	<table align="right">
		<tr>
			<td class="txtrightmenu">
				<a href="http://www.erc.ua/Service/#&&p=5" target="blank">Узнать о ходе ремонта</a>
			</td>
			<td>
				<a href="http://www.erc.ua/Service/#&&p=5" target="blank">
					<img src="../../images/icon_repair.png" alt="" align="middle" /></a>
			</td>
		</tr>
		<tr>
			<td class="txtrightmenu">
				<a href="http://www.apple.com/ru/support/exchange_repair/" target="blank">Программы Apple<br />
					по замене и ремонту</a>
			</td>
			<td>
				<a href="http://www.apple.com/ru/support/exchange_repair/" target="blank">
					<img src="../../images/icon_change_repair.png" alt="" align="middle" /></a>
			</td>
		</tr>
		<tr>
			<td class="txtrightmenu">
				<a href="../content/Important.aspx">Что важно знать о гарантии </a>
			</td>
			<td>
				<a href="../content/Important.aspx">
					<img src="../../images/iconimportant.png" alt="" align="middle" /></a>
			</td>
		</tr>
		<tr>
			<td class="txtrightmenu">
				<a href="../Request_SN.aspx">Проверка серийного номера</a>
			</td>
			<td>
				<a href="../Request_SN.aspx">
					<img src="../../images/sn.jpg" alt="sn.jpg" align="middle" /></a>
			</td>
		</tr>      
	</table>
<!-- .sidebar.sr -->
</asp:Content>
