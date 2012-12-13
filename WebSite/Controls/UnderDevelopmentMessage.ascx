<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UnderDevelopmentMessage.ascx.cs"
    Inherits="Apple.Web.Controls.UnderDevelopmentMessage" %>
<div id="mess" style="padding-top: 25px; display: none;">
    Страница в процессе разработки
</div>

<script type="text/javascript">
        var comingDialog = null;
        
        $(function() {
            comingDialog = $('#mess').dialog
	        (
	            { 
	                autoOpen:false,
                    resizable:false,
	                modal:true,
	                title:"Информация",
	                width:300,
	                buttons: {
        				Ok: function() {
		    			    $(this).dialog('close');
				        }
			        }
	            }
	        );
	        
	        $("a[href='#'],a[href='/#'],a[href='../#']").click(openComingDialog);
	        
	        $(".ui-dialog-titlebar-close").unbind("click",openComingDialog);
        });
        
        function openComingDialog(){
            comingDialog.dialog('open');
	        return false;
        }
</script>

