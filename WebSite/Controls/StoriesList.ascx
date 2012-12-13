<%@ Control Language="C#" AutoEventWireup="true" Codebehind="StoriesList.ascx.cs"
    Inherits="Apple.Web.Controls.StoriesList" %>
<div style="margin-left:20px;">
    <asp:DataList ID="dlItems" runat="server" DataSourceID="odsItems" RepeatColumns="4"
        RepeatDirection="Horizontal" CellPadding="5" OnPreRender="dlItems_PreRender">
        <HeaderTemplate>
            <h2>
                Истории</h2>
        </HeaderTemplate>
        <ItemTemplate>
            <div style="margin-bottom: 20px;">
                <asp:Image ID="i" ImageUrl='<%# Eval("GroupID","~/GetImage.ashx?type=4&id={0}") %>'
                    runat="server" />
            </div>
            <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' Font-Bold="true"></asp:Label><br />
            <asp:Label ID="NoticeLabel" runat="server" Text='<%# Eval("Notice") %>'></asp:Label><br />
            <asp:Label ID="TextLabel" runat="server" Text='<%# Eval("Text") %>'></asp:Label><br />
<asp:PlaceHolder runat="server" Visible='<%#(bool.Parse(Eval("HasPdfFile").ToString())) %>'>
               <p style="margin-bottom:40px;"><img src='<%=this.ResolveUrl("~/images/iconPDF.png") %>' alt="" width="16" height="16" align="absmiddle" /> 
                <asp:HyperLink ID="hlPdfFile" Text='<%$ Resources: AppleRes, ReadMore %>'  NavigateUrl='<%# string.Format("~/GetPDF.ashx?type=2&groupid={0}&lang={1}",Eval("GroupID"), Eval("LangCode")) %>'
              runat="server" Visible='<%#Eval("HasPdfFile") %>' /></p>
</asp:PlaceHolder>
        </ItemTemplate>
        <ItemStyle Width="160" HorizontalAlign="Left" VerticalAlign="Top" />
    </asp:DataList>
</div>
<asp:ObjectDataSource ID="odsItems" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetByLangForSection" TypeName="Erc.Apple.Data.Stories" OnSelecting="odsItems_Selecting">
    <SelectParameters>
        <asp:Parameter Name="langCode" Type="String" />
        <asp:Parameter Name="sectionID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
