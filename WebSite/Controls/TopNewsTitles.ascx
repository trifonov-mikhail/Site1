<%@ Control Language="C#" AutoEventWireup="true" Codebehind="TopNewsTitles.ascx.cs"
    Inherits="Apple.Web.Controls.TopNewsTitles" %>

<script type="text/javascript">
	var currentBlock;
	var openFirst = <%if (OpenFirst){ %>true<%}else{ %>false<%} %>;
	var imageUrl = '<%=ImageUrl %>';
	var acc;
	$(function() {
		acc = $(".accordion").accordion({
		    header: "p",
		    active: false,
		    collapsible:true,
		    autoHeight: false,
		    event:""
		});
		
		var p = $("p", ".accordion");
		p.click(function(e){
            currentBlock = $(this).next("div");
            LoadNewsText();
        }); 
        //load first 
        if (openFirst && p.length > 0)
            $(p[0]).click();
	});
	
	function LoadNewsText(){
        var state = currentBlock.attr("state");
        var index = parseInt(currentBlock.attr("index"));
        
        if (state=="0"){    
            var id = currentBlock.attr("newsid");
            var gid = currentBlock.attr("gid");
    	
            $.ajax({  
               type: "POST",  
               contentType: "application/json; charset=utf-8",  
               url: "<%=ServiceMethod %>",   
               data:    "{"+
                            "id:'"+id+"'"+
                        "}",
               dataType: "json",
               success:function(data)
               {
                    if (data){
                        currentBlock.attr("state","1")
                        var url = imageUrl+gid;
                        //var a = "<img src="+url+" alt='' />";
                        //var date = "<tr><td colspan='2'><div class='date2'>"+data.DateString+"</div></td></tr>";
                        //var html = "<table border='0'>"+date+"<tr><td align='left' valign='top'>"+a+"</td><td style='padding-left:10px;' align='left' valign='top'>"+data.Text+"</td></tr></table>";
                        var img = "";
                        
                        if(data.HasImage){
                            img = "<img align='left' style='padding:0 10px 10px 0;' src="+url+" alt='' />";
                        }
                        
                        var date = "<div class='date2'>"+data.DateString+"</div>";
                        var body = "<div class='news_body'>" + img + data.Text+"</div";
                        currentBlock.html(date+body);
                        acc.accordion('activate', index);
                    }
               }
            });
            
        }else
        {
            acc.accordion('activate', index);
        }
        
    }
</script>

<asp:Repeater ID="rItems" runat="server" DataSourceID="odsItems" OnItemDataBound="rItems_ItemDataBound">
    <HeaderTemplate>
        <div class="accordion" style="width:680px;">
    </HeaderTemplate>
    <ItemTemplate>
        <p class="hnews">
            <asp:HyperLink ID="link" Text='<%# Eval("Title") %>' NavigateUrl="javascript:void(0)" runat="server"></asp:HyperLink>
        </p>
        <div state="0" newsid="<%# Eval("ID") %>" gid="<%# Eval("GroupID") %>" index="<%# DataBinder.Eval(Container, "ItemIndex") %>">
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div>
        <div style="margin: 20px 0;">
            <p class="hnews">
                <a href="<%=GetUrl("~/{lang}/NewsArchive.aspx") %>">Посмотреть все новости</a>
            </p>
        </div>
    </FooterTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="odsItems" runat="server" OldValuesParameterFormatString="original_{0}"
    TypeName="Erc.Apple.Data.News" OnSelecting="odsItems_Selecting">
    <SelectParameters>
        <asp:Parameter Name="langCode" Type="String" />
        <asp:Parameter Name="pageID" Type="Int32" />
        <asp:Parameter Name="count" Type="Int32" />
        <asp:Parameter Name="skipMain" Type="Boolean" />
    </SelectParameters>
</asp:ObjectDataSource>
