<%@ Control Language="C#" AutoEventWireup="true" Codebehind="LatestProductsList.ascx.cs"
    Inherits="Apple.Web.Controls.LatestProductsList" %>
<div>
    <table width="700" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="ug1">
            </td>
            <td class="ugc">
            </td>
            <td class="ug2">
            </td>
        </tr>
        <tr>
            <td class="ugc">
            </td>
            <td class="ugtxt">
                <h1 style="padding-bottom: 10px; font-weight:bold; text-align:center;">
                    <%=Title %>
                </h1>
                <asp:Repeater ID="rItems" runat="server" DataSourceID="odsItems" OnPreRender="rItems_PreRender">
                    <HeaderTemplate>
                        <table border="0" cellspacing="0" cellpadding="5">
                            <tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <td>
                            <asp:HyperLink ID="link" NavigateUrl='<%# Eval("LinkUrl") %>' runat="server">
                                <asp:Image ID="img" ImageUrl='<%# Eval("GroupID","~/GetImage.ashx?type=6&id={0}") %>' runat="server" />
                            </asp:HyperLink>
                        </td>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tr> </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
            <td class="ugc">
            </td>
        </tr>
        <tr>
            <td class="ug4">
            </td>
            <td class="ugc">
            </td>
            <td class="ug3">
            </td>
        </tr>
    </table>
</div>
<asp:ObjectDataSource ID="odsItems" runat="server" OldValuesParameterFormatString="original_{0}"
    TypeName="Erc.Apple.Data.LatestProducts" OnSelecting="odsItems_Selecting">
    <SelectParameters>
        <asp:Parameter Name="langCode" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
