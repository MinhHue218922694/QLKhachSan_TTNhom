
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AdminGroupmenus.aspx.cs" Inherits="AdminGroupmenus" Title="AdminGroupmenus List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Admin Groupmenus List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AdminGroupmenusDataSource"
				DataKeyNames="IdMenu, IdGroup"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AdminGroupmenus.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Id Menu" DataNavigateUrlFormatString="AdminMenusEdit.aspx?IdMenu={0}" DataNavigateUrlFields="IdMenu" DataContainer="IdMenuSource" DataTextField="MenuName" />
				<data:HyperLinkField HeaderText="Id Group" DataNavigateUrlFormatString="AdminGroupsEdit.aspx?IdGroup={0}" DataNavigateUrlFields="IdGroup" DataContainer="IdGroupSource" DataTextField="GroupName" />
				<data:BoundRadioButtonField DataField="View" HeaderText="View" SortExpression="[VIEW]"  />
				<data:BoundRadioButtonField DataField="Add" HeaderText="Add" SortExpression="[ADD]"  />
				<data:BoundRadioButtonField DataField="Edit" HeaderText="Edit" SortExpression="[EDIT]"  />
				<data:BoundRadioButtonField DataField="Delete" HeaderText="Delete" SortExpression="[DELETE]"  />
				<data:BoundRadioButtonField DataField="Control" HeaderText="Control" SortExpression="[CONTROL]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No AdminGroupmenus Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAdminGroupmenus" OnClientClick="javascript:location.href='AdminGroupmenusEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AdminGroupmenusDataSource ID="AdminGroupmenusDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AdminGroupmenusProperty Name="AdminGroups"/> 
					<data:AdminGroupmenusProperty Name="AdminMenus"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AdminGroupmenusDataSource>
	    		
</asp:Content>



