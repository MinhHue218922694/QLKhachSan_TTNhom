
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AdminMenus.aspx.cs" Inherits="AdminMenus" Title="AdminMenus List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Admin Menus List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AdminMenusDataSource"
				DataKeyNames="IdMenu"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AdminMenus.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="IdMenu" HeaderText="Id Menu" SortExpression="ID_MENU" ReadOnly />
				<asp:BoundField DataField="MenuName" HeaderText="Menu Name" SortExpression="MENU_NAME"  />
				<asp:BoundField DataField="Active" HeaderText="Active" SortExpression="ACTIVE"  />
				<asp:BoundField DataField="Parent" HeaderText="Parent" SortExpression="PARENT"  />
				<asp:BoundField DataField="ImageName" HeaderText="Image Name" SortExpression="IMAGE_NAME"  />
				<asp:BoundField DataField="IsCreateIcon" HeaderText="Is Create Icon" SortExpression="IS_CREATE_ICON"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="DESCRIPTION"  />
				<asp:BoundField DataField="SafeNameChecked" HeaderText="Checked" SortExpression="CHECKED"  />
				<asp:BoundField DataField="Modified" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified" SortExpression="MODIFIED"  />
				<asp:BoundField DataField="MenuOrder" HeaderText="Menu Order" SortExpression="MENU_ORDER"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No AdminMenus Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAdminMenus" OnClientClick="javascript:location.href='AdminMenusEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AdminMenusDataSource ID="AdminMenusDataSource" runat="server"
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
		</data:AdminMenusDataSource>
	    		
</asp:Content>



