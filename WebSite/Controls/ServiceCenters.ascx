<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ServiceCenters.ascx.cs"
    Inherits="Apple.Web.Controls.ServiceCenters" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="uc" TagName="map" Src="~/Controls/Map.ascx" %>

<p style="padding: 0 0 20px 30px">
    <%--   <asp:Localize ID="LocalizeTopInstruction" Text='<%$ Resources: TopInstruction %>'
        runat="server">
    </asp:Localize>--%>
</p>
<div class="map" style="margin-bottom: 30px;">
    <uc:map id="map1" runat="server" />
</div>
<div class="FormSearchProduct">
    <%--    <script type="text/javascript">
<!-- begin hiding
function expandSELECT(sel) {
sel.style.width = '';
}


function contractSELECT(sel) {
sel.style.width = '130px';
}
// end hiding -->
</script>--%>
    <%--<p>
        <asp:Localize ID="LocalizeSelectProductsTitle" Text='<%$ Resources: SelectProductsTitle %>'
            runat="server">
        </asp:Localize>
    </p>
    <div class="bg_input">
        <asp:DropDownList ID="ddlSpecializations" runat="server" Width="150">
        </asp:DropDownList>
    </div>
    <cc1:CascadingDropDown ID="CDD1" runat="server" Category="Specialization" LoadingText='<%$ Resources: AppleRes, CddLoadingText %>'
        PromptText='<%$ Resources: AppleRes, SelectAll %>' ServiceMethod="GetSpecializations"
        ServicePath="~/WS/SysService.asmx" TargetControlID="ddlSpecializations">
    </cc1:CascadingDropDown>--%>
    <p>
        <asp:Localize ID="Localize2" Text='<%$ Resources: AppleRes, Region %>' runat="server">
        </asp:Localize>
    </p>
    <div class="bg_input">
        <asp:DropDownList ID="ddlRegions" DataSourceID="odsRegions" runat="server" AppendDataBoundItems="true"
            Width="130px" AutoPostBack="True" DataTextField="Name" DataValueField="GroupID">
            <asp:ListItem Text='<%$ Resources: AppleRes, SelectAll %>' Value=""></asp:ListItem>
        </asp:DropDownList>
        <asp:ObjectDataSource ID="odsRegions" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAllByLanguage" TypeName="Erc.Apple.Data.Regions" OnSelecting="odsRegions_Selecting">
            <SelectParameters>
                <asp:Parameter Name="language" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <p>
        <asp:Localize ID="Localize3" Text='<%$ Resources: AppleRes, City %>' runat="server">
        </asp:Localize>
    </p>
    <div class="bg_input">
        <asp:UpdatePanel ID="upCities" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="ddlCities" DataSourceID="odsCities" AppendDataBoundItems="true"
                    runat="server" Width="130px" DataTextField="Name" DataValueField="GroupID" OnDataBinding="ddlCities_DataBinding">
                    <asp:ListItem Text='<%$ Resources: AppleRes, SelectAll %>' Value=""></asp:ListItem>
                </asp:DropDownList>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlRegions" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:ObjectDataSource ID="odsCities" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAllByLanguageAndRegion" TypeName="Erc.Apple.Data.Cities" OnSelecting="odsCities_Selecting">
            <SelectParameters>
                <asp:Parameter Name="language" Type="String" />
                <asp:ControlParameter ControlID="ddlRegions" Name="regionID" DefaultValue="0" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <div style="height: 15px;">
    </div>
    <asp:ImageButton ID="btnShow" runat="server" ImageUrl="~/images/button_pokazat.png"
        AlternateText="ShowServices" OnClick="btnShow_Click" />
    <div id="progress" style="display:none; margin-top:3px;">
        <asp:Image ID="imgProgress" ImageUrl="~/images/loading64.gif" ImageAlign="AbsMiddle" Height="40" Width="40" runat="server" />
        <asp:Label ID="lblLoading" runat="server"></asp:Label>    
    </div>
