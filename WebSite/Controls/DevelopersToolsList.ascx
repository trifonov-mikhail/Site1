<%@ Control Language="C#" AutoEventWireup="true" Codebehind="DevelopersToolsList.ascx.cs"
    Inherits="Apple.Web.Controls.DevelopersToolsList" %>
<asp:Repeater ID="rItems" runat="server" DataSourceID="odsItems">
    <HeaderTemplate>
        <div id="tools-list" style="margin: 20px 0;">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="tools-item">
            <h2 style="margin: 35px 0 5px 27px;">
                <asp:Label ID="Label1" Font-Bold="true" Text='<%# Eval("Title") %>' runat="server"></asp:Label>
                <asp:Label ID="Label2" Text='<%# Eval("Notice") %>' runat="server"></asp:Label>
            </h2>
            <div class="col1dev">
                <asp:Image ID="i" ImageUrl='<%# Eval("GroupID","~/GetImage.ashx?type=5&id={0}") %>'
                    runat="server" />
            </div>
            <div class="col2dev">
                <asp:Literal ID="Literal1" Text='<%# Eval("Text") %>' runat="server"></asp:Literal>
            </div>
            <div class="clear">
            </div>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="odsItems" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAll" TypeName="Erc.Apple.Data.DevelopersTools" OnSelecting="odsItems_Selecting">
    <SelectParameters>
        <asp:Parameter Name="langCode" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
