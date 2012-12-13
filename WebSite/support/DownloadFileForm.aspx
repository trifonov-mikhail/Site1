<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadFileForm.aspx.cs" Inherits="Apple.Web.DownloadFileForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <%--<link href="../App_Themes/Default/css/my.css" type="text/css" rel="stylesheet" />
    <link href="../App_Themes/Default/css/style2.css" type="text/css" rel="stylesheet" />
    <link href="../App_Themes/Default/smoothness/jquery-ui-1.7.2.custom.css" type="text/css" rel="stylesheet" />--%>
    <script src="../../js/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../../js/jquery.cookie.js" type="text/javascript"></script>
	<script src="../../js/jquery.base64.js" type="text/javascript"></script>
</head>
<body>
<script type="text/javascript">
    $(document).ready(function () {
//        var firstname = $.cookie("firstname");
//        var lastname = $.cookie("lastname");
//        var email = $.cookie("email");
//        var txtF = $('#<%=txtFirstName.ClientID %>');
//        var txtL = $('#<%=txtLastName.ClientID %>');
//        var txtE = $('#<%=txtEmail.ClientID %>');
//        if (firstname) {
//            txtF.val(firstname);
//        }
//        if (lastname) {
//            txtL.val(lastname);
//        }
//        if (email) {
//            txtE.val(email);
//        }
        $('#<%=imgSubmit.ClientID %>').click(function () {
            var txtF = $('#<%=txtFirstName.ClientID %>');
            var txtL = $('#<%=txtLastName.ClientID %>');
            var txtE = $('#<%=txtEmail.ClientID %>');
            $.cookie("firstname", $.base64Encode(txtF.val()));
            $.cookie("lastname", $.base64Encode(txtL.val()));
            $.cookie("email", $.base64Encode(txtE.val()));
        });
    });
</script>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server">
                </asp:ScriptManager>
    <asp:UpdatePanel ID="up" runat="server">
    <ContentTemplate>
	<asp:PlaceHolder runat="server" ID="phForm">
    <table width="100%" cellspacing="0" cellpadding="0" border="0">
        <tbody>
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
            <td class="ugtxt2">
                <table>
                    <tbody><tr>
                        <td valign="top">
                            <h1>
                                <span style="color:red;">*</span><asp:Label ID="lbFirstName" runat="server" style="color:Black;" Text="Имя"></asp:Label>
                            </h1>
                            <div class="box_input_wide">
                                <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox></div>
                            <h1>
                                <span style="color:red;">*</span><asp:Label ID="lbLastName" style="color:Black;" runat="server" Text="Фамилия"></asp:Label>
                            </h1>
                            <div class="box_input_wide">
                                <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox>
                            </div>
                            
                          <h1>
                                <span style="color:red;">*</span><asp:Label ID="lbEmail" runat="server" Text="Email" style="color:Black;"></asp:Label>
                          </h1>
                          <div class="box_input_wide">
                                <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                          </div>
                          <table style="width: 325px; font-size: 13px; font-weight: bold;">
                                <tbody>
                                <tr>
                                    <td style="text-align: right;" colspan="3">
                                        <asp:ImageButton ID="imgSubmit" ImageUrl="~/images/buttom_send_request_RU.png" runat="server"
                                                            OnClick="imgSubmit_Click" style="border-width: 0px;"/>
                                        
                                        
                                        <br>
                                        <asp:Label runat="server" ID="lbError" Visible="false"></asp:Label>                                        
                                    </td>
                                </tr>
                            </tbody></table>
                        </td>
                    </tr>
                </tbody></table>
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
    </tbody>
    </table>
	</asp:PlaceHolder>
	<asp:PlaceHolder runat="server" ID="phLink">
	<div class="ugtxt2" style="width: 230px; height: 155px; padding-top: 125px; padding-left: 120px;">
		<asp:HyperLink style="font-size:20pt;" runat="server" ID="hlLink">Скачать</asp:HyperLink>
	</div>	
	</asp:PlaceHolder>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
