<%@ Control Language="C#" AutoEventWireup="true" Codebehind="LangSwitcher.ascx.cs"
    Inherits="Apple.Web.Controls.LangSwitcher" %>
<asp:Repeater ID="rLangs" runat="server" DataSourceID="odsLangs" OnItemDataBound="rLangs_ItemDataBound">
    <HeaderTemplate>
        <div id="langauge_selector">
    </HeaderTemplate>
    <ItemTemplate>
        <asp:HyperLink ID="hlLang" runat="server">
        </asp:HyperLink>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="odsLangs" runat="server" SelectMethod="GetAll" TypeName="Erc.Apple.Data.Cache.LanguagesCache">
</asp:ObjectDataSource>
