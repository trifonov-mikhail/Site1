<%@ Control Language="C#" AutoEventWireup="true" Codebehind="HomePageImage.ascx.cs"
    Inherits="Apple.Web.Admin.Controls.Editors.HomePageEditor" %>
<table border="0" cellpadding="6" cellspacing="1">
    <tr>
        <td style="width: 170px" class="label">
            Формат изображения:
        </td>
        <td class="field">
            jpg
        </td>
    </tr>
    <tr>
        <td style="width: 170px" class="label">
            Оптимальная высота:
        </td>
        <td class="field">
            325px
        </td>
    </tr>
    <tr>
        <td style="width: 170px" class="label">
            Оптимальная ширина:
        </td>
        <td class="field">
            645px
        </td>
    </tr>
    <tr>
        <td style="width: 170px" class="label">
            Выберите изображение:
        </td>
        <td class="field">
            <asp:FileUpload ID="HomePageImage" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="width: 170px" class="label">
            Адрес ссылки:
        </td>
        <td class="field">
            <asp:TextBox ID="txtBannerUrl" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="right" class="label" style="padding:1px;">
            <asp:Button ID="btnUpload" runat="server" Text="Сохранить" OnClick="btnUpload_Click" />
        </td>
    </tr>

	<tr>
        <td style="width: 170px" class="label">
            Выберите изображение:
        </td>
        <td class="field">
            <asp:FileUpload ID="HomePageImage2" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="width: 170px" class="label">
            Адрес ссылки:
        </td>
        <td class="field">
            <asp:TextBox ID="txtBannerUrl2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="right" class="label" style="padding:1px;">
            <asp:Button ID="btnUpload2" runat="server" Text="Сохранить" OnClick="btnUpload_Click2" />
        </td>
    </tr>
</table>
