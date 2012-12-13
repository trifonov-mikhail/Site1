<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" Codebehind="ForDevelopers.aspx.cs"
    Inherits="Apple.Web.ForDevelopers" %>
<%@ Register TagPrefix="uc" TagName="UsefulResources" Src="~/Controls/UsefulResourcesForDevelopers.ascx" %>
<%@ Register TagPrefix="uc" TagName="ToolsList" Src="~/Controls/DevelopersToolsList.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left:17px; width:650px; line-height:11px;">
        <asp:Literal ID="lText" runat="server"></asp:Literal>
    </div>
    <uc:UsefulResources ID="res" runat="server" />
    <uc:ToolsList ID="tools" runat="server" />
</asp:Content>
