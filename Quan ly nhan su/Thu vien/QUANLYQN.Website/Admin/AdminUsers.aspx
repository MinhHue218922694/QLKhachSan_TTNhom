
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AdminUsers.aspx.cs" Inherits="AdminUsers" Title="AdminUsers List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Admin Users List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AdminUsersDataSource"
				DataKeyNames="IdUser"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AdminUsers.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="IdUser" HeaderText="Id User" SortExpression="ID_USER" ReadOnly />
				<asp:BoundField DataField="Password" HeaderText="Password" SortExpression="PASSWORD"  />
				<asp:BoundField DataField="FullName" HeaderText="Full Name" SortExpression="FULL_NAME"  />
				<asp:BoundField DataField="Active" HeaderText="Active" SortExpression="ACTIVE"  />
				<asp:BoundField DataField="Modified" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified" SortExpression="MODIFIED"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="DESCRIPTION"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No AdminUsers Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAdminUsers" OnClientClick="javascript:location.href='AdminUsersEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AdminUsersDataSource ID="AdminUsersDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
>			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AdminUsersDataSource>
	    		
</asp:Content>



