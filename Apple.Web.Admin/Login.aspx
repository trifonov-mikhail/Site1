<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" 
CodeBehind="Login.aspx.cs" Inherits="Apple.Web.Admin.LoginPage" Title="Login Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div id="content">
        <div id="loginform">
            <h2>
                Страница авторизации
            </h2>
            <table>
                <tr>
                    <td style="width: 100px; text-align: right;">
                        Эл. почта:
                    </td>
                    <td style="width: 100px;">
                        <asp:TextBox ID="txtEmail" Width="145px" runat="server" TabIndex="1"></asp:TextBox>
                    </td>
                    <td style="width: 10px;">
                        <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="*" Display="Static"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Пароль:
                    </td>
                    <td >
                        <asp:TextBox ID="txtPass" Width="145px" runat="server" TextMode="Password" TabIndex="2"></asp:TextBox></td>
                    <td >
                        <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="txtPass"
                            ErrorMessage="*" Display="Static"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="right" style="padding-right:8px">
                        <asp:Button ID="SubmitButton" Text="Войти" CssClass="btn" runat="server" OnClick="SubmitButton_Click" TabIndex="3" /><br />
                        <asp:Label ID="lblMess" ForeColor="red" Font-Names="Verdana" Font-Size="10" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
