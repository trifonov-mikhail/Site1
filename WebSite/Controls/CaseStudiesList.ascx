<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaseStudiesList.ascx.cs" Inherits="Apple.Web.Controls.CaseStudiesList" %>

<asp:Repeater ID="rCaseStudies" runat="server" DataSourceID="odsCaseStudies" OnItemDataBound="rCaseStudies_ItemDataBound">
</asp:Repeater>
<asp:ObjectDataSource ID="odsCaseStudies" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetByLangForSection" TypeName="Erc.Apple.Data.CaseStudies" OnSelecting="odsCaseStudies_Selecting">
    <SelectParameters>
        <asp:Parameter Name="langCode" Type="String" />
        <asp:Parameter Name="sectionID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

