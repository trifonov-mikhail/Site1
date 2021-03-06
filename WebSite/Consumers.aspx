﻿<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" Codebehind="Consumers.aspx.cs"
    Inherits="Apple.Web.ConsumersPage" Title="Домашние пользователи" %>

<%@ Register TagPrefix="uc" TagName="CsList" Src="~/Controls/CaseStudiesList.ascx" %>
<%@ Register TagPrefix="uc" TagName="StList" Src="~/Controls/StoriesList.ascx" %>
<%@ Register TagPrefix="uc" TagName="LatestProducts" Src="~/Controls/LatestProductsList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SecondMenu" runat="server">
    <div id="contentmenu">
        <table class="foursection">
            <tbody>
                <tr>
                    <td>
                        <img src="/images/contentmenu_separator2.gif" alt="">
                        <a href="Consumers.aspx" style="font-weight: bold;">Домашние
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
                        <a href="SMB.aspx">Малый и средний
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
    <h2 style="margin-left: 25px; margin-bottom: 20px;">
        Почему вы полюбите Mac
    </h2>
    <div style="margin-left: 2px; width: 650px;">
        <img src="<%=this.GetUrl("~/images/main_consumer.jpg")%>" alt="" style="margin: 0 0 10px 0" /></div>
    <div style="margin-left: 25px; margin-bottom: 30px; width: 644px;">
        <table width="100%">
            <tr>
                <td valign="top">
                    <p>
                        Почему именно Apple? Потому, что с новым компьютером Mac вы сможете делать удивительные
                        вещи на основе готовых решений — фильмы, музыку, веб-сайты и фотоальбомы, — и для
                        этого вам не потребуется приобретать дополнительное программное обеспечение. Кроме
                        того, компьютеры Mac совместимы с цифровой аппаратурой, которой вы уже пользуетесь
                        — фотоаппаратами, принтерами и сканерами. С технологией Intel в каждом новом Mac
                        и самой передовой операционной системой вы будете меньше времени тратить на поиск
                        и устранение неисправностей, и больше — на полезную деятельность.
                    </p>
                </td>
                <td align="right" valign="top" style="padding: 17px 0 0 25px;">
                    <a href="http://www.apple.com/ru/getamac/whichmac/" target="blank">
                        <img src="<%=this.GetUrl("~/images/bytton_viberete.png")%>" alt="" width="155" height="109" /></a></td>
            </tr>
        </table>
    </div>
    <div style="margin-left: 25px; margin-bottom: 30px; width: 644px;">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="3" valign="top">
                    <h2>
                        Какой iPod ваш?</h2>
                </td>
                <td rowspan="2" valign="top">
					<a href="http://www.apple.com/ru/ipodtouch/" target="blank">
                    <img src="<%=this.GetUrl("~/images/iPodtouch8.jpg")%>" alt="" width="133" height="185" />
					</a>
					</td>
                <td rowspan="2" valign="top">
					<a href="http://www.apple.com/ru/ipodtouch/" target="blank">
                    <img src="<%=this.GetUrl("~/images/iPodtouch32.jpg")%>" alt="" width="145" height="185" />
					</a>
					</td>
            </tr>
            <tr>
                <td valign="top">
					<a href="http://www.apple.com/ru/ipodshuffle/" target="blank">
                    <img src="<%=this.GetUrl("~/images/iPodSchuffle.jpg")%>" alt="" width="132" height="166" />
					</a>
					</td>
                <td valign="top">
					<a href="http://www.apple.com/ru/ipodnano/" target="blank">
                    <img src="<%=this.GetUrl("~/images/iPodNano.jpg")%>" alt="" width="134" height="166" />
					</a>
					</td>
                <td valign="top">
					<a href="http://www.apple.com/ru/ipodclassic/" target="blank">
                    <img src="<%=this.GetUrl("~/images/iPodClassic.jpg")%>" alt="" width="133" height="166" />
					</a>
					</td>
            </tr>
            <tr>
                <td>
                    <h2 style="letter-spacing: -1px; font-size: 18px;">
                        <strong>iPod</strong> shuffle</h2>
                </td>
                <td>
                    <h2 style="letter-spacing: -1px; font-size: 18px;">
                        <strong>iPod</strong> nano</h2>
                </td>
                <td>
                    <h2 style="letter-spacing: -1px; font-size: 18px;">
                        <strong>iPod</strong> classic</h2>
                </td>
                <td>
                    <h2 style="letter-spacing: -1px; font-size: 18px;">
                        <strong>iPod</strong> touch</h2>
                </td>
                <td>
                    <h2 style="letter-spacing: -1px; font-size: 18px;">
                        <strong>iPod</strong> touch</h2>
                </td>
            </tr>
            <tr>
                <td style="padding: 30px 5px 25px 0">
                    Самый маленький и портативный плеер в мире выпускается в новых цветах и говорит,
                    какая звучит песня.
                </td>
                <td style="padding: 30px 5px 25px 0">
                    Тонкий, яркий iPod nano с видеокамерой, новым корпусом, большим дисплеем и другими
                    новыми функциями.
                </td>
                <td style="padding: 30px 5px 25px 0">
                    160 ГБ для музыки, видео и фотографий. Всё своё ношу с собой.
                </td>
                <td style="padding: 30px 5px 25px 0">
                    Игры, музыка, видео, а ещё электронная почта и Интернет — всегда с вами.
                </td>
                <td style="padding: 30px 0 25px 0">
                    Все функции iPod touch 8 ГБ плюс улучшенная производительность, насыщенная графика
                    и Управление голосом.
                </td>
            </tr>
                <tr>
                    <td>
                        <a href="http://www.apple.com/ru/ipodtouch/" target="blank">Подробнее &gt;&gt;</a></td>
                    <td>
                        <a href="http://www.apple.com/ru/ipodtouch/" target="blank">Подробнее &gt;&gt;</a></td>
                    <td>
                        <a href="http://www.apple.com/ru/ipodshuffle/" target="blank">Подробнее &gt;&gt;</a></td>
                    <td>
                        <a href="http://www.apple.com/ru/ipodnano/" target="blank">Подробнее &gt;&gt;</a></td>
                    <td>
                        <a href="http://www.apple.com/ru/ipodclassic/" target="blank">Подробнее &gt;&gt;</a></td>
                </tr>
        </table>
    </div>
    <div style="width: 660px;">
     <h2 style="margin-left: 25px;">Популярные приложения для пользователей  </h2>
        <table width="100%" style="margin-left: 0px;">
            <tr>
                <td style="padding: 15px 5px 20px 0">
                    <img src="<%=this.GetUrl("~/images/cons1.jpg")%>" alt="" width="185" height="135" /></td>
                <td valign="top" style="padding-bottom: 20px;">
                    <p>
                        <strong>iTunes. Лучший способ организовывать, просматривать и слушать вашу цифровую
                            коллекцию. </strong>
                    </p>
                    <p>
                        iTunes — это бесплатная программа для Mac и PC, которая позволяет упорядочивать
                        цифровую медиаколлекцию на компьютере, слушать музыку и смотреть видео. Она также
                        поможет синхронизировать любые файлы на iPod, iPhone и Apple TV.
                        <br />
                        <br />
                        <a href="#">Подробнее &gt;&gt;</a>
                    </p>
                </td>
            </tr>
            <tr>
                <td style="padding: 15px 5px 20px 0">
                    <img src="<%=this.GetUrl("~/images/cons2.jpg")%>" alt="" width="185" height="154" /></td>
                <td valign="top" style="padding-bottom: 20px;">
                    <p>
                        <strong>iLife ’09. Комплект программ цифрового образа жизни Apple.</strong></p>
                    <p>
                        iLife ‘09 состоит из <a href="http://www.apple.com/ru/ilife/iphoto/">iPhoto</a>, 
						<a href="http://www.apple.com/ru/imovie/" target="blank">iMovie</a>, 
						<a href="http://www.apple.com/ru/garageband" target="blank">GarageBand</a>,
                        <a href="http://www.apple.com/ru/iweb" target="blank">iWeb</a> и 
						<a href="http://www.apple.com/ru/idvd" target="blank">iDVD</a>. С его помощью пользователи Mac могут
                        легко и инновационно создавать, пользоваться и делиться собственными фотографиями,
                        фильмами и музыкой. Вы можете организовать и осуществлять поиски Ваших фотографий
                        на основе лиц и мест в iPhoto. Создавать за минуты великолепные фильмы и редактировать
                        прецизионно в iMovie. Научиться играть на фортепьяно и гитаре, или сочинять и записывать
                        собственные песни с помощью гитарных усилителей и напольных эффектов в GarageBand.
                        iLife поставляется бесплатно с каждым новым Mac, а если Вы уже имеете Mac, то это
                        доступный апгрейд.</p>
                </td>
            </tr>
            <tr>
                <td style="padding: 15px 5px 20px 0">
                    <img src="<%=this.GetUrl("~/images/cons3.jpg")%>" alt="" width="185" height="166" /></td>
                <td valign="top" style="padding-bottom: 20px;">
                    <p>
                        <strong>iWork ‘09. Документы, таблицы, презентации — в стиле Mac.</strong></p>
                    <p>
                        iWork ’09 — это комплект офисных программ, которым очень легко пользоваться. Он
                        состоит из программ 
						<a href="http://www.apple.com/ru/pages" target="blank">Pages</a>, 
						<a href="http://www.apple.com/ru/numbers" target="blank">Numbers</a> и 
						<a href="http://www.apple.com/ru/keynote" target="blank">Keynote</a>.
                        Эти программы помогут вам создать впечатляющие документы, электронные таблицы и
                        презентации с помощью предоставленных тем, или создать Ваш собственный стиль. Кроме
                        того, iWork ’09 позволяет Вам легко обмениваться документами со всеми, несмотря
                        на то, пользуются ли они файлами Microsoft Office, iWork или PDF.
                    </p>
                </td>
            </tr>
            <tr>
                <td style="padding: 15px 5px 20px 0">
                    <img src="<%=this.GetUrl("~/images/cons4.jpg")%>" alt="" width="185" height="160" /></td>
                <td valign="top" style="padding-bottom: 20px;">
                    <p>
                        <strong>MobileMe. Сохранять актуальность данных — просто. </strong>
                    </p>
                    <p>
                        MobileMe — это новая служба Apple, которая сохраняет актуальность данных вашей почты,
                        контактов и календаря на iPhone, iPod touch, Mac или PC. MobileMe хранит информацию
                        на веб-сервере (в «облаке»). Вы вносите изменения на одном устройстве — и MobileMe
                        отправляет информацию в «облако», которое обновляет данные на всех остальных устройствах.
                        Поэтому где бы вы ни находились, нужная вам информация всегда актуальна. Вместе
                        с подпиской вы получаете собственную галерею в Сети, где вы можете обмениваться
                        фотографиями с друзьями и близкими, объёмный iDisk для хранения и обмена важными
                        файлами в Интернете и пакет гибких веб-приложений для управления данными.
                    </p>
                    <p>&nbsp;
                        </p>
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-bottom:20px;">
        <uc:LatestProducts ID="products" Title="Последние новинки Apple" SectionID="1" runat="server" />
    </div>
</asp:Content>
