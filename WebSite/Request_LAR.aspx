<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Request_LAR.aspx.cs" 
Inherits="Apple.Web.Request_LAR" Title="Заявка на получение статуса Limited Authorized Reseller" %>
<%@ Register TagPrefix="uc" TagName="RequestForm" Src="~/Controls/RequestStatusForm.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:RequestForm ID="form1" Status="LAR" runat="server" />
</asp:Content>
