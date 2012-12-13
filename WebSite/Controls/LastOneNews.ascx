<%@ Control Language="C#" AutoEventWireup="true" Codebehind="LastOneNews.ascx.cs"
    Inherits="Apple.Web.Controls.LastOneNews" %>
<asp:FormView ID="fvItem" runat="server" DataSourceID="odsItem">
    <ItemTemplate>
        <div id="last-news" style="margin-bottom: 15px;">
            <asp:Image ID="img" ImageAlign="Left" style="padding:0 10px 10px 0;" Visible='<%# Eval("HasImage") %>' ImageUrl='<%# Eval("GroupID","~/GetImage.ashx?type=2&id={0}") %>'
                runat="server" />
            <div class="date2">
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Date","{0:dd MMMM yyyy}") %>'></asp:Label>
            </div>
            <h5 style="margin: 5px 0 0 10px 0">
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
            </h5>
            <p style="margin-top: 20px;">
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Text") %>'></asp:Label>
            </p>
        </div>
    </ItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="odsItem" runat="server" OldValuesParameterFormatString="original_{0}"
    OnSelecting="odsItem_Selecting" SelectMethod="GetLastOneNewsForPage" TypeName="Erc.Apple.Data.News">
    <SelectParameters>
        <asp:Parameter Name="langCode" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
