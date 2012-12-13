<%@ Control Language="C#" AutoEventWireup="true" Codebehind="HomePageBlocks.ascx.cs"
    Inherits="Apple.Web.Controls.HomePageBlocks" %>
	
<table style="margin: 20px 0pt;" border="0" cellpadding="0" cellspacing="0">
            <tbody><tr>
    
        <td>
            <table border="0" cellpadding="0" cellspacing="0">
                <tbody><tr>
                    <td style="padding-right: 6px;">
                        <a href="http://www.ierc.com.ua/ru/ErcProAudio.aspx"><img src="http://ierc.com.ua/images/home_1.jpeg" style="border-width: 0px;"></a>
                    </td>
                </tr>
                <tr>
                    <td class="td_imgbox_txt">
                        <a href="http://www.ierc.com.ua/ru/ErcProAudio.aspx">Профессионалы</a>
                    </td>
                </tr>
            </tbody></table>
        </td>
    
        <td>
            <table border="0" cellpadding="0" cellspacing="0">
                <tbody><tr>
                    <td style="padding-right: 6px;">
                        <a  href="http://www.ierc.com.ua/ru/Consumers.aspx"><img src="http://ierc.com.ua/images/home_2.jpeg" style="border-width: 0px;"></a>
                    </td>
                </tr>
                <tr>
                    <td class="td_imgbox_txt">
                        <a  href="http://www.ierc.com.ua/ru/Consumers.aspx">Домашние пользователи</a>
                    </td>
                </tr>
            </tbody></table>
        </td>
    
        <td>
            <table border="0" cellpadding="0" cellspacing="0">
                <tbody><tr>
                    <td style="padding-right: 6px;">
                        <a href="http://www.ierc.com.ua/ru/Education.aspx"><img src="http://ierc.com.ua/images/home_3.jpeg" style="border-width: 0px;"></a>
                    </td>
                </tr>
                <tr>
                    <td class="td_imgbox_txt">
                        <a href="http://www.ierc.com.ua/ru/Education.aspx">Образование</a><br />
                        <a href="http://www.ierc.com.ua/ru/content/educationaldiscounts.aspx">Получи скидку!</a>
					</td>
                </tr>
            </tbody></table>
        </td>
    
        <td>
            <table border="0" cellpadding="0" cellspacing="0">
                <tbody><tr>
                    <td style="padding-right: 6px;">
                        <a href="http://www.ierc.com.ua/ru/content/Trainings.aspx"><img src="http://ierc.com.ua/images/home_4.jpeg" style="border-width: 0px;"></a>
                    </td>
                </tr>
                <tr>
                    <td class="td_imgbox_txt">
                        <a href="http://www.ierc.com.ua/ru/content/Trainings.aspx">Тренинги<br> и сертификация</a>
                    </td>
                </tr>
            </tbody></table>
        </td>
    
        <td>
            <table border="0" cellpadding="0" cellspacing="0">
                <tbody><tr>
                    <td style="padding-right: 6px;">
                        <a href="http://www.ierc.com.ua/ru/Interesting.aspx"><img src="http://ierc.com.ua/images/home_5.jpeg" style="border-width: 0px;"></a>
                    </td>
                </tr>
                <tr>
                    <td class="td_imgbox_txt">
                        <a  href="http://www.ierc.com.ua/ru/Interesting.aspx">Интересно знать</a>
                    </td>
                </tr>
            </tbody></table>
        </td>
    
        </tr> </tbody></table>

		
<!--	
<asp:Repeater ID="rItems" runat="server" DataSourceID="odsItems">
    <HeaderTemplate>
        <table border="0" style="margin: 20px 0;" cellpadding="0" cellspacing="0">
            <tr>
    </HeaderTemplate>
    <ItemTemplate>
        <td>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="padding-right: 6px;">
                        <asp:HyperLink ID="hl1" NavigateUrl='<%#Eval("LinkUrl") %>' runat="server">
                            <asp:Image ID="img" ImageUrl='<%# Eval("GroupID","~/GetImage.ashx?type=7&id={0}") %>' runat="server" />    
                        </asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="td_imgbox_txt">
                        <asp:HyperLink ID="hl2" NavigateUrl='<%#Eval("LinkUrl") %>' Text='<%#Eval("LinkText") %>' runat="server">
                        </asp:HyperLink>
                    </td>
                </tr>
            </table>
        </td>
    </ItemTemplate>
    <FooterTemplate>
        </tr> </table>
    </FooterTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="odsItems" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAll" TypeName="Erc.Apple.Data.HomePageBlocks" OnSelecting="odsItems_Selecting">
    <SelectParameters>
        <asp:Parameter Name="langCode" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
-->
