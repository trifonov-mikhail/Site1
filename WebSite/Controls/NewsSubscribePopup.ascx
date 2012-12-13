<%@ Control Language="C#" AutoEventWireup="true" Codebehind="NewsSubscribePopup.ascx.cs"
    Inherits="Apple.Web.Controls.NewsSubscribePopup" %>
<div id="popupAddSubscriber" style="padding-top: 10px; display: none;">
    <div class="title">Фамилия, имя</div>
    <input id="popupTxtName" type="text" /><span id="rvf1" style="color: Red; display: none;">*</span><br />
    <div class="title">e-mail</div>
    <input id="popupTxtEmail" type="text" /><span id="rvf2" style="color: Red; display: none;">*</span><br />
</div>

<script type="text/javascript">
        var dialogAddSubscriber = null;
        var rvf1;
        var rvf2;
        $(function() {
            
            rvf1 = $('#rvf1');
            rvf2 = $('#rvf2');
        
            dialogAddSubscriber = $('#popupAddSubscriber').dialog
	        (
	            { 
	                dialogClass: 'erc',
	                autoOpen:false,
                    resizable:false,
	                modal:true,
	                width:320,
	                height:300,
	                buttons: {
        				'Подписаться на новости': function() {
        				    var name = $('#popupTxtName').val();
                            var email = $('#popupTxtEmail').val();
                            if (ValidSubscriber(name,email)){
        				        AddSubscriber(name, email);
		    			        $(this).dialog('close');
		    			    }
				        }
			        }
	            }
	        );
	        
	        $("a[href='/#Subscribe']").click(openAddSubscriberDialog);
	        
	        $(".ui-dialog-titlebar-close").unbind("click",openAddSubscriberDialog);
	        //$(".ui-dialog").ifixpng();
        });
        function ValidSubscriber(name,email)
        {
            var result = true;
            var filter = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
            
            rvf1.hide();
            rvf1.hide();
            
            if (name==''){
                result = false;
                rvf1.show();
            }
            if (!email.match(filter)){
                result = false;
                rvf2.show();
            }
            return result;
        }
        function AddSubscriber(name,email){
            $.ajax({  
               type: "POST",  
               contentType: "application/json; charset=utf-8",  
               url: "<%=ServiceMethod %>",   
               data:    "{"+
                            "name:'"+name+"',"+
                            "email:'"+email+"'"+
                        "}",
               dataType: "json",
               success:function(data){}
            });
        }
        function openAddSubscriberDialog(){
            dialogAddSubscriber.dialog('open');
	        return false;
        }
</script>

