<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" Codebehind="SMB2.aspx.cs"
    Inherits="Apple.Web.SMB2" Title="SMB2" %>

<%@ Register TagPrefix="uc" TagName="CsList" Src="~/Controls/CaseStudiesList.ascx" %>
<%@ Register TagPrefix="uc" TagName="StList" Src="~/Controls/StoriesList.ascx" %>
<%@ Register TagPrefix="uc" TagName="LatestProducts" Src="~/Controls/LatestProductsList2.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SecondMenu" runat="server">
    <div id="contentmenu">
        <table class="foursection">
            <tbody>
                <tr>
                    <td>
                        <img src="/images/contentmenu_separator2.gif" alt="">
                        <a href="Consumers.aspx">Домашние
                            <br>
                            пользователи</a>
                    </td>
                    <td>
                        <img src="/images/contentmenu_separator2.gif" alt="">Профессионалы:<br>
                        <a href="ErcProAudio.aspx">Аудио</a> | <a href="ErcProVideo.aspx">Видео</a> | <a
                            href="ErcProPhoto.aspx">Фото</a>
                    </td>
                    <td>
                        <img src="/images/contentmenu_separator2.gif" alt="">
                        <a href="SMB.aspx" style="font-weight: bold;">Малый и средний
                            <br>
                            бизнес</a>
                    </td>
                    <td>
                        <img src="/images/contentmenu_separator2.gif" alt="">
                        <a href="Education.aspx">Образование</a>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left: 25px">
        <asp:Image ID="iMap" ImageUrl="~/images/smb2.jpg" AlternateText="" runat="server" />
    </div>
    <map id="map1" name="map1">
        <area alt='smb' href='<%=this.GetUrl("~/{lang}/SMB.aspx") %>' shape="rect" coords="55,262,262,297" />
    </map>
    <uc:CsList ID="cs" SectionID="8" runat="server" />
    <uc:StList ID="st" SectionID="8" runat="server" />
    <uc:LatestProducts ID="products" Title="Последние новинки Apple" SectionID="8" runat="server" />
</asp:Content>
