<%@ Page Title="Mac_Action" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Mac_Action.aspx.cs" Inherits="Apple.Web.Mac_Action" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <link rel="stylesheet" href="http://code.jquery.com/ui/1.7.2/themes/base/jquery-ui.css" />
 <script src="http://code.jquery.com/ui/1.7.2/jquery-ui.js"></script>
 <script type="text/javascript">
 	$(function () {
 		$("#txtDate").datepicker({
 			showOn: "button",
 			buttonImage: "../images/calendar.gif",
 			buttonImageOnly: true,
			dateFormat: "dd.mm.yy"			
 		});
 	});
    </script>
	<style>
	.ui-datepicker-trigger
	{
		vertical-align:middle;
		padding-left:5px;
	}
	</style>
<script type="text/javascript">
	$(document).ready(function () {
		$("#btnSend").click(function () {
			var serialNumber = $("#tbxSerialNumber").val();
			if (serialNumber.length == 12) {
				$("#btnSend").attr('disabled', 'disabled');
				doAjaxRequest();
			} else {
				$("#btnSend").removeAttr('disabled');
				SwitchMessage('ltWrongLength');
			}
		});
	});

	function doAjaxRequest() {
		var data = prepareData();
		var location = "<%= this.Page.Request.Url %>";
		$.ajax({ type: "POST",
			url: location,
			data: data,
			dataType: "json",
			beforeSend: function (xhr) {
				var header = "<%= CHECK_SERIALNUMBER_HEADER %>";
				xhr.setRequestHeader(header, "true");
			},
			success: function (data, textStatus) {
				if (data.IsValid == 'True') {
					//if (data.ServiceCenter != '') {
						SwitchMessage('ltCheckSerialNumberInfo'); 
					//} else {
//						SwitchMessage('ltSerialWithoutServiceCenter');
	//				}
				}else {
					$("#btnSend").removeAttr('disabled');

					if (data.Message == 'invalid date')
						SwitchMessage('ltWrongDate');
					if (data.Message == 'invalid daterange')
						SwitchMessage('ltWrongDateRange');
					if (data.Message == 'invalid serial number')
						SwitchMessage('ltWrongSerialNumber');
					if(data.Message == 'duplicate number')
						SwitchMessage('ltDuplicateSerialNumber');
					if (data.Message == 'invalid seller')
						SwitchMessage('ltInvalidseller');	
					if(data.Message == 'invalid email')
						SwitchMessage('ltInvalidemail');	
				}
			}
		});
	}

	function prepareData() {
		var serialNumber = $("#tbxSerialNumber").val();
		var buyDate = $("#txtDate").val();
		var email = $("#txtEmail").val();
		var seller = $("#seller").val();
		return { SNValue: serialNumber, BuyDate: buyDate, Email:email, Seller : seller };
	}

	function SwitchMessage(elem_id) {
		$('.resultmess').css('display', 'none');
		$('#' + elem_id).css('display', 'inline');
	}

</script>
    
	<div class="main">
        
       <b>Приобретайте технику Apple у авторизованных реселлеров и получайте дополнительно 1 год гарантии!</b>
<p>
С 8 февраля по 10 марта 2013 года при покупке любого MacBookPro, MacBookAir и Macmini у 
    авторизованных реселлеров Apple Вы можете получить дополнительный 1 год гарантии на Ваше устройство. 
    Чтобы получить дополнительный год гарантии на Ваш MacBookPro, MacBookAirили Macmini, 
    покупку нужно зарегистрировать до 15.03.2013 г., заполнив соответствующие поля в таблице ниже.
</p>
<p>
    Также в течение 2-х (двух) лет с момента приобретения устройства и при успешной регистрации
    второго года гарантии Вы можете получить 50% скидки на ремонт механических повреждений* 
    при условии обращений в сервисный центр не более 1 раза в год.
</p>
<p>
    Акция распространяется на все модели MacBookPro, MacBookAir и Macmini, которые будут приобретены 
    в указанный период в авторизованных точках продаж техники Apple (список указан ниже на странице).  
    Акция не распространяется на модели iMac и MacPro.
</p>

<p>
	<img src='<%=this.GetUrl("~/images/zebra.jpg") %>' />
</p>
<p>
<b>Для активации услуги дополнительной гарантии введите данные в поля ниже:</b>
</p>

<p>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
<thead>
<tr>
	<td class=name><b>Серийный номер устройства</b><br />
(12-значный буквенно-цифровой код), например C02HWJLWDTY3)</td>
	<td class=name><b>Дата покупки</b> (указанная в чеке на Ваш MacBookAir, MacBookPro или Macmini)</td>
	<td class=name><b>Электронный адрес</b> (на этот адрес будет направлено письмо с подтверждением дополнительной гарантии)</td>
<td class=name><b>Место покупки</b><br />Вашего MacBookAir, MacBookPro или Macmini
</td>
</tr>
</thead>
<tbody>
<tr>

	<td class="ugtxt">	
	<input type="text" name="tbxSerialNumber" id="tbxSerialNumber" class="key" style="width:100%" />
	
	</td>
	<td class="ugtxt">
	<input type="text" name="txtDate" id="txtDate" class="key" style="width:65%" />	
	</td>
	<td class="ugtxt">
	<input type="text" name="txtEmail" id="txtEmail" class="key" style="width:100%" />	
	</td>
	<td class="ugtxt">
		<select id="seller" name="seller" style="border: 1px #CCC solid;padding: 5px 5px;font-size: 12px;">
			<%for (int i = 0; i < this.Sellers.Count; i++)
	 {
	 %>
		<option value='<%=Sellers[i].ID %>'><%=Sellers[i].Name %></option>
	 <%
	 } %>
		</select>
	</td>
