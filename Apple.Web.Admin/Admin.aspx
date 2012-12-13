<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    Codebehind="Admin.aspx.cs" Inherits="Apple.Web.Admin.AdminsPage" Title="Admin Page" %>
<%@ Register TagPrefix="uc" Namespace="Apple.Web.Admin.Controls" Assembly="Apple.Web.Admin" %>
<%@ Register TagPrefix="uc" TagName="AddButton" Src="~/Controls/AddItemButton.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <uc:CustomMenu ID="menu1" runat="server"></uc:CustomMenu>
    <div id="content">
        <div id="sitepath" style="float: left;">
            <asp:Label ID="lblTabContentTitle" runat="server"></asp:Label>
        </div>
        <div style="float:right;">
            <uc:AddButton ID="btnAdd" Visible="false" runat="server" />
        </div>
        <div style="clear: both;">
        </div>
        <asp:Label ID="lblError" CssClass="ErrorMess" EnableViewState="false" runat="server"></asp:Label>
        <asp:Label ID="lblInfo" CssClass="Mess" EnableViewState="false" runat="server"></asp:Label>
        <asp:Panel ID="PanelMain" runat="server">
        </asp:Panel>
    </div>
</asp:Content>
