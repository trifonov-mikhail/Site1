<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AllSuccessStories.ascx.cs" Inherits="Apple.Web.Controls.AllSuccessStories" %>
<style type="text/css">
.main {
margin:0 0 30px 25px;
}
</style>
<asp:GridView ID="gvSS" runat="server" AllowPaging="true" PageSize=2 AutoGenerateColumns="false" GridLines="None" 
CellPadding="0"  Width="680px">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
             <div id="last-news" style="margin-bottom: 15px;margin-top:15px;">
                <div class="date2">
                    <span id="ctl00_MainContent_mainNews_fvItem_Label1"><asp:Literal ID="ltDate" runat="server" Text='<%# Bind("Date","{0:dd MMMM yyyy}") %>'></asp:Literal></span>
                </div>
                <h2><strong><asp:Literal runat="server" ID="ltTitle" Text='<%# Bind("Title") %>'></asp:Literal></strong></h2>
                <p style="margin: 30px 0;">
                <asp:Image ID="i" ImageUrl='<%# Eval("GroupID","~/GetImage.ashx?type=8&id={0}") %>' runat="server" align="left" style="padding-right: 10px;" /><asp:Literal ID="ltText" runat="server" Text='<%# Bind("Text") %>'></asp:Literal>
                </p>
                <p style="margin-bottom:40px;"><img src='<%=this.ResolveUrl("~/images/iconPDF.png") %>' alt="" width="16" height="16" align="absmiddle" /> 
                <asp:HyperLink ID="hlPdfFile" Text='<%$ Resources: AppleRes, ReadMore %>'  NavigateUrl='<%# string.Format("~/GetPDF.ashx?type=1&groupid={0}&lang={1}",Eval("GroupID"), Eval("LangCode")) %>'
                            runat="server" Visible='<%#Eval("HasPdfFile") %>' /></p>
                
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerStyle CssClass="pager" HorizontalAlign="Right" />
</asp:GridView>