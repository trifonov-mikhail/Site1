<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" Codebehind="News.aspx.cs"
    Inherits="Apple.Web.NewsPage" Title="Новости" %>

<%@ Register TagPrefix="uc" TagName="MainNews" Src="~/Controls/MainOneNews.ascx" %>
<%@ Register TagPrefix="uc" TagName="NewsList" Src="~/Controls/TopNewsTitles.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main">
        <h6 style="margin: 30px 0 35px 0;">
            Новости</h6>
        <uc:MainNews ID="mainNews" runat="server" />
        <uc:NewsList ID="news" OpenFirst="false" SkipMain="true" PageID="3" runat="server" />
    </div>
</asp:Content>
