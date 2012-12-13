<%@ Page Title="Истории успеха" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SuccessStories.aspx.cs" Inherits="Apple.Web.SuccessStories" %>

<%@ Register TagPrefix="uc" TagName="SuccessStoriesList" Src="~/Controls/AllSuccessStories.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SecondMenu" runat="server">
    <asp:Localize ID="localize1" runat="server" Text='<%$ Resources: AppleRes,  SuccessStories.SecondMenu %>'></asp:Localize>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main">
        <h6 style="margin: 30px 0 35px 0;">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources: AppleRes, SuccessStory%>" /></h6>
        
        <uc:SuccessStoriesList ID="news" runat="server" SkipFirst="false" PageSize="10" />
    </div>
</asp:Content>