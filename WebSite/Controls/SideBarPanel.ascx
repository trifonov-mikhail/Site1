<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SideBarPanel.ascx.cs" Inherits="Apple.Web.Controls.SideBarPanel" %>
<asp:Repeater ID="rItems" runat="server" OnItemDataBound="rItems_ItemDataBound">
    <HeaderTemplate>
        <table align="right">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td class="txtrightmenu">
                <asp:HyperLink ID="hl1" runat="server"></asp:HyperLink>
            </td>
            <td>
                <asp:HyperLink ID="hl2" runat="server">
                    <asp:Image ID="icon_news" ImageUrl='<%#Eval("ImageUrl") %>' ImageAlign="Middle" runat="server" />
                </asp:HyperLink>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
