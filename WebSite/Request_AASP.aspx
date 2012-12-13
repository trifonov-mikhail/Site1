<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" 
CodeBehind="Request_AASP.aspx.cs" Inherits="Apple.Web.Request_AASP" Title="Заявка на получение статуса Authorised Service Provider" %>
<%@ Register TagPrefix="uc" TagName="RequestForm" Src="~/Controls/RequestStatusForm.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:RequestForm ID="form1" Status="AASP" runat="server" />
</asp:Content>
