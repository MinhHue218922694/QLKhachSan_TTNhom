
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AdminGroupusers.aspx.cs" Inherits="AdminGroupusers" Title="AdminGroupusers List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Admin Groupusers List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AdminGroupusersDataSource"
				DataKeyNames="IdGroup, IdUser"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AdminGroupusers.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Id Group" DataNavigateUrlFormatString="AdminGroupsEdit.aspx?IdGroup={0}" DataNavigateUrlFields="IdGroup" DataContainer="IdGroupSource" DataTextField="GroupName" />
				<data:HyperLinkField HeaderText="Id User" DataNavigateUrlFormatString="AdminUsersEdit.aspx?IdUser={0}" DataNavigateUrlFields="IdUser" DataContainer="IdUserSource" DataTextField="Password" />
			</Columns>
			<EmptyDataTemplate>
				<b>No AdminGroupusers Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAdminGroupusers" OnClientClick="javascript:location.href='AdminGroupusersEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AdminGroupusersDataSource ID="AdminGroupusersDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AdminGroupusersProperty Name="AdminGroups"/> 
					<data:AdminGroupusersProperty Name="AdminUsers"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AdminGroupusersDataSource>
	    		
</asp:Content>



