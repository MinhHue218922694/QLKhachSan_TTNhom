
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Lscapbac.aspx.cs" Inherits="Lscapbac" Title="Lscapbac List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Lscapbac List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="LscapbacDataSource"
				DataKeyNames="IdLichsucapbac"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Lscapbac.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Id Quannhan" DataNavigateUrlFormatString="QuannhanEdit.aspx?IdQuannhan={0}" DataNavigateUrlFields="IdQuannhan" DataContainer="IdQuannhanSource" DataTextField="MaQuannhan" />
				<data:HyperLinkField HeaderText="Id Capbac" DataNavigateUrlFormatString="DmcapbacEdit.aspx?IdCapbac={0}" DataNavigateUrlFields="IdCapbac" DataContainer="IdCapbacSource" DataTextField="Capbac" />
				<asp:BoundField DataField="Ngaynhan" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngaynhan" SortExpression="NGAYNHAN"  />
				<asp:BoundField DataField="Ghichu" HeaderText="Ghichu" SortExpression=""  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Lscapbac Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnLscapbac" OnClientClick="javascript:location.href='LscapbacEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:LscapbacDataSource ID="LscapbacDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:LscapbacProperty Name="Quannhan"/> 
					<data:LscapbacProperty Name="Dmcapbac"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:LscapbacDataSource>
	    		
</asp:Content>



