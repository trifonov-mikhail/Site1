<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrackSerialNumbersEditor.ascx.cs" Inherits="Apple.Web.Admin.Controls.TrackSerialNumbersEditor" %>
<%@ Register Namespace="Apple.Web.Admin.Controls" TagPrefix="UC" Assembly="Apple.Web.Admin" %>    
<asp:GridView ID="GridViewItemsList" runat="server" AutoGenerateColumns="False"
			EnableViewState="true"
            DataSourceID="sqlDataSource" AllowPaging="True" PageSize="20" EmptyDataText="There are no data records to display."
            Width="800" CssClass="mylist">
            <Columns>
                <asp:BoundField DataField="Serial" HeaderText="Серийный номер" SortExpression="Serial">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="DateStamp" HeaderText="Дата создания" DataFormatString="{0:D}" SortExpression="DateStamp">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="150" />
                </asp:BoundField>
				<asp:BoundField DataField="City" HeaderText="Город" SortExpression="City">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
				<asp:BoundField DataField="IP" HeaderText="IP" SortExpression="IP">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
            </Columns>
</asp:GridView>
<br />
<UC:GetCsvControl id="csv" DataSourceID="sqlDataSource" runat="server"  />
<br />

<asp:SqlDataSource ID="sqlDataSource" runat="server"   SelectCommand="SELECT * FROM TrackSerialNumber ORDER BY DateStamp Desc"
 SelectCommandType="Text" ConnectionString="<%$ ConnectionStrings:SiteDBConnectionString %>"></asp:SqlDataSource>
