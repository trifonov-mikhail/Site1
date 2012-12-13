<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SerialNumbersUpload.ascx.cs" Inherits="Apple.Web.Admin.Controls.Editors.SerialNumbersUpload" %>
<asp:PlaceHolder ID="phUploadDialog" runat="server">
	<div class="fileUploadErrors">
		<asp:RegularExpressionValidator Display="Dynamic" CssClass="ErrorMess" 
			id="revFileExtensionValidator" runat="server" 
			ValidationExpression=".*\.xls$" 
			ControlToValidate="fileUpload" SetFocusOnError="true" 
			meta:resourcekey="revFileExtensionValidatorResource1"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator Display="Dynamic" id="rfvFileNameValidator" 
			CssClass="ErrorMess" runat="server" 
			SetFocusOnError="true"
			ControlToValidate="fileUpload" meta:resourcekey="rfvFileNameValidatorResource1"></asp:RequiredFieldValidator>
	</div>
	<div class="fileUpload">
	    <asp:FileUpload ID="fileUpload" runat="server" 
			meta:resourcekey="fileUploadResource1" />
	</div>
	<div>
	    <asp:Button ID="btnUploadFile" runat="server" 
			meta:resourcekey="btnUploadFileResource1" />&nbsp;<br />
	</div>
</asp:PlaceHolder>
<asp:PlaceHolder ID="phConfirmationDialog" runat="server" Visible="False">
	<asp:Button ID="btnConfirmUpload" runat="server" Text="Подтвердить" 
		meta:resourcekey="btnConfirmUploadResource1" />
	<asp:Button ID="btnCancelUpload" runat="server" Text="Отменить" 
		meta:resourcekey="btnCancelUploadResource1" />
</asp:PlaceHolder>