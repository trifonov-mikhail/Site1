<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SeminarRegistrationControl.ascx.cs" Inherits="Apple.Web.Controls.SeminarRegistrationControl" %>
<div style="width: 31em; margin: 0px auto;">
  <div id="ctl00_MainContent_form1_up">
    <%if (!IsFormSubmitted)
      {%>
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
                                <span style="color:red;">*</span><asp:Label ID="lbFIO" runat="server" Text="ФИО"></asp:Label>
                            </h1>
                            <div class="box_input_wide">
                                <asp:TextBox runat="server" ID="txtFio"></asp:TextBox></div>
                            <h1>
                                <span style="color:red;">*</span><asp:Label ID="lbCompanyName" runat="server" Text="Компания"></asp:Label>
                            </h1>
                            <div class="box_input_wide">
                                <asp:TextBox runat="server" ID="txtCompanyName"></asp:TextBox>
                            </div>
                            <h1 style="padding-left: 3px;">
                                <span style="color:red;">*</span><asp:Label ID="lbFirmAction" runat="server" Text="Вид деятельности вашей компании"></asp:Label>
                            </h1>
                            <div class="box_select_wide">
                              <asp:DropDownList ID="ddlFirmAction" runat="server" Width="320px" style="margin-left:5px;">
                                  <asp:ListItem Value="1" Text="Брендовая розница"></asp:ListItem>
                                  <asp:ListItem Value="2" Text="Медийное агентство"></asp:ListItem>
                                  <asp:ListItem Value="3" Text="Маркетинговое агентство"></asp:ListItem>
                                  <asp:ListItem Value="4" Text="Туристическое агентство"></asp:ListItem>
                                  <asp:ListItem Value="5" Text="Юридическая компания"></asp:ListItem>
                                  <asp:ListItem Value="6" Text="Другие профессиональные услуги"></asp:ListItem>
                                  <asp:ListItem Value="7" Text="Торговая компания"></asp:ListItem>
                              </asp:DropDownList>
                          </div>
                          <br />
                           <h1>
                                <span style="color:red;">*</span><asp:Label ID="lbJobTitle" runat="server" Text="Должность"></asp:Label>
                          </h1>                            
                          <div class="box_input_wide">
                            <asp:TextBox runat="server" ID="txtJobTitle"></asp:TextBox>
                          </div>
                         
                          <h1>
                                <span style="color:red;">*</span><asp:Label ID="lbEmail" runat="server" Text="Email(Рабочий)"></asp:Label>
                          </h1>
                          <div class="box_input_wide">
                                <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                          </div>
                          <h1>
                                <span style="color:red;">*</span><asp:Label ID="lbSite" runat="server" Text="Веб сайт вашей компании"></asp:Label>
                          </h1>
                          <div class="box_input_wide">
                                <asp:TextBox runat="server" ID="txtSite"></asp:TextBox>
                          </div>
                           <br>
                            <table style="width: 325px; font-size: 13px; font-weight: bold;">
                                <tbody>
                                <tr>
                                    <td style="text-align: right;" colspan="3">
                                        <asp:ImageButton ID="imgSubmit" ImageUrl="~/images/buttom_send_request_RU.png" runat="server"
                                                            OnClick="imgSubmit_Click" style="border-width: 0px;"/>
                                        
                                        
                                        <br>
                                        <asp:Label runat="server" ID="lbError" Visible="false"></asp:Label>
                                        <br />
                                        <a href='<%=ResolveUrl("~/ru/SMBSeminar.aspx") %>'>Вернуться на страницу семинара</a>
                                        
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
    <%
        }
      else
      {%>
      Регистрация прошла успешно. <br />
      Ваша заявка будет рассмотрена и подтверждение будет отправлено вам на e-mail в ближайшее время
      <br />
      <a href='<%=ResolveUrl("~/ru/SMBSeminar.aspx") %>'>Вернуться на страницу семинара</a>
      <%
      }%>
  </div>
          <br>
        <br>

</div>
    