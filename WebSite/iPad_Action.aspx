<%@ Page Title="iPad_Action" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="iPad_Action.aspx.cs" Inherits="Apple.Web.iPad_Action" %>

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
        <%--
            iPad Action</h6>--%>
       <b>
Покупайте iPad у авторизованного реселлера Apple и получайте дополнительно 1 год гарантии
на свой планшет!</b>
<p>
С 1 декабря 2012 года по 10 января 2013 года проводится акция по предоставлению дополнительного года гарантии на все iPad, купленные у авторизованных партнеров. Суть ее в том, что срок гарантийной поддержки
нового купленного iPad увеличивается вдвое: к 12 месяцам официальной гарантии производителя
добавляются дополнительные 12 месяцев аналогичной гарантийной поддержки.
Акция распространяется на все модели планшетов iPad, которые будут приобретены
в указанный период в авторизованных точках продаж техники Apple (список указан ниже). Для того чтобы на Ваш iPad
распространилась дополнительная гарантия, необходимо активировать эту услугу, предоставив
данные об устройстве и дате покупки.
</p>

<p>
	<img src='<%=this.GetUrl("~/images/activation.jpg") %>' />
</p>
<p>
<b>Для активации услуги дополнительной гарантии введите данные в поля ниже:</b>
</p>
<p>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
<thead>
<tr>
	<td class=name>Серийный номер iPad<br />
(12-значный буквенно-
цифровой код), напр.
DN6G1GRXDFHW)</td>
	<td class=name>Дата покупки (указанная
в чеке на ваш iPad)</td>
	<td class=name>Электронный адрес (на этот
адрес будет направлено письмо с
подтверждением активации услуги
дополнительной гарантии)</td>
<td class=name>Место покупки</td>
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
Дата покупки должна быть между 01.12.2012 г. и 10.01.2013 г.
</span>

<span id="ltWrongSerialNumber" style="display:none" class="resultmess">
						Указанная модель либо официально не поставлялась на территорию Украины, либо при введении серийного номера допущена ошибка. Для получения дополнительной информации воспользуйтесь 
						<a href="http://www.ierc.com.ua/ru/ServiceCenters.aspx">формой обратной связи</a> 
						или телефоном горячей линии информационной поддержки пользователей 0 800 302 777 0
</span>

</div>

</p>


<p>1. Период действия акции: все купленные iPad в период с 01.12.2012 г. по 10.01.2013 г. и активированные с 01.12.2012 по 15.01.2013г. (включительно).</p>
<p>2. Акционное предложение распространяется на все официально поставленные в Украину модели iPad, приобретенные в период
действия акции исключительно у авторизованных партнеров Apple в Украине. Список
авторизованных партнеров-участников акции:<br />
<ul class="listable">
			<%for (int i = 2; i < this.Sellers.Count; i++)
	 {
	 %>
		<li style="list-style:disc;margin-left:40px;"><%=this.Sellers[i].Name %></li>
	 <%
	 } %>

</ul>
</p>
<p>3. Под «двумя годами официальной гарантии» имеется в виду дополнительная сервисная
поддержка сроком 12 месяцев с даты приобретения устройства, которая добавляется к
однолетней гарантии производителя. Как следствие, общий гарантийный срок обслуживания
устройства составляет 24 месяца с даты приобретения устройства.</p>
<p>4. Для активации услуги дополнительного гарантийного обслуживания необходимо оформить
заявку на сайте <a href="www.erc.ua/apple">www.erc.ua/apple</a>, введя серийный номер приобретенного iPad, дату и место
совершения покупки в соответствии с чеком и свой электронный адрес. Заявку на активацию
услуги дополнительного гарантийного обслуживания необходимо оформить не позже 15.01.2013 года.</p>
<p>5. На устройства, не прошедшие активацию услуги на сайте <a href="www.erc.ua/apple">www.erc.ua/apple</a> или
зарегистрированные после 15.01.2013, дополнительная гарантия сроком 12 месяцев
не распространяется. На эти устройства действует стандартная 12-месячная гарантия от
производителя.</p>
<p>6. Информация о гарантийной поддержке указана на сайте <a href="http://www.ierc.com.ua/ru/support/Warranty.aspx">http://www.ierc.com.ua/ru/support/Warranty.aspx</a></p>
<p>7. Акция действует только на территории Украины.</p>
<br />

    </div>
</asp:Content>