<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" 
Codebehind="NewsArchive.aspx.cs"
    Inherits="Apple.Web.NewsArchive" Title="Архив Новостей" %>

<%@ Register TagPrefix="uc" TagName="NewsList" Src="~/Controls/AllNewsTitles.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main">
        <h6 style="margin: 30px 0 35px 0;">
            Архив Новостей</h6>
        
        <uc:NewsList ID="news" runat="server" SkipFirst="false" PageSize="10" />
    </div>
</asp:Content>
