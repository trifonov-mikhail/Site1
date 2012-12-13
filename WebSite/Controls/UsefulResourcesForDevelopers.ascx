<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UsefulResourcesForDevelopers.ascx.cs"
    Inherits="Apple.Web.Controls.UsefulResourcesForDevelopers" %>
<asp:Repeater ID="rItems" runat="server" DataSourceID="odsItems" OnItemDataBound="rItems_ItemDataBound">
    <HeaderTemplate>
        <table width="650px" border="0" cellpadding="0" cellspacing="0" style="margin-top: 30px;margin-left:27px;">
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
                    <h1 style="padding-bottom: 10px;">
                        Полезные ресурсы для разработчиков 
                    </h1>
    </HeaderTemplate>
    <ItemTemplate>
        <div class="resource-item" style="font-size:12px;">
            <asp:HyperLink ID="hlRes" Text='<%# Eval("LinkText") %>' NavigateUrl='<%# Eval("LinkUrl") %>'
                runat="server" />
            <asp:Label ID="lDesrc" runat="server" />
        </div>
    </ItemTemplate>
    <FooterTemplate>
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
    </FooterTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="odsItems" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAll" TypeName="Erc.Apple.Data.DevelopersLinks" OnSelecting="odsItems_Selecting">
    <SelectParameters>
        <asp:Parameter Name="langCode" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
