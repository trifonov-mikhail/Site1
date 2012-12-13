<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AllNewsTitles.ascx.cs"
    Inherits="Apple.Web.Controls.AllNewsTitles" %>

    
<script type="text/javascript">
	var currentBlock;
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
		
		$("p", ".accordion").click(function(e){
            currentBlock = $(this).next("div");
            LoadNewsText();
        });  
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

    
<asp:GridView ID="gvItems" runat="server" CssClass="accordion" GridLines="None" CellPadding="0" AutoGenerateColumns="False"
    DataSourceID="odsItems" AllowPaging="True" Width="680px" OnRowDataBound="gvItems_RowDataBound">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <p class="hnews">
                    <asp:HyperLink ID="link" Text='<%# Eval("Title") %>' NavigateUrl="javascript:void(0)" runat="server">
                    </asp:HyperLink>
                </p>
                <div state="0" newsid="<%# Eval("ID") %>" gid="<%# Eval("GroupID") %>" 
                <%if (SkipFirst && gvItems.PageIndex==0) {%>
                index="<%# (int)DataBinder.Eval(Container, "RowIndex")-1 %>"
                <%} else {%>
                index="<%# DataBinder.Eval(Container, "RowIndex") %>"
                <%}%>
                >
                </div>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerStyle CssClass="pager" HorizontalAlign="Right" />
</asp:GridView>
<div style="height:30px;">
</div>
<asp:ObjectDataSource ID="odsItems" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAll" TypeName="Erc.Apple.Data.News" OnSelecting="odsItems_Selecting">
    <SelectParameters>
        <asp:Parameter Name="language" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
