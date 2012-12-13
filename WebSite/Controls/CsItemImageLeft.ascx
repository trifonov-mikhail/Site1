<%@ Control Language="C#" AutoEventWireup="true" Inherits="Apple.Web.Controls.CsItem" %>
<div class="cs-item" style="margin-bottom: 20px; margin-left: 20px;">
    <h2 style="margin-left: 5px;">
        <asp:Label ID="Label1" Font-Bold="true" runat="server"></asp:Label>
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </h2>
    <div class="col11" style="margin-left: -50px; width: 370px;">
        <asp:Image ID="i" ImageUrl='<%=ImageUrl %>' runat="server" />
    </div>
    <div class="col22" style="width: 325px;">
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <asp:PlaceHolder ID="phLink1" runat="server">
            <p>
                <asp:HyperLink ID="link1" Target="_blank" runat="server"></asp:HyperLink>
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phLink2" runat="server">
            <div style="">
                <div class="button">
                    <asp:HyperLink ID="link2" Target="_blank" runat="server"></asp:HyperLink>
                </div>
            </div>
        </asp:PlaceHolder>
    </div>
    <div class="clear">
    </div>
</div>
