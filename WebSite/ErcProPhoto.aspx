﻿<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" 
CodeBehind="ErcProPhoto.aspx.cs" Inherits="Apple.Web.ErcProPhoto" Title="ERC Pro Photo" %>

<%@ Register TagPrefix="uc" TagName="CsList" Src="~/Controls/CaseStudiesList.ascx" %>
<%@ Register TagPrefix="uc" TagName="StList" Src="~/Controls/StoriesList.ascx" %>
<%@ Register TagPrefix="uc" TagName="LatestProducts" Src="~/Controls/LatestProductsList2.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SecondMenu" runat="server">
<div id="contentmenu">
	<table class="foursection">
		<tbody><tr>
			<td>
				<img src="/images/contentmenu_separator2.gif" alt="">
				<a href="Consumers.aspx">Домашние <br>пользователи</a>
			</td>
			<td>
				<img src="/images/contentmenu_separator2.gif" alt="">Профессионалы:<br>
				<a href="ErcProAudio.aspx">Аудио</a> | 
				<a href="ErcProVideo.aspx">Видео</a> | 
				<a href="ErcProPhoto.aspx" style="font-weight:bold;">Фото</a>
			</td>
			<td>
				<img src="/images/contentmenu_separator2.gif" alt="">
				<a href="SMB.aspx">Малый и средний <br>бизнес</a>
			</td>
			<td>
				<img src="/images/contentmenu_separator2.gif" alt="">
				<a href="Education.aspx">Образование</a>
			</td>
		</tr>
	</tbody></table>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:CsList ID="cs" SectionID="4" runat="server" />
    <uc:StList ID="st" SectionID="4" runat="server" />
    <uc:LatestProducts ID="products" Title="Последние новинки Apple для профессионального фото" SectionID="4" runat="server" />
</asp:Content>
