<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" Codebehind="Feedback.aspx.cs"
    Inherits="Apple.Web.FeedbackPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main">
        <asp:Localize ID="Localize1" Text='<%$ Resources: AppleRes, Feedback.Header %>' runat="server"></asp:Localize>
        <asp:UpdatePanel ID="up" runat="server" RenderMode="Inline">
            <ContentTemplate>
                <asp:PlaceHolder runat="server" ID="phForm">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 30px;">
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
                                <table width="100%">
                                    <tr>
                                        <td valign="top">
                                            <h4>
                                                <asp:Label ID="lbFirstName" Text='<%$ Resources: AppleRes, Feedback.FirstName %>'
                                                    runat="server" />
                                            </h4>
                                            <div class="box_input">
                                                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></div>
                                            <h4>
                                                <asp:Label ID="lbLastName" Text='<%$ Resources: AppleRes, Feedback.LastName %>' runat="server" /></h4>
                                            <div class="box_input">
                                                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></div>
                                            <h4 style="padding-left: 3px;">
                                                <asp:Label ID="Label2" Text='<%$ Resources: AppleRes, Feedback.Telephone %>' runat="server" /></h4>
                                            <div class="box_input">
                                                <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox></div>
                                            <h4>
                                                <asp:Label ID="lbEmail" Text='<%$ Resources: AppleRes, Feedback.Email %>' runat="server" /></h4>
                                            <div class="box_input">
                                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></div>
                                            <h4 style="padding-left: 3px;">
                                                <asp:Label ID="lbCompany" Text='<%$ Resources: AppleRes, Feedback.Company %>' runat="server" /></h4>
                                            <div class="box_input">
                                                <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox></div>
                                            <h4 style="padding-left: 3px;">
                                                <asp:Label ID="lbPosition" Text='<%$ Resources: AppleRes, Feedback.Position %>' runat="server" /></h4>
                                            <div class="box_input">
                                                <asp:TextBox ID="txtPosition" runat="server"></asp:TextBox></div>
                                        </td>
                                        <td valign="top">
                                            <h4 style="padding: 0 0 0 3px;">
                                                Оставьте ваш комментарий или интересующий вопрос</h4>
                                            <div class="box_textarea">
                                                <asp:TextBox ID="txtComment" TextMode="MultiLine" Columns="45" Rows="5" Width="450px"
                                                    Height="315px" BackColor="transparent" BorderWidth="0" runat="server"></asp:TextBox>
                                            </div>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="grey">
                                            * обязательные поля<br />
                                            для заполнения</td>
                                        <td align="right">
                                            <asp:ImageButton AlternateText="Отправить" ID="btnSend" ImageUrl="~/images/buttom_send.png"
                                                runat="server" Width="154" Height="37" />
                                            <br />
                                            <asp:Label ID="lblError" runat="server" Text='<%$ Resources: AppleRes, MailNotSent %>' ForeColor="Red"></asp:Label>
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
                <asp:PlaceHolder ID="phThankYou" runat="server">
                    <asp:Label ID="lbThankYou" runat="server" Text='<%$ Resources: AppleRes, Feedback.ThankYou %>'></asp:Label>
                </asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
