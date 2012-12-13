<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ProductList.ascx.cs"
    Inherits="Apple.Web.Controls.ProductList" %>
<%@ Register TagPrefix="uc" TagName="Category" Src="~/Controls/ProductCategory.ascx" %>

<asp:Repeater ID="rCategories" runat="server" DataSourceID="odsCategories">
    <ItemTemplate>
        <uc:Category ID="c" runat="server" ItemIndex='<%#Container.ItemIndex+1 %>' CategoryID='<%#Eval("GroupID") %>' CategoryName='<%#Eval("Name") %>' />
    </ItemTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="odsCategories" runat="server" OldValuesParameterFormatString="original_{0}"
    OnSelecting="odsCategories_Selecting" SelectMethod="GetAllByLanguage" TypeName="Erc.Apple.Data.Categories">
    <SelectParameters>
        <asp:Parameter Name="language" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