</tr>
</tbody>
</table>

<p>Важно о поле "Серийный номер устройства": первую букву S вводить не нужно (это кодировка словосочетания «Serial No»). 
	Все буквенные символы должны быть введены только латиницей.
</p>

<input type="button" name="button" id="btnSend" value="Отправить" class="keybut" />

<div class=ugtxt>
<span id="ltCheckSerialNumberInfo" class="resultmess" style="display:none">
	<p>Спасибо, Ваша заявка на активацию услуги дополнительной гарантии на iPad принята.</p>

<p>Активация услуги может занять до 48 часов. Письмо, информирующее о статусе активации
услуги, будет направлено на указанный электронный адрес. Если в течение 48 часов такое
письмо не будет получено, просьба сообщить об этом по телефону линии поддержки техники
Apple: 0 800 302 777 0</p>
</span>
<span id="ltWrongLength" style="display:none" class="resultmess">
	Серийный номер должен состоять из 12 знаков.
	Первую букву S вводить не нужно (это кодировка словосочетания «Serial No»). 
	Все буквенные символы должны быть введены только латиницей.
</span>
<span id="ltDuplicateSerialNumber" style="display:none" class="resultmess">
	Данный серийный номер уже зарегистрирован.
</span>
<span id="ltWrongDate" style="display:none" class="resultmess">
Некорректный формат даты
</span>
<span id="ltInvalidseller" style="display:none" class="resultmess">
Пожалуйста, выберите место покупки
</span>
<span id="ltInvalidemail" style="display:none" class="resultmess">
Пожалуйста введите адрес электронной почты
</span>

<span id="ltWrongDateRange" style="display:none" class="resultmess">
Дата покупки должна быть между 08.02.2013 г. и 10.03.2013 г.
</span>

<span id="ltWrongSerialNumber" style="display:none" class="resultmess">
	Указанная модель либо официально не поставлялась на территорию Украины, 
    либо при введении серийного номера допущена ошибка. 
    Для получения дополнительной информации воспользуйтесь 
	<a href="http://www.ierc.com.ua/ru/ServiceCenters.aspx">формой обратной связи</a> 
	или телефоном горячей линии информационной поддержки пользователей 0 800 302 777 0
</span>

</div>

</p>


<p>1. Период действия акции: все устройства, купленные в период с 08.02.2013 г. по 10.03.2013 г. и зарегистрированные с 08.02.2013 г. по 15.03.2013 г. (включительно).</p>
<p>2. 6. Акционное предложение распространяется на все официально поставленные в Украину модели 
    MacBookAir, MacBook Pro и Mac mini, приобретенные в период действия акции исключительно у 
    авторизованных реселлеров Apple в Украине. Акция не распространяется на iMac и MacPro. 
    Список авторизованныхреселлеров-участников акции:
<br />
<ul class="listable">
			<%for (int i = 2; i < this.Sellers.Count; i++)
	 {
	 %>
		<li style="list-style:disc;margin-left:40px;"><%=this.Sellers[i].Name %></li>
	 <%
	 } %>

</ul>
</p>
<p>3. 7. Под «двумя годами официальной гарантии» имеется в виду дополнительная сервисная 
    поддержка сроком 12 месяцев с даты приобретения устройства, которая добавляется к 
    однолетней гарантии производителя. Как следствие, общий гарантийный срок обслуживания 
    устройства составляет 24  месяца с даты приобретения устройства.
</p>
<p>4. Для активации услуги дополнительного гарантийного обслуживания необходимо оформить
заявку на сайте <a href="www.erc.ua/apple">www.erc.ua/apple</a>, введя серийный номер приобретенного iPad, дату и место
совершения покупки в соответствии с чеком и свой электронный адрес. Заявку на активацию
услуги дополнительного гарантийного обслуживания необходимо оформить не позже 15.03.2013 года.</p>

<p>5. На устройства, не прошедшие активацию услуги на сайте <a href="www.erc.ua/apple">www.erc.ua/apple</a> или
зарегистрированные после 15.03.2013, дополнительная гарантия сроком 12 месяцев
не распространяется. На эти устройства действует стандартная 12-месячная гарантия от
производителя.</p>

<p>6. Поддержка и обслуживание устройств производится только в Сервисном центре "Монблан" (Киев). 
Отправка устройств в СЦ «Монблан» производится за счет получателя (ERC); 
процедура отправки описана в разделе 
<a href="http://www.ierc.com.ua/files/shipping.pdf" target="_blank">http://www.ierc.com.ua/files/shipping.pdf</a>
</p>

<p>7. Акция действует только на территории Украины.</p>
<br />

        <p style="font-size:x-small">
            *Подразумеваются случайные повреждения при использовании. Данные обязательства истекают с окончанием двухлетнего периода, а также после проведения двух ремонтов в течение двух лет (по одному ремонту в год).

        </p>
    </div>
</asp:Content>