<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" Codebehind="WhereToBuy.aspx.cs"
    Inherits="Apple.Web.WhereToBuy"%>

<%@ Register TagPrefix="uc" TagName="WhereToBuy" Src="~/Controls/WhereToBuy.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:WhereToBuy id="wbt" runat="server" />
</asp:Content>

