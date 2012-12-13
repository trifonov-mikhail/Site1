<%@ Control Language="C#" AutoEventWireup="true" Codebehind="DatePicker.ascx.cs"
    Inherits="Apple.Web.Admin.Controls.DatePicker" %>
<span>
    <asp:TextBox ID="txtDate" Width="100" runat="server" AUTOCOMPLETE="off"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rvf" ControlToValidate="txtDate" Display="Dynamic" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
    <asp:Image ID="imgTrigger" ImageUrl="~/img/Calendar.png" Style="position: relative; top: 2px;" runat="server" />
</span>

<script type="text/javascript">
//<![CDATA 
    Zapatec.Calendar.setup({
    firstDay          : 1,
    showOthers        : true,
    range             : [1900.01, 2100.01],
    electric          : false,
    displayArea       : 'none',  
    inputField        : '<%=txtDate.ClientID %>',
    button            : '<%=imgTrigger.ClientID %>',
    ifFormat          : '%d.%m.%Y'
  });
//]]>
</script>

