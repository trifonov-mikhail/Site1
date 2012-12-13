<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" 
Codebehind="PartnersNews.aspx.cs" Inherits="Apple.Web.PartnersNews" Title="Новости для партнеров" %>

<%--<%@ Register TagPrefix="uc" TagName="LastNews" Src="~/Controls/LastOneNews.ascx" %>
<%@ Register TagPrefix="uc" TagName="NewsList" Src="~/Controls/TopNewsTitles.ascx" %>--%>
<%@ Register TagPrefix="uc" TagName="News" Src="~/Controls/TopNewsList.ascx" %>
<%@ Register TagPrefix="uc" TagName="LatestProducts" Src="~/Controls/LatestProductsList.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div class="main">
        <h6 style="margin:30px 0 75px 0;">
            Новости для партнеров</h6>
        <uc:LastNews ID="last" runat="server" />
        <uc:NewsList ID="news" runat="server" />
    </div>--%>
    <div>
        <uc:LatestProducts ID="products" Title="Последние новинки Apple" PageID="1" runat="server" />
    </div>
    <div class="bg_partnernews">
        Новости для партнеров
    </div>
    <uc:News ID="news" NewsCount="5" PageID="1" runat="server" />
</asp:Content>
