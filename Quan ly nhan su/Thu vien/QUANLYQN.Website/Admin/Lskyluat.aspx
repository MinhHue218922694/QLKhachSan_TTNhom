
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Lskyluat.aspx.cs" Inherits="Lskyluat" Title="Lskyluat List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Lskyluat List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="LskyluatDataSource"
				DataKeyNames="IdLichsukyluat"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Lskyluat.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Id Quannhan" DataNavigateUrlFormatString="QuannhanEdit.aspx?IdQuannhan={0}" DataNavigateUrlFields="IdQuannhan" DataContainer="IdQuannhanSource" DataTextField="MaQuannhan" />
				<data:HyperLinkField HeaderText="Id Hinhthuc Kyluat" DataNavigateUrlFormatString="DmhinhthuckyluatEdit.aspx?IdHinhthucKyluat={0}" DataNavigateUrlFields="IdHinhthucKyluat" DataContainer="IdHinhthucKyluatSource" DataTextField="HinhthucKyluat" />
				<asp:BoundField DataField="CapKyluat" HeaderText="Cap Kyluat" SortExpression="CAP_KYLUAT"  />
				<asp:BoundField DataField="NgayQuyetdinh" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngay Quyetdinh" SortExpression="NGAY_QUYETDINH"  />
				<asp:BoundField DataField="Ghichu" HeaderText="Ghichu" SortExpression=""  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Lskyluat Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnLskyluat" OnClientClick="javascript:location.href='LskyluatEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:LskyluatDataSource ID="LskyluatDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:LskyluatProperty Name="Quannhan"/> 
					<data:LskyluatProperty Name="Dmhinhthuckyluat"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:LskyluatDataSource>
	    		
</asp:Content>



