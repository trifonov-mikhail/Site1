<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" Codebehind="Default.aspx.cs"
    Inherits="Apple.Web.Default" %>

<%@ Register TagPrefix="uc" TagName="Default" Src="~/Controls/Default.ascx" %>
    
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <uc:Default id="def" runat="server" />
</asp:Content>


