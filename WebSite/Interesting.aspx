<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" Codebehind="Interesting.aspx.cs"
    Inherits="Apple.Web.Interesting" Title="Интересно знать" %>

<%@ Register TagPrefix="uc" TagName="News" Src="~/Controls/TopNewsList.ascx" %>
<%@ Register TagPrefix="uc" TagName="LatestProducts" Src="~/Controls/LatestProductsList.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <uc:LatestProducts ID="products" Title="Последние новинки Apple" PageID="2" runat="server" />
    </div>
    <div class="bg_int">
        Интересно знать
    </div>
    <uc:News ID="news" NewsCount="5" PageID="2" runat="server" />
</asp:Content>
