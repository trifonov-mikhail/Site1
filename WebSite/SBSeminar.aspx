<%@ Page Title="" Language="C#" MasterPageFile="~/DynamicPage.Master" AutoEventWireup="true" Inherits="Apple.Web.PageBase" %>
<%@ Register src="Controls/ReadTemplateControl.ascx" tagname="ReadTemplateControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
    <uc1:ReadTemplateControl FileName="HowCan" ID="ReadTemplateControl1" runat="server" />    
</asp:Content>
