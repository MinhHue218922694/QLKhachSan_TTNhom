
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AdminGroups.aspx.cs" Inherits="AdminGroups" Title="AdminGroups List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Admin Groups List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AdminGroupsDataSource"
				DataKeyNames="IdGroup"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AdminGroups.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="IdGroup" HeaderText="Id Group" SortExpression="ID_GROUP" ReadOnly />
				<asp:BoundField DataField="GroupName" HeaderText="Group Name" SortExpression="GROUP_NAME"  />
				<asp:BoundField DataField="Active" HeaderText="Active" SortExpression="ACTIVE"  />
				<asp:BoundField DataField="Parent" HeaderText="Parent" SortExpression="PARENT"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="DESCRIPTION"  />
				<asp:BoundField DataField="Modified" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified" SortExpression="MODIFIED"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No AdminGroups Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAdminGroups" OnClientClick="javascript:location.href='AdminGroupsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AdminGroupsDataSource ID="AdminGroupsDataSource" runat="server"
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
		</data:AdminGroupsDataSource>
	    		
</asp:Content>



