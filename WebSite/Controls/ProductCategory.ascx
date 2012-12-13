<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ProductCategory.ascx.cs"
    Inherits="Apple.Web.Controls.ProductCategory" %>


<asp:Repeater ID="rProducts" runat="server" DataSourceID="odsProducts" OnItemDataBound="rProducts_ItemDataBound">
    <HeaderTemplate>
        <table cellspacing="0" cellpadding="0" border="0" width="695" style="margin-top: 16px;">
            <tbody>
                <tr>
                    <td align="right" valign="top">
                        <asp:Image ID="btnLeft" runat="server" Height="200" Width="28" ImageUrl="~/images/tab_left.png" />
                    </td>
                    <td class="tabcen">
                        <h2 class="items-name">
                            <%=CategoryName %>
                        </h2>
                        <div id="<%=this.ScriptID%>_container" class="container">
                            <div id="<%=this.ScriptID%>_pane" class="pane">
                                <table id="<%=this.ScriptID%>_items" class="scroll-items" border="0" cellspacing="0">
                                    <tr>
    </HeaderTemplate>
    <ItemTemplate>
                                        <td align="center" valign="bottom" class="scroll-item">
                                            <asp:Image ID="iProduct" AlternateText='<%#Eval("Name") %>' ImageUrl='<%#Eval("GroupID","~/GetImage.ashx?id={0}&type=1") %>'
                                                runat="server" />
                                            <a href='<%#Eval("Url") %>'>
                                                <%#FormatName((string)Eval("Name"))%>
                                            </a>
                                        </td>
    </ItemTemplate>
    <FooterTemplate>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                    <td valign="top">
                        <asp:Image ID="btnRight" runat="server" Height="200" Width="28" ImageUrl="~/images/tab_right.png" />
                    </td>
                </tr>
            </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>

<asp:ObjectDataSource ID="odsProducts" runat="server" OldValuesParameterFormatString="original_{0}"
    OnSelecting="odsProducts_Selecting" SelectMethod="GetAllByLanguageCategory" TypeName="Erc.Apple.Data.Products">
    <SelectParameters>
        <asp:Parameter Name="language" Type="String" />
        <asp:Parameter Name="categoryId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>


