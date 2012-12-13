<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Default.ascx.cs" Inherits="Apple.Web.Controls.Default" %>

<%@ Register TagPrefix="uc" TagName="Blocks" Src="~/Controls/HomePageBlocks.ascx" %>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
	 <script src="http://code.jquery.com/ui/1.7.2/jquery-ui.js"></script>
<div class="main" style="margin-top: -10px;">

		<script type="text/javascript">
			var imagesPath = ['<%=this.GetUrl("~/images/main.jpg") %>', '<%=this.GetUrl("~/images/main2.jpg") %>'];
			var urlPath = ['<%=this.url1 %>', '<%=this.url2 %>']
			if ($.cookie("currentImage") === null)
				$.cookie("currentImage", 0);


			var currentImage = parseInt($.cookie("currentImage"));
			
			$(document).ready(function () {
				if (currentImage == NaN)
					currentImage = 0;
				currentImage = parseInt(currentImage) + 1;

				if (currentImage > 1)
					currentImage = 0
					
				$.cookie("currentImage", currentImage);
				
				$('#imagebanner').attr("src", imagesPath[currentImage]);
				$('#banner').attr("href", urlPath[currentImage]);




				function changeImages() {
					$("#imagebanner").fadeOut(1000, function () {
						currentImage = parseInt($.cookie("currentImage"));

						if (currentImage === undefined)
							currentImage = 0;

						currentImage = currentImage + 1;

						if (currentImage > 1)
							currentImage = 0

						$.cookie("currentImage", currentImage);
						$("#imagebanner").attr("src", imagesPath[currentImage]);
						$('#banner').attr("href", urlPath[currentImage]);
					}).fadeIn(1000);
				}

				window.setInterval(changeImages, 5000);
			});
			
			
		</script>
		<a href='<%=this.url1 %>' id="banner">
			<img src='<%=this.GetUrl("~/images/main.jpg") %>' alt="" width="645" height="325"  id="imagebanner"/>
		</a>
		
		

    <uc:Blocks ID="blocks" runat="server" />
</div>
<div class="mainnews">
    <table width="720">
        <tr>
            <td width="60" align="left">
                <a href="<%=this.GetUrl("~/{lang}/News.aspx") %>" style="font-size:12px; padding:0;">
                    <strong>Последние <br /> новости</strong>
                </a>
            </td>
            <td>
                <a href="<%=this.GetUrl("~/{lang}/News.aspx") %>">
                    <asp:Literal ID="ltLastNews" runat="server"></asp:Literal>
                </a>
            </td>
        </tr>
    </table>
</div>
<p class="blue" style="padding-bottom: 20px;">
    &nbsp;
</p>
<div class="clear">
</div>
