<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" 
CodeBehind="Request_ACP.aspx.cs" Inherits="Apple.Web.Request_ACP" Title="Заявка на получение статуса Authorized Collection Point" %>
<%@ Register TagPrefix="uc" TagName="RequestForm" Src="~/Controls/RequestStatusForm.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:RequestForm ID="form1" Status="ACP" runat="server" />
</asp:Content>
