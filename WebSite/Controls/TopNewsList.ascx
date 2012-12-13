<%@ Control Language="C#" AutoEventWireup="true" Codebehind="TopNewsList.ascx.cs"
    Inherits="Apple.Web.Controls.TopNewsList" %>
<asp:Repeater ID="rItems" runat="server" DataSourceID="odsItems" OnItemDataBound="rItems_ItemDataBound">
    <HeaderTemplate>
        <table width="680" style="margin-bottom: 20px;">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td class="date" style="padding-top:2px;">
                <asp:Label ID="Label1" runat="server" Width="160" Text='<%# Eval("Date","{0:dd MMMM yyyy}") %>'></asp:Label>
            </td>
            <td class="txt_news">
                <h5>
                    <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                    <asp:HyperLink ID="hlTitle" Visible="false" Text='<%# Eval("Title") %>' NavigateUrl='<%# Eval("LinkUrl") %>' runat="server"></asp:HyperLink>
                </h5>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Text") %>'></asp:Label>
                <asp:PlaceHolder ID="phMore" Visible="false" runat="server">
                    <asp:Label ID="lblMore" runat="server" Text="Читайте дальше: " />
                    <asp:HyperLink ID="hlMore" Text=">>" NavigateUrl='<%# Eval("LinkUrl") %>' runat="server" />
                </asp:PlaceHolder>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        <tr>
            <td class="date">
                <a href="<%=GetUrl("~/{lang}/NewsArchive.aspx") %>">Архив новостей</a></td>
            <td class="txt_news">
            </td>
        </tr>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="odsItems" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetByLangForPageTopN" TypeName="Erc.Apple.Data.News" OnSelecting="odsItems_Selecting">
    <SelectParameters>
        <asp:Parameter Name="langCode" Type="String" />
        <asp:Parameter Name="pageID" Type="Int32" />
        <asp:Parameter Name="count" Type="Int32" />
        <asp:Parameter Name="skipMain" Type="Boolean" />
    </SelectParameters>
</asp:ObjectDataSource>
