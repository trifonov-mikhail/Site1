<%@ Page Title="" Language="C#" MasterPageFile="~/DynamicPage.Master" AutoEventWireup="true" Inherits="Apple.Web.PageBase" %>
<%@ Register src="Controls/ReadTemplateControl.ascx" tagname="ReadTemplateControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
<script runat="server" language="C#">
protected override void OnInit(EventArgs e)
{
    base.OnInit(e);
//    UnRegJS("~/js/jquery-1.3.2.min.js");
  //  UnRegJS("~/js/jquery-ui-1.7.2.custom.min.js");
//    UnRegJS("~/js/jquery.ifixpng.js");
    RegJS("~/js/jquery.cross-slide.min.js");
//    RegJS("~/js/jquery.min.js");

}
protected void Page_Load(object sender, EventArgs e)
{
    SideBarItemsNames.AddRange(new string[] { "about", "feedback", "SerialNumberCheck", "Important" });
}
</script>
<script type="javascript">
$.isEmptyObject = function(obj) { for (var name in obj) return false; return true; };

</script>
    <uc1:ReadTemplateControl FileName="SMBseminar" ID="ReadTemplateControl1" runat="server" />    
</asp:Content>
