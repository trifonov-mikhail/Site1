<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SMB-registration.aspx.cs" Inherits="Apple.Web.SMB_registration" %>
<%@ Register TagPrefix="uc" TagName="RequestForm" Src="~/Controls/SeminarRegistrationControl.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:RequestForm ID="form1" runat="server" />
</asp:Content>

