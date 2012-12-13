<%@ Control Language="C#" AutoEventWireup="true" Codebehind="RequestStatusForm.ascx.cs"
    Inherits="Apple.Web.Controls.RequestStatusForm" %>
<style type="text/css">
        #content{
            padding-top:13px;
        }
</style>
<div class="main">
    <%if (ShowSubMenu())
      {%>
    <div id="contentmenu" style="padding:0;">
        <table width="640">
            <tr>
                <td>
                    <asp:Image ID="Image1" ImageUrl="~/images/contentmenu_separator2.gif" runat="server" />
                    <a href="<%=GetUrl("~/ru/content/Warranty.aspx") %>">Гарантийные<br />
                        обязательства Apple</a>
                </td>
                <td>
                    <asp:Image ID="Image2" ImageUrl="~/images/contentmenu_separator2.gif" runat="server" />
                    <a href="<%=GetUrl("~/ru/content/AASP.aspx") %>">Получение
                        статуса авторизованного<br />
                        сервисного центра по продукции Apple</a>
                </td>
                <td>
                    <asp:Image ID="Image3" ImageUrl="~/images/contentmenu_separator2.gif" runat="server" />
                    <a href="<%=GetUrl("~/ru/ServiceCenters.aspx") %>">Авторизованные<br />
                        сервисные центры Apple</a>
                </td>
            </tr>
        </table>
    </div>
    <%} %>
    <div style="margin-top: 10px; margin-bottom: 25px; line-height: 30px; font-size: 14px;
        font-weight: bold; text-align: center;">
        <table width="640">
            <tr>
                <td style="padding-top: 1px;" align="right">
                    Заявка на получение статуса &nbsp;</td>
                <td align="left">
                    <asp:Image ID="imgStatus" ImageAlign="AbsMiddle" AlternateText="" runat="server" /></td>
            </tr>
        </table>
    </div>
    <div style="width: 31em; margin: 0px auto;">
        <asp:UpdatePanel ID="up" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder runat="server" ID="phForm">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
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
                                    <tr>
                                        <td valign="top">
                                            <h1>
                                                <asp:Label ID="lbCompanyName" runat="server" Text="Название компании"></asp:Label>
                                            </h1>
                                            <div class="box_input_wide">
                                                <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox></div>
                                            <h1>
                                                <asp:Label ID="lbAddress" runat="server" Text="Адрес"></asp:Label>
                                            </h1>
                                            <div class="box_input_wide">
                                                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></div>
                                            <h1 style="padding-left: 3px;">
                                                <asp:Label ID="lbContactName" runat="server" Text="Фамилия, имя контактного лица"></asp:Label>
                                            </h1>
                                            <div class="box_input_wide">
                                                <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox></div>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <h1>
                                                            <asp:Label ID="lbPhone" runat="server" Text="Телефон"></asp:Label>
                                                        </h1>
                                                        <div class="box_input">
                                                            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></div>
                                                    </td>
                                                    <td style="width: 30px">&nbsp;
                                                        
                                                    </td>
                                                    <td>
                                                        <h1>
                                                            <asp:Label ID="lbEmail" runat="server" Text="e-mail"></asp:Label>
                                                        </h1>
                                                        <div class="box_input">
                                                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table style="width: 325px; font-size: 13px; font-weight: bold;">
                                                <tr>
                                                    <td style="width: 200px; line-height: 20px;">
                                                        Является ли компания партнером ERC
                                                    </td>
                                                    <td style="text-align: right">
                                                        Да<br />
                                                        <asp:RadioButton ID="rbIsPartner" GroupName="Partner" runat="server" Checked="True" />
                                                    </td>
                                                    <td style="text-align: right">
                                                        Нет<br />
                                                        <asp:RadioButton ID="rbIsNotPartner" GroupName="Partner" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" style="height: 20px">&nbsp;
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 200px; line-height: 20px;">
                                                        Является ли компания сервисным партнером ERC
                                                    </td>
                                                    <td style="text-align: right">
                                                        Да<br />
                                                        <asp:RadioButton ID="rbIsServicePartner" GroupName="ServicePartner" runat="server"
                                                            Checked="True" />
                                                    </td>
                                                    <td style="text-align: right">
                                                        Нет<br />
                                                        <asp:RadioButton ID="rbIsNotServicePartner" GroupName="ServicePartner" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" style="height: 40px">&nbsp;
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" style="text-align: right">
                                                        <asp:ImageButton ID="imgSubmit" ImageUrl="~/images/buttom_send_request_RU.png" runat="server"
                                                            OnClick="imgSubmit_Click" />
                                                        <br />
                                                        <asp:Label ID="lblError" runat="server" Text='<%$ Resources: AppleRes, MailNotSent %>'
                                                            ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
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
                </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="phThankYou">
                    <asp:Label ID="lbThankYou" runat="server" Text='<%$ Resources: AppleRes, RequestStatusFormThankYou %>'></asp:Label>
                </asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
    </div>
</div>
