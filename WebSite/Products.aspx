<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" Codebehind="Products.aspx.cs"
    Inherits="Apple.Web.ProductsPage" %>

<%@ Register TagPrefix="uc" TagName="ProductList" Src="~/Controls/ProductList.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        #content{
            margin-bottom:30px;
        }
    </style>
    <uc:ProductList ID="ProductList" runat="server" />
</asp:Content>