<script type="text/javascript">
        var <%=this.ScriptID%>_pane = null;
        var <%=this.ScriptID%>_left = null;
        var <%=this.ScriptID%>_right = null;
        var <%=this.ScriptID%>_container = null;
        
        var <%=this.ScriptID%>_cw = 0;
        var <%=this.ScriptID%>_pw = 0;
        
        var <%=this.ScriptID%>_fl = null;
        var <%=this.ScriptID%>_fr = null;
        
        var <%=this.ScriptID%>_current = 0;
        
        var <%=this.ScriptID%>_count = 3;
        var <%=this.ScriptID%>_padding = 24;
        var <%=this.ScriptID%>_speed = 'slow';
        
        
        
        $(function(){
        
            var t = $('#<%=this.ScriptID%>_items');
            var tw = t.width();
            t.css({width:tw});
            
            <%=this.ScriptID%>_pane = $("#<%=this.ScriptID%>_pane");
            <%=this.ScriptID%>_container = $("#<%=this.ScriptID%>_container");
            
            <%=this.ScriptID%>_left = $("#<%=LeftButtonID %>");
            <%=this.ScriptID%>_right = $("#<%=RightButtonID %>");
            
            //-----------
            //override hide/show
            <%=this.ScriptID%>_left.show = function()
            {
                var src = <%=this.ScriptID%>_left.attr('src');
                <%=this.ScriptID%>_left.attr('src',src.replace('tab','arrow')).addClass('hand');
                
            }
            <%=this.ScriptID%>_left.hide = function()
            {
                var src = <%=this.ScriptID%>_left.attr('src');
                <%=this.ScriptID%>_left.attr('src',src.replace('arrow','tab')).removeClass('hand');
            }
            
            <%=this.ScriptID%>_right.show = function()
            {
                var src = <%=this.ScriptID%>_right.attr('src');
                <%=this.ScriptID%>_right.attr('src',src.replace('tab','arrow')).addClass('hand');
            }
            <%=this.ScriptID%>_right.hide = function()
            {
                var src = <%=this.ScriptID%>_right.attr('src');
                <%=this.ScriptID%>_right.attr('src',src.replace('arrow','tab')).removeClass('hand');
            }
            //-----------
                        
            <%=this.ScriptID%>_fl = $("<div class='fade_left' style='background-image:url(../images/fade-left.png);'></div>").hide();
            <%=this.ScriptID%>_fr = $("<div class='fade_right' style='background-image:url(../images/fade-right.png);'></div>").hide();
            <%=this.ScriptID%>_fl.ifixpng();
            <%=this.ScriptID%>_fr.ifixpng();
            <%=this.ScriptID%>_container.append(<%=this.ScriptID%>_fl);
            <%=this.ScriptID%>_container.append(<%=this.ScriptID%>_fr);
            
            $(window).bind("load",function(){
                //after all pictures loaded
                <%=this.ScriptID%>_cw = <%=this.ScriptID%>_container.width();
                <%=this.ScriptID%>_pw = <%=this.ScriptID%>_pane.width();
                
                if (<%=this.ScriptID%>_pw > <%=this.ScriptID%>_cw){
                    <%=this.ScriptID%>_right.show();
                    <%=this.ScriptID%>_fr.show();
                }
            });
            
            <%=this.ScriptID%>_left.click(function(){
                
                var src = <%=this.ScriptID%>_left.attr('src');
                if (src.indexOf('arrow')==-1)
                    return;
                
                <%=this.ScriptID%>_current--;
                
                var w = 0;
                var wl = 0;
                var i = 0;

                while(i++ < <%=this.ScriptID%>_count && <%=this.ScriptID%>_current>=0){
                    wl = $("#<%=this.ScriptID%>_pane td:eq("+<%=this.ScriptID%>_current+")").width()+<%=this.ScriptID%>_padding;
                    w += wl;
                    <%=this.ScriptID%>_current--;
                }
                <%=this.ScriptID%>_current++;
                w++;
                
                var p = <%=this.ScriptID%>_pane.position().left + w;
                p = Math.round(p);
                <%=this.ScriptID%>_pane.animate({left: '+='+w},<%=this.ScriptID%>_speed);
                
                if (p >= - <%=this.ScriptID%>_padding/2)
                {
                    <%=this.ScriptID%>_left.hide();
                    <%=this.ScriptID%>_fl.hide();
                }
                <%=this.ScriptID%>_right.show(); 
                <%=this.ScriptID%>_fr.show();               
            });
            <%=this.ScriptID%>_right.click(function(){
                
                
                var src = <%=this.ScriptID%>_right.attr('src');
                if (src.indexOf('arrow')==-1)
                    return;
                
                var w = 0;
                var wl = 0;
                var i = 0;

                while(i++ < <%=this.ScriptID%>_count && <%=this.ScriptID%>_current<=<%=this.ScriptID%>_pw){
                    wl = $("#<%=this.ScriptID%>_pane td:eq("+<%=this.ScriptID%>_current+")").width()+<%=this.ScriptID%>_padding;
                    w += wl;
                    <%=this.ScriptID%>_current++;
                }
                w++;
                var p = <%=this.ScriptID%>_pane.position().left - w;
                p = Math.round(p);
                <%=this.ScriptID%>_pane.animate({left: '-='+w},<%=this.ScriptID%>_speed);
                
                // - <%=this.ScriptID%>_padding/2
                if (p + <%=this.ScriptID%>_pw - <%=this.ScriptID%>_cw <= 0)
                {
                    <%=this.ScriptID%>_right.hide();
                    <%=this.ScriptID%>_fr.hide();
                }
                
                <%=this.ScriptID%>_left.show();
                <%=this.ScriptID%>_fl.show();
            });
        });
</script>