</div>
<div class="clear">
</div>
<asp:UpdatePanel ID="up" runat="server">
    <ContentTemplate>
        <asp:Repeater ID="rItems" runat="server" DataSourceID="odsCenters" OnItemDataBound="rItems_ItemDataBound"
            OnPreRender="rItems_PreRender">
            <HeaderTemplate>
                <table width="850" border="0" cellpadding="0" cellspacing="0" style="margin-left: 25px;">
                    <tr>
                        <td class="u1">
                        </td>
                        <td colspan="5" class="uc">
                        </td>
                        <td class="u2">
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" class="uc" style="width:10px;">&nbsp;
                            </td>
                        <td width="130" valign="middle" class="uc" style="padding-right:10px;">
                            <asp:Localize ID="lc1" Text='<%$ Resources: AppleRes, PartnerStatus %>' runat="server">
                            </asp:Localize></td>
                        <td valign="middle" class="uc">
                            <asp:Localize ID="lc2" Text='<%$ Resources: AppleRes, Name %>' runat="server">
                            </asp:Localize></td>
                        <td valign="middle" class="uc" width="200">
                            <asp:Localize ID="lc3" Text='<%$ Resources: AppleRes, City %>' runat="server">
                            </asp:Localize></td>
                        <td valign="middle" class="uc" width="220">
                            <asp:Localize ID="lc4" Text='<%$ Resources: AppleRes, Address %>' runat="server">
                            </asp:Localize></td>
                        <td valign="middle" class="uc" width="180">
                            <asp:Localize ID="lc5" Text='<%$ Resources: AppleRes, Telephone %>' runat="server">
                            </asp:Localize></td>
                        <%--<td width="100" class="uc">
                            <asp:Localize ID="cl6" Text='<%$ Resources: AppleRes, Specialization %>' runat="server">
                            </asp:Localize></td>--%>
                        <td valign="middle" class="uc" style="width:10px;">&nbsp;
                            </td>
                    </tr>
                    <tr>
                        <td class="u4">
                        </td>
                        <td colspan="5" class="uc">
                        </td>
                        <td class="u3">
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>&nbsp;
                        </td>
                    <td class="row">
                        <%#Eval("StatusName")%>
                    </td>
                    <td class="row">
                        <%#Eval("Name")%>
                    </td>
                    <td class="row">
                        <%#Eval("CityName")%>
                    </td>
                    <td class="row">
                        <%#Eval("Address")%>
                        <br>
                        <a href='<%#Eval("Url")%>' target="_blank">
                            <%#Eval("Url")%>
                        </a>
                    </td>
                    <td class="row">
                        <%#Eval("Telephone")%>
                    </td>
                    <%--<td class="row">
                        <asp:Label ID="lblSpecialization" runat="server"></asp:Label></td>--%>
                    <td>&nbsp;
                        </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <asp:PlaceHolder ID="phNoData" runat="server">
                    <tr>
                        <td colspan="8" align="center" valign="middle"height="100" style="padding-bottom:20px;">
                            Для этого региона (города) пока что нет данных
                        </td>
                    </tr>
                </asp:PlaceHolder>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="odsCenters" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="Services_GetAllByLanguageRegionCitySpecialization" TypeName="Erc.Apple.Data.Services"
            OnSelecting="odsCenters_Selecting">
            <SelectParameters>
                <asp:Parameter Name="language" Type="String" />
                <asp:Parameter DefaultValue="0" Name="cityID" Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="specializationID" Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="regionID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:PlaceHolder ID="phDetails" runat="server" Visible="false">
            <br />
            <br />
            <div class="clear">
            </div>
            <div class="footnote" style="padding-left: 30px; margin-bottom:30px;">
                <img src='<%=this.GetUrl("~/images/banners_img2.jpg") %>' alt="" />
            </div>
        </asp:PlaceHolder>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(initializeRequestHandler);
    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(pageLoadedHandler)

    var lblLoading;
    var imgProgress;
    var progressDiv;
    
    var LoadingServiceCentersMess = "<asp:Localize runat='server' Text='<%$ Resources: LoadingPartners %>'></asp:Localize>";
    var LoadingCitiesMess = "<asp:Localize runat='server' Text='<%$ Resources: LoadingCities %>'></asp:Localize>";
    
    $(function(){
        lblLoading = $("#<%=lblLoading.ClientID %>");
        imgProgress = $("#<%=imgProgress.ClientID %>");
        progressDiv = $("#progress");
    });

    function initializeRequestHandler(sender, args)
    {
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        var id = args.get_postBackElement().id;
        
        if (prm.get_isInAsyncPostBack()){
            args.set_cancel(true);
        }else{
            if (id.indexOf('btnShow')>=0){
                ShowStatus(LoadingServiceCentersMess);
            }else{
                ShowStatus(LoadingCitiesMess);
            }
        }
    }
    function ShowStatus(text){
        lblLoading.text(text).show();
        progressDiv.fadeIn();
    }
    function HideStatus(){
        progressDiv.hide();
    }
    function pageLoadedHandler(sender, args)
    {
        HideStatus();
    }

</script>