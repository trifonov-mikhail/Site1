<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="CheckSerialNumber.ascx.cs" Inherits="Apple.Web.Controls.CheckSerialNumber" %>

<script type="text/javascript">
	$(document).ready(function() {
		$("#btnSend").click(function() {
			var serialNumber = $("#tbxSerialNumber").val();
			if (serialNumber.length >= 11 && serialNumber.length <= 12) {
				doAjaxRequest();
			} else {
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
			beforeSend: function(xhr) {
				var header = "<%= CHECK_SERIALNUMBER_HEADER %>";
				xhr.setRequestHeader(header, "true");
			},
			success: function(data, textStatus) {
				if (data.IsValid == 'True') {
					if (data.ServiceCenter != '') {
						SwitchMessage('ltValidSerialWithServiceCenter');
						$('#ltServiceCenterName').html(data.ServiceCenter);
					} else {
						SwitchMessage('ltSerialWithoutServiceCenter');
					}
				}
				else {
					SwitchMessage('ltWrongSerialNumber');
				}
			}
		});
	}

	function prepareData() {
		var serialNumber = $("#tbxSerialNumber").val();
		return { SNValue: serialNumber };
	}

	function SwitchMessage(elem_id) {
		$('.resultmess').css('display', 'none');
		$('#' + elem_id).css('display', 'inline');
	}

</script>

<div style="padding-left: 30px;">
	<h1>
		База проверки продукции Apple по серийному номеру</h1>
	<table style="margin-top: 30px; margin-left: 0px;" border="0" cellpadding="0" cellspacing="0" width="650px">
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
				<td class="ugtxt">
					<input type="text" name="textfield" id="tbxSerialNumber" class="key" style="width: 200px;" />
					<input type="button" name="button" id="btnSend" value="Проверить" class="keybut" />
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
	<table style="margin-top: 30px; margin-left: 0px;" border="0" cellpadding="0" cellspacing="0" width="650px">
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
				<td class="ugtxt">
					<span id="ltCheckSerialNumberInfo" class="resultmess">
						Для проверки введите серийный номер продукта и нажмите кнопку «Проверить»
					</span>
					<span id="ltWrongLength" style="display:none" class="resultmess">
						Серийный номер должен состоять из 11 или 12 знаков.
					</span>	
					<span id="ltSerialWithoutServiceCenter" style="display:none" class="resultmess">
						Благодарим Вас за приобретение продукции Apple. Указанная модель была официально ввезена на территорию Украины, сертифицирована в соответствии с законодательством Украины* и подлежит сервисному обслуживанию через 
						<a href="http://www.ierc.com.ua/ru/ServiceCenters.aspx">сеть Авторизованных сервисных партнеров</a>.
					</span>
					<span id="ltWrongSerialNumber" style="display:none" class="resultmess">
						Указанная модель либо официально не поставлялась на территорию Украины, либо при введении серийного номера допущена ошибка. Для получения дополнительной информации воспользуйтесь 
						<a href="http://www.ierc.com.ua/ru/ServiceCenters.aspx">формой обратной связи</a> 
						или телефоном горячей линии информационной поддержки пользователей 0 800 302 777 0
					</span>
					<span id="ltValidSerialWithServiceCenter" style="display:none" class="resultmess">
						Отказано в гарантийном ремонте. Последнее обращение было в СЦ <span id="ltServiceCenterName"></span>. Для получения дополнительной информации воспользуйтесь 
						<a href="http://www.ierc.com.ua/ru/ServiceCenters.aspx">формой обратной связи</a> 
						или телефоном горячей линии информационной поддержки пользователей 0 800 302 777 0
					</span>
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
	<div>
		<p>
			* Список продукции, подлежащий обязательной сертификации, можно посмотреть <a href="http://zakon1.rada.gov.ua/cgi-bin/laws/main.cgi?nreg=z0466-05" target="blank">тут</a>.</p>
		<p>
			По требованию покупателя продавец <strong>обязан</strong> предоставить действующий <strong>Сертификат соответствия</strong>, который 
			отвечает требованиям нормативно-технических документов, установленных для данной продукции (ГОСТ, ДСТУ, ETSI, др.).</p>
			<br />
		<p>
			<strong>Преимущества использования Авторизованного сервиса:</strong></p>
		<ul>
			<li><img src="/images/bullet.gif" alt="">Гарантийное и постгарантийное обслуживание продукции Apple.</li>
			<li><img src="/images/bullet.gif" alt="">Использование только оригинальных запасных частей Apple.</li>
			<li><img src="/images/bullet.gif" alt="">Поддержка по <a href="http://www.apple.com/ru/support/exchange_repair/">программам расширенной замены Apple</a>.</li>
			<li><img src="/images/bullet.gif" alt="">Проведение диагностики и ремонтов только сертифицированными специалистами.</li>
		</ul>
		<br />
		<p>
			<strong>Полезная информация о заводском идентификаторе продукта</strong></p>
		<ol>
			<li>Серийный номер представляет собой одиннадцатизначный буквенно-цифровой код, уникальный для каждого продукта.</li>
		</ol>
		<ol>
			<li>Код продукта представляет собой 2 буквы, 3 цифры и код региона.</li>
		</ol>
		<ol>
			<li>Код региона:</li>
			<ul>
				<li><img src="/images/bullet.gif" alt="">Для Mac RS/A (очень редко ZH/A);</li>
				<li><img src="/images/bullet.gif" alt="">Для всех iPod, кроме iPod touch (QB/A) или</li>
				<li><img src="/images/bullet.gif" alt="">Для iPod touch (RP/A).</li>
			</ul>
		</ol>
		<br />
		<p>
			<u>Комментарий</u>: Если код региона отличается от вышеуказанных вариантов, то это означает, что данный товар не предназначен для использования на территории Украины и ввезен в Украину неофициально*.<br />
			*<u>Исключение</u>: Если продукт приобретен за пределами Украины, то для получения сервисного обслуживания следует предоставить оригиналы документов, подтверждающих покупку.</p>
		<p>
			&nbsp;</p>
		<p>
			<strong>ПРИМЕР идентификатор</strong><strong>а</strong></p>
		<p>
			<strong>Ноутбук Apple MacBook 13&quot; в алюминиевом корпусе </strong>
			<br />
			<strong>MB 13.3/</strong><strong>2.0GHz/2x</strong><strong>1GB</strong><strong>/160G</strong><strong>B</strong><strong>/SD</strong><strong> </strong>
		</p>
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
		<!--
			<tr>
				<td style="padding-right: 20px;">
					<img src="../images/shtrih1.jpg" alt="" width="345" height="413" />
				</td>
				<td valign="top">
					<ul>
						<li>1. Штрих код</li>
						<li>2. Код модели (2 буквы, 3 цифры и код региона)</li>
						<li>3. Серийный номер (одиннадцатизначный буквенно-цифровой код)</li>
						<li>4. Модель, название и конфигурация </li>
						<li>5. Мас-адреса карты Wi-Fi, сетевой карты Eathernet и модуля Bluetooth</li>
						<li>6. Страна производства</li>
						<li>7. Сертификаты</li>
					</ul>
				</td>
			</tr>
			-->
			
			<tr>
				<td valign="top">
					<ul>
						<li>1. Код модели (2 буквы, 3 цифры и код региона) </li>
						<li>2. Серийный номер (одиннадцатизначный буквенно-цифровой код) </li>
						<li>3. Модель</li>
					</ul>
				</td>
				<td style="padding-left: 20px;">
					<img src="../images/shtrih2.jpg" alt="" width="343" height="268" />
				</td>
			</tr>
		</table>
		<p>
			&nbsp;</p>
		<p>
			&nbsp;
		</p>
	</div>
</div>
